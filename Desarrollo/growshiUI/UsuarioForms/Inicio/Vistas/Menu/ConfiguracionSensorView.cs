using System;
using System.IO.Ports;
using System.Windows.Forms;
using MetroFramework;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class ConfiguracionSensorView : UserControl
    {
        private SerialPort _puertoSerie;
        private bool _escuchando = false;

        // --- FRENO DE MANO PARA EVITAR LOOPS INFINITOS ---
        private volatile bool _cerrando = false;

        public ConfiguracionSensorView()
        {
            InitializeComponent();
            CargarPuertos(); // Esto carga la lista física de COMs

            // NUEVO: Cargar lo que el usuario eligió la última vez
            CargarConfiguracionGuardada();
        }

        private void CargarConfiguracionGuardada()
        {
            // 1. Recuperar modo (USB vs MQTT)
            string modoGuardado = Properties.Settings.Default.Sensor_Modo;
            if (modoGuardado == "MQTT")
                cboTipoConexion.SelectedIndex = 1;
            else
                cboTipoConexion.SelectedIndex = 0;

            // 2. Recuperar Puerto USB
            string puertoGuardado = Properties.Settings.Default.Sensor_Puerto;
            // Intentamos seleccionarlo en el combo si existe
            if (!string.IsNullOrEmpty(puertoGuardado) && cboPuertos.Items.Contains(puertoGuardado))
            {
                cboPuertos.SelectedItem = puertoGuardado;
            }

            // 3. Recuperar MQTT
            txtBrokerIP.Text = Properties.Settings.Default.MQTT_IP;
            txtTopic.Text = Properties.Settings.Default.MQTT_Topic;
        }

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
        }

        private void cboTipoConexion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoConexion.SelectedIndex == 0)
            {
                pnlUSB.Visible = true;
                pnlMQTT.Visible = false;
            }
            else
            {
                pnlUSB.Visible = false;
                pnlMQTT.Visible = true;
            }
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
                AgregarLog("⚠️ MQTT no implementado aún.");
            }
        }

        private void IniciarUSB()
        {
            if (cboPuertos.SelectedItem == null)
            {
                MetroMessageBox.Show(this, "Selecciona un puerto COM.");
                return;
            }

            try
            {
                _cerrando = false; // Levantamos el freno
                string puerto = cboPuertos.SelectedItem.ToString();

                _puertoSerie = new SerialPort(puerto, 115200);

                // Configuración vital anti-bloqueo
                _puertoSerie.ReadTimeout = 500;
                _puertoSerie.DtrEnable = false;
                _puertoSerie.RtsEnable = false;

                _puertoSerie.DataReceived += PuertoSerie_DataReceived;
                _puertoSerie.Open();

                // Limpiamos basura vieja
                _puertoSerie.DiscardInBuffer();

                _escuchando = true;
                btnProbar.Text = "DETENER";
                btnProbar.Style = MetroFramework.MetroColorStyle.Red;
                cboTipoConexion.Enabled = false;
                pnlUSB.Enabled = false;

                AgregarLog($"✅ Puerto {puerto} ABIERTO.");
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Error: " + ex.Message);
            }
        }

        private void PuertoSerie_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 1. SEGURIDAD: Si estamos cerrando o el puerto murió, salimos.
            if (_cerrando || !_escuchando || _puertoSerie == null || !_puertoSerie.IsOpen) return;

            try
            {
                // Leemos una línea del puerto
                string linea = _puertoSerie.ReadLine();

                // 2. SEGURIDAD DOBLE
                if (_cerrando) return;

                // --- AQUÍ ESTÁ EL FILTRO MÁGICO ---
                string lineaLimpia = linea.Trim();

                // Regla: Solo aceptamos líneas que empiecen con '{' (JSON) o mensajes del sistema conocidos
                bool esJsonValido = lineaLimpia.StartsWith("{");
                bool esMensajeSistema = lineaLimpia.Contains("ENVIANDO") || lineaLimpia.Contains("RECONSTRUIDO") || lineaLimpia.Contains("OFFLINE");

                if (esJsonValido || esMensajeSistema)
                {
                    // Es un dato bueno, lo mostramos
                    this.BeginInvoke(new Action(() =>
                    {
                        if (!_cerrando && _escuchando) AgregarLog(lineaLimpia);
                    }));
                }
                else
                {
                    // --- DETECTOR DE BASURA ---
                    // Si llegamos aquí, es porque leímos "tas:[0,0,0]" o basura incompleta.
                    // NO lo mostramos en el log para no trabar la pantalla.

                    // ACCIÓN: Limpiamos el buffer para "reiniciar" la lectura y alinearnos con el próximo mensaje nuevo.
                    _puertoSerie.DiscardInBuffer();
                }
            }
            catch
            {
                // Si hay error de lectura, ignoramos silenciosamente para no romper el flujo
            }
        }
        private void DetenerTodo()
        {
            // 1. ACTIVAR FRENO DE MANO
            _cerrando = true;
            _escuchando = false;

            if (_puertoSerie != null)
            {
                // 2. CORTAR EL CABLE LÓGICO (Vital para detener el loop)
                _puertoSerie.DataReceived -= PuertoSerie_DataReceived;

                try
                {
                    if (_puertoSerie.IsOpen)
                    {
                        _puertoSerie.DiscardInBuffer(); // Tirar datos pendientes
                        _puertoSerie.Close();
                    }
                }
                catch { } // Ignorar errores al cerrar

                _puertoSerie.Dispose();
                _puertoSerie = null;
            }

            // Resetear UI
            btnProbar.Text = "INICIAR PRUEBA";
            btnProbar.Style = MetroFramework.MetroColorStyle.Blue;
            cboTipoConexion.Enabled = true;
            pnlUSB.Enabled = true;
            AgregarLog("⏹️ Conexión detenida.");
        }

        private void AgregarLog(string texto)
        {
            if (txtTerminal.IsDisposed) return;

            // Limpieza automática para no saturar memoria
            if (txtTerminal.Lines.Length > 200) txtTerminal.Clear();

            txtTerminal.AppendText($"[{DateTime.Now:HH:mm:ss}] {texto}\r\n");
            txtTerminal.SelectionStart = txtTerminal.Text.Length;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Capturar datos de la pantalla
            string modo = cboTipoConexion.SelectedIndex == 0 ? "USB" : "MQTT";
            string puerto = cboPuertos.SelectedItem != null ? cboPuertos.SelectedItem.ToString() : "";
            string ip = txtBrokerIP.Text;
            string topic = txtTopic.Text;

            // 2. Guardar en la Memoria Permanente (Settings)
            Properties.Settings.Default.Sensor_Modo = modo;
            Properties.Settings.Default.Sensor_Puerto = puerto;
            Properties.Settings.Default.MQTT_IP = ip;
            Properties.Settings.Default.MQTT_Topic = topic;

            // 3. Confirmar cambios en disco (VITAL)
            Properties.Settings.Default.Save();

            MetroMessageBox.Show(this, "Configuración guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            DetenerTodo();
            base.OnHandleDestroyed(e);
        }
    }
}