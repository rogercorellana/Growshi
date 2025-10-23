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

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_RolesYPermisos
{
    public partial class ModificarFamilia : UserControl
    {
        RolesYPermisosBLL RolesYPermisosBLL = new RolesYPermisosBLL();

        public ModificarFamilia(string id, string nombre)
        {
            InitializeComponent();


            textBoxPermisoIDAntes.Text = id;
            textBoxNombreDescriptivoAntes.Text = nombre;

            textBoxPermisoIDAntes.Enabled = false;
            textBoxNombreDescriptivoAntes.Enabled = false;

            textBoxPermisoIDDespues.Text = id;
            textBoxNombreDescriptivoDespues.Text = nombre;

        }



        private void CargarVista(UserControl vista)
        {
            this.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.Controls.Add(vista);
        }



        private void buttonModificarFamilia_Click(object sender, EventArgs e)
        {

            string idOriginal = textBoxPermisoIDAntes.Text;
            string idDespues = textBoxPermisoIDDespues.Text;
            string descripcionDespues = textBoxNombreDescriptivoDespues.Text;


            RolesYPermisosBLL.ModificarFamiliaDeRoles(idOriginal,idDespues,descripcionDespues);


            MessageBox.Show($"Familia modificada Exitosamente",
                                    "Exito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.None);

            CargarVista(new RolesYPermisosView());
        }
    }
}
