namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanta
{
    partial class AgregarPlantaForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelFondo = new System.Windows.Forms.Panel();
            this.panelTarjeta = new System.Windows.Forms.Panel();
            this.lnkNuevoPlan = new MetroFramework.Controls.MetroLink();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.marcoGrid = new System.Windows.Forms.Panel();
            this.metroGridPlantas = new MetroFramework.Controls.MetroGrid();
            this.cmbPlanCultivo = new MetroFramework.Controls.MetroComboBox();
            this.lblPlan = new MetroFramework.Controls.MetroLabel();
            this.txtNombrePlanta = new MetroFramework.Controls.MetroTextBox();
            this.lblNombre = new MetroFramework.Controls.MetroLabel();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.panelFondo.SuspendLayout();
            this.panelTarjeta.SuspendLayout();
            this.marcoGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridPlantas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFondo
            // 
            this.panelFondo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFondo.Controls.Add(this.panelTarjeta);
            this.panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFondo.Location = new System.Drawing.Point(20, 60);
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.Padding = new System.Windows.Forms.Padding(20);
            this.panelFondo.Size = new System.Drawing.Size(1085, 572);
            this.panelFondo.TabIndex = 0;
            // 
            // panelTarjeta
            // 
            this.panelTarjeta.BackColor = System.Drawing.Color.White;
            this.panelTarjeta.Controls.Add(this.lnkNuevoPlan);
            this.panelTarjeta.Controls.Add(this.btnGuardar);
            this.panelTarjeta.Controls.Add(this.marcoGrid);
            this.panelTarjeta.Controls.Add(this.cmbPlanCultivo);
            this.panelTarjeta.Controls.Add(this.lblPlan);
            this.panelTarjeta.Controls.Add(this.txtNombrePlanta);
            this.panelTarjeta.Controls.Add(this.lblNombre);
            this.panelTarjeta.Controls.Add(this.lblTitulo);
            this.panelTarjeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTarjeta.Location = new System.Drawing.Point(20, 20);
            this.panelTarjeta.Name = "panelTarjeta";
            this.panelTarjeta.Size = new System.Drawing.Size(1045, 532);
            this.panelTarjeta.TabIndex = 0;
            // 
            // lnkNuevoPlan
            // 
            this.lnkNuevoPlan.Location = new System.Drawing.Point(350, 125);
            this.lnkNuevoPlan.Name = "lnkNuevoPlan";
            this.lnkNuevoPlan.Size = new System.Drawing.Size(300, 23);
            this.lnkNuevoPlan.TabIndex = 6;
            this.lnkNuevoPlan.Text = "¿No encuentras el plan? Crear uno nuevo";
            this.lnkNuevoPlan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkNuevoPlan.UseSelectable = true;
            this.lnkNuevoPlan.Click += new System.EventHandler(this.lnkNuevoPlan_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(20, 140);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 40);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar Planta";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // marcoGrid
            // 
            this.marcoGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.marcoGrid.BackColor = System.Drawing.Color.Silver;
            this.marcoGrid.Controls.Add(this.metroGridPlantas);
            this.marcoGrid.Location = new System.Drawing.Point(20, 200);
            this.marcoGrid.Name = "marcoGrid";
            this.marcoGrid.Padding = new System.Windows.Forms.Padding(1);
            this.marcoGrid.Size = new System.Drawing.Size(1005, 312);
            this.marcoGrid.TabIndex = 7;
            // 
            // metroGridPlantas
            // 
            this.metroGridPlantas.AllowUserToResizeRows = false;
            this.metroGridPlantas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridPlantas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGridPlantas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGridPlantas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridPlantas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGridPlantas.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGridPlantas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGridPlantas.EnableHeadersVisualStyles = false;
            this.metroGridPlantas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGridPlantas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridPlantas.Location = new System.Drawing.Point(1, 1);
            this.metroGridPlantas.Name = "metroGridPlantas";
            this.metroGridPlantas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridPlantas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGridPlantas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGridPlantas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGridPlantas.Size = new System.Drawing.Size(1003, 310);
            this.metroGridPlantas.TabIndex = 0;
            // 
            // cmbPlanCultivo
            // 
            this.cmbPlanCultivo.FormattingEnabled = true;
            this.cmbPlanCultivo.ItemHeight = 23;
            this.cmbPlanCultivo.Location = new System.Drawing.Point(350, 90);
            this.cmbPlanCultivo.Name = "cmbPlanCultivo";
            this.cmbPlanCultivo.Size = new System.Drawing.Size(300, 29);
            this.cmbPlanCultivo.TabIndex = 4;
            this.cmbPlanCultivo.UseSelectable = true;
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(350, 65);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(100, 19);
            this.lblPlan.TabIndex = 3;
            this.lblPlan.Text = "Plan de Cultivo:";
            // 
            // txtNombrePlanta
            // 
            // 
            // 
            // 
            this.txtNombrePlanta.CustomButton.Image = null;
            this.txtNombrePlanta.CustomButton.Location = new System.Drawing.Point(272, 2);
            this.txtNombrePlanta.CustomButton.Name = "";
            this.txtNombrePlanta.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtNombrePlanta.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNombrePlanta.CustomButton.TabIndex = 1;
            this.txtNombrePlanta.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNombrePlanta.CustomButton.UseSelectable = true;
            this.txtNombrePlanta.CustomButton.Visible = false;
            this.txtNombrePlanta.Lines = new string[0];
            this.txtNombrePlanta.Location = new System.Drawing.Point(20, 90);
            this.txtNombrePlanta.MaxLength = 32767;
            this.txtNombrePlanta.Name = "txtNombrePlanta";
            this.txtNombrePlanta.PasswordChar = '\0';
            this.txtNombrePlanta.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNombrePlanta.SelectedText = "";
            this.txtNombrePlanta.SelectionLength = 0;
            this.txtNombrePlanta.SelectionStart = 0;
            this.txtNombrePlanta.ShortcutsEnabled = true;
            this.txtNombrePlanta.Size = new System.Drawing.Size(300, 30);
            this.txtNombrePlanta.TabIndex = 2;
            this.txtNombrePlanta.UseSelectable = true;
            this.txtNombrePlanta.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNombrePlanta.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 65);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(135, 19);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre de la Planta:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(339, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Asignación de Planta y Plan de Cultivo";
            this.lblTitulo.UseCustomForeColor = true;
            // 
            // AgregarPlantaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 652);
            this.Controls.Add(this.panelFondo);
            this.Name = "AgregarPlantaForm";
            this.Text = "Agregar Planta";
            this.Load += new System.EventHandler(this.AgregarPlantaForm_Load);
            this.Resize += new System.EventHandler(this.ABMPlanta_Resize);
            this.panelFondo.ResumeLayout(false);
            this.panelTarjeta.ResumeLayout(false);
            this.panelTarjeta.PerformLayout();
            this.marcoGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGridPlantas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFondo;
        private System.Windows.Forms.Panel panelTarjeta;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private MetroFramework.Controls.MetroLabel lblNombre;
        private MetroFramework.Controls.MetroTextBox txtNombrePlanta;
        private MetroFramework.Controls.MetroLabel lblPlan;
        private MetroFramework.Controls.MetroComboBox cmbPlanCultivo;
        private System.Windows.Forms.Button btnGuardar;
        private MetroFramework.Controls.MetroLink lnkNuevoPlan;
        private System.Windows.Forms.Panel marcoGrid;
        private MetroFramework.Controls.MetroGrid metroGridPlantas;
    }
}