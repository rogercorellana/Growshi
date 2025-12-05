using MetroFramework.Forms;
using MetroFramework;
using System;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanta
{
    public partial class PlantaResumenForm : MetroForm
    {
        // Variable privada para recordar qué slot estamos viendo
        private int _slotId;
        private string _nombrePlanta; // La guardamos para usarla en el mensaje de eliminar

        // Constructor que recibe el ID del Slot
        public PlantaResumenForm(int slot)
        {
            InitializeComponent();

            // 1. Guardamos la referencia
            this._slotId = slot;

            // 2. Cargamos los datos específicos de este slot
            CargarDatosSimulados();
        }

        private void CargarDatosSimulados()
        {
            // --- SIMULACIÓN DE BASE DE DATOS ---
            // Aquí iría: Planta planta = plantaBLL.ObtenerPorSlot(_slotId);

            // Simulamos que obtenemos el nombre de la BD
            _nombrePlanta = "Skunk #1 Auto";

            // 1. Actualizamos Títulos usando el ID del Slot
            this.Text = $"Detalle del Slot #{_slotId}"; // Título de la ventana
            lblTituloPlanta.Text = $"Slot {_slotId}: {_nombrePlanta}";

            // 2. Datos Generales
            lblPlanAsignado.Text = "Plan: Autoflorecientes Invernales";
            lblFechaSiembra.Text = $"Fecha Siembra: {DateTime.Now.AddDays(-25).ToShortDateString()}";
            lblFechaCosecha.Text = $"Estimada Cosecha: {DateTime.Now.AddDays(45).ToShortDateString()}";

            // 3. Estado
            lblEtapaActual.Text = "Etapa: Vegetación";
            lblProgresoDia.Text = "Día 25 de 70";
            progresoEtapa.Value = 35;

            // 4. Sensores (Usamos el ID para 'sembrar' el Random y que varíen los datos según el slot)
            Random rnd = new Random(_slotId * DateTime.Now.Millisecond);

            // Temperatura
            double temp = rnd.Next(18, 30) + rnd.NextDouble(); // Ej: 24.5
            lblTempVal.Text = $"{temp:0.0} °C";
            lblTempVal.Style = (temp > 28 || temp < 18) ? MetroColorStyle.Red : MetroColorStyle.Green;

            // Humedad
            int hum = rnd.Next(40, 80);
            lblHumedadVal.Text = $"{hum}%";

            // Luminosidad
            bool lucesOn = rnd.Next(0, 2) == 1;
            lblLuminosidadVal.Text = lucesOn ? "ON 💡" : "OFF 🌙";
            lblLuminosidadVal.Style = lucesOn ? MetroColorStyle.Yellow : MetroColorStyle.Silver;

            lblUltimaMedicion.Text = $"Última medición del Slot {_slotId}: {DateTime.Now.ToShortTimeString()}";
        }

        private void btnEliminarPlanta_Click(object sender, EventArgs e)
        {
            var result = MetroMessageBox.Show(this,
                $"¿Estás SEGURO de que deseas vaciar el Slot #{_slotId} y eliminar la planta '{_nombrePlanta}'?\n\nEsta acción no se puede deshacer.",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Stop);

            if (result == DialogResult.Yes)
            {
                // AQUI CONECTARÍAS CON LA BLL:
                // plantaBLL.EliminarPlantaDelSlot(_slotId);

                MetroMessageBox.Show(this, $"El Slot #{_slotId} ha sido vaciado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}