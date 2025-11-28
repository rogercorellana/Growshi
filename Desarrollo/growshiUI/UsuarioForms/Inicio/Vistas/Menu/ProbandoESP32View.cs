using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class ProbandoESP32View : UserControl
    {
        private SerialPort _puertoSerie;
        private bool _conectado = false;

        public ProbandoESP32View()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (!_conectado)
            {
                // CONECTAR
                try
                {
                    _puertoSerie = new SerialPort("COM5", 115200);

                    // Evitar reinicios en ESP32
                    _puertoSerie.DtrEnable = false;
                    _puertoSerie.RtsEnable = false;

                    // IMPORTANTE: Aumentar timeout para que no se congele si tarda en llegar
                    _puertoSerie.ReadTimeout = 500;

                    _puertoSerie.DataReceived += PuertoSerie_DataReceived;
                    _puertoSerie.Open();

                    // TRUCO: Limpiar basura vieja del cable para que ReadLine no se trabe
                    _puertoSerie.DiscardInBuffer();

                    _conectado = true;
                    btnConectar.Text = "DESCONECTAR";
                    btnConectar.Style = MetroFramework.MetroColorStyle.Red;
                    LogDebug(">>> Conectado. Esperando datos...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error conexión: " + ex.Message);
                }
            }
            else
            {
                CerrarConexion();
            }
        }

        private void CerrarConexion()
        {
            try
            {
                if (_puertoSerie != null)
                {
                    _puertoSerie.DataReceived -= PuertoSerie_DataReceived;
                    if (_puertoSerie.IsOpen)
                    {
                        _puertoSerie.DiscardInBuffer(); // Limpiar antes de salir
                        _puertoSerie.Close();
                    }
                }
                _conectado = false;
                btnConectar.Text = "CONECTAR COM5";
                btnConectar.Style = MetroFramework.MetroColorStyle.Blue;
                LogDebug(">>> Desconectado.");
            }
            catch (Exception ex) { LogDebug("Error cierre: " + ex.Message); }
        }

        private void PuertoSerie_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (!_puertoSerie.IsOpen) return;

                // Usamos ReadLine porque tu Arduino usa Serial.println()
                string jsonRecibido = _puertoSerie.ReadLine();

                this.Invoke(new Action(() =>
                {
                    ProcesarDatos(jsonRecibido);
                }));
            }
            catch
            {
                // Ignoramos timeouts de lectura normales
            }
        }

        private void ProcesarDatos(string json)
        {
            try
            {
                string jsonLimpio = json.Trim();
                if (string.IsNullOrEmpty(jsonLimpio) || !jsonLimpio.StartsWith("{")) return;

                LogDebug("RX: " + jsonLimpio);

                // DESERIALIZAR
                var datos = JsonConvert.DeserializeObject<DatosSensor>(jsonLimpio);

                if (datos != null && datos.valores != null)
                {
                    // 1. Mostrar valores
                    lblTempValor.Text = datos.valores.temp_c.ToString("0.0") + " °C";
                    lblHumValor.Text = datos.valores.hum_rel.ToString() + " %";

                    // 2. Info
                    lblInfoID.Text = $"ID: {datos.SlotID} | {datos.tipoDispositivo}\n" +
                                     $"Fecha: {datos.fecha_registro}";

                    // 3. LÓGICA CORREGIDA PARA ENTEROS (1=OK, 0=MAL)
                    if (datos.alertas != null && datos.alertas.Length > 0)
                    {
                        // AHORA LEEMOS UN ENTERO (int)
                        int estado = datos.alertas[0];

                        if (estado == 1)
                        {
                            // ESTADO 1 = OK (Verde)
                            lblEstadoAlerta.Text = "ESTADO: OK";
                            lblEstadoAlerta.ForeColor = Color.Green;
                        }
                        else
                        {
                            // ESTADO 0 = MAL (Rojo)
                            lblEstadoAlerta.Text = "ALERTA: TEMP ALTA";
                            lblEstadoAlerta.ForeColor = Color.Red;
                        }
                    }
                }
            }
            catch (JsonException) { LogDebug("Error JSON (Formato incorrecto)"); }
            catch (Exception ex) { LogDebug("Error: " + ex.Message); }
        }

        private void LogDebug(string texto)
        {
            if (txtDebug.Lines.Length > 50) txtDebug.Clear();
            txtDebug.AppendText(DateTime.Now.ToString("mm:ss") + " " + texto + Environment.NewLine);
        }
    }

    // --- CLASES PARA MAPEAR EL JSON ---

    public class DatosValores
    {
        public float temp_c { get; set; }
        public int hum_rel { get; set; }
    }

    public class DatosSensor
    {
        public string SlotID { get; set; }
        public string tipoDispositivo { get; set; }

        [JsonProperty("fecha_registro")]
        public string fecha_registro { get; set; }

        public DatosValores valores { get; set; }

        // CORRECCIÓN FINAL: int[] porque Arduino manda [1] o [0]
        public int[] alertas { get; set; }
    }
}