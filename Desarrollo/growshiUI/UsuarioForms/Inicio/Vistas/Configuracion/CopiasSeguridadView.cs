using BE;
using BLL;
using Interfaces.IBE;
using Interfaces.IServices;
using Services; 
using System;
using System.Diagnostics; 
using System.Windows.Forms;

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
            ActualizarGrilla();
        }


        #region BOTON - CREAR COPIA DE SEGURIDAD
        private void buttonCrearCopia_Click(object sender, EventArgs e)
        {

            if (_usuarioActual == null)
            {
                MessageBox.Show("No se pudo identificar al usuario de la sesión.", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmResult = new DialogResult();

            confirmResult = MessageBox.Show("¿Desea iniciar una nueva copia de seguridad ahora?", "Confirmar Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes) 
                return;

            try
            {
                string notaDeBackUp = textBoxNotasCopia.Text;
                this.Cursor = Cursors.WaitCursor;

                _backupBLL.CrearCopiaDeSeguridad(notaDeBackUp, _usuarioActual);

                MessageBox.Show("Copia de seguridad creada con éxito.", "Operación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al crear la copia de seguridad:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                textBoxNotasCopia.Clear();
                ActualizarGrilla();
            }
        }
        #endregion

        private void buttonRestaurar_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistorial.CurrentRow?.DataBoundItem is IBackup backupSeleccionado)
            {
                var confirmResult = MessageBox.Show($"¿Está seguro de que desea restaurar la base de datos desde el archivo '{backupSeleccionado.NombreArchivo}'?\n\n¡ESTA ACCIÓN SOBREESCRIBIRÁ TODOS LOS DATOS ACTUALES Y NO SE PUEDE DESHACER!", "Confirmar Restauración Crítica", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult != DialogResult.Yes) return;

                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    _backupBLL.RestaurarCopiaDeSeguridad(backupSeleccionado);
                    MessageBox.Show("Base de datos restaurada con éxito.", "Operación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error durante la restauración:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ActualizarGrilla();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void buttonAbrirUbicacion_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistorial.CurrentRow?.DataBoundItem is IBackup backupSeleccionado)
            {
                Process.Start("explorer.exe", backupSeleccionado.RutaArchivo);
            }
            else
            {
                // Si no hay nada seleccionado, abre la carpeta raíz de backups

                DialogResult resultado = MessageBox.Show(
                "Usted no ha seleccionado ninguna copia de seguridad. Desea abrir el directorio destino?",
                "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", @"C:\Growshi\Backups\");
                }
                

                //


            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistorial.CurrentRow?.DataBoundItem is IBackup backupSeleccionado)
            {
                var confirmResult = MessageBox.Show($"¿Está seguro de que desea eliminar permanentemente el backup '{backupSeleccionado.NombreArchivo}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult != DialogResult.Yes) return;

                try
                {
                    _backupBLL.EliminarCopiaDeSeguridad(backupSeleccionado);
                    ActualizarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo eliminar el backup:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ActualizarGrilla()
        {
            try
            {
                dataGridViewHistorial.DataSource = null;
                dataGridViewHistorial.DataSource = _backupBLL.ObtenerHistorial();
                ConfigurarColumnasGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el historial: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasGrilla()
        {
            if (dataGridViewHistorial.Columns.Count == 0) return;

            dataGridViewHistorial.Columns["Id"].Visible = false;
            dataGridViewHistorial.Columns["RutaArchivo"].Visible = false;
            dataGridViewHistorial.Columns["Usuario"].Visible = false;


            dataGridViewHistorial.Columns["FechaHora"].HeaderText = "Fecha y Hora";
            dataGridViewHistorial.Columns["NombreArchivo"].HeaderText = "Nombre del Archivo";
            dataGridViewHistorial.Columns["Nota"].HeaderText = "Notas";

            dataGridViewHistorial.Columns["NombreArchivo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewHistorial.Columns["Nota"].Width = 250;
        }
    }
}