using BE;
using BLL;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using MetroFramework; // Necesario para los mensajes modernos

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    public partial class CopiasSeguridadView : UserControl
    {
        private readonly BackupBLL _backupBLL;
        private readonly ISessionService<Usuario> _sessionService;
        private IUsuarioLogueado _usuarioActual;
        
        // Servicio de Traducción
        private readonly IdiomaBLL _idiomaBLL;

        public CopiasSeguridadView()
        {
            InitializeComponent();
            _backupBLL = new BackupBLL();
            _sessionService = SessionService<Usuario>.GetInstance();
            _usuarioActual = _sessionService.UsuarioLogueado;
            _idiomaBLL = new IdiomaBLL(); 
        }

        private void CopiasSeguridadView_Load(object sender, EventArgs e)
        {
            TraducirInterfaz();

            IdiomaService.GetInstance().IdiomaCambiado += () => {
                TraducirInterfaz();
                ActualizarGrilla();
            };

            ConfigurarEstiloGrid();
            ActualizarGrilla();
        }

        private void TraducirInterfaz()
        {
            if (btnCrearCopia != null) btnCrearCopia.Text = _idiomaBLL.Traducir("btn_crear_copia");
            if (btnRestaurar != null) btnRestaurar.Text = _idiomaBLL.Traducir("btn_restaurar_backup");
            if (btnAbrirUbicacion != null) btnAbrirUbicacion.Text = _idiomaBLL.Traducir("btn_abrir_ubicacion");
            if (btnEliminar != null) btnEliminar.Text = _idiomaBLL.Traducir("btn_eliminar_backup");

            if (lblTituloCrear != null) lblTituloCrear.Text = _idiomaBLL.Traducir("lbltitulocrear_CopiaSeguridad");
            if (lblInstruccion != null) lblInstruccion.Text = _idiomaBLL.Traducir("lblInstruccion_CopiaSeguridad");
            if (txtNotas.WaterMark != null) txtNotas.WaterMark = _idiomaBLL.Traducir("watermark_txtNotas_CopiaSeguridad");
            if (lblTituloHistorial != null) lblTituloHistorial.Text = _idiomaBLL.Traducir("lblTituloHistorial_CopiaSeguridad");

        }

        private void ConfigurarEstiloGrid()
        {
            metroGridHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        #region BOTON - CREAR COPIA DE SEGURIDAD
        private void buttonCrearCopia_Click(object sender, EventArgs e)
        {
            if (_usuarioActual == null)
            {
                // Mensaje genérico de error
                MetroMessageBox.Show(this, "No se pudo identificar al usuario de la sesión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mensaje = _idiomaBLL.Traducir("msg_confirmar_crear_backup");
            string titulo = _idiomaBLL.Traducir("titulo_confirmar_operacion");

            DialogResult confirmResult = MetroMessageBox.Show(this, mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes) return;

            try
            {
                string notaDeBackUp = txtNotas.Text;
                _backupBLL.CrearCopiaDeSeguridad(notaDeBackUp, _usuarioActual);

                string msgExito = _idiomaBLL.Traducir("msg_backup_exito");
                string tituloExito = _idiomaBLL.Traducir("titulo_operacion_completada");

                MetroMessageBox.Show(this, msgExito, tituloExito, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string formatoError = _idiomaBLL.Traducir("msg_error_crear_backup");
                string tituloError = _idiomaBLL.Traducir("titulo_error");
                
                MetroMessageBox.Show(this, string.Format(formatoError, ex.Message), tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtNotas.Clear(); // Limpiar el MetroTextBox
                ActualizarGrilla();
            }
        }
        #endregion

        private void buttonRestaurar_Click(object sender, EventArgs e)
        {
            string tituloAtencion = _idiomaBLL.Traducir("titulo_atencion");

            if (metroGridHistorial.CurrentRow?.DataBoundItem is IBackup backupSeleccionado)
            {
                string formatoMsg = _idiomaBLL.Traducir("msg_confirmar_restaurar_critico");
                string tituloCritico = _idiomaBLL.Traducir("titulo_restauracion_critica");
                
                var confirmResult = MetroMessageBox.Show(this, string.Format(formatoMsg, backupSeleccionado.NombreArchivo), tituloCritico, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (confirmResult != DialogResult.Yes) return;

                try
                {
                    _backupBLL.RestaurarCopiaDeSeguridad(backupSeleccionado);
                    
                    string msgExito = _idiomaBLL.Traducir("msg_restauracion_exito");
                    string tituloExito = _idiomaBLL.Traducir("titulo_operacion_completada");

                    MetroMessageBox.Show(this, msgExito, tituloExito, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    string tituloError = _idiomaBLL.Traducir("titulo_error");
                    MetroMessageBox.Show(this, $"Error: {ex.Message}", tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ActualizarGrilla();
                    
                    string msgNota = _idiomaBLL.Traducir("msg_nota_restauracion");
                    string tituloInfo = _idiomaBLL.Traducir("titulo_informacion");

                    MetroMessageBox.Show(this, msgNota, tituloInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string msgSel = _idiomaBLL.Traducir("msg_seleccione_backup");
                MetroMessageBox.Show(this, msgSel, tituloAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonAbrirUbicacion_Click(object sender, EventArgs e)
        {
            if (metroGridHistorial.CurrentRow?.DataBoundItem is IBackup backupSeleccionado)
            {
                try
                {
                    Process.Start("explorer.exe", backupSeleccionado.RutaArchivo);
                }
                catch
                {
                    
                    Process.Start("explorer.exe", backupSeleccionado.RutaArchivo);
                }
            }
            else
            {
                string msgPregunta = _idiomaBLL.Traducir("msg_abrir_directorio_general");
                string tituloAbrir = _idiomaBLL.Traducir("titulo_abrir_ubicacion");

                DialogResult resultado = MetroMessageBox.Show(this, msgPregunta, tituloAbrir, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    string rutaDefault = @"C:\Growshi\Backups\";
                    if (System.IO.Directory.Exists(rutaDefault))
                        Process.Start("explorer.exe", rutaDefault);
                    else
                    {
                        string tituloError = _idiomaBLL.Traducir("titulo_error");
                        MetroMessageBox.Show(this, "Ruta no encontrada / Path not found", tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            string tituloAtencion = _idiomaBLL.Traducir("titulo_atencion");

            if (metroGridHistorial.CurrentRow?.DataBoundItem is IBackup backupSeleccionado)
            {
                string formatoMsg = _idiomaBLL.Traducir("msg_confirmar_eliminar_backup");
                string tituloConfirmar = _idiomaBLL.Traducir("titulo_confirmar_operacion");

                var confirmResult = MetroMessageBox.Show(this, string.Format(formatoMsg, backupSeleccionado.NombreArchivo), tituloConfirmar, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (confirmResult != DialogResult.Yes) return;

                try
                {
                    _backupBLL.EliminarCopiaDeSeguridad(backupSeleccionado);
                    ActualizarGrilla();
                }
                catch (Exception ex)
                {
                    string tituloError = _idiomaBLL.Traducir("titulo_error");
                    MetroMessageBox.Show(this, $"Error: {ex.Message}", tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string msgSel = _idiomaBLL.Traducir("msg_seleccione_backup");
                MetroMessageBox.Show(this, msgSel, tituloAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarGrilla()
        {
            try
            {
                metroGridHistorial.DataSource = null;
                metroGridHistorial.DataSource = _backupBLL.ObtenerHistorial();
                ConfigurarColumnasGrilla();
            }
            catch (Exception ex)
            {
                string tituloError = _idiomaBLL.Traducir("titulo_error");
                MetroMessageBox.Show(this, ex.Message, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrilla()
        {
            if (metroGridHistorial.Columns.Count == 0) return;

            if (metroGridHistorial.Columns["Id"] != null) metroGridHistorial.Columns["Id"].Visible = false;
            if (metroGridHistorial.Columns["RutaArchivo"] != null) metroGridHistorial.Columns["RutaArchivo"].Visible = false;
            if (metroGridHistorial.Columns["Usuario"] != null) metroGridHistorial.Columns["Usuario"].Visible = false;

            if (metroGridHistorial.Columns["FechaHora"] != null)
            {
                metroGridHistorial.Columns["FechaHora"].HeaderText = _idiomaBLL.Traducir("col_fecha_hora");
                metroGridHistorial.Columns["FechaHora"].Width = 150;
            }

            if (metroGridHistorial.Columns["NombreArchivo"] != null)
            {
                metroGridHistorial.Columns["NombreArchivo"].HeaderText = _idiomaBLL.Traducir("col_archivo");
                metroGridHistorial.Columns["NombreArchivo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (metroGridHistorial.Columns["Nota"] != null)
            {
                metroGridHistorial.Columns["Nota"].HeaderText = _idiomaBLL.Traducir("col_notas");
                metroGridHistorial.Columns["Nota"].Width = 200;
            }
        }
    }
}