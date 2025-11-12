using BE;
using BLL;
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

namespace growshiUI.UsuarioForms.Inicio
{
    public partial class InicioView : UserControl
    {

        private readonly IdiomaBLL _idiomaBLL;
        private readonly ISessionService<Usuario> _sessionService;
        private readonly Usuario _usuarioActual;

        public InicioView()
        {
            InitializeComponent();
            _idiomaBLL = new IdiomaBLL();

            _sessionService = SessionService<Usuario>.GetInstance();
            _usuarioActual = _sessionService.UsuarioLogueado;

            this._usuarioActual = _sessionService.UsuarioLogueado;

            _idiomaBLL.CargarIdiomaInicial(this._usuarioActual);
            IdiomaService.GetInstance().IdiomaCambiado += ActualizarTraducciones;
            ActualizarTraducciones();

        }

        


        public void ActualizarTraducciones()
        {
            labelBienvenidosAGrowshi.Text = _idiomaBLL.Traducir("labelBienvenidosAGrowshi");
            labelCultivosActivos.Text = _idiomaBLL.Traducir("labelCultivosActivos");
            labelAlertasPendientes.Text = _idiomaBLL.Traducir("labelAlertasPendientes");
            labelGestionarCultivos.Text = _idiomaBLL.Traducir("labelGestionarCultivos");
            labelConfiguracion.Text = _idiomaBLL.Traducir("labelConfiguracion");

        }

        #region Movimiento de mouse
        private void tileGestionarCultivos_MouseEnter(object sender, EventArgs e)
        {
            this.tileGestionarCultivos.BackColor = Color.LightGray;
        }

        private void tileGestionarCultivos_MouseLeave(object sender, EventArgs e)
        {
            this.tileGestionarCultivos.BackColor = SystemColors.ControlLight;
        }
        #endregion
    }
}

