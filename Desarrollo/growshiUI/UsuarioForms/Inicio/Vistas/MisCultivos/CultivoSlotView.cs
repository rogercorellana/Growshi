using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos
{
    public partial class CultivoSlotView : UserControl
    {
        public int SlotId { get; private set; }

        public new event EventHandler Click;

        public CultivoSlotView()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        public void Inicializar(int id)
        {
            this.SlotId = id;
            this.lblTexto.Text = $"Espacio {id}\n(Disponible)";
            
        }

        private void ConfigurarEventos()
        {
            // 1. Unificar el Clic: Que funcione clickeando el panel, la imagen o el texto
            EventHandler triggerClick = (s, e) => this.Click?.Invoke(this, e);
            this.panelFondo.Click += triggerClick;
            this.lblTexto.Click += triggerClick;
            this.picIcono.Click += triggerClick;

            // 2. Efecto Hover (Interactividad Visual)
            this.panelFondo.MouseEnter += (s, e) => CambiarColor(Color.White);
            this.panelFondo.MouseLeave += (s, e) => CambiarColor(Color.WhiteSmoke);

            // Propagar el hover a los hijos para que no "parpadee"
            this.picIcono.MouseEnter += (s, e) => CambiarColor(Color.White);
            this.lblTexto.MouseEnter += (s, e) => CambiarColor(Color.White);
        }

        private void CambiarColor(Color color)
        {
            this.panelFondo.BackColor = color;
        }
    }
}