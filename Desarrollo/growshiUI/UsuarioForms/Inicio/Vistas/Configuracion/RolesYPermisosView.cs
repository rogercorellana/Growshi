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
            rolesYPermisosBLL.ListarFamiliaDeRoles();
        }



        

   
    }
}
