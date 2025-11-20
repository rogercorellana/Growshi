using BE; 
using BLL; 
using Interfaces.IServices; 
using Services; 
using System;

using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    public partial class IdiomaView : UserControl
    {
        private readonly IdiomaBLL _idiomaBLL;
        private readonly ISessionService<Usuario> _sessionService;
        private readonly Usuario _usuarioActual;

        public IdiomaView()
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
            labelSeleccioneUnIdioma.Text = _idiomaBLL.Traducir("label_seleccioneUnIdioma");
            labelEspañol.Text = _idiomaBLL.Traducir("label_español");
            labelIngles.Text = _idiomaBLL.Traducir("label_ingles");
        }


        private void pictureBoxEspañol_Click(object sender, EventArgs e)
        {
            
            _idiomaBLL.CambiarIdioma(1, _usuarioActual);

        }

        private void pictureBoxIngles_Click(object sender, EventArgs e)
        {
            
            _idiomaBLL.CambiarIdioma(2, _usuarioActual);


        }
    }
}