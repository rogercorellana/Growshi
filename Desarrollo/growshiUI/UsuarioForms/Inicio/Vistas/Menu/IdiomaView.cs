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

        private readonly Color ColorNormal = Color.White;
        private readonly Color ColorHover = Color.FromArgb(235, 255, 235);
        private readonly Color ColorDeshabilitado = Color.WhiteSmoke;
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
            lblProximo.Text = _idiomaBLL.Traducir("label_proximamente");
            lblConstruction.Text = _idiomaBLL.Traducir("label_espacio_reservado");
        }

        // --- ACCIONES ---

        private void SeleccionarEspanol(object sender, EventArgs e)
        {
            CambiarIdioma(1); // 1 = Español
        }

        private void SeleccionarIngles(object sender, EventArgs e)
        {
            CambiarIdioma(2); // 2 = Inglés
        }

        private void SeleccionarProximo(object sender, EventArgs e)
        {
            string mensaje = _idiomaBLL.Traducir("msg_idioma_no_disponible");
            string titulo = _idiomaBLL.Traducir("titulo_construccion");

            MetroMessageBox.Show(this, mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CambiarIdioma(int idIdioma)
        {
            try
            {
                _idiomaBLL.CambiarIdioma(idIdioma, _usuarioActual);

                // 2. Obtener mensajes traducidos del nuevo idioma elegido
                string mensaje = _idiomaBLL.Traducir("msg_idioma_cambiado");
                string titulo = _idiomaBLL.Traducir("titulo_exito");

                MetroMessageBox.Show(this, mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string tituloError = _idiomaBLL.Traducir("titulo_error");
                MetroMessageBox.Show(this, ex.Message, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region // --- EFECTOS VISUALES (HOVER) ---

        private void ConfigurarEventosHover()
        {
            AsignarEventos(cardEspanol, picEspanol, lblEspanol, SeleccionarEspanol);
            AsignarEventos(cardIngles, picIngles, lblIngles, SeleccionarIngles);

            // Tarjeta Próximamente
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
            if (panel == cardProximo)
                panel.BackColor = entrando ? Color.FromArgb(245, 245, 245) : ColorDeshabilitado;
            else
                panel.BackColor = entrando ? ColorHover : ColorNormal;
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
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