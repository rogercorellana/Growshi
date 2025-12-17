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
using Services; // Necesario para IdiomaService

namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanta
{
    public partial class AgregarPlantaForm : MetroForm
    {
        #region Propiedades y Servicios

        private int _slotIdSeleccionado;

        // BLLs
        private PlanCultivoBLL _planCultivoBLL;
        private PlantaBLL _plantaBLL;
        private IdiomaBLL _idiomaBLL;

        #endregion

        #region Constructores e Inicialización

        public AgregarPlantaForm()
        {
            InitializeComponent();
            InicializarServicios();
            ConfigurarVentana();
        }

        public AgregarPlantaForm(int slotID) : this()
        {
            this._slotIdSeleccionado = slotID;

            // Título específico para cuando se abre desde un slot
            string formato = _idiomaBLL.Traducir("AgregarPlanta_Titulo_Slot");
            this.Text = string.Format(formato, slotID);

            // Ocultamos el título interno si el del form ya lo dice
            if (lblTitulo != null) lblTitulo.Visible = false;
        }

        private void InicializarServicios()
        {
            _planCultivoBLL = new PlanCultivoBLL();
            _plantaBLL = new PlantaBLL();
            _idiomaBLL = new IdiomaBLL();
        }

        private void AgregarPlantaForm_Load(object sender, EventArgs e)
        {
            ConfigurarEstilos();

            // Suscripción al cambio de idioma en caliente
            IdiomaService.GetInstance().IdiomaCambiado += TraducirInterfaz;

            // 1. Traducir textos
            TraducirInterfaz();

            // 2. Cargar datos
            ListarPlanCultivo();
            ListarPlantas();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            // Desuscripción vital para evitar fugas de memoria
            IdiomaService.GetInstance().IdiomaCambiado -= TraducirInterfaz;
            base.OnHandleDestroyed(e);
        }

        #endregion

        #region Gestión de Idioma

        private void TraducirInterfaz()
        {
            if (this.InvokeRequired) { this.Invoke(new Action(TraducirInterfaz)); return; }

            // Si es constructor por defecto (sin slot), título genérico
            if (_slotIdSeleccionado == 0)
                this.Text = _idiomaBLL.Traducir("AgregarPlanta_Titulo_Default");
            else
                this.Text = string.Format(_idiomaBLL.Traducir("AgregarPlanta_Titulo_Slot"), _slotIdSeleccionado);

            // Labels y Botones
            lblTitulo.Text = _idiomaBLL.Traducir("AgregarPlanta_Lbl_TituloMain");
            lblNombre.Text = _idiomaBLL.Traducir("AgregarPlanta_Lbl_Nombre");
            lblPlan.Text = _idiomaBLL.Traducir("AgregarPlanta_Lbl_Plan");
            btnGuardar.Text = _idiomaBLL.Traducir("AgregarPlanta_Btn_Guardar");
            lnkNuevoPlan.Text = _idiomaBLL.Traducir("AgregarPlanta_Lnk_NuevoPlan");

            // Refrescar columnas de la grilla con los nuevos textos
            ConfigurarColumnasGrid();
        }

        #endregion

        #region Configuración Visual (Estilos)

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
        }

        private void ConfigurarEstilos()
        {
            DarVidaAlGrid(metroGridPlantas);
            RedondearControl(panelTarjeta, 25);
            RedondearControl(btnGuardar, 20);
        }

        private void ConfigurarColumnasGrid()
        {
            metroGridPlantas.Columns.Clear();

            metroGridPlantas.Columns.Add("ID", "ID");
            metroGridPlantas.Columns["ID"].Visible = false; // Ocultar ID generalmente es mejor

            metroGridPlantas.Columns.Add("Nombre", _idiomaBLL.Traducir("AgregarPlanta_Col_Nombre"));
            metroGridPlantas.Columns.Add("Plan", _idiomaBLL.Traducir("AgregarPlanta_Col_Plan"));
            metroGridPlantas.Columns.Add("FechaInicio", _idiomaBLL.Traducir("AgregarPlanta_Col_Fecha"));

            // Recargar datos para que se vean en las columnas nuevas
            ListarPlantas();
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

        private void ABMPlanta_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        #endregion

        #region Lógica de Datos

        private void ListarPlantas()
        {
            metroGridPlantas.Rows.Clear();
            List<Planta> lista = _plantaBLL.Listar();

            foreach (Planta p in lista)
            {
                metroGridPlantas.Rows.Add(p.PlantaID, p.Nombre, p.NombrePlan, p.FechaInicio.ToShortDateString());
            }
        }

        private void ListarPlanCultivo()
        {
            cmbPlanCultivo.DataSource = null;
            cmbPlanCultivo.Items.Clear();

            List<PlanCultivo> listaPlanes = _planCultivoBLL.Listar();

            cmbPlanCultivo.DataSource = listaPlanes;
            cmbPlanCultivo.DisplayMember = "NombrePlan";
            cmbPlanCultivo.ValueMember = "PlanCultivoID";
        }

        #endregion

        #region Eventos y Acciones

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string tituloAtencion = _idiomaBLL.Traducir("Global_Titulo_Atencion");

            if (string.IsNullOrEmpty(txtNombrePlanta.Text))
            {
                MetroMessageBox.Show(this, _idiomaBLL.Traducir("AgregarPlanta_Msg_FaltaNombre"), tituloAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPlanCultivo.SelectedItem == null)
            {
                MetroMessageBox.Show(this, _idiomaBLL.Traducir("AgregarPlanta_Msg_FaltaPlan"), tituloAtencion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                _plantaBLL.GuardarNuevaSiembra(nuevaPlanta, _slotIdSeleccionado);

                string tituloExito = _idiomaBLL.Traducir("Global_Titulo_Exito");
                string formatoMensaje = _idiomaBLL.Traducir("AgregarPlanta_Msg_Exito");
                string mensajeFinal = string.Format(formatoMensaje, nuevaPlanta.Nombre, _slotIdSeleccionado);

                MetroMessageBox.Show(this, mensajeFinal, tituloExito, MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                string tituloError = _idiomaBLL.Traducir("Global_Titulo_Error");
                MetroMessageBox.Show(this, ex.Message, tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkNuevoPlan_Click(object sender, EventArgs e)
        {
            // Ventana modal temporal simulando redirección
            string msg = _idiomaBLL.Traducir("AgregarPlanta_Msg_Redirigiendo");

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

                Timer timer = new Timer();
                timer.Interval = 500;
                timer.Tick += (s, ev) =>
                {
                    timer.Stop();
                    mensajeForm.Close();
                };
                timer.Start();

                mensajeForm.ShowDialog();
            }

            // Flujo de navegación
            AgregarPlanCultivoForm planCultivoForm = new AgregarPlanCultivoForm();
            this.Hide();
            planCultivoForm.ShowDialog();

            // Al volver
            ListarPlanCultivo();
            this.Show();
        }

        #endregion
    }
}