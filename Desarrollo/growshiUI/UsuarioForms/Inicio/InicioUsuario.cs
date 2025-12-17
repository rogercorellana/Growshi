using System;
using System.Drawing;
using System.Windows.Forms;
using BE;
using BLL;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
using MetroFramework;
using MetroFramework.Forms;
using growshiUI.UsuarioForms.Inicio;
using growshiUI.UsuarioForms.Inicio.Vistas;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion;
using growshiUI.UsuarioForms.Inicio.Vistas.Menu;
using growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanCultivo;

namespace growshiUI.UsuarioForms
{
    public partial class InicioUsuario : MetroForm
    {
        #region Propiedades y Servicios

        private readonly ISessionService<Usuario> _sessionService;
        private readonly InicioUsuarioBL _inicioUsuarioBLL;
        private readonly IPermissionService _permissionService;
        private readonly IdiomaBLL _idiomaBLL;
        private readonly IBitacoraService _bitacoraService;
        private readonly BitacoraBLL _bitacoraBLL;

        public Usuario UsuarioActual { get; private set; }

        #endregion

        #region Constructor e Inicialización

        public InicioUsuario()
        {
            InitializeComponent();

            // 1. Instancias
            _sessionService = SessionService<Usuario>.GetInstance();
            _inicioUsuarioBLL = new InicioUsuarioBL();
            _permissionService = PermissionService.GetInstance();
            _idiomaBLL = new IdiomaBLL();
            _bitacoraService = BitacoraService.GetInstance();
            _bitacoraBLL = new BitacoraBLL();

            // 2. Validar Sesión
            this.UsuarioActual = _sessionService.UsuarioLogueado;

            if (this.UsuarioActual == null)
            {
                MetroMessageBox.Show(this, "No se ha podido recuperar la sesión del usuario...", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Load += (s, e) => Close();
            }
        }

        private void InicioUsuario_Load(object sender, EventArgs e)
        {
            if (UsuarioActual != null)
            {
                _idiomaBLL.CargarIdiomaInicial(this.UsuarioActual);
                IdiomaService.GetInstance().IdiomaCambiado += ActualizarTextos;

                ActualizarTextos();
                AplicarPermisos();

                MostrarVistaInicio();
            }
        }

        #endregion

        #region Gestión de Idioma (Observer)

        private void ActualizarTextos()
        {
            // Título Principal
            this.Text = _idiomaBLL.Traducir("Main_Titulo_App") ?? "Growshi Dashboard";

            // Ítems Estándar
            MenuStrip_inicioMenuItem.Text = _idiomaBLL.Traducir("Main_Menu_Inicio");
            MenuStrip_misCultivosMenuItem.Text = _idiomaBLL.Traducir("Main_Menu_MisCultivos");
            MenuStrip_historialMenuItem.Text = _idiomaBLL.Traducir("Main_Menu_Historial");
            MenuStrip_reportesMenuItem.Text = _idiomaBLL.Traducir("Main_Menu_Reportes");
            MenuStrip_configuracionMenuItem.Text = _idiomaBLL.Traducir("Main_Menu_Configuracion");
            MenuStrip_miCuentaMenuItem.Text = _idiomaBLL.Traducir("Main_Menu_Soporte");
            MenuStrip_idiomaMenuItem.Text = _idiomaBLL.Traducir("Main_Menu_Idioma");

            // --- TUS ÍTEMS RECUPERADOS ---
            planesDeCultivoToolStripMenuItem.Text = _idiomaBLL.Traducir("Main_Menu_Planes");
            configuracionDeSensorToolStripMenuItem.Text = _idiomaBLL.Traducir("Main_Menu_Sensores");

            this.Refresh();
        }

        #endregion

        #region Gestión de Permisos (Composite)

        private void AplicarPermisos()
        {
            // Verificamos permisos estándar
            VerificarPermiso(MenuStrip_inicioMenuItem, "MenuStrip_inicioMenuItem");
            VerificarPermiso(MenuStrip_misCultivosMenuItem, "MenuStrip_misCultivosMenuItem");
            VerificarPermiso(MenuStrip_historialMenuItem, "MenuStrip_historialMenuItem");
            VerificarPermiso(MenuStrip_reportesMenuItem, "MenuStrip_reportesMenuItem");
            VerificarPermiso(MenuStrip_configuracionMenuItem, "MenuStrip_configuracionMenuItem");
            VerificarPermiso(MenuStrip_miCuentaMenuItem, "MenuStrip_miCuentaMenuItem");

            // --- IMPORTANTE: Dejamos estos visibles por defecto para que no se te pierdan ---
            // Cuando crees los permisos en BD, descomenta las líneas de abajo:

            //planesDeCultivoToolStripMenuItem.Visible = true;
            VerificarPermiso(planesDeCultivoToolStripMenuItem, "MenuStrip_planesMenuItem");

            //configuracionDeSensorToolStripMenuItem.Visible = true;
            VerificarPermiso(configuracionDeSensorToolStripMenuItem, "MenuStrip_sensoresMenuItem");
        }

        private void VerificarPermiso(ToolStripItem item, string permisoKey)
        {
            if (item != null)
            {
                // Si el usuario tiene el permiso, se muestra. Si no, se oculta.
                item.Visible = _permissionService.TienePermiso(this.UsuarioActual, permisoKey);
            }
        }

        #endregion

        #region Navegación y Vistas

        private void CargarVista(UserControl vista)
        {
            this.panelInicio.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.panelInicio.Controls.Add(vista);
        }

        private void ResaltarBotonMenu(ToolStripMenuItem botonSeleccionado)
        {
            foreach (ToolStripItem item in menuStripGlobal.Items)
            {
                if (item is ToolStripMenuItem boton)
                {
                    boton.BackColor = Color.White;
                    boton.ForeColor = Color.FromArgb(64, 64, 64);
                }
            }

            if (botonSeleccionado != null)
            {
                botonSeleccionado.BackColor = Color.FromArgb(230, 255, 230);
                botonSeleccionado.ForeColor = Color.FromArgb(76, 175, 80);
            }
        }

        // --- MÉTODOS DE NAVEGACIÓN ---

        private void MostrarVistaInicio()
        {
            ResaltarBotonMenu(MenuStrip_inicioMenuItem);
            CargarVista(new InicioView());
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e) => MostrarVistaInicio();

        private void MenuStrip_misCultivosMenuItem_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu((ToolStripMenuItem)sender);
            CargarVista(new MisCultivosView());
        }

        private void MenuStrip_historialMenuItem_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu((ToolStripMenuItem)sender);
            CargarVista(new HistorialView());
        }

        private void MenuStrip_reportesMenuItem_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu((ToolStripMenuItem)sender);
            CargarVista(new MisReportesView());
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu((ToolStripMenuItem)sender);
            CargarVista(new ConfigurationView());
        }

        private void MenuStrip_miCuentaMenuItem_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu((ToolStripMenuItem)sender);
            CargarVista(new AyudaSoporteView());
        }

        private void idiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu((ToolStripMenuItem)sender);
            CargarVista(new IdiomaView());
        }

        // --- TUS BOTONES RECUPERADOS ---

        private void planesDeCultivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu((ToolStripMenuItem)sender);
            CargarVistaListaPlanes();
        }

        private void configuracionDeSensorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu((ToolStripMenuItem)sender);
            CargarVista(new ConfiguracionSensorView());
        }

        // --- LÓGICA ESPECIAL PLANES (LISTA -> EDICIÓN) ---

        private void CargarVistaListaPlanes()
        {
            this.panelInicio.Controls.Clear();
            PlanesDeCultivoView planesView = new PlanesDeCultivoView();
            planesView.Dock = DockStyle.Fill;

            // Suscripción para navegar a Edición
            planesView.OnSolicitarEdicion += AbrirEditorDePlan;

            this.panelInicio.Controls.Add(planesView);
        }

        private void AbrirEditorDePlan(PlanCultivo planSeleccionado)
        {
            this.panelInicio.Controls.Clear();
            PlanEdicionView editorView = new PlanEdicionView();
            editorView.Dock = DockStyle.Fill;

            // Cargar datos
            editorView.CargarDatos(planSeleccionado);

            // Suscripción para volver
            editorView.OnCancelar += (s, e) => CargarVistaListaPlanes();
            editorView.OnGuardar += (s, e) => CargarVistaListaPlanes();

            this.panelInicio.Controls.Add(editorView);
        }

        #endregion

        #region Cierre de Sesión

        private void InicioUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                string msg = _idiomaBLL.Traducir("Main_Msg_ConfirmarSalida") ?? "¿Estás seguro de que deseas salir?";
                string titulo = _idiomaBLL.Traducir("Global_Titulo_Confirmar") ?? "Confirmar";

                DialogResult resultado = MetroMessageBox.Show(this, msg, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            IdiomaService.GetInstance().IdiomaCambiado -= ActualizarTextos;

            try
            {
                var evento = _bitacoraService.CrearEvento(NivelCriticidad.Info, "Cierre de sesión", "Sistema", UsuarioActual?.IdUsuario ?? 0);
                var bitacora = new Bitacora
                {
                    FechaHora = evento.FechaHora,
                    Nivel = evento.Nivel,
                    Mensaje = evento.Mensaje,
                    Modulo = evento.Modulo,
                    UsuarioID = evento.UsuarioID
                };
                _bitacoraBLL.Registrar(bitacora);
            }
            catch { }

            _inicioUsuarioBLL.CerrarSesion(this.UsuarioActual);
        }

        #endregion
    }
}