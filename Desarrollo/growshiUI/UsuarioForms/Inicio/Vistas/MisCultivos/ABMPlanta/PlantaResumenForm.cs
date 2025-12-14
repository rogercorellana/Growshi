using BE;
using BLL;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanta
{
    public partial class PlantaResumenForm : MetroForm
    {
        // --- PROPIEDADES ---
        private int _slotId;
        private Planta miPlanta;

        // Instanciamos BLLs
        private PlantaBLL plantaBLL = new PlantaBLL();
        private MedicionBLL medicionBLL = new MedicionBLL(); // Asegúrate de tener esta clase creada como vimos antes

        // Bandera de navegación
        public bool SolicitaIrAPlanes { get; private set; } = false;

        // --- VARIABLES SENSOR ---
        private SerialPort _puertoSerie;
        private bool _sensorActivo = false;

        public PlantaResumenForm(int slot)
        {
            InitializeComponent();
            this._slotId = slot;

            CargarDatosReales();
            IniciarConexionSensor();
        }

        #region Lógica del Sensor

        private void IniciarConexionSensor()
        {
            string puertoGuardado = Properties.Settings.Default.Sensor_Puerto;
            string modo = Properties.Settings.Default.Sensor_Modo;

            if (modo != "USB" || string.IsNullOrEmpty(puertoGuardado))
            {
                lblUltimaMedicion.Text = "Sensor no configurado";
                lblUltimaMedicion.ForeColor = Color.Gray;
                return;
            }

            try
            {
                _puertoSerie = new SerialPort(puertoGuardado, 115200);
                _puertoSerie.DtrEnable = false;
                _puertoSerie.RtsEnable = false;
                _puertoSerie.ReadTimeout = 500;

                _puertoSerie.DataReceived += Puerto_DataReceived;
                _puertoSerie.Open();
                _puertoSerie.DiscardInBuffer();

                _sensorActivo = true;
                lblUltimaMedicion.Text = "Esperando datos...";
                lblUltimaMedicion.ForeColor = Color.Blue;
            }
            catch
            {
                lblUltimaMedicion.Text = "Error conexión sensor";
                lblUltimaMedicion.ForeColor = Color.Red;
            }
        }

        private void Puerto_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!_sensorActivo || _puertoSerie == null || !_puertoSerie.IsOpen) return;

            try
            {
                string linea = _puertoSerie.ReadLine().Trim();

                // DEBUG: Esto imprimirá en la ventana de "Salida" de Visual Studio lo que llega
                System.Diagnostics.Debug.WriteLine($"Recibido RAW: {linea}");

                Medicion nuevaMedicion = medicionBLL.InterpretarDatosSensor(linea, this._slotId, this.miPlanta?.PlantaID ?? 0);

                if (nuevaMedicion != null)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        ActualizarPanelMediciones(nuevaMedicion);
                        medicionBLL.Guardar(nuevaMedicion);
                    }));
                }
                else
                {
                    // Si entra aquí es porque el JSON llegó mal o es de otro Slot
                    System.Diagnostics.Debug.WriteLine($"Dato descartado (Null o Slot incorrecto)");
                }
            }
            catch (Exception ex)
            {
                // ¡Ahora sí verás si falla!
                System.Diagnostics.Debug.WriteLine($"ERROR PUERTO: {ex.Message}");
            }
        }
        private void ActualizarPanelMediciones(Medicion m)
        {
            if (this.IsDisposed) return;

            lblTempVal.Text = $"{m.Temperatura:0.0} °C";
            lblTempVal.ForeColor = m.AlertaTemperatura ? Color.Red : Color.Black;

            lblHumedadVal.Text = $"{m.Humedad:0}%";
            lblHumedadVal.ForeColor = m.AlertaHumedad ? Color.Red : Color.Teal;

            lblLuminosidadVal.Text = $"{m.Luminosidad}%";
            lblLuminosidadVal.ForeColor = m.AlertaLuz ? Color.Gray : Color.Orange;

            lblUltimaMedicion.Text = $"Lectura: {m.FechaRegistro:HH:mm:ss}";
            lblUltimaMedicion.ForeColor = Color.Green;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (_puertoSerie != null && _puertoSerie.IsOpen)
            {
                _sensorActivo = false;
                _puertoSerie.DataReceived -= Puerto_DataReceived;
                try
                {
                    _puertoSerie.DiscardInBuffer();
                    _puertoSerie.Close();
                }
                catch { }
                _puertoSerie.Dispose();
            }
            base.OnFormClosing(e);
        }

        #endregion

        #region UI: Carga de Datos (LIMPIA)

        private void CargarDatosReales()
        {
            miPlanta = plantaBLL.ObtenerPorSlot(_slotId);

            if (miPlanta != null)
            {
                // 1. Textos directos
                this.Text = $"Detalle del Slot #{_slotId}";
                lblPlanAsignado.Text = $"Slot {_slotId}: {miPlanta.NombrePlan}";
                lblTituloPlanta.Text = $"Slot {_slotId}: {miPlanta.Nombre}";
                lblFechaSiembra.Text = $"Siembra: {miPlanta.FechaInicio:dd/MM/yyyy}";

                // 2. Cálculos delegados a la BLL (¡Mucho más limpio!)
                DateTime fechaCosecha = plantaBLL.CalcularFechaCosecha(miPlanta);
                int diasPasados = plantaBLL.CalcularDiasPasados(miPlanta);
                int porcentaje = plantaBLL.CalcularPorcentajeProgreso(miPlanta);

                // 3. Asignación a controles
                lblFechaCosecha.Text = $"Estimada: {fechaCosecha:dd/MM/yyyy}";
                lblProgresoDia.Text = $"Día {diasPasados} de {miPlanta.DiasTotalesPlan}";

                progresoEtapa.Value = porcentaje;

                // Aquí llamamos al método nuevo que creamos arriba
                lblEtapaActual.Text = plantaBLL.ObtenerEstadoEtapa(miPlanta);
            }
            else
            {
                MetroMessageBox.Show(this, "No se encontró planta en este slot.");
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void btnEliminarPlanta_Click(object sender, EventArgs e)
        {
            if (miPlanta == null) return;

            var result = MetroMessageBox.Show(this,
                $"¿Estás SEGURO de eliminar '{miPlanta.Nombre}'?\nSe perderán los datos.",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (result == DialogResult.Yes)
            {
                plantaBLL.EliminarPlantaDelSlot(_slotId, miPlanta.PlantaID);
                this.Close();
            }
        }

        private void lnkVerPlan_Click(object sender, EventArgs e)
        {
            this.SolicitaIrAPlanes = true;
            this.Close();
        }

        #endregion
    }
}