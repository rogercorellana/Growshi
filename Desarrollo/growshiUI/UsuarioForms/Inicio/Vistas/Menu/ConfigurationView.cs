using BE;
using BLL;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion;
using Interfaces.IServices;
using Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace growshiUI.UsuarioForms.Inicio.Vistas
{
    public partial class ConfigurationView : UserControl
    {
        private readonly ISessionService<Usuario> _sessionService;
        private readonly InicioUsuarioBL _inicioUsuarioBLL;
        private readonly IPermissionService _permissionService;

        public Usuario UsuarioActual { get; private set; }

        public ConfigurationView()
        {
            InitializeComponent();

            _sessionService = SessionService<Usuario>.GetInstance();
            _inicioUsuarioBLL = new InicioUsuarioBL();
            _permissionService = PermissionService.GetInstance();

            this.UsuarioActual = _sessionService.UsuarioLogueado;

            AplicarPermisos();
        }

        private void AplicarPermisos()
        {
            btnGestionUsuarios.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonGestionUsuarios");
            btnRolesPermisos.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonRolesPermisos");
            btnAjusteSistema.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonAjusteSistema");
            btnCopiaSeguridad.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonCopiaSeguridad");
            btnActualizaciones.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonActualizaciones");
        }

        private void CargarVista(UserControl vista)
        {
            this.panelContenido.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.panelContenido.Controls.Add(vista);
        }

        // --- DISEÑO VISUAL ---

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
            // PALETA NUEVA: Verde Claro / Naturaleza
            Color colorArriba = Color.FromArgb(60, 150, 90);   // Verde Hoja
            Color colorAbajo = Color.FromArgb(100, 200, 120); // Verde Lima Suave (Luz)

            using (LinearGradientBrush brush = new LinearGradientBrush(this.panelMenu.ClientRectangle, colorArriba, colorAbajo, 90F))
            {
                e.Graphics.FillRectangle(brush, this.panelMenu.ClientRectangle);
            }
        }

        private void panelMenu_Resize(object sender, EventArgs e)
        {
            this.panelMenu.Invalidate();
        }

        // Efecto al hacer clic en un botón
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
                // Blanco semitransparente para resaltar
                botonSeleccionado.BackColor = Color.FromArgb(220, 255, 255, 255);
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

        // --- EVENTOS CLICK ---

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
            MetroFramework.MetroMessageBox.Show(this, "Módulo en desarrollo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnActualizaciones_Click(object sender, EventArgs e)
        {
            ResaltarBoton((MetroButton)sender);
            MetroFramework.MetroMessageBox.Show(this, "Sistema actualizado.", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}