using System;
using System.IO.Ports;
using System.Windows.Forms;
using BE;
using BLL;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
using MetroFramework;
using MetroFramework.Controls;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class ConfiguracionSensorView : UserControl
    {
        #region Propiedades y Servicios

        private readonly IdiomaBLL _idiomaBLL;
        private readonly BitacoraBLL _bitacoraBLL;
        private readonly ISessionService<Usuario> _sessionService;
        private readonly IBitacoraService _bitacoraService;
        private readonly Usuario _usuarioActual;

        private SerialPort _puertoSerie;
        private bool _escuchando = false;
        private volatile bool _cerrando = false;

        #endregion

        #region Constructor e Inicialización

        public ConfiguracionSensorView()
        {
            InitializeComponent();

            _idiomaBLL = new IdiomaBLL();
            _bitacoraBLL = new BitacoraBLL();
            _sessionService = SessionService<Usuario>.GetInstance();
            _bitacoraService = BitacoraService.GetInstance();
            _usuarioActual = _sessionService.UsuarioLogueado;

            IdiomaService.GetInstance().IdiomaCambiado += ActualizarTraducciones;

            CargarPuertos();
            CargarConfiguracionGuardada();

            // Llamamos a actualizar traducciones AL FINAL para sobrescribir lo del Designer
            ActualizarTraducciones();
        }

        #endregion

        #region Gestión de Idioma

        public void ActualizarTraducciones()
        {
            // --- NUEVOS TÍTULOS AGREGADOS ---
            lblTitulo.Text = _idiomaBLL.Traducir("ConfigSensor_Lbl_TituloPrincipal");
            lblTerminal.Text = _idiomaBLL.Traducir("ConfigSensor_Lbl_TerminalDebug");

            // Etiquetas existentes
            lblModo.Text = _idiomaBLL.Traducir("ConfigSensor_Lbl_ModoConexion");
            lblPuerto.Text = _idiomaBLL.Traducir("ConfigSensor_Lbl_PuertoCOM");
            lblBrokerIP.Text = "Broker IP (MQTT)";
            lblTopic.Text = "Topic";

            // Botones
            btnRefrescar.Text = _idiomaBLL.Traducir("ConfigSensor_Btn_Refrescar");
            btnGuardar.Text = _idiomaBLL.Traducir("ConfigSensor_Btn_Guardar");

            // Botón dinámico
            if (_escuchando)
                btnProbar.Text = _idiomaBLL.Traducir("ConfigSensor_Btn_Detener");
            else
                btnProbar.Text = _idiomaBLL.Traducir("ConfigSensor_Btn_Probar");
        }

        #endregion

        #region Lógica de Configuración (Carga/Guardado)

        private void CargarConfiguracionGuardada()
        {
            string modoGuardado = Properties.Settings.Default.Sensor_Modo;
            cboTipoConexion.SelectedIndex = (modoGuardado == "MQTT") ? 1 : 0;

            string puertoGuardado = Properties.Settings.Default.Sensor_Puerto;
            if (!string.IsNullOrEmpty(puertoGuardado) && cboPuertos.Items.Contains(puertoGuardado))
            {
                cboPuertos.SelectedItem = puertoGuardado;
            }

            txtBrokerIP.Text = Properties.Settings.Default.MQTT_IP;
            txtTopic.Text = Properties.Settings.Default.MQTT_Topic;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string modo = cboTipoConexion.SelectedIndex == 0 ? "USB" : "MQTT";

                Properties.Settings.Default.Sensor_Modo = modo;
                Properties.Settings.Default.Sensor_Puerto = cboPuertos.SelectedItem?.ToString() ?? "";
                Properties.Settings.Default.MQTT_IP = txtBrokerIP.Text;
                Properties.Settings.Default.MQTT_Topic = txtTopic.Text;

                Properties.Settings.Default.Save();

                IBitacora evento = _bitacoraService.CrearEvento(
                    NivelCriticidad.Info,
                    $"Configuración de sensores actualizada. Modo: {modo}",
                    "Configuración",
                    _usuarioActual.IdUsuario
                );

                var bitacoraSave = new Bitacora
                {
                    FechaHora = evento.FechaHora,
                    Nivel = evento.Nivel,
                    Mensaje = evento.Mensaje,
                    Modulo = evento.Modulo,
                    UsuarioID = evento.UsuarioID
                };

                _bitacoraBLL.Registrar(bitacoraSave);

                MetroMessageBox.Show(this,
                    _idiomaBLL.Traducir("ConfigSensor_Msg_GuardadoExito"),
                    _idiomaBLL.Traducir("Global_Titulo_Exito"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message,
                    _idiomaBLL.Traducir("Global_Titulo_Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Lógica de Hardware (USB/Serial)

        private void CargarPuertos()
        {
            cboPuertos.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string p in ports) cboPuertos.Items.Add(p);

            if (cboPuertos.Items.Count > 0) cboPuertos.SelectedIndex = 0;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarPuertos();

            //if (cboPuertos.Items.Count == 0)
            //{
            //    MessageBox.Show("El botón funciona, pero Windows dice que hay 0 puertos conectados.");
            //}
        }
        private void cboTipoConexion_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esUSB = cboTipoConexion.SelectedIndex == 0;
            pnlUSB.Visible = esUSB;
            pnlMQTT.Visible = !esUSB;
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            if (_escuchando)
            {
                DetenerTodo();
                return;
            }

            if (cboTipoConexion.SelectedIndex == 0)
            {
                IniciarUSB();
            }
            else
            {
                AgregarLog(_idiomaBLL.Traducir("ConfigSensor_Msg_MqttNoImplementado"));
            }
        }

        private void IniciarUSB()
        {
            if (cboPuertos.SelectedItem == null)
            {
                MetroMessageBox.Show(this,
                    _idiomaBLL.Traducir("ConfigSensor_Msg_SeleccionarPuerto"),
                    _idiomaBLL.Traducir("Global_Titulo_Atencion"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _cerrando = false;
                string puerto = cboPuertos.SelectedItem.ToString();

                _puertoSerie = new SerialPort(puerto, 115200);
                _puertoSerie.ReadTimeout = 500;
                _puertoSerie.DtrEnable = false;
                _puertoSerie.RtsEnable = false;

                _puertoSerie.DataReceived += PuertoSerie_DataReceived;
                _puertoSerie.Open();
                _puertoSerie.DiscardInBuffer();

                _escuchando = true;

                btnProbar.Text = _idiomaBLL.Traducir("ConfigSensor_Btn_Detener");
                btnProbar.Style = MetroColorStyle.Red;
                cboTipoConexion.Enabled = false;
                pnlUSB.Enabled = false;

                string msj = string.Format(_idiomaBLL.Traducir("ConfigSensor_Msg_PuertoAbierto"), puerto);
                AgregarLog(msj);
            }
            catch (Exception ex)
            {
                string msjError = string.Format(_idiomaBLL.Traducir("ConfigSensor_Msg_Error"), ex.Message);
                MetroMessageBox.Show(this, msjError, _idiomaBLL.Traducir("Global_Titulo_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PuertoSerie_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_cerrando || !_escuchando || _puertoSerie == null || !_puertoSerie.IsOpen) return;

            try
            {
                string linea = _puertoSerie.ReadLine();
                if (_cerrando) return;

                string lineaLimpia = linea.Trim();

                bool esJsonValido = lineaLimpia.StartsWith("{");
                bool esMensajeSistema = lineaLimpia.Contains("ENVIANDO") || lineaLimpia.Contains("RECONSTRUIDO") || lineaLimpia.Contains("OFFLINE");

                if (esJsonValido || esMensajeSistema)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        if (!_cerrando && _escuchando) AgregarLog(lineaLimpia);
                    }));
                }
                else
                {
                    _puertoSerie.DiscardInBuffer();
                }
            }
            catch
            {
                // Ignorar errores de lectura en tiempo real
            }
        }

        private void DetenerTodo()
        {
            _cerrando = true;
            _escuchando = false;

            if (_puertoSerie != null)
            {
                _puertoSerie.DataReceived -= PuertoSerie_DataReceived;
                try
                {
                    if (_puertoSerie.IsOpen)
                    {
                        _puertoSerie.DiscardInBuffer();
                        _puertoSerie.Close();
                    }
                }
                catch { }
                _puertoSerie.Dispose();
                _puertoSerie = null;
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(RestaurarEstadoUI));
            }
            else
            {
                RestaurarEstadoUI();
            }
        }

        private void RestaurarEstadoUI()
        {
            btnProbar.Text = _idiomaBLL.Traducir("ConfigSensor_Btn_Probar");
            btnProbar.Style = MetroColorStyle.Blue;
            cboTipoConexion.Enabled = true;
            pnlUSB.Enabled = true;
            AgregarLog(_idiomaBLL.Traducir("ConfigSensor_Log_ConexionDetenida"));
        }

        private void AgregarLog(string texto)
        {
            if (txtTerminal.IsDisposed) return;

            if (txtTerminal.Lines.Length > 200) txtTerminal.Clear();

            txtTerminal.AppendText($"[{DateTime.Now:HH:mm:ss}] {texto}\r\n");

            // Corrección aplicada: SelectionStart en lugar de ScrollToCaret
            txtTerminal.SelectionStart = txtTerminal.Text.Length;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            DetenerTodo();
            base.OnHandleDestroyed(e);
        }

        #endregion
    }
}