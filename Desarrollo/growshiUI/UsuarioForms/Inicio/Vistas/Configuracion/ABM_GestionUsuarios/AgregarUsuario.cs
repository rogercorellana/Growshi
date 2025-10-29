using BLL;
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

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_GestionUsuarios
{
    public partial class AgregarUsuario : UserControl
    {
        GestionUsuariosBLL GestionUsuariosBLL = new GestionUsuariosBLL();

        public AgregarUsuario()
        {
            InitializeComponent();
        }


        private void CargarVista(UserControl vista)
        {
            this.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.Controls.Add(vista);
        }


        #region AGREGAR FAMILIA

        private void buttonAgregarUsuario_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBoxNombreUsuario.Text.Trim();
            string contraseñaUsuario = textBoxContraseñaUsuario.Text.Trim();
            string contraseñaRespaldo = textBoxContraseñaRespaldoUsuario.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contraseñaUsuario) || string.IsNullOrWhiteSpace(contraseñaRespaldo))
            {
                MessageBox.Show("Debe completar todos los campos (Nombre, Contraseña, Contraseña respaldo).",
                                "Campos Vacíos",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            try
            {

                GestionUsuariosBLL.CrearUsuario(nombreUsuario, contraseñaUsuario, contraseñaRespaldo);


                string mensaje = "¡Usuario creado correctamente!\n\n" +
                                 "¿Desea seguir creando usuarios?";

                DialogResult resultado = MessageBox.Show(
                    mensaje,
                    "Éxito",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    textBoxNombreUsuario.Text = "";
                    textBoxContraseñaUsuario.Text = "";
                    textBoxContraseñaRespaldoUsuario.Text = "";
                    textBoxNombreUsuario.Focus();
                }
                else
                {

                    CargarVista(new GestionUsuariosView());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al crear el Usuario: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        #endregion


    }
}
