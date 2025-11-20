using System;
using System.Drawing;
using System.Windows.Forms;
using BE;
using Interfaces.IBE; // Asegúrate de importar donde está tu enum NivelCriticidad

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class BitacoraItemView : UserControl
    {
        // Constructor vacío para el Diseñador de VS
        public BitacoraItemView()
        {
            InitializeComponent();
        }

        // Constructor principal que recibe los datos
        public BitacoraItemView(Bitacora log) : this()
        {
            CargarDatos(log);
        }

        private void CargarDatos(Bitacora log)
        {
            // 1. Asignar textos
            lblHora.Text = log.FechaHora.ToString("HH:mm");
            lblFecha.Text = log.FechaHora.ToString("dd/MM");
            lblMensaje.Text = log.Mensaje;
            lblModulo.Text = log.Modulo?.ToUpper();

            // 2. Lógica de colores según la gravedad del evento
            // (Ajusta los 'case' según los nombres reales de tu Enum)
            switch (log.Nivel)
            {
                case NivelCriticidad.Error:
                    pnlIndicador.BackColor = Color.Crimson; // Rojo
                    break;
                case NivelCriticidad.Advertencia:
                    pnlIndicador.BackColor = Color.Orange;  // Naranja
                    break;
                default:
                    pnlIndicador.BackColor = Color.FromArgb(0, 174, 219); // Azul (Info)
                    break;
            }
        }
    }
}