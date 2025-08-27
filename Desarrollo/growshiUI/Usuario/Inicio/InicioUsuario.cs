using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace growshiUI.Usuario
{
    public partial class InicioUsuario : Form
    {
        public InicioUsuario()
        {
            InitializeComponent();
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
    }
}
