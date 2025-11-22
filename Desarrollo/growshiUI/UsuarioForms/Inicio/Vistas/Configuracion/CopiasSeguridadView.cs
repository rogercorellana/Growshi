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

        public CopiasSeguridadView()
        {
            InitializeComponent();
            _backupBLL = new BackupBLL();
            _sessionService = SessionService<Usuario>.GetInstance();
            _usuarioActual = _sessionService.UsuarioLogueado;
        }

        private void CopiasSeguridadView_Load(object sender, EventArgs e)
        {
            // Forzar estilos del Grid al cargar
            ConfigurarEstiloGrid();
            ActualizarGrilla();
        }

        // Método extra para asegurar que el MetroGrid se vea bien
        private void ConfigurarEstiloGrid()
        {
            // Ajustes visuales adicionales si hacen falta
            metroGridHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        #region BOTON - CREAR COPIA DE SEGURIDAD
        private void buttonCrearCopia_Click(object sender, EventArgs e)
        {
            if (_usuarioActual == null)
            {
                MetroMessageBox.Show(this, "No se pudo identificar al usuario de la sesión.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmResult = MetroMessageBox.Show(this, "¿Desea iniciar una nueva copia de seguridad ahora?", "Confirmar Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            try
            {
                string notaDeBackUp = txtNotas.Text;

                _backupBLL.CrearCopiaDeSeguridad(notaDeBackUp, _usuarioActual);

                MetroMessageBox.Show(this, "Copia de seguridad creada con éxito.", "Operación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"Ocurrió un error al crear la copia de seguridad:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (metroGridHistorial.CurrentRow?.DataBoundItem is IBackup backupSeleccionado)
            {
                var confirmResult = MetroMessageBox.Show(this, $"¿Está seguro de que desea restaurar la base de datos desde el archivo '{backupSeleccionado.NombreArchivo}'?\n\n¡ESTA ACCIÓN SOBREESCRIBIRÁ TODOS LOS DATOS ACTUALES Y NO SE PUEDE DESHACER!", "Confirmar Restauración Crítica", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult != DialogResult.Yes) return;

                try
                {
                    _backupBLL.RestaurarCopiaDeSeguridad(backupSeleccionado);
                    MetroMessageBox.Show(this, "Base de datos restaurada con éxito.", "Operación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, $"Ocurrió un error durante la restauración:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ActualizarGrilla();
                    MetroMessageBox.Show(this,
                    "Nota: Al restaurar una versión antigua, es posible que el historial de copias recientes no aparezca en la lista, aunque los archivos físicos siguen seguros en su carpeta.",
                    "Información de Restauración",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Por favor seleccione un archivo de la lista para restaurar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonAbrirUbicacion_Click(object sender, EventArgs e)
        {
            if (metroGridHistorial.CurrentRow?.DataBoundItem is IBackup backupSeleccionado)
            {
                try
                {
                    // Intentar abrir el archivo seleccionado
                    //C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\



                    //

                    Process.Start("explorer.exe", backupSeleccionado.RutaArchivo);
                }
                catch
                {
                    // Si falla (ej: ruta no exacta), abrimos la carpeta
                    Process.Start("explorer.exe", backupSeleccionado.RutaArchivo);
                }
            }
            else
            {
                DialogResult resultado = MetroMessageBox.Show(this,
                "Usted no ha seleccionado ninguna copia de seguridad. ¿Desea abrir el directorio general de backups?",
                "Abrir Ubicación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    // Asegúrate de que esta ruta exista o manéjala dinámicamente
                    string rutaDefault = @"C:\Growshi\Backups\";
                    if (System.IO.Directory.Exists(rutaDefault))
                        Process.Start("explorer.exe", rutaDefault);
                    else
                        MetroMessageBox.Show(this, "No se encontró la ruta predeterminada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (metroGridHistorial.CurrentRow?.DataBoundItem is IBackup backupSeleccionado)
            {
                var confirmResult = MetroMessageBox.Show(this, $"¿Está seguro de que desea eliminar permanentemente el backup '{backupSeleccionado.NombreArchivo}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.Yes) return;

                try
                {
                    _backupBLL.EliminarCopiaDeSeguridad(backupSeleccionado);
                    ActualizarGrilla();
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, $"No se pudo eliminar el backup:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Por favor seleccione un archivo de la lista para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MetroMessageBox.Show(this, $"Error al cargar el historial: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrilla()
        {
            if (metroGridHistorial.Columns.Count == 0) return;

            // Ocultar columnas técnicas
            if (metroGridHistorial.Columns["Id"] != null) metroGridHistorial.Columns["Id"].Visible = false;
            if (metroGridHistorial.Columns["RutaArchivo"] != null) metroGridHistorial.Columns["RutaArchivo"].Visible = false;
            if (metroGridHistorial.Columns["Usuario"] != null) metroGridHistorial.Columns["Usuario"].Visible = false;

            // Configurar columnas visibles
            if (metroGridHistorial.Columns["FechaHora"] != null)
            {
                metroGridHistorial.Columns["FechaHora"].HeaderText = "Fecha y Hora";
                metroGridHistorial.Columns["FechaHora"].Width = 150;
            }

            if (metroGridHistorial.Columns["NombreArchivo"] != null)
            {
                metroGridHistorial.Columns["NombreArchivo"].HeaderText = "Archivo";
                metroGridHistorial.Columns["NombreArchivo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (metroGridHistorial.Columns["Nota"] != null)
            {
                metroGridHistorial.Columns["Nota"].HeaderText = "Notas";
                metroGridHistorial.Columns["Nota"].Width = 200;
            }
        }
    }
}