using System.Globalization;
using System.Windows.Forms;
using BE;
using Interfaces.IBE;
using MetroFramework;

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

            // Usamos CultureInfo.CurrentCulture para que "OCT" salga en el idioma de la app si está configurado
            lblFecha.Text = log.FechaHora.ToString("dd MMM", CultureInfo.CurrentCulture).ToUpper();

            lblMensaje.Text = log.Mensaje;
            lblModulo.Text = log.Modulo?.ToUpper() ?? "SISTEMA";

            // Colores por Criticidad
            switch (log.Nivel)
            {
                case NivelCriticidad.Error:
                case NivelCriticidad.Critico: // Agregamos Crítico al rojo también
                    pnlIndicador.BackColor = MetroColors.Red;
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