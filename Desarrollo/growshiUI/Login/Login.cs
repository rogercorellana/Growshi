using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        #region INICIARSESION
        public int IntentosLoginContador = 0;


        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {

            //organizando variables

            string usuarioLogin = textBoxUsuario.Text;
            string contraseñaLogin = textBoxContraseña.Text;
            bool iniciarSesion = BLL.UsuarioBLL.GetInstance.iniciarSesion(usuarioLogin, contraseñaLogin);
            bool existeUsuario = BLL.UsuarioBLL.GetInstance.traerUsuarioDeLaDB(usuarioLogin, contraseñaLogin);

            //Validacion superficial de los textbox

            if (usuarioLogin.Trim().Length == 0 || contraseñaLogin.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, revise los campos marcados");
                IntentosLoginContador += 1;

                if(IntentosLoginContador < 4)
                {

                }
                else
                {
                    BloquearForm();
                }

            }
            else
            {


                //eventos posibles

                //Usuario existe en la DB?
                if (existeUsuario)
                {


                    //aca existeUsuario deberia traerme un objeto usuario cargado. 
                    //aca setear intentosLoginContador con los intentos de la DB

                    //IntentosLoginContador < 4
                    if (IntentosLoginContador < 4)
                    {
                        //Iniciar Sesion
                        if(iniciarSesion)
                        {


                            IntentosLoginContador = 0;
                            //igualar estos intentos y mandar a la DB en 0


                            MessageBox.Show("Sesion Iniciada Correctamente");

                            this.Hide();

                            InicioUsuario inicioUsuario = new InicioUsuario();
                            inicioUsuario.ShowDialog();

                            this.Close();

                        }
                        else
                        {
                            IntentosLoginContador += 1;
                            //igualar estos intentos y mandar a la DB
                            contraseñaLogin = "";

                            if(IntentosLoginContador > 3)
                            {
                                BloquearForm();
                                MessageBox.Show("Tu cuenta se encuentra bloqueada, por favor comunicarse con atencion al cliente");
                            }
                        }
                    }
                    else
                    {
                        BloquearForm();
                    }
                }
                else
                {
                    //Caso usuario no existe en la DB
                    IntentosLoginContador += 1;

                    if (IntentosLoginContador < 4)
                    {
                        ///vuelve al flujo inicial
                    }
                    else
                    {
                        BloquearForm();
                    }
                }

                

               
            }


           





        }

        //Bloquear textboxs, iniciar temporizador bloqueo
        public void BloquearForm() {
            textBoxUsuario.Enabled = false;
            textBoxContraseña.Enabled = false;
            buttonIniciarSesion.Enabled = false;

            MessageBox.Show("Cuenta bloqueada por favor vuelve a intentarlo mas tarde");
        }


        #endregion
    }
}