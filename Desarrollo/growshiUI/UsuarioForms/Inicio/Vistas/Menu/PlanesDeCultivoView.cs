using BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanCultivo;
using growshiUI.Reportes;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class PlanesDeCultivoView : UserControl
    {
        PlanCultivoBLL planCultivoBLL = new PlanCultivoBLL();
        EtapaCultivoBLL etapaCultivoBLL = new EtapaCultivoBLL();
        public event Action<PlanCultivo> OnSolicitarEdicion;
        public PlanesDeCultivoView()
        {
            InitializeComponent();
            this.Load += PlanesDeCultivoView_Load;
        }

        private void PlanesDeCultivoView_Load(object sender, EventArgs e)
        {
            ConfigurarGrillas();

            // Suscribimos eventos
            gridPlanes.SelectionChanged += GridPlanes_SelectionChanged;
            gridEtapas.SelectionChanged += GridEtapas_SelectionChanged; // Nuevo evento

            CargarPlanes();
        }

        private void ConfigurarGrillas()
        {
            if (gridPlanes != null)
            {
                gridPlanes.AutoGenerateColumns = false;
                gridPlanes.MultiSelect = false;
                gridPlanes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                colPlanNombre.DataPropertyName = "NombrePlan";
            }

            if (gridEtapas != null)
            {
                gridEtapas.AutoGenerateColumns = true;
                gridEtapas.MultiSelect = false;
                gridEtapas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void CargarPlanes()
        {
            try
            {
                var lista = planCultivoBLL.Listar();
                gridPlanes.DataSource = null;
                gridPlanes.DataSource = lista;
                gridPlanes.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar planes: " + ex.Message);
            }
        }

        // --- IZQUIERDA: SELECCION DE PLAN ---
        private void GridPlanes_SelectionChanged(object sender, EventArgs e)
        {
            if (gridPlanes.SelectedRows.Count > 0)
            {
                PlanCultivo planSeleccionado = (PlanCultivo)gridPlanes.SelectedRows[0].DataBoundItem;
                if (planSeleccionado != null)
                {
                    CargarEtapasDelPlan(planSeleccionado);
                }
            }
            else
            {
                gridEtapas.DataSource = null;
                LimpiarDetalleFicha();
            }
        }

        private void CargarEtapasDelPlan(PlanCultivo plan)
        {
            try
            {
                List<EtapaCultivo> listaEtapas = etapaCultivoBLL.ListarPorPlan(plan.PlanCultivoID);

                gridEtapas.DataSource = null;
                gridEtapas.DataSource = listaEtapas;

                // Ocultar columnas técnicas feas, dejamos solo lo básico para la grilla
                OcultarColumnasTecnicas();

                // Si hay etapas, seleccionamos la primera por defecto
                if (gridEtapas.Rows.Count > 0)
                    gridEtapas.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar etapas: " + ex.Message);
            }
        }

        private void OcultarColumnasTecnicas()
        {
            // Ocultamos IDs y datos que mostraremos abajo
            string[] columnasOcultar = { "EtapaCultivoID", "PlanCultivoID",
                                         "TempMin", "TempMax",
                                         "HumMin", "HumMax",
                                         "PhMin", "PhMax",
                                         "EcMin", "EcMax" };

            foreach (string col in columnasOcultar)
            {
                if (gridEtapas.Columns[col] != null)
                    gridEtapas.Columns[col].Visible = false;
            }
        }

        // --- DERECHA ARRIBA: SELECCION DE ETAPA ---
        private void GridEtapas_SelectionChanged(object sender, EventArgs e)
        {
            if (gridEtapas.SelectedRows.Count > 0)
            {
                // Obtenemos la etapa seleccionada
                EtapaCultivo etapa = (EtapaCultivo)gridEtapas.SelectedRows[0].DataBoundItem;
                MostrarFichaTecnica(etapa);
            }
            else
            {
                LimpiarDetalleFicha();
            }
        }

        // --- DERECHA ABAJO: MOSTRAR DATOS ---
        private void MostrarFichaTecnica(EtapaCultivo etapa)
        {
            // Actualizamos los labels del panel inferior
            lblTituloFicha.Text = $"Ficha Técnica: {etapa.NombreEtapa}";

            lblInfoTemp.Text = $"Temperatura: {etapa.TempMin}°C - {etapa.TempMax}°C";
            lblInfoHum.Text = $"Humedad: {etapa.HumMin}% - {etapa.HumMax}%";
            lblInfoPh.Text = $"pH Ideal: {etapa.PhMin} - {etapa.PhMax}";

            // Puedes agregar más labels para EC o Duración si quieres
        }

        private void LimpiarDetalleFicha()
        {
            lblTituloFicha.Text = "Seleccione una etapa...";
            lblInfoTemp.Text = "Temperatura: --";
            lblInfoHum.Text = "Humedad: --";
            lblInfoPh.Text = "pH: --";
        }

        // --- BOTONES ---
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AgregarPlanCultivoForm planCultivoForm = new AgregarPlanCultivoForm();

            this.Hide();
            planCultivoForm.ShowDialog();


            CargarPlanes(); 
            this.Show();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gridPlanes.SelectedRows.Count > 0)
            {
                var plan = (PlanCultivo)gridPlanes.SelectedRows[0].DataBoundItem;

                // EN LUGAR DE MESSAGEBOX, DISPARAMOS EL EVENTO
                OnSolicitarEdicion?.Invoke(plan);
            }
            else
            {
                MessageBox.Show("Selecciona un plan para editar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gridPlanes.SelectedRows.Count > 0)
            {
                var plan = (PlanCultivo)gridPlanes.SelectedRows[0].DataBoundItem;

                var confirmacion = MetroFramework.MetroMessageBox.Show(this,
                    $"¿Estás seguro de que deseas eliminar el plan '{plan.NombrePlan}'?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        planCultivoBLL.EliminarPlan(plan.PlanCultivoID, plan.NombrePlan);

                        MetroFramework.MetroMessageBox.Show(this,
                            "Plan eliminado correctamente.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        CargarPlanes();
                        gridEtapas.DataSource = null;
                        LimpiarDetalleFicha();
                    }
                    catch (Exception ex)
                    {
                        // --- AQUI ESTÁ LA TRADUCCIÓN DEL ERROR ---

                        // Verificamos si el mensaje de error contiene el nombre de la restricción que vimos en la foto
                        if (ex.Message.Contains("FK_Planta_PlanCultivo"))
                        {
                            MetroFramework.MetroMessageBox.Show(this,
                                "No se puede eliminar este Plan de Cultivo porque tiene plantas activas asociadas.\n\n" +
                                "Por favor, elimina primero las plantas que usan este plan.",
                                "No se puede eliminar",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning); // Usamos icono de advertencia, no de error
                        }
                        else
                        {
                            // Si es cualquier otro error, lo mostramos normal
                            MetroFramework.MetroMessageBox.Show(this,
                                "Ocurrió un error inesperado: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this,
                    "Selecciona un plan para eliminar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }


        // Asegúrate de agregar el using de tu carpeta nueva

        // --- BOTÓN EXPORTAR ---
        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (gridPlanes.SelectedRows.Count > 0)
            {
                var plan = (PlanCultivo)gridPlanes.SelectedRows[0].DataBoundItem;
                var etapas = etapaCultivoBLL.ListarPorPlan(plan.PlanCultivoID);

                // 1. LIMPIEZA DE NOMBRE (Evita caracteres prohibidos como / \ : *)
                string nombreSeguro = string.Join("_", plan.NombrePlan.Split(System.IO.Path.GetInvalidFileNameChars()));

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "PDF Files|*.pdf";
                saveFile.Title = "Guardar Reporte de Cultivo";
                saveFile.FileName = $"Plan_{nombreSeguro}.pdf";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        GeneradorReportePlan generador = new GeneradorReportePlan();
                        generador.ExportarPdf(plan, etapas, saveFile.FileName);

                        var abrir = MetroFramework.MetroMessageBox.Show(this,
                            "PDF generado exitosamente.\n¿Deseas abrirlo ahora?",
                            "Exportación Exitosa",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (abrir == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(saveFile.FileName);
                        }
                    }
                    catch (System.IO.IOException) // Capturamos error de archivo en uso
                    {
                        MetroFramework.MetroMessageBox.Show(this,
                            "El archivo PDF parece estar abierto en otro programa.\n\nPor favor, ciérralo e intenta nuevamente.",
                            "Archivo Bloqueado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        // Mostramos la InnerException para saber qué pasa realmente
                        string mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                        MetroFramework.MetroMessageBox.Show(this,
                            "Error al generar: " + mensaje,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Selecciona un plan para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}