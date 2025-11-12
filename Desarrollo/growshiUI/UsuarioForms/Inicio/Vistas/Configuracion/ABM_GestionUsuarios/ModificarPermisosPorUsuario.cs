using BLL;
using BLL.InicioUsuarioBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_GestionUsuarios
{
    public partial class ModificarPermisosPorUsuario : UserControl
    {

        RolesYPermisosPorUsuarioBLL RolesYPermisosPorUsuarioBLL = new RolesYPermisosPorUsuarioBLL();
        public ModificarPermisosPorUsuario()
        {
            InitializeComponent();
        }

        private void ModificarPermisosPorUsuario_Load(object sender, EventArgs e)
        {
            #region CONFIGURACIONES INICIALES DE LOS DATAGRIDVIEW

            dataGridViewUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsuarios.RowHeadersVisible = false;
            dataGridViewUsuarios.ReadOnly = true;
            dataGridViewUsuarios.AllowUserToAddRows = false;
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridViewUsuarios.RowTemplate.Height = 40; // Ajusta este número
            dataGridViewUsuarios.AllowUserToResizeRows = false;
            dataGridViewUsuarios.Font = new Font(dataGridViewUsuarios.Font, FontStyle.Regular);

            dataGridViewRolesAsociadosAlUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRolesAsociadosAlUsuario.RowHeadersVisible = false;
            dataGridViewRolesAsociadosAlUsuario.ReadOnly = true;
            dataGridViewRolesAsociadosAlUsuario.AllowUserToAddRows = false;
            dataGridViewRolesAsociadosAlUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRolesAsociadosAlUsuario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridViewRolesAsociadosAlUsuario.RowTemplate.Height = 40; // Ajusta este número
            dataGridViewRolesAsociadosAlUsuario.AllowUserToResizeRows = false;
            dataGridViewRolesAsociadosAlUsuario.Font = new Font(dataGridViewRolesAsociadosAlUsuario.Font, FontStyle.Regular);

            dataGridViewRolesDisponibles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRolesDisponibles.RowHeadersVisible = false;
            dataGridViewRolesDisponibles.ReadOnly = true;
            dataGridViewRolesDisponibles.AllowUserToAddRows = false;
            dataGridViewRolesDisponibles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRolesDisponibles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridViewRolesDisponibles.RowTemplate.Height = 40; // Ajusta este número
            dataGridViewRolesDisponibles.AllowUserToResizeRows = false;
            dataGridViewRolesDisponibles.Font = new Font(dataGridViewRolesDisponibles.Font, FontStyle.Regular);

            #endregion

            listarFamiliaDeRoles();
        }

        private void CargarVista(UserControl vista)
        {
            this.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.Controls.Add(vista);
        }

        #region PRIMER DATAGRID
        public void listarFamiliaDeRoles()
        {
            DataTable dataTable = RolesYPermisosPorUsuarioBLL.ListarUsuarios();

            if (dataTable != null)
            {
                dataGridViewUsuarios.DataSource = dataTable;
            }
        }
        #endregion


        #region CRUD - SEGUNDO DATAGRID PERMISOS ASOCIADOS A USUARIO


        public void ListarRolesAsociadosAlUsuario(string idUsuarioSeleccionado)
        {
            DataTable dataTable = RolesYPermisosPorUsuarioBLL.ListarRolesAsociadosAlUsuario(idUsuarioSeleccionado);

            if (dataTable != null)
            {
                dataGridViewRolesAsociadosAlUsuario.DataSource = dataTable;
            }
        }

        #endregion


        #region CRUD - TERCER DATAGRID PERMISOS DISPONIBLES DE LA FAMILIA


        public void ListarRolesDisponibles(string idUsuarioSeleccionado)
        {
            DataTable dataTable = RolesYPermisosPorUsuarioBLL.ListarRolesDelSistemaDisponibles(idUsuarioSeleccionado);

            if (dataTable != null)
            {
                dataGridViewRolesDisponibles.DataSource = dataTable;
            }
        }






        #endregion


        private void dataGridViewUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow == null)
            {
                dataGridViewRolesAsociadosAlUsuario.DataSource = null;
                dataGridViewRolesDisponibles.DataSource = null;
                return;
            }

            string idUsuarioSeleccionado = dataGridViewUsuarios.CurrentRow.Cells["UsuarioNombre"].Value.ToString();

            ListarRolesAsociadosAlUsuario(idUsuarioSeleccionado);
            ListarRolesDisponibles(idUsuarioSeleccionado);
        }



        #region AGREGAR - QUITAR FAMILIA DE PERMISOS A USUARIO
        private void pictureBoxAgregar_Click(object sender, EventArgs e)
        {

            if (dataGridViewUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione el usuario a la cual desea agregar el permiso.",
                                "Usuario no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridViewRolesDisponibles.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione el permiso que desea agregar.",
                                "Permiso no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string idFamiliaPadre = dataGridViewUsuarios.CurrentRow.Cells["UsuarioNombre"].Value.ToString();
                string idParaAgregar = dataGridViewRolesDisponibles.CurrentRow.Cells["PermisoID"].Value.ToString();


                RolesYPermisosPorUsuarioBLL.AgregarPermisoAUsuario(idParaAgregar, idFamiliaPadre);

                ListarRolesAsociadosAlUsuario(idFamiliaPadre);
                ListarRolesDisponibles(idFamiliaPadre);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar Permiso:  {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void pictureBoxQuitar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione el usuario.",
                                "Usuario no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // AHORA VALIDAMOS Y LEEMOS DEL GRID DE ROLES ASOCIADOS
            if (dataGridViewRolesAsociadosAlUsuario.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione el permiso que desea quitar de la lista de 'Roles Asociados'.",
                                "Permiso no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string idFamiliaPadre = dataGridViewUsuarios.CurrentRow.Cells["UsuarioNombre"].Value.ToString();

                // ¡LA CORRECCIÓN! Leemos del grid de roles ASOCIADOS
                string idParaQuitar = dataGridViewRolesAsociadosAlUsuario.CurrentRow.Cells["PermisoID"].Value.ToString();

                // Llamamos al BLL (que llamará al DAO)
                RolesYPermisosPorUsuarioBLL.QuitarPermisoAUsuario(idParaQuitar, idFamiliaPadre);

                // Refrescamos ambas listas
                ListarRolesAsociadosAlUsuario(idFamiliaPadre);
                ListarRolesDisponibles(idFamiliaPadre);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al quitar Permiso: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
