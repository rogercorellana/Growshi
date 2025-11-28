using BLL;
using BLL.InicioUsuarioBLL;
using Services; 
using System;
using System.Windows.Forms;
using MetroFramework;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_GestionUsuarios
{
    public partial class ModificarUsuario : UserControl
    {
        
        private GestionUsuariosBLL gestionUsuariosBLL = new GestionUsuariosBLL();
        private EncriptacionService encriptacionService = new EncriptacionService();

        private int _usuarioId;
        private string _nombreUsuarioOriginal;
        private string _hashPasswordOriginal;

        public ModificarUsuario(int usuarioid, string nombre, string hashActual, string claveRecuperacion, int intentos, int activo)
        {
            InitializeComponent();

            _usuarioId = usuarioid;
            _nombreUsuarioOriginal = nombre;
            _hashPasswordOriginal = hashActual;

            txtNombre.Text = nombre;

            // SEGURIDAD
            txtPass.Text = "";
            txtPass.WaterMark = "Dejar vacío para mantener actual";
            txtPass.PasswordChar = '●'; 

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

        private void chkVerPass_CheckedChanged(object sender, EventArgs e)
        {
         
            if (chkVerPass.Checked)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '●';
            }
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (metroCheckBoxContraseñaRespaldo.Checked)
            {
                txtRespaldo.PasswordChar = '\0';
            }
            else
            {
                txtRespaldo.PasswordChar = '●';
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MetroMessageBox.Show(this, "El nombre es obligatorio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string nuevoNombre = txtNombre.Text.Trim();
                string nuevaRespaldo = txtRespaldo.Text.Trim();
                int nuevoActivo = toggleActivo.Checked ? 1 : 0;

                int nuevosIntentos = 0;
                int.TryParse(txtIntentos.Text, out nuevosIntentos);

                string passwordFinal;

                if (string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    passwordFinal = _hashPasswordOriginal;
                }
                else
                {
                    passwordFinal = encriptacionService.Hashear(txtPass.Text.Trim());
                }

                gestionUsuariosBLL.ActualizarUsuario(
                    _usuarioId,
                    nuevoNombre,
                    passwordFinal,
                    nuevaRespaldo,
                    nuevosIntentos,
                    nuevoActivo
                );

                MetroMessageBox.Show(this, "Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarVista(new GestionUsuariosView());
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CargarVista(new GestionUsuariosView());
        }

        
    }
}