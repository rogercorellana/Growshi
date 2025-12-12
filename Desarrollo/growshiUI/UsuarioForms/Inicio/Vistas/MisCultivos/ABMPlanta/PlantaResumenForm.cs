using BE;
using BLL;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanta
{
    public partial class PlantaResumenForm : MetroForm
    {
        private int _slotId;
        private string _nombrePlanta;
        private Planta miPlanta;
        private PlantaBLL plantaBLL = new PlantaBLL();

        public PlantaResumenForm(int slot)
        {
            InitializeComponent();

            this._slotId = slot;

            CargarDatosReales();
        }

        private void CargarDatosReales()
        {
            miPlanta = plantaBLL.ObtenerPorSlot(_slotId);

            if (miPlanta != null)
            {
                _nombrePlanta = miPlanta.Nombre;

                // --- A. TEXTOS BÁSICOS ---
                this.Text = $"Detalle del Slot #{_slotId}";
                lblPlanAsignado.Text = $"Slot {_slotId}: {miPlanta.NombrePlan}";
                lblTituloPlanta.Text = $"Slot {_slotId}: {miPlanta.Nombre}";
                lblFechaSiembra.Text = $"Fecha Siembra: {miPlanta.FechaInicio}";

                // --- B. CÁLCULOS MATEMÁTICOS ---
                double totalDiasPlan = miPlanta.DiasTotalesPlan.GetValueOrDefault();

                // Cálculo 1: Fecha Estimada
                DateTime fechaEstimada = miPlanta.FechaInicio.AddDays(totalDiasPlan);
                lblFechaCosecha.Text = $"Estimada Cosecha: {fechaEstimada.ToShortDateString()}";

                // Cálculo 2: Días Transcurridos
                TimeSpan tiempoTranscurrido = DateTime.Now - miPlanta.FechaInicio;
                int diasPasados = tiempoTranscurrido.Days + 1;

                if (diasPasados < 0) diasPasados = 0;

                lblProgresoDia.Text = $"Día {diasPasados} de {totalDiasPlan}";

                // Cálculo 3: Porcentaje para la barra
                if (totalDiasPlan > 0)
                {
                    int porcentaje = (int)((diasPasados * 100) / totalDiasPlan);
                    progresoEtapa.Value = porcentaje > 100 ? 100 : porcentaje;
                }
                else
                {
                    progresoEtapa.Value = 0;
                }

                // --- C. ESTADO ---
                if (diasPasados >= totalDiasPlan && totalDiasPlan > 0)
                    lblEtapaActual.Text = "Etapa: ¡Lista para Cosecha!";
                else
                    lblEtapaActual.Text = "Etapa: En Progreso";
            }
            else
            {
                // Si llegamos aquí y no hay planta, cerramos el form
                MetroMessageBox.Show(this, "No se encontró planta en este slot.");
                this.Close();
            }
        }

        // --- BOTÓN CERRAR ---
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- BOTÓN ELIMINAR ---
        private void btnEliminarPlanta_Click(object sender, EventArgs e)
        {
            // Verificación de seguridad por si miPlanta es nula
            if (miPlanta == null) return;

            var result = MetroMessageBox.Show(this,
                $"¿Estás SEGURO de que deseas vaciar el Slot #{_slotId} y eliminar la planta '{_nombrePlanta}'?\n\nEsta acción eliminará todos los datos de la planta permanentemente.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop);

            if (result == DialogResult.Yes)
            {
                // CORRECCIÓN: Aquí enviamos el SlotID y el PlantaID
                plantaBLL.EliminarPlantaDelSlot(_slotId, miPlanta.PlantaID);

                MetroMessageBox.Show(this, $"El Slot #{_slotId} ha sido vaciado y la planta eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}