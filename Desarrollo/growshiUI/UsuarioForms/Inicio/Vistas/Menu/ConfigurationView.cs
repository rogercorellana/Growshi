using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BE;
using BLL;
using Interfaces.IServices;
using Services;
using MetroFramework;
using MetroFramework.Controls;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion; // Para GestionUsuariosView, RolesView, etc.
using growshiUI.UsuarioForms.Inicio.Vistas.Menu; // Para IdiomaView (si lo moviste ahí)

namespace growshiUI.UsuarioForms.Inicio.Vistas
{
    public partial class ConfigurationView : UserControl
    {
        #region Propiedades y Servicios

        private readonly ISessionService<Usuario> _sessionService;
        private readonly IPermissionService _permissionService;
        private readonly IdiomaBLL _idiomaBLL;

        public Usuario UsuarioActual { get; private set; }

        #endregion

        #region Constructor e Inicialización

        public ConfigurationView()
        {
            InitializeComponent();

            // 1. Instancias
            _sessionService = SessionService<Usuario>.GetInstance();
            _permissionService = PermissionService.GetInstance();
            _idiomaBLL = new IdiomaBLL();

            this.UsuarioActual = _sessionService.UsuarioLogueado;

            // 2. Configuración Inicial
            AplicarPermisos();
            TraducirInterfaz();

            // 3. Suscripción a cambios de idioma
            IdiomaService.GetInstance().IdiomaCambiado += TraducirInterfaz;
        }

        #endregion

        #region Gestión de Idioma

        private void TraducirInterfaz()
        {
            // Títulos y Labels
            lblMenuTitulo.Text = _idiomaBLL.Traducir("Config_Lbl_TituloMenu");
            lblPlaceholder.Text = _idiomaBLL.Traducir("Config_Lbl_Placeholder");

            // Botones del Menú
            btnGestionUsuarios.Text = _idiomaBLL.Traducir("Config_Btn_GestionUsuarios");
            btnRolesPermisos.Text = _idiomaBLL.Traducir("Config_Btn_RolesPermisos");
            btnAjusteSistema.Text = _idiomaBLL.Traducir("Config_Btn_AjustesIdioma"); // Cambiado a Idioma
            btnCopiaSeguridad.Text = _idiomaBLL.Traducir("Config_Btn_Backups");
            btnActualizaciones.Text = _idiomaBLL.Traducir("Config_Btn_Actualizaciones");
        }

        #endregion

        #region Gestión de Permisos

        private void AplicarPermisos()
        {
            // Verificamos permisos para mostrar/ocultar botones
            btnGestionUsuarios.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonGestionUsuarios");
            btnRolesPermisos.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonRolesPermisos");

            // Estos suelen ser visibles para admins o usuarios avanzados
            btnAjusteSistema.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonAjusteSistema");
            btnCopiaSeguridad.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonCopiaSeguridad");

            // Actualizaciones visible para todos o restringido según lógica
            btnActualizaciones.Visible = true;
        }

        #endregion

        #region Navegación y UI

        private void CargarVista(UserControl vista)
        {
            this.panelContenido.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.panelContenido.Controls.Add(vista);
        }

        private void ResaltarBoton(MetroButton botonSeleccionado)
        {
            ResetearBoton(btnGestionUsuarios);
            ResetearBoton(btnRolesPermisos);
            ResetearBoton(btnAjusteSistema);
            ResetearBoton(btnCopiaSeguridad);
            ResetearBoton(btnActualizaciones);

            if (botonSeleccionado != null)
            {
                botonSeleccionado.UseCustomBackColor = true;
                botonSeleccionado.BackColor = Color.FromArgb(220, 255, 255, 255); // Blanco semi-transparente
                botonSeleccionado.ForeColor = Color.DarkGreen;
                botonSeleccionado.UseCustomForeColor = true;
            }
        }

        private void ResetearBoton(MetroButton btn)
        {
            btn.UseCustomBackColor = true;
            btn.BackColor = Color.Transparent;
            btn.UseCustomForeColor = true;
            btn.ForeColor = Color.White;
        }

        // Efecto gradiente en el panel izquierdo
        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
            Color colorArriba = Color.FromArgb(60, 150, 90);
            Color colorAbajo = Color.FromArgb(100, 200, 120);

            using (LinearGradientBrush brush = new LinearGradientBrush(this.panelMenu.ClientRectangle, colorArriba, colorAbajo, 90F))
            {
                e.Graphics.FillRectangle(brush, this.panelMenu.ClientRectangle);
            }
        }

        private void panelMenu_Resize(object sender, EventArgs e)
        {
            this.panelMenu.Invalidate();
        }

        #endregion

        #region Eventos Click (Botones)

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            ResaltarBoton((MetroButton)sender);
            CargarVista(new GestionUsuariosView());
        }

        private void btnRolesPermisos_Click(object sender, EventArgs e)
        {
            ResaltarBoton((MetroButton)sender);
            CargarVista(new RolesYPermisosView());
        }

        private void btnCopiaSeguridad_Click(object sender, EventArgs e)
        {
            ResaltarBoton((MetroButton)sender);
            CargarVista(new CopiasSeguridadView());
        }

        private void btnAjusteSistema_Click(object sender, EventArgs e)
        {
            ResaltarBoton((MetroButton)sender);

            // Ahora abrimos la vista real de Idioma que creamos antes
            CargarVista(new IdiomaView());
        }

        private void btnActualizaciones_Click(object sender, EventArgs e)
        {
            ResaltarBoton((MetroButton)sender);

            // Simulación de check de updates
            MetroMessageBox.Show(this,
                _idiomaBLL.Traducir("Config_Msg_SistemaActualizado"),
                _idiomaBLL.Traducir("Global_Titulo_Estado"),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}