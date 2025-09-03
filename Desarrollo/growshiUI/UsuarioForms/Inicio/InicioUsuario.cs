using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms
{
    public partial class InicioUsuario : Form
    {

        public Usuario UsuarioActual { get; private set; }

        public InicioUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.UsuarioActual = usuario;

            
            // Podrías tener lógica como:
            // if (this.UsuarioActual.EsAdmin) { botonDeAdmin.Visible = true; }
        }

        private void InicioUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Muestra un cuadro de diálogo con botones de Sí y No, y un ícono de advertencia.
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de que deseas salir? Tu sesión se cerrará.",
                "Confirmar Cierre de Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Comprueba la respuesta del usuario.
            // Si el usuario hace clic en "No"...
            if (resultado == DialogResult.No)
            {
                // ...cancela el evento de cierre.
                e.Cancel = true;
            }

            // Si el usuario hace clic en "Sí", no hacemos nada.
            // El código simplemente continúa y el formulario se cierra normalmente.
        }

        private void InicioUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
