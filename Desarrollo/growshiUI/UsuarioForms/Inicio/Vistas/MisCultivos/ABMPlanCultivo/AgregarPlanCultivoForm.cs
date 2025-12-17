using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BE;
using BLL;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanCultivo
{
    public partial class AgregarPlanCultivoForm : MetroForm
    {
        #region Propiedades y Servicios

        private readonly IdiomaBLL _idiomaBLL;
        private readonly PlanCultivoBLL _planCultivoBLL;
        private readonly BitacoraBLL _bitacoraBLL;
        private readonly ISessionService<Usuario> _sessionService;
        private readonly IBitacoraService _bitacoraService;
        private readonly Usuario _usuarioActual;

        #endregion

        #region Constructor e Inicialización

        public AgregarPlanCultivoForm()
        {
            InitializeComponent();

            // 1. Instancias
            _idiomaBLL = new IdiomaBLL();
            _planCultivoBLL = new PlanCultivoBLL();
            _bitacoraBLL = new BitacoraBLL();
            _sessionService = SessionService<Usuario>.GetInstance();
            _bitacoraService = BitacoraService.GetInstance();
            _usuarioActual = _sessionService.UsuarioLogueado;

            // 2. Configuración Visual
            this.Load += AgregarPlanCultivoForm_Load;
            this.Resize += (s, e) => this.Refresh(); // Redibujar bordes redondeados al cambiar tamaño
        }

        private void AgregarPlanCultivoForm_Load(object sender, EventArgs e)
        {
            TraducirInterfaz();
            ConfigurarPaneles();
            ConfigurarEstilos();
        }

        #endregion

        #region Gestión de Idioma y UI

        private void TraducirInterfaz()
        {
            this.Text = _idiomaBLL.Traducir("AgregarPlan_TituloVentana");
            lblTituloPrincipal.Text = _idiomaBLL.Traducir("AgregarPlan_Lbl_TituloPrincipal");
            lblNombrePlan.Text = _idiomaBLL.Traducir("AgregarPlan_Lbl_NombrePlan");
            txtNombrePlan.WaterMark = _idiomaBLL.Traducir("AgregarPlan_Txt_Placeholder");

            btnGuardar.Text = _idiomaBLL.Traducir("AgregarPlan_Btn_Guardar");
            btnCancelar.Text = _idiomaBLL.Traducir("AgregarPlan_Btn_Cancelar");
        }

        private void ConfigurarPaneles()
        {
            // Creamos los controles dinámicamente con textos traducidos
            CrearControlesEtapa(panelGerminacion, lblTituloGerm, _idiomaBLL.Traducir("Etapa_Germinacion"), 1);
            CrearControlesEtapa(panelVegetacion, lblTituloVeg, _idiomaBLL.Traducir("Etapa_Vegetacion"), 2);
            CrearControlesEtapa(panelFloracion, lblTituloFlor, _idiomaBLL.Traducir("Etapa_Floracion"), 3);
        }

        private void ConfigurarEstilos()
        {
            // Botones redondeados
            RedondearControl(btnGuardar, 20);
            RedondearControl(btnCancelar, 20);

            // Paneles redondeados
            RedondearControl(panelGerminacion, 15);
            RedondearControl(panelVegetacion, 15);
            RedondearControl(panelFloracion, 15);
        }

        private void CrearControlesEtapa(Panel panel, Label lblTitulo, string tituloTexto, int index)
        {
            lblTitulo.Text = tituloTexto;
            lblTitulo.ForeColor = Color.FromArgb(76, 175, 80); // Verde Growshi

            string[] labels = {
                _idiomaBLL.Traducir("Param_Duracion"),
                _idiomaBLL.Traducir("Param_TempMin"),
                _idiomaBLL.Traducir("Param_TempMax"),
                _idiomaBLL.Traducir("Param_HumMin"),
                _idiomaBLL.Traducir("Param_HumMax"),
                _idiomaBLL.Traducir("Param_PhMin"),
                _idiomaBLL.Traducir("Param_PhMax"),
                _idiomaBLL.Traducir("Param_EcMin"),
                _idiomaBLL.Traducir("Param_EcMax"),
                _idiomaBLL.Traducir("Param_HorasLuz")
            };

            // Sufijos para identificar los TextBox (Clave interna, no se traduce)
            string[] suffixes = {
                "Duracion", "TempMin", "TempMax", "HumMin", "HumMax",
                "PhMin", "PhMax", "EcMin", "EcMax", "HorasLuz"
            };

            int y = 60;

            for (int i = 0; i < labels.Length; i++)
            {
                // Etiqueta
                Label lbl = new Label();
                lbl.Text = labels[i];
                lbl.Location = new Point(20, y);
                lbl.AutoSize = true;
                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                lbl.ForeColor = Color.DimGray;
                panel.Controls.Add(lbl);

                // Campo de Texto
                MetroTextBox txt = new MetroTextBox();
                txt.Location = new Point(140, y - 3);
                txt.Size = new Size(120, 25);
                txt.FontSize = MetroTextBoxSize.Medium;

                // Nombre único: txt_Ger_TempMin, txt_Veg_Duracion, etc.
                string prefijo = index == 1 ? "Ger" : (index == 2 ? "Veg" : "Flo");
                txt.Name = $"txt_{prefijo}_{suffixes[i]}";

                // Validación simple: Solo números y comas/puntos (Evento KeyPress)
                txt.KeyPress += (s, e) =>
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ','))
                    {
                        e.Handled = true;
                    }
                };

                panel.Controls.Add(txt);
                y += 35;
            }
        }

        private void RedondearControl(Control control, int radio)
        {
            Rectangle bounds = new Rectangle(0, 0, control.Width, control.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radio, radio, 180, 90);
            path.AddArc(bounds.X + bounds.Width - radio, bounds.Y, radio, radio, 270, 90);
            path.AddArc(bounds.X + bounds.Width - radio, bounds.Y + bounds.Height - radio, radio, radio, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - radio, radio, radio, 90, 90);
            path.CloseFigure();
            control.Region = new Region(path);
        }

        #endregion

        #region Lógica de Guardado (Negocio)

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación básica
                if (string.IsNullOrWhiteSpace(txtNombrePlan.Text))
                {
                    MetroMessageBox.Show(this,
                        _idiomaBLL.Traducir("Global_Msg_CamposObligatorios"),
                        _idiomaBLL.Traducir("Global_Titulo_Atencion"),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                PlanCultivo nuevoPlan = new PlanCultivo();
                nuevoPlan.NombrePlan = txtNombrePlan.Text;
                nuevoPlan.Etapas = new System.Collections.Generic.List<EtapaCultivo>();

                // Recuperar datos de los paneles (ahora con nombres de etapa traducidos si se desea, o fijos)
                // Usamos nombres fijos internamente ("Germinación", etc) o claves para luego traducirlos al mostrar
                // Por simplicidad en DB, guardamos el nombre en el idioma actual o uno estándar.
                // Aquí usaré el texto traducido actual para el nombre.

                nuevoPlan.Etapas.Add(ObtenerEtapaDelPanel(panelGerminacion, "Ger", _idiomaBLL.Traducir("Etapa_Germinacion"), 1));
                nuevoPlan.Etapas.Add(ObtenerEtapaDelPanel(panelVegetacion, "Veg", _idiomaBLL.Traducir("Etapa_Vegetacion"), 2));
                nuevoPlan.Etapas.Add(ObtenerEtapaDelPanel(panelFloracion, "Flo", _idiomaBLL.Traducir("Etapa_Floracion"), 3));

                // Guardar en DB
                int usuarioID = _usuarioActual.IdUsuario;
                _planCultivoBLL.GuardarPlan(nuevoPlan, usuarioID);

                // --- BITÁCORA ---
                IBitacora evento = _bitacoraService.CrearEvento(
                    NivelCriticidad.Info,
                    $"Nuevo Plan creado: {nuevoPlan.NombrePlan}",
                    "Gestión Cultivos",
                    usuarioID
                );

                var bitacora = new Bitacora
                {
                    FechaHora = evento.FechaHora,
                    Nivel = evento.Nivel,
                    Mensaje = evento.Mensaje,
                    Modulo = evento.Modulo,
                    UsuarioID = evento.UsuarioID
                };

                _bitacoraBLL.Registrar(bitacora);
                // ----------------

                MetroMessageBox.Show(this,
                    _idiomaBLL.Traducir("AgregarPlan_Msg_Exito"),
                    _idiomaBLL.Traducir("Global_Titulo_Exito"),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MetroMessageBox.Show(this,
                    _idiomaBLL.Traducir("AgregarPlan_Err_FormatoNumerico"),
                    _idiomaBLL.Traducir("Global_Titulo_Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message,
                    _idiomaBLL.Traducir("Global_Titulo_Error"),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private EtapaCultivo ObtenerEtapaDelPanel(Panel panel, string prefijo, string nombreEtapa, int orden)
        {
            EtapaCultivo etapa = new EtapaCultivo();
            etapa.NombreEtapa = nombreEtapa;
            etapa.Orden = orden;

            // Helper local para parsear seguro (evita crash si está vacío)
            decimal ParseDecimal(string key)
            {
                string text = panel.Controls[$"txt_{prefijo}_{key}"].Text;
                if (string.IsNullOrWhiteSpace(text)) return 0;
                return decimal.Parse(text.Replace('.', ',')); // Normalizar separador decimal
            }

            int ParseInt(string key)
            {
                string text = panel.Controls[$"txt_{prefijo}_{key}"].Text;
                if (string.IsNullOrWhiteSpace(text)) return 0;
                return int.Parse(text);
            }

            etapa.Duracion = ParseInt("Duracion");
            etapa.TempMin = ParseDecimal("TempMin");
            etapa.TempMax = ParseDecimal("TempMax");
            etapa.HumMin = ParseDecimal("HumMin");
            etapa.HumMax = ParseDecimal("HumMax");
            etapa.PhMin = ParseDecimal("PhMin");
            etapa.PhMax = ParseDecimal("PhMax");
            etapa.EcMin = ParseDecimal("EcMin");
            etapa.EcMax = ParseDecimal("EcMax");
            etapa.HorasLuz = ParseDecimal("HorasLuz");

            return etapa;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}