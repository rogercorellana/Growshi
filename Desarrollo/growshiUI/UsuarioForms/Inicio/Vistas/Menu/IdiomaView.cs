using System;
using System.Drawing;
using System.Windows.Forms;
using BE;
using BLL;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
using MetroFramework;
using MetroFramework.Controls;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    public partial class IdiomaView : UserControl
    {
        #region Propiedades y Servicios

        private readonly IdiomaBLL _idiomaBLL;
        private readonly BitacoraBLL _bitacoraBLL; // <--- Agregamos la BLL de Bitácora
        private readonly ISessionService<Usuario> _sessionService;
        private readonly IBitacoraService _bitacoraService; // <--- Agregamos el Service
        private readonly Usuario _usuarioActual;

        // Colores para efectos visuales
        private readonly Color ColorNormal = Color.White;
        private readonly Color ColorHover = Color.FromArgb(235, 255, 235);
        private readonly Color ColorDeshabilitado = Color.WhiteSmoke;
        private readonly Color ColorBordeNormal = Color.Silver;
        private readonly Color ColorBordeHover = Color.FromArgb(76, 175, 80);

        #endregion

        #region Constructor e Inicialización

        public IdiomaView()
        {
            InitializeComponent();

            // 1. Instanciar Servicios y BLLs
            _idiomaBLL = new IdiomaBLL();
            _bitacoraBLL = new BitacoraBLL(); // <--- Instancia
            _sessionService = SessionService<Usuario>.GetInstance();
            _bitacoraService = BitacoraService.GetInstance(); // <--- Singleton

            _usuarioActual = _sessionService.UsuarioLogueado;

            // 2. Suscribirse a eventos
            IdiomaService.GetInstance().IdiomaCambiado += ActualizarTraducciones;

            // 3. Configuración inicial
            ConfigurarEventosHover();
            ActualizarTraducciones();
        }

        #endregion

        #region Gestión de Idioma y Bitácora

        public void ActualizarTraducciones()
        {
            lblTitulo.Text = _idiomaBLL.Traducir("Idioma_Lbl_TituloSeleccion");
            lblEspanol.Text = _idiomaBLL.Traducir("Idioma_Lbl_Espanol");
            lblIngles.Text = _idiomaBLL.Traducir("Idioma_Lbl_Ingles");
            lblProximo.Text = _idiomaBLL.Traducir("Idioma_Lbl_Proximamente");
            lblConstruction.Text = _idiomaBLL.Traducir("Idioma_Lbl_EnConstruccion");
        }

        private void CambiarIdioma(int idIdioma)
        {
            try
            {
                // Si ya tiene ese idioma, no hacemos nada
                if (_usuarioActual.IdiomaPreferidoID == idIdioma) return;

                // 1. Cambiar el idioma
                _idiomaBLL.CambiarIdioma(idIdioma, _usuarioActual);

                // 2. Registrar en Bitácora (El objetivo que faltaba)
                string nombreIdioma = idIdioma == 1 ? "Español" : "Inglés";

                // a) Crear el evento usando el Service
                IBitacora evento = _bitacoraService.CrearEvento(
                    NivelCriticidad.Info,
                    $"El usuario cambió el idioma a {nombreIdioma}",
                    "Configuración",
                    _usuarioActual.IdUsuario
                );

                // b) Mapear a entidad BE
                var bitacoraParaGuardar = new Bitacora
                {
                    FechaHora = evento.FechaHora,
                    Nivel = evento.Nivel,
                    Mensaje = evento.Mensaje,
                    Modulo = evento.Modulo,
                    UsuarioID = evento.UsuarioID
                };

                // c) Guardar usando la BLL
                _bitacoraBLL.Registrar(bitacoraParaGuardar);

                // 3. Feedback al usuario
                MetroMessageBox.Show(this,
                    _idiomaBLL.Traducir("Idioma_Msg_CambioExito"),
                    _idiomaBLL.Traducir("Global_Titulo_Exito"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message,
                    _idiomaBLL.Traducir("Global_Titulo_Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos de Selección (Clicks)

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
            MetroMessageBox.Show(this,
                _idiomaBLL.Traducir("Idioma_Msg_NoDisponible"),
                _idiomaBLL.Traducir("Global_Titulo_Construccion"),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Efectos Visuales (Hover & Paint)

        private void ConfigurarEventosHover()
        {
            VincularEventosTarjeta(cardEspanol, picEspanol, lblEspanol, SeleccionarEspanol);
            VincularEventosTarjeta(cardIngles, picIngles, lblIngles, SeleccionarIngles);
            VincularEventosTarjeta(cardProximo, picProximo, lblProximo, SeleccionarProximo);

            lblConstruction.Click += SeleccionarProximo;
            lblConstruction.MouseEnter += (s, e) => PintarHover(cardProximo, true);
            lblConstruction.MouseLeave += (s, e) => PintarHover(cardProximo, false);

            cardEspanol.Paint += Card_Paint;
            cardIngles.Paint += Card_Paint;
            cardProximo.Paint += Card_Paint;
        }

        private void VincularEventosTarjeta(Panel panel, Control pic, Control lbl, EventHandler clickAction)
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

            panel.Invalidate();
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            if (p == null) return;

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