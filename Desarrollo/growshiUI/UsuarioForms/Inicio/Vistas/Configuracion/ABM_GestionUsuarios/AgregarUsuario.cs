using BLL;
using BLL.InicioUsuarioBLL;
using System;
using System.Windows.Forms;
using MetroFramework;
using Services; 

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_GestionUsuarios
{
    public partial class AgregarUsuario : UserControl
    {
        GestionUsuariosBLL GestionUsuariosBLL = new GestionUsuariosBLL();
        EncriptacionService EncriptacionService = new EncriptacionService();

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

        #region AGREGAR USUARIO

        private void buttonAgregarUsuario_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text.Trim();
            string contraseñaUsuario = txtContraseñaUsuario.Text.Trim();
            string contraseñaRespaldo = txtContraseñaRespaldo.Text.Trim();

            string contraseñaHasheada = EncriptacionService.Hashear(contraseñaUsuario);


            // 1. Validación visual
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contraseñaUsuario) || string.IsNullOrWhiteSpace(contraseñaRespaldo))
            {
                MetroMessageBox.Show(this, "Por favor complete todos los campos requeridos.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Llamada a BLL
                GestionUsuariosBLL.CrearUsuario(nombreUsuario, contraseñaHasheada, contraseñaRespaldo);

                // 3. Confirmación y flujo
                string mensaje = "¡Usuario creado correctamente!\n\n¿Desea seguir creando usuarios?";

                DialogResult resultado = MetroMessageBox.Show(this, mensaje, "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Limpiar campos para el siguiente
                    txtNombreUsuario.Text = "";
                    txtContraseñaUsuario.Text = "";
                    txtContraseñaRespaldo.Text = "";
                    txtNombreUsuario.Focus();
                }
                else
                {
                    // Volver a la lista
                    CargarVista(new GestionUsuariosView());
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"Ocurrió un error al crear el Usuario:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Botón extra para volver atrás sin guardar
            CargarVista(new GestionUsuariosView());
        }

        #endregion
    }
}