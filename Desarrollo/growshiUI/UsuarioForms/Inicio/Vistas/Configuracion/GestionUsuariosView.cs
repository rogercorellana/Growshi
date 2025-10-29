using BLL;
using BLL.InicioUsuarioBLL;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_GestionUsuarios;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_RolesYPermisos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    public partial class GestionUsuariosView : UserControl
    {

        GestionUsuariosBLL gestionUsuariosBLL = new GestionUsuariosBLL();
        public GestionUsuariosView()
        {
            InitializeComponent();

        }

        private void GestionUsuariosView_Load(object sender, EventArgs e)
        {
            #region CONFIGURACION INICIAR DGV
            dataGridViewUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsuarios.RowHeadersVisible = false;
            dataGridViewUsuarios.ReadOnly = true;
            dataGridViewUsuarios.AllowUserToAddRows = false;
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridViewUsuarios.RowTemplate.Height = 40; // Ajusta este número
            dataGridViewUsuarios.AllowUserToResizeRows = false;
            dataGridViewUsuarios.Font = new Font(dataGridViewUsuarios.Font, FontStyle.Regular);
            #endregion

            ListarUsuarios();

        }
        private void CargarVista(UserControl vista)
        {
            this.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.Controls.Add(vista);
        }

        public void ListarUsuarios()
        {
            DataTable dataTable = gestionUsuariosBLL.ListarUsuarios();

            if (dataTable != null)
            {
                dataGridViewUsuarios.DataSource = dataTable;
            }
        }

        private void buttonAgregarUsuario_Click(object sender, EventArgs e)
        {
            CargarVista(new AgregarUsuario());

        }

        private void buttonEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow == null)
            {
                return;
            }

            string mensaje = "¡Esta será una acción IRREVERSIBLE!\n\n" +
                             "¿Desea borrar el usuario PERMANENTEMENTE?";

            DialogResult resultado = MessageBox.Show(mensaje, "Atención",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int idParaDesactivar = Convert.ToInt32(dataGridViewUsuarios.CurrentRow.Cells["UsuarioID"].Value);
                    gestionUsuariosBLL.DesactivarUsuario(idParaDesactivar);

                    MessageBox.Show($"Usuario Borrado Exitosamente",
                                    "Exito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.None);


                    ListarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el Usuario: {ex.Message}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonEditarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione el usuario que desea modificar.",
                                "Ninguna fila seleccionada",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string mensaje = "Desea modificar el usuario??";

            DialogResult resultado = MessageBox.Show(
                mensaje,
                "Atención",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    string nombreParaModificar = dataGridViewUsuarios.CurrentRow.Cells["UsuarioNombre"].Value.ToString();
                    string contraseñaParaModificar = dataGridViewUsuarios.CurrentRow.Cells["UsuarioContraseña"].Value.ToString();
                    string claveRecuperacionParaModificar = dataGridViewUsuarios.CurrentRow.Cells["UsuarioClaveRecuperacion"].Value.ToString();
                    int usuarioIntentosParaModificar = Convert.ToInt32(dataGridViewUsuarios.CurrentRow.Cells["UsuarioIntentos"].Value);
                    int usuarioActivoParaModificar = Convert.ToInt32(dataGridViewUsuarios.CurrentRow.Cells["EstaActivo"].Value);

                

                    CargarVista(new ModificarUsuario(nombreParaModificar, contraseñaParaModificar, claveRecuperacionParaModificar, usuarioIntentosParaModificar, usuarioActivoParaModificar));

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar el usuario: {ex.Message}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }
    }
}
