using BE;
using BLL; 
using System;
using System.Drawing;
using System.Windows.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos
{
    public partial class CultivoSlotView : UserControl
    {
        public Slot SlotActual { get; private set; }
        public new event EventHandler Click;

        private IdiomaBLL _idiomaBLL = new IdiomaBLL();

        public CultivoSlotView()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        public void Inicializar(Slot slot)
        {
            this.SlotActual = slot;

            // --- CASO 1: Slot APAGADO (SlotEstado = false) ---
            if (!slot.SlotEstado)
            {
                string formato = _idiomaBLL.Traducir("format_slot_mantenimiento");
                this.lblTexto.Text = string.Format(formato, slot.NumeroVisual);

                this.panelFondo.BackColor = Color.Gray;
                this.panelFondo.Cursor = Cursors.No;
                this.Enabled = false;
                return;
            }

            this.Enabled = true;
            this.panelFondo.Cursor = Cursors.Hand;

            // verificacion si tiene planta o no
            if (slot.PlantaAsociadaID == null)
            {
                string formato = _idiomaBLL.Traducir("format_slot_disponible");
                this.lblTexto.Text = string.Format(formato, slot.NumeroVisual);

                this.panelFondo.BackColor = Color.WhiteSmoke;
            }
            else
            {
                string formato = _idiomaBLL.Traducir("format_slot_ocupado");
                this.lblTexto.Text = string.Format(formato, slot.NombrePlanta);

                this.panelFondo.BackColor = Color.FromArgb(192, 255, 192);
            }
        }

        private void ConfigurarEventos()
        {
            EventHandler triggerClick = (s, e) =>
            {
                if (SlotActual != null && !SlotActual.SlotEstado) return;
                this.Click?.Invoke(this, e);
            };

            this.panelFondo.Click += triggerClick;
            this.lblTexto.Click += triggerClick;
            this.picIcono.Click += triggerClick;

            this.panelFondo.MouseEnter += (s, e) => {
                if (SlotActual != null && SlotActual.SlotEstado && SlotActual.PlantaAsociadaID == null)
                    this.panelFondo.BackColor = Color.White;
            };
            this.panelFondo.MouseLeave += (s, e) => {
                if (SlotActual != null && SlotActual.SlotEstado && SlotActual.PlantaAsociadaID == null)
                    this.panelFondo.BackColor = Color.WhiteSmoke;
            };
        }

        
    }
}