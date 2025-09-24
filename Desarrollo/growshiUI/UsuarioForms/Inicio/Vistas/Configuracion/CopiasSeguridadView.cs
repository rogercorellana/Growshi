using BE;
using BLL;
using Interfaces.IBE; // Necesario para obtener el usuario de la sesión y castear el objeto de la grilla
using Interfaces.IServices;
using Services; // Necesario para acceder al SessionService
using System;
using System.Diagnostics; // Necesario para abrir la ubicación del archivo
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    public partial class CopiasSeguridadView : UserControl
    {
        // La UI solo necesita conocer a la BLL para darle órdenes.
        private readonly BackupBLL _backupBLL;

        // Asumo que tu SessionService se llama así y es un Singleton.
        private readonly ISessionService<Usuario> _sessionService;

        public Usuario UsuarioActual { get; private set; }

        public CopiasSeguridadView()
        {
            InitializeComponent();

            // Instanciamos la BLL y el servicio de sesión que usaremos.
            _backupBLL = new BackupBLL();

            this.UsuarioActual = _sessionService.UsuarioLogueado;

            
        }

        private void CopiasSeguridadView_Load(object sender, EventArgs e)
        {
            // Al cargar la vista, llenamos la grilla con el historial.
            ActualizarGrilla();
        }

        private void buttonCrearCopia_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("¿Desea iniciar una nueva copia de seguridad ahora?", "Confirmar Operación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            try
            {
                // La UI prepara los ingredientes y se los pasa a la BLL.
                string nota = textBoxNotasCopia.Text;
                IUsuarioLogueado usuario = _sessionService.UsuarioLogueado;

                this.Cursor = Cursors.WaitCursor; // Cambiamos el cursor para dar feedback

                // Le damos la orden a la BLL. La UI no sabe cómo se hace, solo lo pide.
                _backupBLL.CrearCopiaDeSeguridad(nota, usuario);

                MessageBox.Show("Copia de seguridad creada con éxito.", "Operación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al crear la copia de seguridad:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Pase lo que pase, restauramos el cursor y actualizamos la vista.
                this.Cursor = Cursors.Default;
                textBoxNotasCopia.Clear();
                ActualizarGrilla();
            }
        }

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
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void buttonAbrirUbicacion_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistorial.CurrentRow?.DataBoundItem is IBackup backupSeleccionado)
            {
                // Usamos la ruta del backup seleccionado para abrir la carpeta.
                Process.Start("explorer.exe", backupSeleccionado.RutaArchivo);
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
                    ActualizarGrilla(); // Actualizamos para que desaparezca de la lista.
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo eliminar el backup:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- MÉTODOS PRIVADOS DE AYUDA ---

        private void ActualizarGrilla()
        {
            try
            {
                // Le pedimos los datos a la BLL.
                dataGridViewHistorial.DataSource = null;
                dataGridViewHistorial.DataSource = _backupBLL.ObtenerHistorial();

                // Aquí puedes configurar las columnas para que se vean mejor.
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

            // Ocultamos las columnas que no son útiles para el usuario.
            dataGridViewHistorial.Columns["Id"].Visible = false;
            dataGridViewHistorial.Columns["RutaArchivo"].Visible = false;

            // Cambiamos los títulos de las columnas a algo más amigable.
            dataGridViewHistorial.Columns["FechaHora"].HeaderText = "Fecha y Hora";
            dataGridViewHistorial.Columns["NombreArchivo"].HeaderText = "Nombre del Archivo";
            dataGridViewHistorial.Columns["Nota"].HeaderText = "Notas";
            dataGridViewHistorial.Columns["Usuario"].HeaderText = "Realizado por";

            // Ajustamos el tamaño de las columnas.
            dataGridViewHistorial.Columns["NombreArchivo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewHistorial.Columns["Nota"].Width = 250;
        }
    }
}