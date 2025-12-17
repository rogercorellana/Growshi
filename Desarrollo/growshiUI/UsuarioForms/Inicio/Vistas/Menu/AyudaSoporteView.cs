using System;
using System.Windows.Forms;
using BE;
using BLL;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
using MetroFramework;
using MetroFramework.Controls;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class AyudaSoporteView : UserControl
    {
        #region Propiedades y Servicios

        private readonly IdiomaBLL _idiomaBLL;
        private readonly BitacoraBLL _bitacoraBLL;
        private readonly ISessionService<Usuario> _sessionService;
        private readonly IBitacoraService _bitacoraService;
        private readonly Usuario _usuarioActual;

        #endregion

        #region Constructor

        public AyudaSoporteView()
        {
            InitializeComponent();

            // Instancias de Capas de Negocio y Servicios
            _idiomaBLL = new IdiomaBLL();
            _bitacoraBLL = new BitacoraBLL();
            _sessionService = SessionService<Usuario>.GetInstance();
            _bitacoraService = BitacoraService.GetInstance();

            _usuarioActual = _sessionService.UsuarioLogueado;

            // Suscripción al evento de cambio de idioma
            IdiomaService.GetInstance().IdiomaCambiado += ActualizarTraducciones;

            // Carga inicial
            CargarLegales();
            ActualizarTraducciones();
        }

        #endregion

        #region Métodos de Idioma y Textos

        public void ActualizarTraducciones()
        {
            // --- PESTAÑAS (Tabs) ---
            tabContacto.Text = _idiomaBLL.Traducir("AyudaSoporte_Tab_CanalesContacto");
            tabTicket.Text = _idiomaBLL.Traducir("AyudaSoporte_Tab_EnviarTicket");
            tabLegales.Text = _idiomaBLL.Traducir("AyudaSoporte_Tab_Legales");

            // --- SECCIÓN: CONTACTO ---
            lblTituloContacto.Text = _idiomaBLL.Traducir("AyudaSoporte_Lbl_TituloContacto");
            lblTelSoporte.Text = _idiomaBLL.Traducir("AyudaSoporte_Lbl_TelSoporte");
            lblTelVentas.Text = _idiomaBLL.Traducir("AyudaSoporte_Lbl_TelVentas");
            lblEmailTitle.Text = _idiomaBLL.Traducir("AyudaSoporte_Lbl_Email");
            lblWhatsAppTitle.Text = _idiomaBLL.Traducir("AyudaSoporte_Lbl_WhatsApp");

            // --- SECCIÓN: TICKET ---
            lblTituloTicket.Text = _idiomaBLL.Traducir("AyudaSoporte_Lbl_TituloFormulario");
            lblAsunto.Text = _idiomaBLL.Traducir("AyudaSoporte_Lbl_Asunto");
            lblMensaje.Text = _idiomaBLL.Traducir("AyudaSoporte_Lbl_Mensaje");
            btnEnviarTicket.Text = _idiomaBLL.Traducir("AyudaSoporte_Btn_EnviarConsulta");
            txtMensaje.WaterMark = _idiomaBLL.Traducir("AyudaSoporte_Txt_PlaceholderMensaje");

            // --- SECCIÓN: LEGALES ---
            lblEmpresa.Text = "Growshi S.A.S."; // Marca (No se traduce)
            lblVersion.Text = $"{_idiomaBLL.Traducir("AyudaSoporte_Lbl_Version")}: 1.0";
        }

        private void CargarLegales()
        {
            // Texto largo legal
            txtLegales.Text = _idiomaBLL.Traducir("AyudaSoporte_Txt_TerminosLegales");
        }

        #endregion

        #region Lógica del Ticket (Bitácora)

        private void btnEnviarTicket_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (cmbAsunto.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtMensaje.Text))
            {
                MetroMessageBox.Show(this,
                    _idiomaBLL.Traducir("Global_Msg_CamposObligatorios"), // Usamos 'Global' para mensajes reusables
                    _idiomaBLL.Traducir("Global_Titulo_Atencion"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string asunto = cmbAsunto.SelectedItem.ToString();

                // 1. Crear el evento (Lógica del Servicio)
                IBitacora evento = _bitacoraService.CrearEvento(
                    NivelCriticidad.Info,
                    $"Ticket Generado | Asunto: {asunto}",
                    "Soporte",
                    _usuarioActual.IdUsuario
                );

                // 2. Mapear a Entidad BE
                var bitacoraParaGuardar = new Bitacora
                {
                    FechaHora = evento.FechaHora,
                    Nivel = evento.Nivel,
                    Mensaje = evento.Mensaje,
                    Modulo = evento.Modulo,
                    UsuarioID = evento.UsuarioID
                };

                // 3. Persistir usando la BLL
                _bitacoraBLL.Registrar(bitacoraParaGuardar);

                // Feedback
                MetroMessageBox.Show(this,
                    _idiomaBLL.Traducir("AyudaSoporte_Msg_TicketExito"),
                    _idiomaBLL.Traducir("Global_Titulo_Exito"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            cmbAsunto.SelectedIndex = -1;
            txtMensaje.Text = string.Empty;
        }

        #endregion
    }
}