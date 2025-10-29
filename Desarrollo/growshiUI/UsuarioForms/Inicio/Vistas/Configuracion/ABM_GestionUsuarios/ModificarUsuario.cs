using BLL;
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
    public partial class ModificarUsuario : UserControl
    {

        UsuarioBLL UsuarioBLL = new UsuarioBLL();

        public ModificarUsuario(string nombreParaModificar, string contraseñaParaModificar, string claveRecuperacionParaModificar, int usuarioIntentosParaModificar, int usuarioActivoParaModificar)
        {
            InitializeComponent();


            


            textBoxNombreUsuario.Text = nombreParaModificar;
            textBoxNombreUsuario.Enabled = false;

            textBoxContraseñaUsuario.Text = contraseñaParaModificar;
            textBoxContraseñaUsuario.Enabled = false;

            textBoxContraseñaRecuperacionUsuario.Text = claveRecuperacionParaModificar;
            textBoxContraseñaRecuperacionUsuario.Enabled = false;

            textBoxIntentosUsuario.Text = usuarioIntentosParaModificar.ToString();
            textBoxIntentosUsuario.Enabled = false;

            textBoxEstaActivoUsuario.Text = usuarioActivoParaModificar.ToString();
            textBoxEstaActivoUsuario.Enabled = false;
        }





        private void buttonModificarUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
