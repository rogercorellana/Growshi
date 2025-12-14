using System;
using System.Collections.Generic;
using System.Drawing; // Necesario para Point, Size y Color
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

        // --- PUNTOS CLAVE ---
        // Esta lista define dónde se dibujará cada slot.
        // DEBES AJUSTAR ESTOS NÚMEROS (X, Y) para que coincidan exactamente
        // sobre las macetas de tu imagen de fondo. Prueba y error.
        private readonly List<Point> _coordenadasMacetas = new List<Point>
{
    // X (Solo el 1 modificado), Y (165 fijo)
    new Point(435, 165), // Maceta 1 (+10px a la derecha)
    new Point(543, 165), // Maceta 2 (PERFECTO)
    new Point(668, 165), // Maceta 3 (PERFECTO)
    new Point(780, 165)  // Maceta 4 (PERFECTO)
};
        // Define el tamaño del área interactiva sobre cada maceta
        private readonly Size _tamanoSlot = new Size(100, 120);


        public MisCultivosView()
        {
            InitializeComponent();

            // --- CONFIGURACIÓN DEL FONDO ---
            // ASEGÚRATE de que tu imagen se llame 'FondoHidroponia' en tus Recursos, o cambia el nombre aquí.
            // Si te da error aquí, es porque no has agregado la imagen a Properties.Resources.resx
            this.BackgroundImage = Properties.Resources.FondoHidroponia;

            _sessionService = SessionService<Usuario>.GetInstance();
            slotBLL = new SlotBLL();
            _idiomaBLL = new IdiomaBLL();

            this.UsuarioActual = _sessionService.UsuarioLogueado;

            IdiomaService.GetInstance().IdiomaCambiado += CargarSlots;

            CargarSlots();
        }

        private void CargarSlots()
        {
            // Limpiamos los controles antiguos directamente del formulario principal
            this.Controls.Clear();

            if (this.UsuarioActual == null) return;

            int usuarioId = this.UsuarioActual.IdUsuario;
            List<Slot> misSlots = slotBLL.ListarSlots(usuarioId);

            // Iteramos usando un 'for' normal para usar el índice 'i' para las coordenadas
            for (int i = 0; i < misSlots.Count; i++)
            {
                // Seguridad: Si tienes más slots que coordenadas definidas, paramos para no dar error.
                if (i >= _coordenadasMacetas.Count) break;

                Slot slot = misSlots[i];
                CultivoSlotView vistaSlot = new CultivoSlotView();

                // --- CONFIGURACIÓN VISUAL CLAVE ---
                // 1. Posición absoluta basada en nuestra lista de puntos
                vistaSlot.Location = _coordenadasMacetas[i];
                // 2. Tamaño fijo para que encaje sobre la maceta dibujada
                vistaSlot.Size = _tamanoSlot;
                // 3. Hacerlo transparente para ver la maceta de fondo
                vistaSlot.BackColor = Color.Transparent;
                // 4. Quitar cualquier margen que moleste
                vistaSlot.Margin = Padding.Empty;

                vistaSlot.Inicializar(slot);
                vistaSlot.Click += Slot_Click;

                this.Controls.Add(vistaSlot);

                // Truco: Enviar al fondo a veces ayuda con la transparencia en WinForms,
                // aunque aquí deberían estar al frente. Si no se ven, prueba .BringToFront();
                vistaSlot.BringToFront();
            }
        }

        private void Slot_Click(object sender, EventArgs e)
        {
            var vista = (CultivoSlotView)sender;
            var slot = vista.SlotActual;

            if (!slot.SlotEstado)
            {
                MessageBox.Show("Este slot está en mantenimiento o desactivado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (slot.PlantaAsociadaID == null)
            {
                // Slot vacío -> Agregar planta
                var formAgregar = new AgregarPlantaForm(slot.SlotID);
                formAgregar.ShowDialog();
                CargarSlots(); // Recargar al cerrar el diálogo
            }
            else
            {
                // Slot ocupado -> Ver resumen
                var formResumen = new PlantaResumenForm(slot.SlotID);
                formResumen.ShowDialog();
                CargarSlots(); // Recargar al cerrar el diálogo
            }
        }
    }
}