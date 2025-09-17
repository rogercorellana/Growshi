using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio
{
    public partial class InicioView : UserControl
    {
        public InicioView()
        {
            InitializeComponent();
        }

        private void tileGestionarCultivos_Click(object sender, EventArgs e)
        {
            // Aquí irá la lógica para cambiar a la vista de "Mis Cultivos"
            MessageBox.Show("¡Cambiando a la pantalla de gestión de cultivos!");
            // Por ahora, un mensaje es suficiente para probar que funciona.
        }

        private void tileGestionarCultivos_MouseEnter(object sender, EventArgs e)
        {
            // Cambia el color de fondo cuando el mouse está encima
            this.tileGestionarCultivos.BackColor = Color.LightGray;
        }

        private void tileGestionarCultivos_MouseLeave(object sender, EventArgs e)
        {
            // Vuelve al color original cuando el mouse se va
            this.tileGestionarCultivos.BackColor = SystemColors.ControlLight;
        }
    }
}

