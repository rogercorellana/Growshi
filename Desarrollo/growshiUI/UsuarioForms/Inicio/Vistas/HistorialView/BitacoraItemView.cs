using System;
using System.Drawing;
using System.Windows.Forms;
using BE;
using Interfaces.IBE; 

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class BitacoraItemView : UserControl
    {
        public BitacoraItemView()
        {
            InitializeComponent();
        }

        public BitacoraItemView(Bitacora log) : this()
        {
            CargarDatos(log);
        }

        private void CargarDatos(Bitacora log)
        {
            lblHora.Text = log.FechaHora.ToString("HH:mm");
            lblFecha.Text = log.FechaHora.ToString("dd/MM");
            lblMensaje.Text = log.Mensaje;
            lblModulo.Text = log.Modulo?.ToUpper();

           
            switch (log.Nivel)
            {
                case NivelCriticidad.Error:
                    pnlIndicador.BackColor = Color.Crimson; 
                    break;
                case NivelCriticidad.Advertencia:
                    pnlIndicador.BackColor = Color.Orange;  
                    break;
                default:
                    pnlIndicador.BackColor = Color.FromArgb(0, 174, 219); 
                    break;
            }
        }
    }
}