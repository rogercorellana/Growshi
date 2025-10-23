using BLL.InicioUsuarioBLL;
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
    public partial class RolesYPermisosView : UserControl
    {
        RolesYPermisosBLL rolesYPermisosBLL = new RolesYPermisosBLL();

        public RolesYPermisosView()
        {
            InitializeComponent();
        }

        private void RolesYPermisosView_Load(object sender, EventArgs e)
        {
            #region CONFIGURACIONES INICIALES DE LOS DATAGRIDVIEW

            dataGridViewFamiliaDeRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFamiliaDeRoles.RowHeadersVisible = false;
            dataGridViewFamiliaDeRoles.ReadOnly = true;
            dataGridViewFamiliaDeRoles.AllowUserToAddRows = false;
            dataGridViewFamiliaDeRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewFamiliaDeRoles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridViewFamiliaDeRoles.RowTemplate.Height = 40; // Ajusta este número
            dataGridViewFamiliaDeRoles.AllowUserToResizeRows = false;
            dataGridViewFamiliaDeRoles.Font = new Font(dataGridViewFamiliaDeRoles.Font, FontStyle.Regular);

            dataGridViewRolesAsociados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRolesAsociados.RowHeadersVisible = false;
            dataGridViewRolesAsociados.ReadOnly = true;
            dataGridViewRolesAsociados.AllowUserToAddRows = false;
            dataGridViewRolesAsociados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRolesAsociados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridViewRolesAsociados.RowTemplate.Height = 40; // Ajusta este número
            dataGridViewRolesAsociados.AllowUserToResizeRows = false;
            dataGridViewRolesAsociados.Font = new Font(dataGridViewFamiliaDeRoles.Font, FontStyle.Regular);

            dataGridViewRolesDelSistema.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewRolesDelSistema.RowHeadersVisible = false;
            dataGridViewRolesDelSistema.ReadOnly = true;
            dataGridViewRolesDelSistema.AllowUserToAddRows = false;
            dataGridViewRolesDelSistema.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewRolesDelSistema.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridViewRolesDelSistema.RowTemplate.Height = 40; // Ajusta este número
            dataGridViewRolesDelSistema.AllowUserToResizeRows = false;
            dataGridViewRolesDelSistema.Font = new Font(dataGridViewFamiliaDeRoles.Font, FontStyle.Regular);

            #endregion

            // 1. Carga solo la grilla principal
            listarFamiliaDeRoles();

            // 2. Las otras grillas se cargarán automáticamente
            // por el evento 'dataGridViewFamiliaDeRoles_SelectionChanged'
            // al seleccionarse la primera fila.
        }

        private void CargarVista(UserControl vista)
        {
            this.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.Controls.Add(vista);
        }

        #region CRUD - PRIMER DATAGRID FAMILIA DE PERMISOS

        private void buttonAgregarNuevaFamilia_Click(object sender, EventArgs e)
        {
            CargarVista(new AgregarFamilia());
        }

        public void listarFamiliaDeRoles()
        {
            DataTable dataTable = rolesYPermisosBLL.ListarFamiliaDeRoles();

            if (dataTable != null)
            {
                dataGridViewFamiliaDeRoles.DataSource = dataTable;
            }
        }

        private void buttonEliminarFamilia_Click(object sender, EventArgs e)
        {
            if (dataGridViewFamiliaDeRoles.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione la familia que desea eliminar.",
                                "Ninguna fila seleccionada",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string mensaje = "¡Esta será una acción IRREVERSIBLE!\n\n" +
                             "¿Desea borrar esta familia de permisos?";

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
                    string idParaBorrar = dataGridViewFamiliaDeRoles.CurrentRow.Cells["PermisoID"].Value.ToString();
                    rolesYPermisosBLL.EliminarFamiliaDeRoles(idParaBorrar);

                    MessageBox.Show($"Familia Borrada Exitosamente",
                                    "Exito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.None);

                    CargarVista(new RolesYPermisosView());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la familia: {ex.Message}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRenombrarFamilia_Click(object sender, EventArgs e)
        {
            if (dataGridViewFamiliaDeRoles.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione la familia que desea modificar.",
                                "Ninguna fila seleccionada",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string mensaje = "¡Esta accion puede ser REVERSIBLE!\n\n" +
                             "Desea modificar la familia de Permisos??";

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
                    string idParaModificar = dataGridViewFamiliaDeRoles.CurrentRow.Cells["PermisoID"].Value.ToString();
                    string nombreParaModificar = dataGridViewFamiliaDeRoles.CurrentRow.Cells["NombreDescriptivo"].Value.ToString();

                    CargarVista(new ModificarFamilia(idParaModificar, nombreParaModificar));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar la familia: {ex.Message}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region CRUD - SEGUNDO DATAGRID PERMISOS ASOCIADOS A UNA FAMILIA

        // *** MÉTODO CORREGIDO ***
        // Ahora recibe el ID de la familia seleccionada
        public void listarRolesAsociadosAUnaFamilia(string idFamilia)
        {
            DataTable dataTable = rolesYPermisosBLL.ListarRolesAsociadosAfamilia(idFamilia);

            if (dataTable != null)
            {
                dataGridViewRolesAsociados.DataSource = dataTable;
            }
        }

        #endregion

        #region CRUD - TERCER DATAGRID PERMISOS DISPONIBLES DE LA FAMILIA

        // *** MÉTODO CORREGIDO ***
        // Ahora recibe el ID de la familia seleccionada
        public void ListarRolesDelSistemaDisponibles(string idFamilia)
        {
            DataTable dataTable = rolesYPermisosBLL.ListarRolesDelSistemaDisponibles(idFamilia);

            if (dataTable != null)
            {
                dataGridViewRolesDelSistema.DataSource = dataTable;
            }
        }

        #endregion

        // *** MÉTODO CORREGIDO ***
        // Este evento ahora controla la carga de las otras dos grillas.
        private void dataGridViewFamiliaDeRoles_SelectionChanged(object sender, EventArgs e)
        {
            // 1. Verificación de seguridad
            // Si CurrentRow es null (porque la grilla se está cargando o está vacía),
            // limpia las grillas secundarias y detiene la ejecución.
            if (dataGridViewFamiliaDeRoles.CurrentRow == null)
            {
                dataGridViewRolesAsociados.DataSource = null;
                dataGridViewRolesDelSistema.DataSource = null;
                return;
            }

            // 2. Si la verificación pasa, obtiene el ID de la fila seleccionada
            string idFamiliaSeleccionada = dataGridViewFamiliaDeRoles.CurrentRow.Cells["PermisoID"].Value.ToString();

            // 3. Llama a los métodos de carga pasándoles el ID
            listarRolesAsociadosAUnaFamilia(idFamiliaSeleccionada);
            ListarRolesDelSistemaDisponibles(idFamiliaSeleccionada);
        }

        public void listarTodosRolesDelSistema()
        {
            DataTable dataTable = rolesYPermisosBLL.ListarTodosRolesDelSistema();

            if (dataTable != null)
            {
                dataGridViewRolesDelSistema.DataSource = dataTable;
            }
        }
    }
}