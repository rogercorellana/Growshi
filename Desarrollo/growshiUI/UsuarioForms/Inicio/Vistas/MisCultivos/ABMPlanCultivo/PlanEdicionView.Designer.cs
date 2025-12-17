namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos.ABMPlanCultivo
{
    partial class PlanEdicionView
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCabecera = new MetroFramework.Controls.MetroPanel();
            this.txtNombrePlan = new MetroFramework.Controls.MetroTextBox();
            this.lblNombrePlan = new MetroFramework.Controls.MetroLabel();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.pnlBotones = new MetroFramework.Controls.MetroPanel();
            this.btnCancelar = new MetroFramework.Controls.MetroButton();
            this.btnGuardar = new MetroFramework.Controls.MetroButton();
            this.grpEtapas = new System.Windows.Forms.GroupBox();
            this.gridEtapasEdicion = new MetroFramework.Controls.MetroGrid();
            this.colEtapa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTempMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTempMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHorasLuz = new System.Windows.Forms.DataGridViewTextBoxColumn(); // <--- 2. INSTANCIAR AQUI
            this.tlpPrincipal.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.grpEtapas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEtapasEdicion)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.pnlCabecera, 0, 0);
            this.tlpPrincipal.Controls.Add(this.pnlBotones, 0, 2);
            this.tlpPrincipal.Controls.Add(this.grpEtapas, 0, 1);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.Padding = new System.Windows.Forms.Padding(20);
            this.tlpPrincipal.RowCount = 3;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpPrincipal.Size = new System.Drawing.Size(959, 621);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // pnlCabecera
            // 
            this.pnlCabecera.Controls.Add(this.txtNombrePlan);
            this.pnlCabecera.Controls.Add(this.lblNombrePlan);
            this.pnlCabecera.Controls.Add(this.lblTitulo);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCabecera.HorizontalScrollbarBarColor = true;
            this.pnlCabecera.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlCabecera.HorizontalScrollbarSize = 10;
            this.pnlCabecera.Location = new System.Drawing.Point(23, 23);
            this.pnlCabecera.Name = "pnlCabecera";
            this.pnlCabecera.Size = new System.Drawing.Size(913, 94);
            this.pnlCabecera.TabIndex = 0;
            this.pnlCabecera.VerticalScrollbarBarColor = true;
            this.pnlCabecera.VerticalScrollbarHighlightOnWheel = false;
            this.pnlCabecera.VerticalScrollbarSize = 10;
            // 
            // txtNombrePlan
            // 
            // 
            // 
            // 
            this.txtNombrePlan.CustomButton.Image = null;
            this.txtNombrePlan.CustomButton.Location = new System.Drawing.Point(315, 1);
            this.txtNombrePlan.CustomButton.Name = "";
            this.txtNombrePlan.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNombrePlan.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNombrePlan.CustomButton.TabIndex = 1;
            this.txtNombrePlan.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNombrePlan.CustomButton.UseSelectable = true;
            this.txtNombrePlan.CustomButton.Visible = false;
            this.txtNombrePlan.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNombrePlan.Lines = new string[0];
            this.txtNombrePlan.Location = new System.Drawing.Point(3, 56);
            this.txtNombrePlan.MaxLength = 32767;
            this.txtNombrePlan.Name = "txtNombrePlan";
            this.txtNombrePlan.PasswordChar = '\0';
            this.txtNombrePlan.PromptText = "Ej: Tomates Verano 2025";
            this.txtNombrePlan.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNombrePlan.SelectedText = "";
            this.txtNombrePlan.SelectionLength = 0;
            this.txtNombrePlan.SelectionStart = 0;
            this.txtNombrePlan.ShortcutsEnabled = true;
            this.txtNombrePlan.Size = new System.Drawing.Size(337, 23);
            this.txtNombrePlan.TabIndex = 4;
            this.txtNombrePlan.UseSelectable = true;
            this.txtNombrePlan.WaterMark = "Ej: Tomates Verano 2025";
            this.txtNombrePlan.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNombrePlan.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblNombrePlan
            // 
            this.lblNombrePlan.AutoSize = true;
            this.lblNombrePlan.Location = new System.Drawing.Point(3, 34);
            this.lblNombrePlan.Name = "lblNombrePlan";
            this.lblNombrePlan.Size = new System.Drawing.Size(110, 19);
            this.lblNombrePlan.TabIndex = 3;
            this.lblNombrePlan.Text = "Nombre del Plan";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(221, 25);
            this.lblTitulo.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Editar Plan Seleccionado";
            this.lblTitulo.UseStyleColors = true;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBotones.HorizontalScrollbarBarColor = true;
            this.pnlBotones.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlBotones.HorizontalScrollbarSize = 10;
            this.pnlBotones.Location = new System.Drawing.Point(23, 544);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(913, 54);
            this.pnlBotones.TabIndex = 1;
            this.pnlBotones.VerticalScrollbarBarColor = true;
            this.pnlBotones.VerticalScrollbarHighlightOnWheel = false;
            this.pnlBotones.VerticalScrollbarSize = 10;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(681, 10);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 35);
            this.btnCancelar.Style = MetroFramework.MetroColorStyle.Red;
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.UseStyleColors = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(794, 10);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(119, 35);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar Cambios";
            this.btnGuardar.UseSelectable = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // grpEtapas
            // 
            this.grpEtapas.Controls.Add(this.gridEtapasEdicion);
            this.grpEtapas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEtapas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpEtapas.Location = new System.Drawing.Point(23, 123);
            this.grpEtapas.Name = "grpEtapas";
            this.grpEtapas.Padding = new System.Windows.Forms.Padding(10);
            this.grpEtapas.Size = new System.Drawing.Size(913, 415);
            this.grpEtapas.TabIndex = 2;
            this.grpEtapas.TabStop = false;
            this.grpEtapas.Text = "Configuración de Etapas (Puedes editar los valores directamente)";
            // 
            // gridEtapasEdicion
            // 
            this.gridEtapasEdicion.AllowUserToAddRows = false;
            this.gridEtapasEdicion.AllowUserToDeleteRows = false;
            this.gridEtapasEdicion.AllowUserToResizeRows = false;
            this.gridEtapasEdicion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridEtapasEdicion.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridEtapasEdicion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridEtapasEdicion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridEtapasEdicion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEtapasEdicion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridEtapasEdicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEtapasEdicion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEtapa,
            this.colDuracion,
            this.colTempMin,
            this.colTempMax,
            this.colPhMin,
            this.colPhMax,
            this.colHorasLuz}); // <--- AGREGAR AL FINAL});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridEtapasEdicion.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridEtapasEdicion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEtapasEdicion.EnableHeadersVisualStyles = false;
            this.gridEtapasEdicion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridEtapasEdicion.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridEtapasEdicion.Location = new System.Drawing.Point(10, 26);
            this.gridEtapasEdicion.Name = "gridEtapasEdicion";
            this.gridEtapasEdicion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEtapasEdicion.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridEtapasEdicion.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridEtapasEdicion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEtapasEdicion.Size = new System.Drawing.Size(893, 379);
            this.gridEtapasEdicion.Style = MetroFramework.MetroColorStyle.Green;
            this.gridEtapasEdicion.TabIndex = 0;
            this.gridEtapasEdicion.UseStyleColors = true;
            // 
            // colEtapa
            // 
            this.colEtapa.DataPropertyName = "NombreEtapa";
            this.colEtapa.HeaderText = "Etapa";
            this.colEtapa.Name = "colEtapa";
            this.colEtapa.ReadOnly = true;
            // 
            // colDuracion
            // 
            this.colDuracion.DataPropertyName = "Duracion";
            this.colDuracion.HeaderText = "Días";
            this.colDuracion.Name = "colDuracion";
            // 
            // colTempMin
            // 
            this.colTempMin.DataPropertyName = "TempMin";
            this.colTempMin.HeaderText = "Temp Mín";
            this.colTempMin.Name = "colTempMin";
            // 
            // colTempMax
            // 
            this.colTempMax.DataPropertyName = "TempMax";
            this.colTempMax.HeaderText = "Temp Máx";
            this.colTempMax.Name = "colTempMax";
            // 
            // colPhMin
            // 
            this.colPhMin.DataPropertyName = "PhMin";
            this.colPhMin.HeaderText = "pH Mín";
            this.colPhMin.Name = "colPhMin";
            // 
            // colPhMax
            // 
            this.colPhMax.DataPropertyName = "PhMax";
            this.colPhMax.HeaderText = "pH Máx";
            this.colPhMax.Name = "colPhMax";
            // 
            // colHorasLuz (CONFIGURACIÓN NUEVA)
            // 
            this.colHorasLuz.DataPropertyName = "HorasLuz"; // Debe coincidir con tu BE
            this.colHorasLuz.HeaderText = "Horas Luz";
            this.colHorasLuz.Name = "colHorasLuz";

            // PlanEdicionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpPrincipal);
            this.Name = "PlanEdicionView";
            this.Size = new System.Drawing.Size(959, 621);
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlCabecera.ResumeLayout(false);
            this.pnlCabecera.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.grpEtapas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEtapasEdicion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private MetroFramework.Controls.MetroPanel pnlCabecera;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private MetroFramework.Controls.MetroTextBox txtNombrePlan;
        private MetroFramework.Controls.MetroLabel lblNombrePlan;
        private MetroFramework.Controls.MetroPanel pnlBotones;
        private MetroFramework.Controls.MetroButton btnGuardar;
        private MetroFramework.Controls.MetroButton btnCancelar;
        private System.Windows.Forms.GroupBox grpEtapas;
        private MetroFramework.Controls.MetroGrid gridEtapasEdicion;

        // Columnas para la edición rápida
        private System.Windows.Forms.DataGridViewTextBoxColumn colEtapa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTempMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTempMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhMax;

        private System.Windows.Forms.DataGridViewTextBoxColumn colHorasLuz;

    }
}