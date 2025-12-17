using BE;
using BLL;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
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
        #region Propiedades y Servicios

        private int _slotId;
        private Planta miPlanta;
        public bool SolicitaIrAPlanes { get; private set; } = false;

        // BLLs y Servicios
        private readonly PlantaBLL _plantaBLL;
        private readonly MedicionBLL _medicionBLL;
        private readonly IdiomaBLL _idiomaBLL;
        private readonly BitacoraBLL _bitacoraBLL;
        private readonly IBitacoraService _bitacoraService;
        private readonly ISessionService<Usuario> _sessionService;
        private readonly Usuario _usuarioActual;

        // Sensor
        private SerialPort _puertoSerie;
        private bool _sensorActivo = false;

        #endregion

        #region Constructor e Inicialización

        public PlantaResumenForm(int slot)
        {
            InitializeComponent();
            this._slotId = slot;

            // 1. Instancias
            _plantaBLL = new PlantaBLL();
            _medicionBLL = new MedicionBLL();
            _idiomaBLL = new IdiomaBLL();
            _bitacoraBLL = new BitacoraBLL();
            _bitacoraService = BitacoraService.GetInstance();
            _sessionService = SessionService<Usuario>.GetInstance();
            _usuarioActual = _sessionService.UsuarioLogueado;

            // 2. Carga Inicial
            CargarDatosReales();
            IniciarConexionSensor();

            // 3. Traducción y Eventos
            ActualizarTraducciones();
            IdiomaService.GetInstance().IdiomaCambiado += ActualizarTraducciones;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            IdiomaService.GetInstance().IdiomaCambiado -= ActualizarTraducciones;
            base.OnHandleDestroyed(e);
        }

        #endregion

        #region Gestión de Idioma

        private void ActualizarTraducciones()
        {
            // Títulos de Paneles
            lblTituloInfo.Text = _idiomaBLL.Traducir("PlantaResumen_Lbl_InfoGeneral");
            lblTituloEstado.Text = _idiomaBLL.Traducir("PlantaResumen_Lbl_EstadoActual");
            lblTituloMediciones.Text = _idiomaBLL.Traducir("PlantaResumen_Lbl_Sensores");

            // Etiquetas de Datos
            lblTemperatura.Text = _idiomaBLL.Traducir("PlantaResumen_Lbl_Temp");
            lblHumedad.Text = _idiomaBLL.Traducir("PlantaResumen_Lbl_Hum");
            lblLuminosidad.Text = _idiomaBLL.Traducir("PlantaResumen_Lbl_Luz");

            // Botones
            btnEliminarPlanta.Text = _idiomaBLL.Traducir("PlantaResumen_Btn_Eliminar");
            btnCerrar.Text = _idiomaBLL.Traducir("PlantaResumen_Btn_Volver");

            // Título dinámico (si ya cargó la planta)
            if (miPlanta != null)
            {
                this.Text = string.Format(_idiomaBLL.Traducir("PlantaResumen_Titulo_Form"), _slotId);
                lblTituloPlanta.Text = string.Format(_idiomaBLL.Traducir("PlantaResumen_Lbl_PlantaNombre"), miPlanta.Nombre);
                // Recargar textos que dependen de datos
                CargarDatosReales();
            }
        }

        #endregion

        #region Lógica de Negocio (Carga de Datos)

        private void CargarDatosReales()
        {
            miPlanta = _plantaBLL.ObtenerPorSlot(_slotId);

            if (miPlanta != null)
            {
                // Textos con formato traducido
                this.Text = string.Format(_idiomaBLL.Traducir("PlantaResumen_Titulo_Form"), _slotId);
                lblTituloPlanta.Text = string.Format(_idiomaBLL.Traducir("PlantaResumen_Lbl_PlantaNombre"), miPlanta.Nombre);

                lblPlanAsignado.Text = string.Format(_idiomaBLL.Traducir("PlantaResumen_Lbl_Plan"), miPlanta.NombrePlan);
                lblFechaSiembra.Text = string.Format(_idiomaBLL.Traducir("PlantaResumen_Lbl_Siembra"), miPlanta.FechaInicio);

                // Cálculos BLL
                DateTime fechaCosecha = _plantaBLL.CalcularFechaCosecha(miPlanta);
                int diasPasados = _plantaBLL.CalcularDiasPasados(miPlanta);
                int porcentaje = _plantaBLL.CalcularPorcentajeProgreso(miPlanta);

                lblFechaCosecha.Text = string.Format(_idiomaBLL.Traducir("PlantaResumen_Lbl_Cosecha"), fechaCosecha);
                lblProgresoDia.Text = string.Format(_idiomaBLL.Traducir("PlantaResumen_Lbl_Progreso"), diasPasados, miPlanta.DiasTotalesPlan);

                progresoEtapa.Value = porcentaje;
                lblEtapaActual.Text = _plantaBLL.ObtenerEstadoEtapa(miPlanta); // Esto podría necesitar traducción interna en BLL o aquí
            }
            else
            {
                MetroMessageBox.Show(this, _idiomaBLL.Traducir("PlantaResumen_Msg_NoEncontrada"));
                this.Close();
            }
        }

        private void btnEliminarPlanta_Click(object sender, EventArgs e)
        {
            if (miPlanta == null) return;

            string msg = string.Format(_idiomaBLL.Traducir("PlantaResumen_Msg_ConfirmarEliminar"), miPlanta.Nombre);
            string titulo = _idiomaBLL.Traducir("Global_Titulo_Confirmar");

            var result = MetroMessageBox.Show(this, msg, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _plantaBLL.EliminarPlantaDelSlot(_slotId, miPlanta.PlantaID);

                    // BITÁCORA
                    RegistrarBitacora($"Planta eliminada: {miPlanta.Nombre} (Slot {_slotId})", NivelCriticidad.Advertencia);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => this.Close();

        private void RegistrarBitacora(string mensaje, NivelCriticidad nivel)
        {
            var evento = _bitacoraService.CrearEvento(nivel, mensaje, "Gestión Cultivos", _usuarioActual.IdUsuario);
            var bitacora = new Bitacora
            {
                FechaHora = evento.FechaHora,
                Nivel = evento.Nivel,
                Mensaje = evento.Mensaje,
                Modulo = evento.Modulo,
                UsuarioID = evento.UsuarioID
            };
            _bitacoraBLL.Registrar(bitacora);
        }

        #endregion

        #region Lógica del Sensor

        private void IniciarConexionSensor()
        {
            string puertoGuardado = Properties.Settings.Default.Sensor_Puerto;
            string modo = Properties.Settings.Default.Sensor_Modo;

            if (modo != "USB" || string.IsNullOrEmpty(puertoGuardado))
            {
                lblUltimaMedicion.Text = _idiomaBLL.Traducir("PlantaResumen_Sensor_NoConfig");
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
                lblUltimaMedicion.Text = _idiomaBLL.Traducir("PlantaResumen_Sensor_Esperando");
                lblUltimaMedicion.ForeColor = Color.Blue;
            }
            catch
            {
                lblUltimaMedicion.Text = _idiomaBLL.Traducir("PlantaResumen_Sensor_Error");
                lblUltimaMedicion.ForeColor = Color.Red;
            }
        }

        private void Puerto_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!_sensorActivo || _puertoSerie == null || !_puertoSerie.IsOpen) return;

            try
            {
                string linea = _puertoSerie.ReadLine().Trim();
                System.Diagnostics.Debug.WriteLine($"Recibido RAW: {linea}");

                Medicion nuevaMedicion = _medicionBLL.InterpretarDatosSensor(linea, this._slotId, this.miPlanta?.PlantaID ?? 0);

                if (nuevaMedicion != null)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        ActualizarPanelMediciones(nuevaMedicion);
                        _medicionBLL.Guardar(nuevaMedicion);
                    }));
                }
            }
            catch (Exception ex)
            {
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

            lblUltimaMedicion.Text = string.Format(_idiomaBLL.Traducir("PlantaResumen_Sensor_Lectura"), m.FechaRegistro);
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
    }
}