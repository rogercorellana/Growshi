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
            this.ActiveControl = null;
        }

        private void Login_Load(object sender, EventArgs e)
        {

          

            textBoxUsuario.PromptText = "Usuario o Email";
            textBoxContraseña.PromptText = "Contraseña";
            textBoxUsuario.Text = null;
            textBoxContraseña.Text = null;

            // 3. Quitamos el foco inicial.
            this.ActiveControl = null;



        }


    }
}
