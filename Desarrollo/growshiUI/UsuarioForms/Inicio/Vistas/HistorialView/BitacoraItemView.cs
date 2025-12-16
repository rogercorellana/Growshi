using BE;
using Interfaces.IBE;
using MetroFramework; // Importante
using System;
using System.Drawing;
using System.Windows.Forms;

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
            lblFecha.Text = log.FechaHora.ToString("dd MMM").ToUpper();
            lblMensaje.Text = log.Mensaje;
            lblModulo.Text = log.Modulo?.ToUpper() ?? "SISTEMA";

            // Colores estilo Metro
            switch (log.Nivel)
            {
                case NivelCriticidad.Error:
                    pnlIndicador.BackColor = MetroColors.Red; // Usando paleta Metro
                    lblModulo.ForeColor = MetroColors.Red;
                    break;
                case NivelCriticidad.Advertencia:
                    pnlIndicador.BackColor = MetroColors.Orange;
                    lblModulo.ForeColor = MetroColors.Orange;
                    break;
                default:
                    pnlIndicador.BackColor = MetroColors.Blue;
                    lblModulo.ForeColor = MetroColors.Blue;
                    break;
            }
        }
    }
}