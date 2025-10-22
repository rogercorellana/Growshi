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

            listarFamiliaDeRoles();
            listarRolesDelSistema();
        }


        public void listarFamiliaDeRoles()
        {
            DataTable dataTable = rolesYPermisosBLL.ListarFamiliaDeRoles();

            if (dataTable != null)
            {
                dataGridViewFamiliaDeRoles.DataSource = dataTable;

           
            }
        }

        public void listarRolesDelSistema()
        {
            DataTable dataTable = rolesYPermisosBLL.ListarRolesDelSistema();

            if (dataTable != null)
            {
                dataGridViewRolesDelSistema.DataSource = dataTable;

                
            }
        }




        //PRIMER DATAGRID VIEW FAMILIAS
        //ABM
        private void buttonAgregarNuevaFamilia_Click(object sender, EventArgs e)
        {

        }



    }
}
