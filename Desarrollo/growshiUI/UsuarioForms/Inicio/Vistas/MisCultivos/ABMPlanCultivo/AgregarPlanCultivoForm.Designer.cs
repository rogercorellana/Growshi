namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanCultivo
{
    partial class AgregarPlanCultivoForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanelEtapas = new System.Windows.Forms.TableLayoutPanel();
            this.panelGerminacion = new System.Windows.Forms.Panel();
            this.lblTituloGerm = new System.Windows.Forms.Label();
            this.panelVegetacion = new System.Windows.Forms.Panel();
            this.lblTituloVeg = new System.Windows.Forms.Label();
            this.panelFloracion = new System.Windows.Forms.Panel();
            this.lblTituloFlor = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.dtpFechaInicio = new MetroFramework.Controls.MetroDateTime();
            this.lblFecha = new MetroFramework.Controls.MetroLabel();
            this.txtNombrePlan = new MetroFramework.Controls.MetroTextBox();
            this.lblNombrePlan = new MetroFramework.Controls.MetroLabel();
            this.lblTituloPrincipal = new MetroFramework.Controls.MetroLabel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.tableLayoutPanelEtapas.SuspendLayout();
            this.panelGerminacion.SuspendLayout();
            this.panelVegetacion.SuspendLayout();
            this.panelFloracion.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoScroll = true;
            this.panelMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelMain.Controls.Add(this.tableLayoutPanelEtapas);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.btnCancelar);
            this.panelMain.Controls.Add(this.btnGuardar);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(20, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1010, 570);
            this.panelMain.TabIndex = 0;
            // 
            // tableLayoutPanelEtapas
            // 
            this.tableLayoutPanelEtapas.ColumnCount = 3;
            this.tableLayoutPanelEtapas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelEtapas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelEtapas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanelEtapas.Controls.Add(this.panelGerminacion, 0, 0);
            this.tableLayoutPanelEtapas.Controls.Add(this.panelVegetacion, 1, 0);
            this.tableLayoutPanelEtapas.Controls.Add(this.panelFloracion, 2, 0);
            this.tableLayoutPanelEtapas.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelEtapas.Location = new System.Drawing.Point(0, 100);
            this.tableLayoutPanelEtapas.Name = "tableLayoutPanelEtapas";
            this.tableLayoutPanelEtapas.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanelEtapas.RowCount = 1;
            this.tableLayoutPanelEtapas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelEtapas.Size = new System.Drawing.Size(1010, 420);
            this.tableLayoutPanelEtapas.TabIndex = 1;
            // 
            // panelGerminacion
            // 
            this.panelGerminacion.BackColor = System.Drawing.Color.White;
            this.panelGerminacion.Controls.Add(this.lblTituloGerm);
            this.panelGerminacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGerminacion.Location = new System.Drawing.Point(20, 20);
            this.panelGerminacion.Margin = new System.Windows.Forms.Padding(10);
            this.panelGerminacion.Name = "panelGerminacion";
            this.panelGerminacion.Padding = new System.Windows.Forms.Padding(10);
            this.panelGerminacion.Size = new System.Drawing.Size(310, 400);
            this.panelGerminacion.TabIndex = 0;
            // 
            // lblTituloGerm
            // 
            this.lblTituloGerm.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloGerm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloGerm.Location = new System.Drawing.Point(10, 10);
            this.lblTituloGerm.Name = "lblTituloGerm";
            this.lblTituloGerm.Size = new System.Drawing.Size(290, 40);
            this.lblTituloGerm.TabIndex = 0;
            this.lblTituloGerm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelVegetacion
            // 
            this.panelVegetacion.BackColor = System.Drawing.Color.White;
            this.panelVegetacion.Controls.Add(this.lblTituloVeg);
            this.panelVegetacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVegetacion.Location = new System.Drawing.Point(350, 20);
            this.panelVegetacion.Margin = new System.Windows.Forms.Padding(10);
            this.panelVegetacion.Name = "panelVegetacion";
            this.panelVegetacion.Padding = new System.Windows.Forms.Padding(10);
            this.panelVegetacion.Size = new System.Drawing.Size(310, 400);
            this.panelVegetacion.TabIndex = 1;
            // 
            // lblTituloVeg
            // 
            this.lblTituloVeg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloVeg.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloVeg.Location = new System.Drawing.Point(10, 10);
            this.lblTituloVeg.Name = "lblTituloVeg";
            this.lblTituloVeg.Size = new System.Drawing.Size(290, 40);
            this.lblTituloVeg.TabIndex = 0;
            this.lblTituloVeg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFloracion
            // 
            this.panelFloracion.BackColor = System.Drawing.Color.White;
            this.panelFloracion.Controls.Add(this.lblTituloFlor);
            this.panelFloracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFloracion.Location = new System.Drawing.Point(680, 20);
            this.panelFloracion.Margin = new System.Windows.Forms.Padding(10);
            this.panelFloracion.Name = "panelFloracion";
            this.panelFloracion.Padding = new System.Windows.Forms.Padding(10);
            this.panelFloracion.Size = new System.Drawing.Size(310, 400);
            this.panelFloracion.TabIndex = 2;
            // 
            // lblTituloFlor
            // 
            this.lblTituloFlor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloFlor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloFlor.Location = new System.Drawing.Point(10, 10);
            this.lblTituloFlor.Name = "lblTituloFlor";
            this.lblTituloFlor.Size = new System.Drawing.Size(290, 40);
            this.lblTituloFlor.TabIndex = 0;
            this.lblTituloFlor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.dtpFechaInicio);
            this.panelHeader.Controls.Add(this.lblFecha);
            this.panelHeader.Controls.Add(this.txtNombrePlan);
            this.panelHeader.Controls.Add(this.lblNombrePlan);
            this.panelHeader.Controls.Add(this.lblTituloPrincipal);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1010, 100);
            this.panelHeader.TabIndex = 0;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(570, 50);
            this.dtpFechaInicio.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(200, 29);
            this.dtpFechaInicio.Style = MetroFramework.MetroColorStyle.Green;
            this.dtpFechaInicio.TabIndex = 4;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(480, 55);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(80, 19);
            this.lblFecha.TabIndex = 3;
            this.lblFecha.Text = "Fecha Inicio:";
            // 
            // txtNombrePlan
            // 
            // 
            // 
            // 
            this.txtNombrePlan.CustomButton.Image = null;
            this.txtNombrePlan.CustomButton.Location = new System.Drawing.Point(272, 2);
            this.txtNombrePlan.CustomButton.Name = "";
            this.txtNombrePlan.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtNombrePlan.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNombrePlan.CustomButton.TabIndex = 1;
            this.txtNombrePlan.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNombrePlan.CustomButton.UseSelectable = true;
            this.txtNombrePlan.CustomButton.Visible = false;
            this.txtNombrePlan.Lines = new string[0];
            this.txtNombrePlan.Location = new System.Drawing.Point(140, 50);
            this.txtNombrePlan.MaxLength = 32767;
            this.txtNombrePlan.Name = "txtNombrePlan";
            this.txtNombrePlan.PasswordChar = '\0';
            this.txtNombrePlan.WaterMark = "Ej: Tomates Invierno 2025";
            this.txtNombrePlan.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNombrePlan.SelectedText = "";
            this.txtNombrePlan.SelectionLength = 0;
            this.txtNombrePlan.SelectionStart = 0;
            this.txtNombrePlan.ShortcutsEnabled = true;
            this.txtNombrePlan.Size = new System.Drawing.Size(300, 30);
            this.txtNombrePlan.TabIndex = 2;
            this.txtNombrePlan.UseSelectable = true;
            this.txtNombrePlan.WaterMark = "Ej: Tomates Invierno 2025";
            this.txtNombrePlan.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNombrePlan.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblNombrePlan
            // 
            this.lblNombrePlan.AutoSize = true;
            this.lblNombrePlan.Location = new System.Drawing.Point(20, 55);
            this.lblNombrePlan.Name = "lblNombrePlan";
            this.lblNombrePlan.Size = new System.Drawing.Size(113, 19);
            this.lblNombrePlan.TabIndex = 1;
            this.lblNombrePlan.Text = "Nombre del Plan:";
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.AutoSize = true;
            this.lblTituloPrincipal.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTituloPrincipal.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblTituloPrincipal.Location = new System.Drawing.Point(20, 15);
            this.lblTituloPrincipal.Name = "lblTituloPrincipal";
            this.lblTituloPrincipal.Size = new System.Drawing.Size(201, 25);
            this.lblTituloPrincipal.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTituloPrincipal.TabIndex = 0;
            this.lblTituloPrincipal.Text = "Nuevo Plan de Cultivo";
            this.lblTituloPrincipal.UseCustomForeColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Silver;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(189, 526);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(20, 526);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 40);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar Plan";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // AgregarPlanCultivoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.Controls.Add(this.panelMain);
            this.Name = "AgregarPlanCultivoForm";
            this.Text = "Agregar Nuevo Plan";
            this.Load += new System.EventHandler(this.AgregarPlanCultivoForm_Load);
            this.Resize += new System.EventHandler(this.AgregarPlanCultivoForm_Resize);
            this.panelMain.ResumeLayout(false);
            this.tableLayoutPanelEtapas.ResumeLayout(false);
            this.panelGerminacion.ResumeLayout(false);
            this.panelVegetacion.ResumeLayout(false);
            this.panelFloracion.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private MetroFramework.Controls.MetroLabel lblTituloPrincipal;
        private MetroFramework.Controls.MetroTextBox txtNombrePlan;
        private MetroFramework.Controls.MetroLabel lblNombrePlan;
        private MetroFramework.Controls.MetroDateTime dtpFechaInicio;
        private MetroFramework.Controls.MetroLabel lblFecha;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEtapas;
        private System.Windows.Forms.Panel panelGerminacion;
        private System.Windows.Forms.Label lblTituloGerm;
        private System.Windows.Forms.Panel panelVegetacion;
        private System.Windows.Forms.Label lblTituloVeg;
        private System.Windows.Forms.Panel panelFloracion;
        private System.Windows.Forms.Label lblTituloFlor;
    }
}