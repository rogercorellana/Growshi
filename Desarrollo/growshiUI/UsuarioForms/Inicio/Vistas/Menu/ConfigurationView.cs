using BE;
using BLL;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion;
using Interfaces.IServices;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        //permisos
        private void AplicarPermisos()
        {
            
            buttonGestionUsuarios.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonGestionUsuarios");
            buttonRolesPermisos.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonRolesPermisos");
            buttonAjusteSistema.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonAjusteSistema");
            buttonCopiaSeguridad.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonCopiaSeguridad");
            buttonActualizaciones.Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem_buttonActualizaciones");




        }


        private void CargarVista(UserControl vista)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(vista);
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            CargarVista(new GestionUsuariosView());

        }

        private void buttonRolesPermisos_Click(object sender, EventArgs e)
        {
            CargarVista(new RolesYPermisosView());

        }

        private void buttonCopiaSeguridad_Click(object sender, EventArgs e)
        {
            CargarVista(new CopiasSeguridadView());
        }

        
    }
}
