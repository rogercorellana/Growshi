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
using MetroFramework;
using MetroFramework.Forms;
using BE;
using BLL;
using growshiUI.UsuarioForms;
using System.Data.SqlClient;

namespace growshiUI
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {


        private readonly UsuarioBLL usuarioBLL;
        public Usuario UsuarioLogueado { get; private set; }
        public Login()
        {

            InitializeComponent();
            usuarioBLL = new UsuarioBLL();
        }

        private void Login_Load(object sender, EventArgs e)
        {



        }




        //LOGICA UI

        #region INICIARSESION




        public int IntentosLoginContador = 0;

        private void buttonIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuarioLogin = textBoxUsuario.Text;
            string contraseñaLogin = textBoxContraseña.Text;

            try
            {
                //hago una sola llamada a la BLL
                UsuarioLogueado = usuarioBLL.Login(usuarioLogin, contraseñaLogin);

                if (UsuarioLogueado != null)
                {
                    MessageBox.Show($"¡Bienvenido, {UsuarioLogueado.NombreUsuario}!", "Login Exitoso");
                    this.DialogResult = DialogResult.OK;

                    this.Hide();

                    InicioUsuario inicioUsuario = new InicioUsuario(UsuarioLogueado);
                    inicioUsuario.ShowDialog();

                    this.Close();
                }
                else
                {
                    //usuario no existe en la DB, o Contraseña incorrecta
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Sesión");
                }
            }
            catch (CuentaBloqueadaException ex)
            {

                MessageBox.Show(ex.Message, "Cuenta Bloqueada");
                BloquearForm(); 
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Datos Inválidos");
            }
            catch (SqlException ex) {  
                MessageBox.Show($"Error de conexión con la base de datos. Por favor, contacte al administrador. \n\nDetalle técnico: {ex.Message}", "Error de Conexión");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error en el sistema: {ex.Message}", "Error Inesperado");
            }
        }


        private int segundosRestantes;

        public void BloquearForm() {
            segundosRestantes = 5;

            textBoxUsuario.Enabled = false;
            textBoxContraseña.Enabled = false;
            buttonIniciarSesion.Enabled = false;
           

            progressBar.Visible = true;
            progressBar.Maximum = 5;      
            progressBar.Value = 5;

            temporizadorBloqueo.Start();
        }

        private void temporizadorBloqueo_Tick(object sender, EventArgs e)
        {
            segundosRestantes--;
            progressBar.Value = segundosRestantes;

            if(segundosRestantes <= 0)
            {
                temporizadorBloqueo.Stop();

                textBoxUsuario.Enabled = true;
                textBoxContraseña.Enabled = true;
                buttonIniciarSesion.Enabled = true;

                progressBar.Visible = false;
            }

            

        }

        #endregion

    }
}