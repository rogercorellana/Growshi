using BE;
using BLL;
using Interfaces.IServices;
using Services;
using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    public partial class IdiomaView : UserControl
    {
        private readonly IdiomaBLL _idiomaBLL;
        private readonly ISessionService<Usuario> _sessionService;
        private readonly Usuario _usuarioActual;

        // Colores
        private readonly Color ColorNormal = Color.White;
        private readonly Color ColorHover = Color.FromArgb(235, 255, 235);
        private readonly Color ColorDeshabilitado = Color.WhiteSmoke; // Para la tarjeta "Próximamente"
        private readonly Color ColorBordeNormal = Color.Silver;
        private readonly Color ColorBordeHover = Color.FromArgb(76, 175, 80);

        public IdiomaView()
        {
            InitializeComponent();

            _idiomaBLL = new IdiomaBLL();
            _sessionService = SessionService<Usuario>.GetInstance();
            _usuarioActual = _sessionService.UsuarioLogueado;

            _idiomaBLL.CargarIdiomaInicial(this._usuarioActual);
            IdiomaService.GetInstance().IdiomaCambiado += ActualizarTraducciones;

            ActualizarTraducciones();
            ConfigurarEventosHover();
        }

        public void ActualizarTraducciones()
        {
            lblTitulo.Text = _idiomaBLL.Traducir("label_seleccioneUnIdioma");
            lblEspanol.Text = _idiomaBLL.Traducir("label_español");
            lblIngles.Text = _idiomaBLL.Traducir("label_ingles");
            // La tercera tarjeta tiene texto fijo "Próximamente" o se podría traducir también
        }

        // --- ACCIONES ---

        private void SeleccionarEspanol(object sender, EventArgs e)
        {
            CambiarIdioma(1);
        }

        private void SeleccionarIngles(object sender, EventArgs e)
        {
            CambiarIdioma(2);
        }

        private void SeleccionarProximo(object sender, EventArgs e)
        {
            MetroMessageBox.Show(this, "Este idioma estará disponible en futuras actualizaciones de Growshi.", "En Construcción", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CambiarIdioma(int idIdioma)
        {
            try
            {
                _idiomaBLL.CambiarIdioma(idIdioma, _usuarioActual);
                string mensaje = idIdioma == 1 ? "Idioma cambiado a Español" : "Language changed to English";
                MetroMessageBox.Show(this, mensaje, "Growshi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region // --- EFECTOS VISUALES (HOVER) ---

        private void ConfigurarEventosHover()
        {
            AsignarEventos(cardEspanol, picEspanol, lblEspanol, SeleccionarEspanol);
            AsignarEventos(cardIngles, picIngles, lblIngles, SeleccionarIngles);

            // Tarjeta Próximamente (También tiene efecto hover para que se sienta táctil)
            AsignarEventos(cardProximo, picProximo, lblProximo, SeleccionarProximo);
            // Agregamos el label extra de "En construcción" a los eventos
            lblConstruction.Click += SeleccionarProximo;
            lblConstruction.MouseEnter += (s, e) => PintarHover(cardProximo, true);
            lblConstruction.MouseLeave += (s, e) => PintarHover(cardProximo, false);
        }

        private void AsignarEventos(Panel panel, Control pic, Control lbl, EventHandler clickAction)
        {
            panel.Click += clickAction;
            pic.Click += clickAction;
            lbl.Click += clickAction;

            panel.MouseEnter += (s, e) => PintarHover(panel, true);
            pic.MouseEnter += (s, e) => PintarHover(panel, true);
            lbl.MouseEnter += (s, e) => PintarHover(panel, true);

            panel.MouseLeave += (s, e) => PintarHover(panel, false);
            pic.MouseLeave += (s, e) => PintarHover(panel, false);
            lbl.MouseLeave += (s, e) => PintarHover(panel, false);
        }

        private void PintarHover(Panel panel, bool entrando)
        {
            // Si es la tarjeta "Proximo", usamos un color diferente o el mismo
            if (panel == cardProximo)
                panel.BackColor = entrando ? Color.FromArgb(245, 245, 245) : ColorDeshabilitado;
            else
                panel.BackColor = entrando ? ColorHover : ColorNormal;
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            // Detectamos hover por el color de fondo
            bool isHover = (p.BackColor == ColorHover) || (p == cardProximo && p.BackColor == Color.FromArgb(245, 245, 245));

            Color colorBorde = isHover ? ColorBordeHover : ColorBordeNormal;
            int grosor = isHover ? 2 : 1;

            ControlPaint.DrawBorder(e.Graphics, p.ClientRectangle,
                colorBorde, grosor, ButtonBorderStyle.Solid,
                colorBorde, grosor, ButtonBorderStyle.Solid,
                colorBorde, grosor, ButtonBorderStyle.Solid,
                colorBorde, grosor, ButtonBorderStyle.Solid);
        }

        #endregion
    }
}