using BE;
using BLL; // <-- AÑADIR: Para usar la nueva BLL
using growshiUI.UsuarioForms.Inicio;
using growshiUI.UsuarioForms.Inicio.Vistas;
using Interfaces.IServices;
using Services;
using System;
using System.Drawing;
using System.Windows.Forms;
using growshiUI.UsuarioForms.Inicio.Vistas.Configuracion;

namespace growshiUI.UsuarioForms
{
    public partial class InicioUsuario : Form
    {
        private readonly ISessionService<Usuario> _sessionService;
        private readonly InicioUsuarioBLL _inicioUsuarioBLL; // <-- AÑADIR: La dependencia a la BLL
        private readonly IPermissionService _permissionService; // ✅ Añadir


        public Usuario UsuarioActual { get; private set; }

        public InicioUsuario()
        {
            InitializeComponent();

            _sessionService = SessionService<Usuario>.GetInstance();
            _inicioUsuarioBLL = new InicioUsuarioBLL(); // <-- AÑADIR: Se crea la instancia de la BLL
            _permissionService = PermissionService.GetInstance(); // ✅ Añadir

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
                AplicarPermisos();
                MostrarVistaInicio();

            }

        }




        #region COMPOSITE PERMISOS APLICAR
        private void AplicarPermisos()
        {
            // ✅ La verificación se hace a través del servicio, manteniendo el código limpio.
            // btnGestionUsuarios.Enabled = _permissionService.TienePermiso(this.UsuarioActual, "GestionarUsuarios");
            // btnVerBitacora.Visible = _permissionService.TienePermiso(this.UsuarioActual, "VerBitacora");

            //el usuario tiene esa llave??
            //groupBoxCultivos.Enabled = _permissionService.TienePermiso(this.UsuarioActual, "VerCultivos");
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
            // Resalta el botón del menú de inicio
            ResaltarBotonMenu(inicioMenuItem);

            // Carga el UserControl de la vista de inicio
            this.panelInicio.Controls.Clear();
            InicioView vistaDashboard = new InicioView();
            vistaDashboard.Dock = DockStyle.Fill;
            this.panelInicio.Controls.Add(vistaDashboard);
        }


        private void ResaltarBotonMenu(ToolStripMenuItem botonSeleccionado)
        {
            // 1. Quita el resaltado de TODOS los botones del menú principal.
            foreach (ToolStripMenuItem boton in menuStrip1.Items)
            {
                // Vuelve a poner el color de fondo por defecto del menú.
                boton.BackColor = SystemColors.MenuBar;
            }

            // 2. Pinta solo el botón que fue seleccionado.
            // Un buen color es el que usa el sistema para resaltar cosas.
            botonSeleccionado.BackColor = SystemColors.Highlight;
        }




        #endregion

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Resalta el botón del menú
            ResaltarBotonMenu((ToolStripMenuItem)sender);

            // Carga el UserControl principal de configuración
            this.panelInicio.Controls.Clear();
            ConfigurationView vistaConfig = new ConfigurationView();
            vistaConfig.Dock = DockStyle.Fill;
            this.panelInicio.Controls.Add(vistaConfig);
        }

        private void idiomaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Resalta el botón del menú
            ResaltarBotonMenu((ToolStripMenuItem)sender);

            // Carga el UserControl principal de configuración
            this.panelInicio.Controls.Clear();
            IdiomaView idiomaView = new IdiomaView();
            idiomaView.Dock = DockStyle.Fill;
            this.panelInicio.Controls.Add(idiomaView);
        }
    }
}