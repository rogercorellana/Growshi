using BE;
using BLL;
using Interfaces.IServices;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Services; 
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanCultivo
{
    public partial class AgregarPlanCultivoForm : MetroForm
    {
        private IdiomaBLL _idiomaBLL = new IdiomaBLL();
        private readonly ISessionService<Usuario> _sessionService;


        public AgregarPlanCultivoForm()
        {
            InitializeComponent();
            _sessionService = SessionService<Usuario>.GetInstance();


        }

        private void AgregarPlanCultivoForm_Load(object sender, EventArgs e)
        {
            TraducirInterfaz();



            CrearControlesEtapa(this.panelGerminacion, this.lblTituloGerm, _idiomaBLL.Traducir("etapa_germinacion"), 1);
            CrearControlesEtapa(this.panelVegetacion, this.lblTituloVeg, _idiomaBLL.Traducir("etapa_vegetacion"), 2);
            CrearControlesEtapa(this.panelFloracion, this.lblTituloFlor, _idiomaBLL.Traducir("etapa_floracion"), 3);

            RedondearControl(btnGuardar, 20);
            RedondearControl(btnCancelar, 20);

            RedondearControl(panelGerminacion, 15);
            RedondearControl(panelVegetacion, 15);
            RedondearControl(panelFloracion, 15);
        }

        private void TraducirInterfaz()
        {
            this.Text = _idiomaBLL.Traducir("form_plan_titulo");
            lblTituloPrincipal.Text = _idiomaBLL.Traducir("lbl_titulo_principal");
            lblNombrePlan.Text = _idiomaBLL.Traducir("lbl_nombre_plan");

            txtNombrePlan.WaterMark = _idiomaBLL.Traducir("prompt_ejemplo_plan");
            txtNombrePlan.WaterMark = _idiomaBLL.Traducir("prompt_ejemplo_plan");

            lblFecha.Text = _idiomaBLL.Traducir("lbl_fecha_inicio");
            btnGuardar.Text = _idiomaBLL.Traducir("btn_guardar_plan");
            btnCancelar.Text = _idiomaBLL.Traducir("btn_cancelar");
        }

        private void CrearControlesEtapa(Panel panel, Label lblTitulo, string tituloTexto, int index)
        {
            lblTitulo.Text = tituloTexto;
            lblTitulo.ForeColor = Color.FromArgb(76, 175, 80); 

            
            string[] labels = {
                _idiomaBLL.Traducir("param_duracion"),
                _idiomaBLL.Traducir("param_temp_min"),
                _idiomaBLL.Traducir("param_temp_max"),
                _idiomaBLL.Traducir("param_hum_min"),
                _idiomaBLL.Traducir("param_hum_max"),
                _idiomaBLL.Traducir("param_ph_min"),
                _idiomaBLL.Traducir("param_ph_max"),
                _idiomaBLL.Traducir("param_ec_min"),
                _idiomaBLL.Traducir("param_ec_max")
            };

            // Definimos claves internas para poder recuperar los datos después
            // no traduzco, sino para logica interna
            string[] suffixes = {
                "Duracion", "TempMin", "TempMax", "HumMin", "HumMax", "PhMin", "PhMax", "EcMin", "EcMax"
            };

            int y = 60; 

            for (int i = 0; i < labels.Length; i++)
            {
                string labelText = labels[i];
                string internalSuffix = suffixes[i];

                Label lbl = new Label();
                lbl.Text = labelText;
                lbl.Location = new Point(20, y);
                lbl.AutoSize = true;
                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                lbl.ForeColor = Color.DimGray;
                panel.Controls.Add(lbl);

                MetroTextBox txt = new MetroTextBox();
                txt.Location = new Point(140, y - 3);
                txt.Size = new Size(120, 25);
                txt.FontSize = MetroTextBoxSize.Medium;

                string prefijo = index == 1 ? "Ger" : (index == 2 ? "Veg" : "Flo");

                txt.Name = $"txt_{prefijo}_{internalSuffix}";

                panel.Controls.Add(txt);

                y += 35;
            }
        }

        //redondear
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                PlanCultivo nuevoPlan = new PlanCultivo();
                nuevoPlan.NombrePlan = txtNombrePlan.Text;
                nuevoPlan.FechaInicio = dtpFechaInicio.Value;
                nuevoPlan.Estado = "Activo";

                nuevoPlan.Etapas = new System.Collections.Generic.List<EtapaCultivo>();

               

                // Etapa 1: Germinación
                var etapaGerm = ObtenerEtapaDelPanel(this.panelGerminacion, "Ger", "Germinación", 1);
                nuevoPlan.Etapas.Add(etapaGerm);

                // Etapa 2: Vegetación
                var etapaVeg = ObtenerEtapaDelPanel(this.panelVegetacion, "Veg", "Vegetación", 2);
                nuevoPlan.Etapas.Add(etapaVeg);

                // Etapa 3: Floración
                var etapaFlor = ObtenerEtapaDelPanel(this.panelFloracion, "Flo", "Floración", 3);
                nuevoPlan.Etapas.Add(etapaFlor);

                // 3. Llamar a la BLL
                PlanCultivoBLL bll = new PlanCultivoBLL();

                int usuarioID = _sessionService.UsuarioLogueado.IdUsuario;
                bll.GuardarPlan(nuevoPlan, usuarioID);

                // 4. Feedback al usuario
                string mensajeExito = _idiomaBLL.Traducir("msg_plan_guardado") ?? "Plan guardado correctamente"; // Fallback por si no hay traducción
                string tituloExito = _idiomaBLL.Traducir("titulo_exito") ?? "Éxito";

                MetroMessageBox.Show(this, mensajeExito, tituloExito, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (FormatException)
            {
                MetroMessageBox.Show(this, "Por favor revise que todos los campos numéricos tengan valores válidos.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private EtapaCultivo ObtenerEtapaDelPanel(Panel panel, string prefijo, string nombreEtapa, int orden)
        {
            EtapaCultivo etapa = new EtapaCultivo();
            etapa.NombreEtapa = nombreEtapa;
            etapa.Orden = orden;

            

            etapa.Duracion = int.Parse(panel.Controls[$"txt_{prefijo}_Duracion"].Text);

            etapa.TempMin = decimal.Parse(panel.Controls[$"txt_{prefijo}_TempMin"].Text);
            etapa.TempMax = decimal.Parse(panel.Controls[$"txt_{prefijo}_TempMax"].Text);

            etapa.HumMin = decimal.Parse(panel.Controls[$"txt_{prefijo}_HumMin"].Text);
            etapa.HumMax = decimal.Parse(panel.Controls[$"txt_{prefijo}_HumMax"].Text);

            etapa.PhMin = decimal.Parse(panel.Controls[$"txt_{prefijo}_PhMin"].Text);
            etapa.PhMax = decimal.Parse(panel.Controls[$"txt_{prefijo}_PhMax"].Text);

            etapa.EcMin = decimal.Parse(panel.Controls[$"txt_{prefijo}_EcMin"].Text);
            etapa.EcMax = decimal.Parse(panel.Controls[$"txt_{prefijo}_EcMax"].Text);

            return etapa;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AgregarPlanCultivoForm_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}