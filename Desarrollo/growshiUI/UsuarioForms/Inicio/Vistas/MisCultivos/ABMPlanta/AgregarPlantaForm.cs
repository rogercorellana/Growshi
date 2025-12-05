using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BE;
using BLL;
using growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanCultivo;
using MetroFramework;
using MetroFramework.Forms;

namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanta
{
    public partial class AgregarPlantaForm : MetroForm
    {
        #region Campos y Constructores

        private int _slotIdSeleccionado;
        private PlanCultivoBLL planCultivoBll = new PlanCultivoBLL();
        private PlantaBLL plantaBll = new PlantaBLL();

        // Servicio de traducción
        private IdiomaBLL _idiomaBLL = new IdiomaBLL();

        public AgregarPlantaForm()
        {
            InitializeComponent();
            ConfigurarVentana();
        }

        public AgregarPlantaForm(int slotID) : this()
        {
            this._slotIdSeleccionado = slotID;

            // Título dinámico traducido
            string formatoTitulo = _idiomaBLL.Traducir("titulo_asignando_slot");
            this.Text = string.Format(formatoTitulo, slotID);

            if (lblTitulo != null) lblTitulo.Visible = false;
        }

        #endregion

        #region Configuración Inicial

        private void AgregarPlantaForm_Load(object sender, EventArgs e)
        {
            ConfigurarEstilos();

            // 0. Traducir textos estáticos
            TraducirInterfaz();

            // 1. PRIMERO: Definimos las columnas (Ahora traducidas)
            ConfigurarColumnasGrid();

            // 2. SEGUNDO: Cargamos los combos
            ListarPlanCultivo();

            // 3. TERCERO: Llenamos la grilla
            ListarPlantas();
        }

        private void TraducirInterfaz()
        {
            // Si se usó el constructor por defecto, ponemos el título genérico
            if (_slotIdSeleccionado == 0)
                this.Text = _idiomaBLL.Traducir("form_agregar_planta_titulo");

            lblTitulo.Text = _idiomaBLL.Traducir("lbl_asignacion_planta");
            lblNombre.Text = _idiomaBLL.Traducir("lbl_nombre_planta_campo");
            lblPlan.Text = _idiomaBLL.Traducir("lbl_plan_cultivo_campo");
            btnGuardar.Text = _idiomaBLL.Traducir("btn_guardar_planta");
            lnkNuevoPlan.Text = _idiomaBLL.Traducir("lnk_crear_nuevo_plan");
        }

        private void ConfigurarVentana()
        {
            this.Resizable = false;
            this.Movable = true;
            this.ControlBox = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShadowType = MetroFormShadowType.AeroShadow;
            this.Style = MetroColorStyle.Green;
            this.StartPosition = FormStartPosition.CenterParent;
            // El texto se setea en Load o Constructor
        }

        private void ConfigurarEstilos()
        {
            DarVidaAlGrid(metroGridPlantas);
            RedondearControl(panelTarjeta, 25);
            RedondearControl(btnGuardar, 20);
        }

        #endregion

        #region Métodos Visuales 

        private void ConfigurarColumnasGrid()
        {
            metroGridPlantas.Columns.Clear();

            // Agregamos las columnas con encabezados traducidos
            metroGridPlantas.Columns.Add("ID", "ID");

            // Usamos _idiomaBLL para los encabezados visibles
            metroGridPlantas.Columns.Add("Nombre", _idiomaBLL.Traducir("col_nombre_planta"));
            metroGridPlantas.Columns.Add("Plan", _idiomaBLL.Traducir("col_plan_asignado"));

            // Opcional: Ocultar la columna ID
            // metroGridPlantas.Columns[0].Visible = false; 
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

        private void DarVidaAlGrid(MetroFramework.Controls.MetroGrid grid)
        {
            grid.BackgroundColor = Color.White;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(224, 224, 224);

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 125, 50);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 40;

            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 252, 245);
            grid.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 201);
            grid.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            grid.RowTemplate.Height = 35;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.ReadOnly = true;
        }

        #endregion

        #region Lógica de Datos

        private void ListarPlantas()
        {
            metroGridPlantas.Rows.Clear();
            List<Planta> lista = plantaBll.Listar();

            foreach (Planta p in lista)
            {
                metroGridPlantas.Rows.Add(p.PlantaID, p.Nombre, p.NombrePlan);
            }
        }

        private void ListarPlanCultivo()
        {
            cmbPlanCultivo.DataSource = null;
            cmbPlanCultivo.Items.Clear();

            List<PlanCultivo> listaPlanes = planCultivoBll.Listar();

            cmbPlanCultivo.DataSource = listaPlanes;
            cmbPlanCultivo.DisplayMember = "NombrePlan";
            cmbPlanCultivo.ValueMember = "PlanCultivoID";
        }

        #endregion

        #region Eventos

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string tituloAtencion = _idiomaBLL.Traducir("titulo_atencion");

            if (string.IsNullOrEmpty(txtNombrePlanta.Text))
            {
                string msg = _idiomaBLL.Traducir("msg_falta_nombre_planta");
                MetroMessageBox.Show(this, msg, tituloAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPlanCultivo.SelectedItem == null)
            {
                string msg = _idiomaBLL.Traducir("msg_falta_plan");
                MetroMessageBox.Show(this, msg, tituloAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PlanCultivo planSeleccionado = (PlanCultivo)cmbPlanCultivo.SelectedItem;

                Planta nuevaPlanta = new Planta
                {
                    Nombre = txtNombrePlanta.Text,
                    PlanCultivoID = planSeleccionado.PlanCultivoID
                };

                plantaBll.GuardarNuevaSiembra(nuevaPlanta, _slotIdSeleccionado);

                string tituloExito = _idiomaBLL.Traducir("titulo_exito");
                string formatoMensaje = _idiomaBLL.Traducir("msg_planta_guardada_formato");
                string mensajeFinal = string.Format(formatoMensaje, nuevaPlanta.Nombre, _slotIdSeleccionado);

                MetroMessageBox.Show(this, mensajeFinal, tituloExito, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                string tituloError = _idiomaBLL.Traducir("titulo_error");
                MetroMessageBox.Show(this, ex.Message, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkNuevoPlan_Click(object sender, EventArgs e)
        {
            string msg = _idiomaBLL.Traducir("msg_redirigiendo_plan");

            #region VENTANA DE 0.5 SEGUNDOS DE REDIRECCIONAMIENTO
            using (Form mensajeForm = new Form())
            {
                mensajeForm.FormBorderStyle = FormBorderStyle.None;
                mensajeForm.StartPosition = FormStartPosition.CenterScreen;
                mensajeForm.Size = new Size(320, 110);
                mensajeForm.BackColor = Color.FromArgb(0, 174, 219); 
                mensajeForm.TopMost = true; 

                Label lbl = new Label();
                lbl.Text = msg;
                lbl.ForeColor = Color.White;
                lbl.Dock = DockStyle.Fill;
                lbl.TextAlign = ContentAlignment.MiddleCenter; 
                lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                mensajeForm.Controls.Add(lbl);

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 500;
                timer.Tick += (s, ev) =>
                {
                    timer.Stop();
                    mensajeForm.Close(); 
                };
                timer.Start();

                mensajeForm.ShowDialog();
            }
            #endregion

            AgregarPlanCultivoForm planCultivoForm = new AgregarPlanCultivoForm();

            this.Hide(); 
            planCultivoForm.ShowDialog(); 

            ListarPlanCultivo();
            this.Show(); 
        }

        private void ABMPlanta_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        #endregion
    }
}