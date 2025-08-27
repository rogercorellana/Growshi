using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using growshiUI.Usuario;
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

        public int IntentosLoginContador = 0;

        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {

            //Validacion superficial de los textbox

            if(textBoxUsuario.Text.Trim().Length == 0 || textBoxContraseña.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, revise los campos marcados");

            }
            else
            {
                //organizando variables

                string usuarioLogin = textBoxUsuario.Text;
                string contraseñaLogin = textBoxContraseña.Text;
                bool iniciarSesion = BLL.UsuarioBLL.GetInstance.iniciarSesion(usuarioLogin, contraseñaLogin);

                //eventos posibles

                if (iniciarSesion && IntentosLoginContador < 4)
                {
                    MessageBox.Show("Sesion Iniciada Correctamente");

                    IntentosLoginContador = 0;
                    this.Hide();


                    InicioUsuario inicioUsuario = new InicioUsuario();
                    inicioUsuario.ShowDialog();

                    this.Close();
                } else
                {
                    
                    IntentosLoginContador += 1;
                    MessageBox.Show("Por favor, revise los campos marcados ");


                }

            }





        }


    }
}
