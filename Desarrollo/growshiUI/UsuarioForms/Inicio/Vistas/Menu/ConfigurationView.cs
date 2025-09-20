using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas
{
    public partial class ConfigurationView : UserControl
    {
        public ConfigurationView()
        {
            InitializeComponent();
        }

        private void CargarVista(UserControl vista)
        {
            // Panel2 es el panel derecho de nuestro SplitContainer
            this.splitContainer1.Panel2.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(vista);
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            CargarVista(new GestionUsuariosView());

        }

        private void buttonRolesPermisos_Click(object sender, EventArgs e)
        {
            CargarVista(new RolesYPermisosView());

        }

        private void buttonCopiaSeguridad_Click(object sender, EventArgs e)
        {
            CargarVista(new CopiasSeguridadView());
        }
    }
}
