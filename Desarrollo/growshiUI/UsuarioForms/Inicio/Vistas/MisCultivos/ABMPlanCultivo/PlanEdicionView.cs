using System;
using System.Windows.Forms;
using BE;
using BLL;
using System.Collections.Generic;

namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanCultivo
{
    public partial class PlanEdicionView : UserControl
    {
        private int _idPlan;
        private PlanCultivoBLL _planBLL = new PlanCultivoBLL();
        private EtapaCultivoBLL _etapaBLL = new EtapaCultivoBLL();

        public event EventHandler OnCancelar;
        public event EventHandler OnGuardar;

        public PlanEdicionView()
        {
            InitializeComponent();
            btnCancelar.Click += (s, e) => OnCancelar?.Invoke(this, EventArgs.Empty);
            btnGuardar.Click += btnGuardar_Click;
        }

        public void CargarDatos(PlanCultivo plan)
        {
            _idPlan = plan.PlanCultivoID;
            txtNombrePlan.Text = plan.NombrePlan;
            CargarEtapas();
        }

        private void CargarEtapas()
        {
            try
            {
                var etapas = _etapaBLL.ListarPorPlan(_idPlan);
                gridEtapasEdicion.DataSource = null;
                gridEtapasEdicion.DataSource = etapas;

                // Ocultar columnas técnicas
                string[] ocultar = { "EtapaCultivoID", "PlanCultivoID" };
                foreach (var col in ocultar)
                {
                    if (gridEtapasEdicion.Columns[col] != null)
                        gridEtapasEdicion.Columns[col].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error cargando etapas: " + ex.Message); }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtNombrePlan.Text))
            {
                MessageBox.Show("El nombre del plan no puede estar vacío.");
                return;
            }

            try
            {
                // 2. Preparar el objeto PLAN
                PlanCultivo planEditado = new PlanCultivo();
                planEditado.PlanCultivoID = _idPlan;
                planEditado.NombrePlan = txtNombrePlan.Text;

                // 3. Preparar la lista de ETAPAS modificadas
                // Forzamos a la grilla a confirmar la última edición
                gridEtapasEdicion.EndEdit();

                // Obtenemos la lista directamente del DataSource de la grilla
                List<EtapaCultivo> etapasModificadas = (List<EtapaCultivo>)gridEtapasEdicion.DataSource;

                // ASIGNAMOS LAS ETAPAS AL PLAN
                planEditado.Etapas = etapasModificadas;

                // 4. Llamamos a la BLL (UNA SOLA VEZ)
                // Esta función ya se encarga de actualizar Nombre + Todas las Etapas en transacción
                _planBLL.ModificarPlan(planEditado);

                MessageBox.Show("¡Cambios guardados correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 5. Avisar al padre que terminamos
                OnGuardar?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}