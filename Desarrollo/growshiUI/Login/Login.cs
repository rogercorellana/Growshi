using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace growshiUI
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {

        public Login()
        {

            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {



        }



        //LOGICA UI

        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {


            string usuarioLogin = textBoxUsuario.Text;
            string contraseñaLogin = textBoxContraseña.Text;

            BLL.UsuarioBLL.GetInstance.iniciarSesion(usuarioLogin,contraseñaLogin);



        }




    }
}
