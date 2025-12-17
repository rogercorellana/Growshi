using System;
using System.Drawing;
using System.Windows.Forms;
using BE;
using BLL;
using BLL.InicioUsuarioBLL;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
using MetroFramework;
using MetroFramework.Controls;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_GestionUsuarios
{
    public partial class AgregarUsuario : UserControl
    {
        #region Propiedades y Servicios

        private readonly GestionUsuariosBLL _gestionUsuariosBLL;
        private readonly EncriptacionService _encriptacionService;
        private readonly IdiomaBLL _idiomaBLL;
        private readonly BitacoraBLL _bitacoraBLL;
        private readonly ISessionService<Usuario> _sessionService;
        private readonly IBitacoraService _bitacoraService;
        private readonly Usuario _usuarioActual;

        #endregion

        #region Constructor e Inicialización

        public AgregarUsuario()
        {
            InitializeComponent();

            // 1. Instancias
            _gestionUsuariosBLL = new GestionUsuariosBLL();
            _encriptacionService = new EncriptacionService();
            _idiomaBLL = new IdiomaBLL();
            _bitacoraBLL = new BitacoraBLL();
            _sessionService = SessionService<Usuario>.GetInstance();
            _bitacoraService = BitacoraService.GetInstance();
            _usuarioActual = _sessionService.UsuarioLogueado;

            // 2. Eventos y Carga
            this.Load += AgregarUsuario_Load;
            IdiomaService.GetInstance().IdiomaCambiado += TraducirInterfaz;
        }

        private void AgregarUsuario_Load(object sender, EventArgs e)
        {
            TraducirInterfaz();
        }

        #endregion

        #region Gestión de Idioma

        private void TraducirInterfaz()
        {
            // Títulos y Labels
            lblTitulo.Text = _idiomaBLL.Traducir("AgregarUsuario_Lbl_Titulo");
            lblNombre.Text = _idiomaBLL.Traducir("AgregarUsuario_Lbl_Nombre");
            lblPass.Text = _idiomaBLL.Traducir("AgregarUsuario_Lbl_Pass");
            lblPassRespaldo.Text = _idiomaBLL.Traducir("AgregarUsuario_Lbl_Respaldo");

            // Placeholders
            txtNombreUsuario.WaterMark = _idiomaBLL.Traducir("AgregarUsuario_Txt_NombrePh");
            txtContraseñaUsuario.WaterMark = _idiomaBLL.Traducir("AgregarUsuario_Txt_PassPh");
            txtContraseñaRespaldo.WaterMark = _idiomaBLL.Traducir("AgregarUsuario_Txt_RespaldoPh");

            // Botones
            btnGuardar.Text = _idiomaBLL.Traducir("AgregarUsuario_Btn_Guardar");
            btnCancelar.Text = _idiomaBLL.Traducir("AgregarUsuario_Btn_Volver");
        }

        #endregion

        #region Lógica de Negocio

        private void buttonAgregarUsuario_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtNombreUsuario.Text.Trim();
            string contraseñaUsuario = txtContraseñaUsuario.Text.Trim();
            string contraseñaRespaldo = txtContraseñaRespaldo.Text.Trim();

            // 1. Validación visual
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contraseñaUsuario) || string.IsNullOrWhiteSpace(contraseñaRespaldo))
            {
                MetroMessageBox.Show(this,
                    _idiomaBLL.Traducir("Global_Msg_CamposObligatorios"),
                    _idiomaBLL.Traducir("Global_Titulo_Atencion"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 2. Hash de contraseña
                string contraseñaHasheada = _encriptacionService.Hashear(contraseñaUsuario);

                // 3. Llamada a BLL
                _gestionUsuariosBLL.CrearUsuario(nombreUsuario, contraseñaHasheada, contraseñaRespaldo);

                // 4. Bitácora (Objetivo cumplido)
                RegistrarBitacora($"Nuevo usuario creado: {nombreUsuario}", NivelCriticidad.Info);

                // 5. Confirmación y flujo
                string mensaje = _idiomaBLL.Traducir("AgregarUsuario_Msg_ExitoContinuar");
                string titulo = _idiomaBLL.Traducir("Global_Titulo_Exito");

                DialogResult resultado = MetroMessageBox.Show(this, mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    LimpiarCampos();
                }
                else
                {
                    VolverAtras();
                }
            }
            catch (Exception ex)
            {
                string tituloError = _idiomaBLL.Traducir("Global_Titulo_Error");
                MetroMessageBox.Show(this, ex.Message, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            VolverAtras();
        }

        #endregion

        #region Helpers y Navegación

        private void CargarVista(UserControl vista)
        {
            this.Controls.Clear();
            vista.Dock = DockStyle.Fill;
            this.Controls.Add(vista);
        }

        private void VolverAtras()
        {
            CargarVista(new GestionUsuariosView());
        }

        private void LimpiarCampos()
        {
            txtNombreUsuario.Text = "";
            txtContraseñaUsuario.Text = "";
            txtContraseñaRespaldo.Text = "";
            txtNombreUsuario.Focus();
        }

        private void RegistrarBitacora(string mensaje, NivelCriticidad nivel)
        {
            var evento = _bitacoraService.CrearEvento(nivel, mensaje, "Gestión Usuarios", _usuarioActual.IdUsuario);
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

        #endregion
    }
}