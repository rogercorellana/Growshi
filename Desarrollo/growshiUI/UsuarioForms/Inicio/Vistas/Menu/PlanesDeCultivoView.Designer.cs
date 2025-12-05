namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    partial class PlanesDeCultivoView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlIzquierdo = new MetroFramework.Controls.MetroPanel();
            this.gridPlanes = new MetroFramework.Controls.MetroGrid();
            this.colPlanNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBotones = new MetroFramework.Controls.MetroPanel();
            this.btnEliminar = new MetroFramework.Controls.MetroButton();
            this.btnExportar = new MetroFramework.Controls.MetroButton();
            this.btnEditar = new MetroFramework.Controls.MetroButton();
            this.btnNuevo = new MetroFramework.Controls.MetroButton();
            this.lblTituloPlanes = new MetroFramework.Controls.MetroLabel();
            this.pnlDerecho = new MetroFramework.Controls.MetroPanel();
            this.tlpDerecho = new System.Windows.Forms.TableLayoutPanel();
            this.gridEtapas = new MetroFramework.Controls.MetroGrid();
            this.pnlDetalleFicha = new MetroFramework.Controls.MetroPanel();
            this.lblInfoPh = new MetroFramework.Controls.MetroLabel();
            this.lblInfoHum = new MetroFramework.Controls.MetroLabel();
            this.lblInfoTemp = new MetroFramework.Controls.MetroLabel();
            this.lblTituloFicha = new MetroFramework.Controls.MetroLabel();
            this.lblTituloDetalle = new MetroFramework.Controls.MetroLabel();
            this.tlpPrincipal.SuspendLayout();
            this.pnlIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanes)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.pnlDerecho.SuspendLayout();
            this.tlpDerecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEtapas)).BeginInit();
            this.pnlDetalleFicha.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 2;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpPrincipal.Controls.Add(this.pnlIzquierdo, 0, 0);
            this.tlpPrincipal.Controls.Add(this.pnlDerecho, 1, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 1;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Size = new System.Drawing.Size(948, 623);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // pnlIzquierdo
            // 
            this.pnlIzquierdo.Controls.Add(this.gridPlanes);
            this.pnlIzquierdo.Controls.Add(this.pnlBotones);
            this.pnlIzquierdo.Controls.Add(this.lblTituloPlanes);
            this.pnlIzquierdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIzquierdo.HorizontalScrollbarBarColor = true;
            this.pnlIzquierdo.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlIzquierdo.HorizontalScrollbarSize = 10;
            this.pnlIzquierdo.Location = new System.Drawing.Point(3, 3);
            this.pnlIzquierdo.Name = "pnlIzquierdo";
            this.pnlIzquierdo.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlIzquierdo.Size = new System.Drawing.Size(278, 617);
            this.pnlIzquierdo.TabIndex = 0;
            this.pnlIzquierdo.VerticalScrollbarBarColor = true;
            this.pnlIzquierdo.VerticalScrollbarHighlightOnWheel = false;
            this.pnlIzquierdo.VerticalScrollbarSize = 10;
            // 
            // gridPlanes
            // 
            this.gridPlanes.AllowUserToAddRows = false;
            this.gridPlanes.AllowUserToDeleteRows = false;
            this.gridPlanes.AllowUserToResizeRows = false;
            this.gridPlanes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridPlanes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridPlanes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridPlanes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPlanes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridPlanes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPlanes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlanNombre});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPlanes.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPlanes.EnableHeadersVisualStyles = false;
            this.gridPlanes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridPlanes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridPlanes.Location = new System.Drawing.Point(0, 25);
            this.gridPlanes.MultiSelect = false;
            this.gridPlanes.Name = "gridPlanes";
            this.gridPlanes.ReadOnly = true;
            this.gridPlanes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPlanes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridPlanes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridPlanes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPlanes.Size = new System.Drawing.Size(268, 452);
            this.gridPlanes.Style = MetroFramework.MetroColorStyle.Green;
            this.gridPlanes.TabIndex = 2;
            this.gridPlanes.UseStyleColors = true;
            // 
            // colPlanNombre
            // 
            this.colPlanNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPlanNombre.DataPropertyName = "NombrePlan";
            this.colPlanNombre.HeaderText = "Plan";
            this.colPlanNombre.Name = "colPlanNombre";
            this.colPlanNombre.ReadOnly = true;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Controls.Add(this.btnExportar);
            this.pnlBotones.Controls.Add(this.btnEditar);
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.HorizontalScrollbarBarColor = true;
            this.pnlBotones.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlBotones.HorizontalScrollbarSize = 10;
            this.pnlBotones.Location = new System.Drawing.Point(0, 477);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(268, 140);
            this.pnlBotones.TabIndex = 3;
            this.pnlBotones.VerticalScrollbarBarColor = true;
            this.pnlBotones.VerticalScrollbarHighlightOnWheel = false;
            this.pnlBotones.VerticalScrollbarSize = 10;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEliminar.Location = new System.Drawing.Point(0, 90);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(268, 30);
            this.btnEliminar.Style = MetroFramework.MetroColorStyle.Red;
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseSelectable = true;
            this.btnEliminar.UseStyleColors = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExportar.Location = new System.Drawing.Point(0, 60);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(268, 30);
            this.btnExportar.TabIndex = 5;
            this.btnExportar.Text = "Exportar a PDF";
            this.btnExportar.UseSelectable = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEditar.Location = new System.Drawing.Point(0, 30);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(268, 30);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Modificar";
            this.btnEditar.UseSelectable = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevo.Location = new System.Drawing.Point(0, 0);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(268, 30);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "Agregar Nuevo Plan";
            this.btnNuevo.UseSelectable = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblTituloPlanes
            // 
            this.lblTituloPlanes.AutoSize = true;
            this.lblTituloPlanes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPlanes.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTituloPlanes.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTituloPlanes.Location = new System.Drawing.Point(0, 0);
            this.lblTituloPlanes.Name = "lblTituloPlanes";
            this.lblTituloPlanes.Size = new System.Drawing.Size(193, 25);
            this.lblTituloPlanes.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTituloPlanes.TabIndex = 2;
            this.lblTituloPlanes.Text = "Mis Planes de Cultivo";
            this.lblTituloPlanes.UseStyleColors = true;
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.Controls.Add(this.tlpDerecho);
            this.pnlDerecho.Controls.Add(this.lblTituloDetalle);
            this.pnlDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDerecho.HorizontalScrollbarBarColor = true;
            this.pnlDerecho.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlDerecho.HorizontalScrollbarSize = 10;
            this.pnlDerecho.Location = new System.Drawing.Point(287, 3);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pnlDerecho.Size = new System.Drawing.Size(658, 617);
            this.pnlDerecho.TabIndex = 1;
            this.pnlDerecho.VerticalScrollbarBarColor = true;
            this.pnlDerecho.VerticalScrollbarHighlightOnWheel = false;
            this.pnlDerecho.VerticalScrollbarSize = 10;
            // 
            // tlpDerecho
            // 
            this.tlpDerecho.ColumnCount = 1;
            this.tlpDerecho.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDerecho.Controls.Add(this.gridEtapas, 0, 0);
            this.tlpDerecho.Controls.Add(this.pnlDetalleFicha, 0, 1);
            this.tlpDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDerecho.Location = new System.Drawing.Point(10, 25);
            this.tlpDerecho.Name = "tlpDerecho";
            this.tlpDerecho.RowCount = 2;
            this.tlpDerecho.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDerecho.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDerecho.Size = new System.Drawing.Size(648, 592);
            this.tlpDerecho.TabIndex = 4;
            // 
            // gridEtapas
            // 
            this.gridEtapas.AllowUserToAddRows = false;
            this.gridEtapas.AllowUserToDeleteRows = false;
            this.gridEtapas.AllowUserToResizeRows = false;
            this.gridEtapas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridEtapas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridEtapas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridEtapas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridEtapas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEtapas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridEtapas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridEtapas.DefaultCellStyle = dataGridViewCellStyle5;
            this.gridEtapas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEtapas.EnableHeadersVisualStyles = false;
            this.gridEtapas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridEtapas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridEtapas.Location = new System.Drawing.Point(3, 3);
            this.gridEtapas.MultiSelect = false;
            this.gridEtapas.Name = "gridEtapas";
            this.gridEtapas.ReadOnly = true;
            this.gridEtapas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEtapas.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridEtapas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridEtapas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEtapas.Size = new System.Drawing.Size(642, 290);
            this.gridEtapas.Style = MetroFramework.MetroColorStyle.Green;
            this.gridEtapas.TabIndex = 3;
            this.gridEtapas.UseStyleColors = true;
            // 
            // pnlDetalleFicha
            // 
            this.pnlDetalleFicha.Controls.Add(this.lblInfoPh);
            this.pnlDetalleFicha.Controls.Add(this.lblInfoHum);
            this.pnlDetalleFicha.Controls.Add(this.lblInfoTemp);
            this.pnlDetalleFicha.Controls.Add(this.lblTituloFicha);
            this.pnlDetalleFicha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalleFicha.HorizontalScrollbarBarColor = true;
            this.pnlDetalleFicha.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlDetalleFicha.HorizontalScrollbarSize = 10;
            this.pnlDetalleFicha.Location = new System.Drawing.Point(3, 299);
            this.pnlDetalleFicha.Name = "pnlDetalleFicha";
            this.pnlDetalleFicha.Size = new System.Drawing.Size(642, 290);
            this.pnlDetalleFicha.TabIndex = 4;
            this.pnlDetalleFicha.VerticalScrollbarBarColor = true;
            this.pnlDetalleFicha.VerticalScrollbarHighlightOnWheel = false;
            this.pnlDetalleFicha.VerticalScrollbarSize = 10;
            // 
            // lblInfoPh
            // 
            this.lblInfoPh.AutoSize = true;
            this.lblInfoPh.Location = new System.Drawing.Point(10, 105);
            this.lblInfoPh.Name = "lblInfoPh";
            this.lblInfoPh.Size = new System.Drawing.Size(49, 19);
            this.lblInfoPh.TabIndex = 5;
            this.lblInfoPh.Text = "pH: -- ";
            // 
            // lblInfoHum
            // 
            this.lblInfoHum.AutoSize = true;
            this.lblInfoHum.Location = new System.Drawing.Point(10, 75);
            this.lblInfoHum.Name = "lblInfoHum";
            this.lblInfoHum.Size = new System.Drawing.Size(101, 19);
            this.lblInfoHum.TabIndex = 4;
            this.lblInfoHum.Text = "Humedad: -- %";
            // 
            // lblInfoTemp
            // 
            this.lblInfoTemp.AutoSize = true;
            this.lblInfoTemp.Location = new System.Drawing.Point(10, 45);
            this.lblInfoTemp.Name = "lblInfoTemp";
            this.lblInfoTemp.Size = new System.Drawing.Size(120, 19);
            this.lblInfoTemp.TabIndex = 3;
            this.lblInfoTemp.Text = "Temperatura: -- °C";
            // 
            // lblTituloFicha
            // 
            this.lblTituloFicha.AutoSize = true;
            this.lblTituloFicha.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTituloFicha.Location = new System.Drawing.Point(10, 10);
            this.lblTituloFicha.Name = "lblTituloFicha";
            this.lblTituloFicha.Size = new System.Drawing.Size(174, 19);
            this.lblTituloFicha.TabIndex = 2;
            this.lblTituloFicha.Text = "Ficha Técnica de la Etapa";
            // 
            // lblTituloDetalle
            // 
            this.lblTituloDetalle.AutoSize = true;
            this.lblTituloDetalle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloDetalle.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTituloDetalle.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTituloDetalle.Location = new System.Drawing.Point(10, 0);
            this.lblTituloDetalle.Name = "lblTituloDetalle";
            this.lblTituloDetalle.Size = new System.Drawing.Size(133, 25);
            this.lblTituloDetalle.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTituloDetalle.TabIndex = 3;
            this.lblTituloDetalle.Text = "Detalle Etapas";
            this.lblTituloDetalle.UseStyleColors = true;
            // 
            // PlanesDeCultivoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpPrincipal);
            this.Name = "PlanesDeCultivoView";
            this.Size = new System.Drawing.Size(948, 623);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlIzquierdo.ResumeLayout(false);
            this.pnlIzquierdo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPlanes)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.pnlDerecho.ResumeLayout(false);
            this.pnlDerecho.PerformLayout();
            this.tlpDerecho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEtapas)).EndInit();
            this.pnlDetalleFicha.ResumeLayout(false);
            this.pnlDetalleFicha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        #region Declaracion de Controles
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private MetroFramework.Controls.MetroPanel pnlIzquierdo;
        private MetroFramework.Controls.MetroPanel pnlDerecho;
        private System.Windows.Forms.TableLayoutPanel tlpDerecho;

        // Izquierda
        private MetroFramework.Controls.MetroLabel lblTituloPlanes;
        private MetroFramework.Controls.MetroGrid gridPlanes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlanNombre;
        private MetroFramework.Controls.MetroPanel pnlBotones;
        private MetroFramework.Controls.MetroButton btnNuevo;
        private MetroFramework.Controls.MetroButton btnEditar;
        private MetroFramework.Controls.MetroButton btnExportar; // NUEVO
        private MetroFramework.Controls.MetroButton btnEliminar;

        // Derecha
        private MetroFramework.Controls.MetroLabel lblTituloDetalle;
        private MetroFramework.Controls.MetroGrid gridEtapas;

        // Panel Inferior
        private MetroFramework.Controls.MetroPanel pnlDetalleFicha;
        private MetroFramework.Controls.MetroLabel lblTituloFicha;
        private MetroFramework.Controls.MetroLabel lblInfoTemp;
        private MetroFramework.Controls.MetroLabel lblInfoHum;
        private MetroFramework.Controls.MetroLabel lblInfoPh;
        #endregion
    }
}