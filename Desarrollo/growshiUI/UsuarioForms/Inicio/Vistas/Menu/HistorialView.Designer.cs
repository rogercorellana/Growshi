namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    partial class HistorialView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            this.pnlHeader = new MetroFramework.Controls.MetroPanel();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.pnlFiltros = new MetroFramework.Controls.MetroPanel();
            this.btnLimpiar = new MetroFramework.Controls.MetroButton();
            this.lblHasta = new MetroFramework.Controls.MetroLabel();
            this.dtpHasta = new MetroFramework.Controls.MetroDateTime();
            this.lblDesde = new MetroFramework.Controls.MetroLabel();
            this.dtpDesde = new MetroFramework.Controls.MetroDateTime();
            this.cmbNivel = new MetroFramework.Controls.MetroComboBox();
            this.txtBuscar = new MetroFramework.Controls.MetroTextBox();
            this.flowLista = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeader.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.HorizontalScrollbarBarColor = true;
            this.pnlHeader.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlHeader.HorizontalScrollbarSize = 10;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(850, 60);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.VerticalScrollbarBarColor = true;
            this.pnlHeader.VerticalScrollbarHighlightOnWheel = false;
            this.pnlHeader.VerticalScrollbarSize = 10;
            // 
            // lblTitulo
            // 
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.Location = new System.Drawing.Point(15, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(386, 35);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Monitor de Eventos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.btnLimpiar);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.cmbNivel);
            this.pnlFiltros.Controls.Add(this.txtBuscar);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.HorizontalScrollbarBarColor = true;
            this.pnlFiltros.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlFiltros.HorizontalScrollbarSize = 10;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 60);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(850, 70);
            this.pnlFiltros.TabIndex = 1;
            this.pnlFiltros.VerticalScrollbarBarColor = true;
            this.pnlFiltros.VerticalScrollbarHighlightOnWheel = false;
            this.pnlFiltros.VerticalScrollbarSize = 10;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(740, 24);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(80, 29);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Restaurar";
            this.btnLimpiar.UseSelectable = true;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblHasta.Location = new System.Drawing.Point(580, 5);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(39, 15);
            this.lblHasta.TabIndex = 7;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(580, 24);
            this.dtpHasta.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(140, 25);
            this.dtpHasta.TabIndex = 6;
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblDesde.Location = new System.Drawing.Point(420, 5);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(42, 15);
            this.lblDesde.TabIndex = 5;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(420, 24);
            this.dtpDesde.MinimumSize = new System.Drawing.Size(0, 25);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(140, 25);
            this.dtpDesde.TabIndex = 4;
            // 
            // cmbNivel
            // 
            this.cmbNivel.FormattingEnabled = true;
            this.cmbNivel.ItemHeight = 23;
            this.cmbNivel.Location = new System.Drawing.Point(231, 24);
            this.cmbNivel.Name = "cmbNivel";
            this.cmbNivel.PromptText = "Nivel de Criticidad";
            this.cmbNivel.Size = new System.Drawing.Size(170, 29);
            this.cmbNivel.TabIndex = 2;
            this.cmbNivel.UseSelectable = true;
            // 
            // txtBuscar
            // 
            // 
            // 
            // 
            this.txtBuscar.CustomButton.Image = null;
            this.txtBuscar.CustomButton.Location = new System.Drawing.Point(182, 1);
            this.txtBuscar.CustomButton.Name = "";
            this.txtBuscar.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtBuscar.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtBuscar.CustomButton.TabIndex = 1;
            this.txtBuscar.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtBuscar.CustomButton.UseSelectable = true;
            this.txtBuscar.CustomButton.Visible = false;
            this.txtBuscar.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtBuscar.Lines = new string[0];
            this.txtBuscar.Location = new System.Drawing.Point(15, 24);
            this.txtBuscar.MaxLength = 32767;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.PromptText = "🔍 Buscar por módulo o mensaje...";
            this.txtBuscar.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.SelectionLength = 0;
            this.txtBuscar.SelectionStart = 0;
            this.txtBuscar.ShortcutsEnabled = true;
            this.txtBuscar.Size = new System.Drawing.Size(210, 29);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.UseSelectable = true;
            this.txtBuscar.WaterMark = "🔍 Buscar por módulo o mensaje...";
            this.txtBuscar.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtBuscar.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // flowLista
            // 
            this.flowLista.AutoScroll = true;
            this.flowLista.BackColor = System.Drawing.Color.White;
            this.flowLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLista.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLista.Location = new System.Drawing.Point(0, 130);
            this.flowLista.Name = "flowLista";
            this.flowLista.Padding = new System.Windows.Forms.Padding(10);
            this.flowLista.Size = new System.Drawing.Size(850, 470);
            this.flowLista.TabIndex = 2;
            this.flowLista.WrapContents = false;
            // 
            // HistorialView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLista);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlHeader);
            this.Name = "HistorialView";
            this.Size = new System.Drawing.Size(850, 600);
            this.pnlHeader.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlHeader;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private MetroFramework.Controls.MetroPanel pnlFiltros;
        private MetroFramework.Controls.MetroTextBox txtBuscar;
        private MetroFramework.Controls.MetroComboBox cmbNivel;
        private MetroFramework.Controls.MetroLabel lblHasta;
        private MetroFramework.Controls.MetroDateTime dtpHasta;
        private MetroFramework.Controls.MetroLabel lblDesde;
        private MetroFramework.Controls.MetroDateTime dtpDesde;
        private MetroFramework.Controls.MetroButton btnLimpiar;
        private System.Windows.Forms.FlowLayoutPanel flowLista;
    }
}