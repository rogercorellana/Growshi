using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BE;
using BLL;
using growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos;
using growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanta;
using Interfaces.IServices;
using Services;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class MisCultivosView : UserControl
    {
        private SlotBLL slotBLL;
        private IdiomaBLL _idiomaBLL; 
        private readonly ISessionService<Usuario> _sessionService;
        public Usuario UsuarioActual { get; private set; }

        public MisCultivosView()
        {
            InitializeComponent();

            _sessionService = SessionService<Usuario>.GetInstance();
            slotBLL = new SlotBLL();
            _idiomaBLL = new IdiomaBLL();

            this.UsuarioActual = _sessionService.UsuarioLogueado;

            IdiomaService.GetInstance().IdiomaCambiado += CargarSlots;

            CargarSlots();
        }

        private void CargarSlots()
        {
            this.gridLayout.Controls.Clear();

            if (this.UsuarioActual == null) return;

            int usuarioId = this.UsuarioActual.IdUsuario;

            List<Slot> misSlots = slotBLL.ListarSlots(usuarioId);

            foreach (Slot slot in misSlots)
            {
                CultivoSlotView vistaSlot = new CultivoSlotView();
                vistaSlot.Dock = DockStyle.Fill;
                vistaSlot.Margin = new Padding(10);

                vistaSlot.Inicializar(slot);
                vistaSlot.Click += Slot_Click;

                this.gridLayout.Controls.Add(vistaSlot);
            }
        }

        private void Slot_Click(object sender, EventArgs e)
        {
            var vista = (CultivoSlotView)sender;
            var slot = vista.SlotActual;

            if (!slot.SlotEstado) return;

            if (slot.PlantaAsociadaID == null)
            {
                //string titulo = _idiomaBLL.Traducir("msg_slot_disponible_titulo");
                //string formatoCuerpo = _idiomaBLL.Traducir("msg_slot_disponible_cuerpo");
                //string mensaje = string.Format(formatoCuerpo, slot.NumeroVisual);

                //MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);

                new AgregarPlantaForm(slot.SlotID).ShowDialog();
                CargarSlots(); 
            }
            else
            {
                //string tituloInfo = _idiomaBLL.Traducir("titulo_informacion"); 
                //string formatoCuerpo = _idiomaBLL.Traducir("msg_slot_ocupado_cuerpo");
                //string mensaje = string.Format(formatoCuerpo, slot.NumeroVisual, slot.NombrePlanta);

                //MessageBox.Show(mensaje, tituloInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);

                new PlantaResumenForm(slot.SlotID).ShowDialog();
                CargarSlots();


            }
        }
    }
}