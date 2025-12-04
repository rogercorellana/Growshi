using MetroFramework.Forms;
using MetroFramework;
using BLL;
using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace growshiUI.Configuracion_ConnString
{
    public partial class FormConfiguracion : MetroForm
    {
        UsuarioBLL UsuarioBLL = new UsuarioBLL();
        private bool _configuracionGuardada = false;

        public FormConfiguracion()
        {
            InitializeComponent();

            // --- CAMBIO DE LOOK: CLARO Y VERDE (Botánica) ---
            this.Theme = MetroThemeStyle.Light; // Fondo Blanco
            this.Style = MetroColorStyle.Green; // Acentos Verde Growshi

            // Iniciamos la búsqueda automática
            CargarServidoresAsync();
        }

        // ... EL RESTO DE TU CÓDIGO (CargarServidoresAsync, etc.) SE MANTIENE EXACTAMENTE IGUAL ...
        // ... (Copia aquí todo el bloque de lógica que ya probaste y funciona) ...

        // --- LÓGICA DE AUTO-DESCUBRIMIENTO ---

        private async void CargarServidoresAsync()
        {
            // 1. Configuración inicial
            metroLabelInfo.Text = "Buscando servidores locales...";
            cmbServidor.Items.Clear();
            cmbServidor.Enabled = false; // Bloqueamos momentáneamente

            var servidoresEncontrados = new System.Collections.Generic.HashSet<string>();

            // 2. Opciones básicas (INSTANTÁNEO)
            servidoresEncontrados.Add(@".\SQLEXPRESS");
            servidoresEncontrados.Add(@"(local)");
            servidoresEncontrados.Add(Environment.MachineName);

            // 3. Búsqueda en REGISTRO (INSTANTÁNEO)
            try
            {
                RegistryView[] views = new RegistryView[] { RegistryView.Registry32, RegistryView.Registry64 };
                foreach (var view in views)
                {
                    using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view))
                    using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL"))
                    {
                        if (key != null)
                        {
                            foreach (var instanceName in key.GetValueNames())
                            {
                                if (instanceName == "MSSQLSERVER")
                                    servidoresEncontrados.Add(Environment.MachineName);
                                else
                                    servidoresEncontrados.Add(Environment.MachineName + "\\" + instanceName);
                            }
                        }
                    }
                }
            }
            catch { /* Ignorar errores de permisos */ }

            // --- PUNTO CLAVE: DESBLOQUEAR AQUÍ ---
            // Ya tenemos los locales, así que habilitamos el control para que el usuario no espere.
            ActualizarCombo(servidoresEncontrados);
            cmbServidor.Enabled = true;
            metroLabelInfo.Text = "Servidores locales listos. Escaneando red...";

            // 4. Búsqueda en RED (LENTO - Dejamos que corra en segundo plano)
            await Task.Run(() =>
            {
                try
                {
                    DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            string serverName = row["ServerName"].ToString();
                            string instanceName = row["InstanceName"].ToString();
                            string fullName = string.IsNullOrEmpty(instanceName) ? serverName : $"{serverName}\\{instanceName}";

                            // El HashSet se encarga de no agregar duplicados si ya lo encontró el registro
                            servidoresEncontrados.Add(fullName);
                        }
                    }
                }
                catch { }
            });

            // 5. Actualización final (Solo si encontró algo nuevo en la red)
            ActualizarCombo(servidoresEncontrados);
            metroLabelInfo.Text = "Búsqueda completa. Seleccione un servidor.";
        }

        private void ActualizarCombo(System.Collections.Generic.HashSet<string> lista)
        {
            if (cmbServidor.InvokeRequired)
            {
                cmbServidor.Invoke(new Action(() => ActualizarCombo(lista)));
                return;
            }

            string seleccionPrevia = cmbServidor.Text;

            cmbServidor.Items.Clear();
            foreach (var server in lista)
            {
                cmbServidor.Items.Add(server);
            }

            if (!string.IsNullOrEmpty(seleccionPrevia) && cmbServidor.Items.Contains(seleccionPrevia))
                cmbServidor.Text = seleccionPrevia;
            else if (cmbServidor.Items.Count > 0)
                cmbServidor.SelectedIndex = 0;
        }

        private void CargarBasesDeDatos()
        {
            string servidor = cmbServidor.Text;
            if (string.IsNullOrWhiteSpace(servidor))
            {
                MetroMessageBox.Show(this, "Seleccione o escriba un servidor primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                metroLabelInfo.Text = "Conectando al servidor para listar BDs...";
                cmbBaseDatos.Items.Clear();

                string connectionStringTemp = $"Data Source={servidor};Initial Catalog=master;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionStringTemp))
                {
                    conn.Open();
                    string query = "SELECT name FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb') ORDER BY name";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbBaseDatos.Items.Add(reader["name"].ToString());
                        }
                    }
                }

                if (cmbBaseDatos.Items.Count > 0)
                {
                    cmbBaseDatos.SelectedIndex = 0;
        
                    int indexGrowshi = cmbBaseDatos.FindStringExact("Growshi");
                    if (indexGrowshi >= 0) cmbBaseDatos.SelectedIndex = indexGrowshi;
                }
                else
                {
                    metroLabelInfo.Text = "No se encontraron bases de datos de usuario.";
                    MetroMessageBox.Show(this, "Se conectó al servidor pero no tiene bases de datos creadas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                metroLabelInfo.Text = "Error de conexión.";
                MetroMessageBox.Show(this, "No se pudo conectar.\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        // --- EVENTOS DE BOTONES ---

        private void btnRefrescarServidores_Click(object sender, EventArgs e)
        {
            CargarServidoresAsync();
        }

        private void btnBuscarBDs_Click(object sender, EventArgs e)
        {
            CargarBasesDeDatos();
        }

        private void cmbBaseDatos_Click(object sender, EventArgs e)
        {
            if (cmbBaseDatos.Items.Count == 0 && !string.IsNullOrWhiteSpace(cmbServidor.Text))
            {
                CargarBasesDeDatos();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbServidor.Text) || string.IsNullOrWhiteSpace(cmbBaseDatos.Text))
            {
                MetroMessageBox.Show(this, "Debe seleccionar Servidor y Base de Datos.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UsuarioBLL.GuardarCadenaConexion(cmbServidor.Text.Trim(), cmbBaseDatos.Text.Trim());

                MetroMessageBox.Show(this, "Configuración guardada.\nLa aplicación se reiniciará.", "Configuración Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Question);

                _configuracionGuardada = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Error crítico al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormConfiguracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Si ya se guardó la configuración correctamente, dejamos que se cierre normal.
            if (_configuracionGuardada) return;

            // Si NO se guardó, preguntamos.
            var respuesta = MetroMessageBox.Show(this,
                "Si no configura la base de datos, el sistema no puede iniciar.\n\n¿Está seguro que desea salir?",
                "¿Salir de la aplicación?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);

            if (respuesta == DialogResult.Yes)
            {
                // SOLUCIÓN: Usar Environment.Exit(0)
                // Esto mata el proceso del sistema operativo inmediatamente.
                Environment.Exit(0);
            }
            else
            {
                // Si dice que NO, cancelamos el cierre para que se quede en la ventana
                e.Cancel = true;
            }
        }
    }
}