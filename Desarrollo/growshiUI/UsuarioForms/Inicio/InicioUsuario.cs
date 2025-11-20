using BE;
using BLL; 
using growshiUI.UsuarioForms.Inicio;
using growshiUI.UsuarioForms.Inicio.Vistas;
using Interfaces.IServices;
using Services;
using System;
using System.Drawing;
using System.Windows.Forms;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion;
using growshiUI.UsuarioForms.Inicio.Vistas.Menu;

namespace growshiUI.UsuarioForms
{
    public partial class InicioUsuario : Form
    {
        private readonly ISessionService<Usuario> _sessionService;
        private readonly InicioUsuarioBL _inicioUsuarioBLL;
        private readonly IPermissionService _permissionService;
        private readonly IdiomaBLL _idiomaBLL;


        public Usuario UsuarioActual { get; private set; }

        public InicioUsuario()
        {
            InitializeComponent();

            _sessionService = SessionService<Usuario>.GetInstance();
            _inicioUsuarioBLL = new InicioUsuarioBL(); 
            _permissionService = PermissionService.GetInstance();
            _idiomaBLL = new IdiomaBLL();

            this.UsuarioActual = _sessionService.UsuarioLogueado;

            if (this.UsuarioActual == null)
            {
                MessageBox.Show("No se ha podido recuperar la sesión del usuario...", "Error de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ActualizarTextos()
        {
            
            this.Text = _idiomaBLL.Traducir("form_inicio_titulo");

            // Traducir solamente el Menú, no puedo las vistas
            // (Usar las claves que definimos en la BD)
            MenuStrip_inicioMenuItem.Text = _idiomaBLL.Traducir("menu_inicio");
            MenuStrip_misCultivosMenuItem.Text = _idiomaBLL.Traducir("menu_miscultivos");
            MenuStrip_historialMenuItem.Text = _idiomaBLL.Traducir("menu_historial");
            MenuStrip_reportesMenuItem.Text = _idiomaBLL.Traducir("menu_reportes");
            MenuStrip_configuracionMenuItem.Text = _idiomaBLL.Traducir("menu_configuracion");
            MenuStrip_miCuentaMenuItem.Text = _idiomaBLL.Traducir("menu_micuenta");
            MenuStrip_idiomaMenuItem.Text = _idiomaBLL.Traducir("menu_idioma");


        }






        #region COMPOSITE PERMISOS APLICAR
        private void AplicarPermisos()
        {
            // btnGestionUsuarios.Enabled = _permissionService.TienePermiso(this.UsuarioActual, "GestionarUsuarios");
            // btnVerBitacora.Visible = _permissionService.TienePermiso(this.UsuarioActual, "VerBitacora");

            //el usuario tiene esa llave??
            //groupBoxCultivos.Enabled = _permissionService.TienePermiso(this.UsuarioActual, "VerCultivos");

            

            //validacion permisos MenuToolStrip
            menuStripGlobal.Items["MenuStrip_inicioMenuItem"].Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_inicioMenuItem");
            menuStripGlobal.Items["MenuStrip_misCultivosMenuItem"].Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_misCultivosMenuItem");
            menuStripGlobal.Items["MenuStrip_historialMenuItem"].Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_historialMenuItem");
            menuStripGlobal.Items["MenuStrip_reportesMenuItem"].Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_reportesMenuItem");
            menuStripGlobal.Items["MenuStrip_configuracionMenuItem"].Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_configuracionMenuItem");
            menuStripGlobal.Items["MenuStrip_miCuentaMenuItem"].Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_miCuentaMenuItem");     
            menuStripGlobal.Items["MenuStrip_idiomaMenuItem"].Visible = _permissionService.TienePermiso(this.UsuarioActual, "MenuStrip_idiomaMenuItem");


            //validacion permisos internos por apartado, todos dentro de su form 

            //inicio
            //miscultivos
            //historial
            //reportes



            //configuracion


            //micuenta

            //idioma










        }
        #endregion



        #region CERRAR VENTANA - LOGOUT - BITACORA LOGOUT

        private void InicioUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de que deseas salir? Tu sesión se cerrará.",
                "Confirmar Cierre de Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                IdiomaService.GetInstance().IdiomaCambiado -= ActualizarTextos;

                _inicioUsuarioBLL.CerrarSesion(this.UsuarioActual);
            }
        }



        #endregion





        #region Menu Strip
        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarVistaInicio();
        }



        private void MostrarVistaInicio()
        {
            ResaltarBotonMenu(MenuStrip_inicioMenuItem);

            this.panelInicio.Controls.Clear();
            InicioView vistaDashboard = new InicioView();
            vistaDashboard.Dock = DockStyle.Fill;
            this.panelInicio.Controls.Add(vistaDashboard);
        }


        private void ResaltarBotonMenu(ToolStripMenuItem botonSeleccionado)
        {
            foreach (ToolStripMenuItem boton in menuStripGlobal.Items)
            {
                boton.BackColor = SystemColors.MenuBar;
            }

            
            botonSeleccionado.BackColor = SystemColors.Highlight;
        }




        #endregion

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu((ToolStripMenuItem)sender);

            this.panelInicio.Controls.Clear();
            ConfigurationView vistaConfig = new ConfigurationView();
            vistaConfig.Dock = DockStyle.Fill;
            this.panelInicio.Controls.Add(vistaConfig);
        }

        private void idiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu((ToolStripMenuItem)sender);

            this.panelInicio.Controls.Clear();
            IdiomaView idiomaView = new IdiomaView();
            idiomaView.Dock = DockStyle.Fill;
            this.panelInicio.Controls.Add(idiomaView);
        }

        private void MenuStrip_misCultivosMenuItem_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu((ToolStripMenuItem)sender);

            this.panelInicio.Controls.Clear();
            MisCultivosView misCultivosView = new MisCultivosView();
            misCultivosView.Dock = DockStyle.Fill;
            this.panelInicio.Controls.Add(misCultivosView);
        }

        private void MenuStrip_reportesMenuItem_Click(object sender, EventArgs e)
        {
            ResaltarBotonMenu((ToolStripMenuItem)sender);

            this.panelInicio.Controls.Clear();
            MisReportesView misReportesView = new MisReportesView();
            misReportesView.Dock = DockStyle.Fill;
            this.panelInicio.Controls.Add(misReportesView);

        }

        private void MenuStrip_historialMenuItem_Click(object sender, EventArgs e)
        {

            ResaltarBotonMenu((ToolStripMenuItem)sender);

            this.panelInicio.Controls.Clear();
            HistorialView historial = new HistorialView();
            historial.Dock = DockStyle.Fill;
            this.panelInicio.Controls.Add(historial);
        }
    }
}