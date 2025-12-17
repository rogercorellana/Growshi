using System;
using System.Diagnostics;
using System.Windows.Forms;
using BE;
using BLL;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
using MetroFramework;
using MetroFramework.Controls;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    public partial class CopiasSeguridadView : UserControl
    {
        #region Propiedades y Servicios

        private readonly BackupBLL _backupBLL;
        private readonly IdiomaBLL _idiomaBLL;
        private readonly BitacoraBLL _bitacoraBLL;
        private readonly IBitacoraService _bitacoraService;
        private readonly ISessionService<Usuario> _sessionService;
        private readonly IUsuarioLogueado _usuarioActual;

        #endregion

        #region Constructor e Inicialización

        public CopiasSeguridadView()
        {
            InitializeComponent();

            // 1. Instancias
            _backupBLL = new BackupBLL();
            _idiomaBLL = new IdiomaBLL();
            _bitacoraBLL = new BitacoraBLL();
            _bitacoraService = BitacoraService.GetInstance();
            _sessionService = SessionService<Usuario>.GetInstance();
            _usuarioActual = _sessionService.UsuarioLogueado;

            // 2. Configuración
            this.Load += CopiasSeguridadView_Load;
            IdiomaService.GetInstance().IdiomaCambiado += ActualizarTraducciones;
        }

        private void CopiasSeguridadView_Load(object sender, EventArgs e)
        {
            ConfigurarEstiloGrid();
            ActualizarTraducciones(); // Carga inicial textos
            ActualizarGrilla();       // Carga inicial datos
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
            // Método seguro para hilos
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ActualizarTraducciones));
                return;
            }

            // Botones
            if (btnCrearCopia != null) btnCrearCopia.Text = _idiomaBLL.Traducir("Backup_Btn_Crear");
            if (btnRestaurar != null) btnRestaurar.Text = _idiomaBLL.Traducir("Backup_Btn_Restaurar");
            if (btnAbrirUbicacion != null) btnAbrirUbicacion.Text = _idiomaBLL.Traducir("Backup_Btn_AbrirUbicacion");
            if (btnEliminar != null) btnEliminar.Text = _idiomaBLL.Traducir("Backup_Btn_Eliminar");

            // Etiquetas y Placeholders
            if (lblTituloCrear != null) lblTituloCrear.Text = _idiomaBLL.Traducir("Backup_Lbl_TituloCrear");
            if (lblInstruccion != null) lblInstruccion.Text = _idiomaBLL.Traducir("Backup_Lbl_Instruccion");
            if (lblTituloHistorial != null) lblTituloHistorial.Text = _idiomaBLL.Traducir("Backup_Lbl_TituloHistorial");
            if (txtNotas != null) txtNotas.WaterMark = _idiomaBLL.Traducir("Backup_Txt_NotasPlaceholder");

            // Refrescar columnas si hay datos
            ConfigurarColumnasGrilla();
        }

        #endregion

        #region Lógica de Grilla

        private void ConfigurarEstiloGrid()
        {
            metroGridHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Configuraciones visuales extra si son necesarias
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
                MostrarError(ex.Message);
            }
        }

        private void ConfigurarColumnasGrilla()
        {
            if (metroGridHistorial.Columns.Count == 0) return;

            // Ocultar columnas técnicas
            if (metroGridHistorial.Columns["Id"] != null) metroGridHistorial.Columns["Id"].Visible = false;
            if (metroGridHistorial.Columns["RutaArchivo"] != null) metroGridHistorial.Columns["RutaArchivo"].Visible = false;
            if (metroGridHistorial.Columns["Usuario"] != null) metroGridHistorial.Columns["Usuario"].Visible = false;

            // Traducir encabezados visibles
            if (metroGridHistorial.Columns["FechaHora"] != null)
            {
                metroGridHistorial.Columns["FechaHora"].HeaderText = _idiomaBLL.Traducir("Backup_Col_FechaHora");
                metroGridHistorial.Columns["FechaHora"].Width = 150;
            }

            if (metroGridHistorial.Columns["NombreArchivo"] != null)
            {
                metroGridHistorial.Columns["NombreArchivo"].HeaderText = _idiomaBLL.Traducir("Backup_Col_Archivo");
            }

            if (metroGridHistorial.Columns["Nota"] != null)
            {
                metroGridHistorial.Columns["Nota"].HeaderText = _idiomaBLL.Traducir("Backup_Col_Notas");
            }
        }

        #endregion

        #region Acciones (Botones)

        private void buttonCrearCopia_Click(object sender, EventArgs e)
        {
            if (_usuarioActual == null)
            {
                MostrarError("No se pudo identificar al usuario de la sesión.");
                return;
            }

            if (!ConfirmarAccion(_idiomaBLL.Traducir("Backup_Msg_ConfirmarCrear"))) return;

            try
            {
                string notaDeBackUp = txtNotas.Text;
                _backupBLL.CrearCopiaDeSeguridad(notaDeBackUp, _usuarioActual);

                // BITÁCORA
                RegistrarBitacora("Backup creado exitosamente", NivelCriticidad.Info);

                MostrarExito(_idiomaBLL.Traducir("Backup_Msg_CrearExito"));
            }
            catch (Exception ex)
            {
                string msgError = string.Format(_idiomaBLL.Traducir("Backup_Msg_ErrorCrear"), ex.Message);
                MostrarError(msgError);
            }
            finally
            {
                txtNotas.Clear();
                ActualizarGrilla();
            }
        }

        private void buttonRestaurar_Click(object sender, EventArgs e)
        {
            if (metroGridHistorial.CurrentRow?.DataBoundItem is IBackup backupSeleccionado)
            {
                string msgConfirmacion = string.Format(_idiomaBLL.Traducir("Backup_Msg_ConfirmarRestaurar"), backupSeleccionado.NombreArchivo);

                // Usamos MessageBoxIcon.Warning porque restaurar es destructivo para los datos actuales
                if (MetroMessageBox.Show(this, msgConfirmacion, _idiomaBLL.Traducir("Global_Titulo_Atencion"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        _backupBLL.RestaurarCopiaDeSeguridad(backupSeleccionado);

                        // BITÁCORA (CRÍTICO)
                        RegistrarBitacora($"Base de datos restaurada desde: {backupSeleccionado.NombreArchivo}", NivelCriticidad.Critico);

                        MostrarExito(_idiomaBLL.Traducir("Backup_Msg_RestaurarExito"));

                        // Nota adicional post-restauración
                        MetroMessageBox.Show(this,
                            _idiomaBLL.Traducir("Backup_Msg_NotaPostRestauracion"),
                            _idiomaBLL.Traducir("Global_Titulo_Informacion"),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MostrarError(ex.Message);
                    }
                    finally
                    {
                        ActualizarGrilla();
                    }
                }
            }
            else
            {
                MostrarAdvertencia(_idiomaBLL.Traducir("Backup_Msg_SeleccionarItem"));
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (metroGridHistorial.CurrentRow?.DataBoundItem is IBackup backupSeleccionado)
            {
                string msgConfirmacion = string.Format(_idiomaBLL.Traducir("Backup_Msg_ConfirmarEliminar"), backupSeleccionado.NombreArchivo);

                if (ConfirmarAccion(msgConfirmacion))
                {
                    try
                    {
                        _backupBLL.EliminarCopiaDeSeguridad(backupSeleccionado);

                        // BITÁCORA
                        RegistrarBitacora($"Backup eliminado: {backupSeleccionado.NombreArchivo}", NivelCriticidad.Advertencia);

                        ActualizarGrilla();
                    }
                    catch (Exception ex)
                    {
                        MostrarError(ex.Message);
                    }
                }
            }
            else
            {
                MostrarAdvertencia(_idiomaBLL.Traducir("Backup_Msg_SeleccionarItem"));
            }
        }

        private void buttonAbrirUbicacion_Click(object sender, EventArgs e)
        {
            string ruta = @"C:\Growshi\Backups\"; // Default

            if (metroGridHistorial.CurrentRow?.DataBoundItem is IBackup backupSeleccionado)
            {
                // Intentar abrir el archivo seleccionado en el explorador
                ruta = "/select, \"" + backupSeleccionado.RutaArchivo + "\"";
            }
            else
            {
                // Preguntar si abrir la carpeta general
                if (!ConfirmarAccion(_idiomaBLL.Traducir("Backup_Msg_AbrirCarpetaGeneral"))) return;
            }

            try
            {
                Process.Start("explorer.exe", ruta);
            }
            catch
            {
                // Fallback si la ruta específica falla, abrir carpeta base
                try { Process.Start("explorer.exe", @"C:\Growshi\Backups\"); }
                catch { MostrarError("No se pudo abrir la ubicación."); }
            }
        }

        #endregion

        #region Helpers

        private void RegistrarBitacora(string mensaje, NivelCriticidad nivel)
        {
            var evento = _bitacoraService.CrearEvento(nivel, mensaje, "Backup & Restore", ((Usuario)_usuarioActual).IdUsuario);
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

        private bool ConfirmarAccion(string mensaje)
        {
            return MetroMessageBox.Show(this, mensaje, _idiomaBLL.Traducir("Global_Titulo_Confirmar"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void MostrarExito(string mensaje)
        {
            MetroMessageBox.Show(this, mensaje, _idiomaBLL.Traducir("Global_Titulo_Exito"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarAdvertencia(string mensaje)
        {
            MetroMessageBox.Show(this, mensaje, _idiomaBLL.Traducir("Global_Titulo_Atencion"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MostrarError(string mensaje)
        {
            MetroMessageBox.Show(this, mensaje, _idiomaBLL.Traducir("Global_Titulo_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}