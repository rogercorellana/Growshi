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
        // 'new' es necesario porque UserControl ya tiene un evento Click
        public new event EventHandler Click;

        private IdiomaBLL _idiomaBLL = new IdiomaBLL();

        // Colores para los estados (ajusta según tu gusto para que combinen con el fondo)
        private Color _colorTextoOcupado = Color.LightGreen;
        private Color _colorTextoVacio = Color.WhiteSmoke;
        private Color _colorTextoMantenimiento = Color.OrangeRed;
        private Color _colorHover = Color.Yellow; // Color al pasar el mouse

        public CultivoSlotView()
        {
            InitializeComponent();

            // Configuración extra para intentar mejorar la transparencia en WinForms
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;

            ConfigurarEventosClick();
            ConfigurarEventosHover();
        }

        public void Inicializar(Slot slot)
        {
            this.SlotActual = slot;
            this.Enabled = true;
            this.Cursor = Cursors.Hand;

            // --- IMPORTANTE: Limpieza inicial ---
            // Siempre borramos la imagen anterior por si el slot cambió de estado.
            this.picIcono.Image = null;
            // Restablecemos el modo de imagen por si acaso
            this.picIcono.SizeMode = PictureBoxSizeMode.Zoom;

            // --- CASO 1: MANTENIMIENTO ---
            if (!slot.SlotEstado)
            {
                // ... (tu código de mantenimiento sigue igual)
                string formato = _idiomaBLL.Traducir("format_slot_mantenimiento") ?? "Mant. {0}";
                this.lblTexto.Text = string.Format(formato, slot.NumeroVisual);
                this.lblTexto.ForeColor = _colorTextoMantenimiento;
                this.Cursor = Cursors.No;
                return;
            }

            // --- CASO 2: VACÍO ---
            if (slot.PlantaAsociadaID == null)
            {
                // ... (tu código de vacío sigue igual)
                string formato = _idiomaBLL.Traducir("format_slot_disponible") ?? "Vacío {0}";
                this.lblTexto.Text = string.Format(formato, slot.NumeroVisual);
                this.lblTexto.ForeColor = _colorTextoVacio;

                // Aquí no ponemos imagen, para que se vea "vacío".
                // (O podrías poner un ícono gris de un signo '+' si quisieras).
            }
            // --- CASO 3: OCUPADO (EN CURSO) ---
            else
            {
                string formato = _idiomaBLL.Traducir("format_slot_ocupado") ?? "{0}";
                this.lblTexto.Text = string.Format(formato, slot.NombrePlanta);
                this.lblTexto.ForeColor = _colorTextoOcupado;

                //===============================================================
                // ¡AQUÍ ESTÁ LA MAGIA!
                // Agregamos la imagen para darle vida.
                // Asegúrate de cambiar 'IconoPlantaViva' por el nombre real de tu recurso.
                //===============================================================
                this.picIcono.Image = Properties.Resources.IconoPlantaViva;
            }
        }
        private void ConfigurarEventosClick()
        {
            // Delegamos el clic de los controles internos al evento principal del UserControl
            EventHandler triggerClick = (s, e) =>
            {
                this.Click?.Invoke(this, e);
            };

            this.lblTexto.Click += triggerClick;
            this.picIcono.Click += triggerClick;
            // El propio UserControl también dispara el evento
            base.Click += triggerClick;
        }

        private void ConfigurarEventosHover()
        {
            // Efecto visual simple: cambiar el color del texto al pasar el mouse
            this.MouseEnter += (s, e) => EfectoHover(true);
            this.MouseLeave += (s, e) => EfectoHover(false);

            this.lblTexto.MouseEnter += (s, e) => EfectoHover(true);
            this.lblTexto.MouseLeave += (s, e) => EfectoHover(false);

            this.picIcono.MouseEnter += (s, e) => EfectoHover(true);
            this.picIcono.MouseLeave += (s, e) => EfectoHover(false);
        }

        private void EfectoHover(bool entrando)
        {
            if (SlotActual == null || !SlotActual.SlotEstado) return;

            if (entrando)
            {
                this.lblTexto.ForeColor = _colorHover;
                // Opcional: Podrías hacer que el ícono crezca un poco o brille
            }
            else
            {
                // Restaurar el color original según el estado
                if (SlotActual.PlantaAsociadaID == null)
                    this.lblTexto.ForeColor = _colorTextoVacio;
                else
                    this.lblTexto.ForeColor = _colorTextoOcupado;
            }
        }
    }
}