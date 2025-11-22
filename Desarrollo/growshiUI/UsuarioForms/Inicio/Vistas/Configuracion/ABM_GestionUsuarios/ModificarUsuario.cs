using BLL;
using BLL.InicioUsuarioBLL;
using System;
using System.Windows.Forms;
using MetroFramework;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_GestionUsuarios
{
    public partial class ModificarUsuario : UserControl
    {
        GestionUsuariosBLL gestionUsuariosBLL = new GestionUsuariosBLL();
        private string _nombreUsuarioOriginal;

        public ModificarUsuario(string nombre, string pass, string claveRecuperacion, int intentos, int activo)
        {
            InitializeComponent();

            _nombreUsuarioOriginal = nombre;

            // Cargar datos
            txtNombre.Text = nombre;
            txtPass.Text = pass;
            txtRespaldo.Text = claveRecuperacion;
            txtIntentos.Text = intentos.ToString();

            // Activo: 1 = True, 0 = False
            toggleActivo.Checked = (activo == 1);
        }

        private void CargarVista(UserControl vista)
        {
            this.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.Controls.Add(vista);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MetroMessageBox.Show(this, "El nombre y la contraseña son obligatorios.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nuevoNombre = txtNombre.Text.Trim();
                string nuevaPass = txtPass.Text.Trim();
                string nuevaRespaldo = txtRespaldo.Text.Trim();

                int nuevosIntentos = 0;
                int.TryParse(txtIntentos.Text, out nuevosIntentos);

                int nuevoActivo = toggleActivo.Checked ? 1 : 0;

                // TODO: Aquí llamarías a gestionUsuariosBLL.ModificarUsuario(...)
                // gestionUsuariosBLL.ActualizarUsuario(_nombreUsuarioOriginal, nuevoNombre, nuevaPass, nuevaRespaldo, nuevosIntentos, nuevoActivo);

                MetroMessageBox.Show(this, "Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Volver al listado
                CargarVista(new GestionUsuariosView());
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"Error al guardar cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarVista(new GestionUsuariosView());
        }
    }
}