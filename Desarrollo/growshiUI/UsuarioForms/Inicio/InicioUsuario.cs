using BE;
using BLL; // <-- AÑADIR: Para usar la nueva BLL
using Interfaces.IServices;
using Services;
using System;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms
{
    public partial class InicioUsuario : Form
    {
        private readonly ISessionService<Usuario> _sessionService;
        private readonly InicioUsuarioBLL _inicioUsuarioBLL; // <-- AÑADIR: La dependencia a la BLL

        public Usuario UsuarioActual { get; private set; }

        public InicioUsuario()
        {
            InitializeComponent();

            _sessionService = SessionService<Usuario>.GetInstance();
            _inicioUsuarioBLL = new InicioUsuarioBLL(); // <-- AÑADIR: Se crea la instancia de la BLL

            this.UsuarioActual = _sessionService.UsuarioLogueado;

            if (this.UsuarioActual == null)
            {
                MessageBox.Show("No se ha podido recuperar la sesión del usuario...", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Load += (s, e) => Close();
            }
        }

        private void InicioUsuario_Load(object sender, EventArgs e)
        {
            
        }

        private void InicioUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de que deseas salir? Tu sesión se cerrará.",
                "Confirmar Cierre de Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                
                _inicioUsuarioBLL.CerrarSesion(this.UsuarioActual);
            }
        }
    }
}