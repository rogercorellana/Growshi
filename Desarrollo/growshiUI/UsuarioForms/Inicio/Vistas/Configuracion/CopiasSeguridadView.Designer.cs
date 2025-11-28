namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    partial class CopiasSeguridadView
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

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();

            this.tableLayoutPanelPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.panelCrear = new System.Windows.Forms.Panel();
            this.btnCrearCopia = new MetroFramework.Controls.MetroButton();
            this.txtNotas = new MetroFramework.Controls.MetroTextBox();
            this.lblInstruccion = new MetroFramework.Controls.MetroLabel();
            this.lblTituloCrear = new MetroFramework.Controls.MetroLabel();
            this.panelHistorial = new System.Windows.Forms.Panel();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnEliminar = new MetroFramework.Controls.MetroButton();
            this.btnAbrirUbicacion = new MetroFramework.Controls.MetroButton();
            this.btnRestaurar = new MetroFramework.Controls.MetroButton();
            this.metroGridHistorial = new MetroFramework.Controls.MetroGrid();
            this.lblTituloHistorial = new MetroFramework.Controls.MetroLabel();

            this.tableLayoutPanelPrincipal.SuspendLayout();
            this.panelCrear.SuspendLayout();
            this.panelHistorial.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridHistorial)).BeginInit();
            this.SuspendLayout();

            // 
            // tableLayoutPanelPrincipal
            // 
            this.tableLayoutPanelPrincipal.ColumnCount = 1;
            this.tableLayoutPanelPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPrincipal.Controls.Add(this.panelCrear, 0, 0);
            this.tableLayoutPanelPrincipal.Controls.Add(this.panelHistorial, 0, 1);
            this.tableLayoutPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPrincipal.Name = "tableLayoutPanelPrincipal";
            this.tableLayoutPanelPrincipal.RowCount = 2;
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F)); // Altura fija para panel crear
            this.tableLayoutPanelPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPrincipal.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanelPrincipal.TabIndex = 0;

            // 
            // panelCrear
            // 
            this.panelCrear.BackColor = System.Drawing.Color.White;
            this.panelCrear.Controls.Add(this.btnCrearCopia);
            this.panelCrear.Controls.Add(this.txtNotas);
            this.panelCrear.Controls.Add(this.lblInstruccion);
            this.panelCrear.Controls.Add(this.lblTituloCrear);
            this.panelCrear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCrear.Location = new System.Drawing.Point(3, 3);
            this.panelCrear.Name = "panelCrear";
            this.panelCrear.Padding = new System.Windows.Forms.Padding(20);
            this.panelCrear.Size = new System.Drawing.Size(794, 174);
            this.panelCrear.TabIndex = 0;

            // 
            // lblTituloCrear
            // 
            this.lblTituloCrear.AutoSize = true;
            this.lblTituloCrear.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTituloCrear.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTituloCrear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80))))); // Verde Growshi
            this.lblTituloCrear.Location = new System.Drawing.Point(20, 15);
            this.lblTituloCrear.Name = "lblTituloCrear";
            this.lblTituloCrear.Size = new System.Drawing.Size(243, 25);
            this.lblTituloCrear.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTituloCrear.TabIndex = 0;
            this.lblTituloCrear.Text = "Nueva Copia de Seguridad";
            this.lblTituloCrear.UseCustomForeColor = true;

            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Location = new System.Drawing.Point(20, 50);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(327, 19);
            this.lblInstruccion.TabIndex = 1;
            this.lblInstruccion.Text = "Agrega una nota descriptiva para identificar este backup:";

            // 
            // txtNotas
            // 
            // 
            // 
            // 
            this.txtNotas.CustomButton.Image = null;
            this.txtNotas.CustomButton.Location = new System.Drawing.Point(722, 1);
            this.txtNotas.CustomButton.Name = "";
            this.txtNotas.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.txtNotas.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNotas.CustomButton.TabIndex = 1;
            this.txtNotas.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNotas.CustomButton.UseSelectable = true;
            this.txtNotas.CustomButton.Visible = false;
            this.txtNotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotas.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNotas.Lines = new string[0];
            this.txtNotas.Location = new System.Drawing.Point(20, 75);
            this.txtNotas.MaxLength = 32767;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.PasswordChar = '\0';
            this.txtNotas.WaterMark = "Ej: Backup antes de actualización mensual...";
            this.txtNotas.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNotas.SelectedText = "";
            this.txtNotas.SelectionLength = 0;
            this.txtNotas.SelectionStart = 0;
            this.txtNotas.ShortcutsEnabled = true;
            this.txtNotas.Size = new System.Drawing.Size(750, 29);
            this.txtNotas.Style = MetroFramework.MetroColorStyle.Green;
            this.txtNotas.TabIndex = 2;
            this.txtNotas.UseSelectable = true;
            this.txtNotas.WaterMark = "Ej: Backup antes de actualización mensual...";
            this.txtNotas.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNotas.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);

            // 
            // btnCrearCopia
            // 
            this.btnCrearCopia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCrearCopia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80))))); // Verde Growshi
            this.btnCrearCopia.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnCrearCopia.ForeColor = System.Drawing.Color.White;
            this.btnCrearCopia.Location = new System.Drawing.Point(570, 120);
            this.btnCrearCopia.Name = "btnCrearCopia";
            this.btnCrearCopia.Size = new System.Drawing.Size(200, 35);
            this.btnCrearCopia.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCrearCopia.TabIndex = 3;
            this.btnCrearCopia.Text = "Generar Copia Ahora";
            this.btnCrearCopia.UseCustomBackColor = true;
            this.btnCrearCopia.UseCustomForeColor = true;
            this.btnCrearCopia.UseSelectable = true;
            this.btnCrearCopia.Click += new System.EventHandler(this.buttonCrearCopia_Click);

            // 
            // panelHistorial
            // 
            this.panelHistorial.BackColor = System.Drawing.Color.White;
            this.panelHistorial.Controls.Add(this.panelBotones);
            this.panelHistorial.Controls.Add(this.metroGridHistorial);
            this.panelHistorial.Controls.Add(this.lblTituloHistorial);
            this.panelHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHistorial.Location = new System.Drawing.Point(3, 183);
            this.panelHistorial.Name = "panelHistorial";
            this.panelHistorial.Padding = new System.Windows.Forms.Padding(20);
            this.panelHistorial.Size = new System.Drawing.Size(794, 414);
            this.panelHistorial.TabIndex = 1;

            // 
            // lblTituloHistorial
            // 
            this.lblTituloHistorial.AutoSize = true;
            this.lblTituloHistorial.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTituloHistorial.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTituloHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblTituloHistorial.Location = new System.Drawing.Point(20, 15);
            this.lblTituloHistorial.Name = "lblTituloHistorial";
            this.lblTituloHistorial.Size = new System.Drawing.Size(286, 25);
            this.lblTituloHistorial.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTituloHistorial.TabIndex = 0;
            this.lblTituloHistorial.Text = "Historial de Copias de Seguridad";
            this.lblTituloHistorial.UseCustomForeColor = true;

            // 
            // metroGridHistorial
            // 
            this.metroGridHistorial.AllowUserToAddRows = false;
            this.metroGridHistorial.AllowUserToResizeRows = false;
            this.metroGridHistorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroGridHistorial.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGridHistorial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGridHistorial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89))))); // Verde Growshi encabezado
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGridHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGridHistorial.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGridHistorial.EnableHeadersVisualStyles = false;
            this.metroGridHistorial.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.metroGridHistorial.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGridHistorial.Location = new System.Drawing.Point(20, 50);
            this.metroGridHistorial.Name = "metroGridHistorial";
            this.metroGridHistorial.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(208)))), ((int)(((byte)(104)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGridHistorial.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGridHistorial.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGridHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGridHistorial.Size = new System.Drawing.Size(750, 280);
            this.metroGridHistorial.Style = MetroFramework.MetroColorStyle.Green;
            this.metroGridHistorial.TabIndex = 1;
            this.metroGridHistorial.UseStyleColors = true;

            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnRestaurar);
            this.panelBotones.Controls.Add(this.btnAbrirUbicacion);
            this.panelBotones.Controls.Add(this.btnEliminar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(20, 344);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(754, 50);
            this.panelBotones.TabIndex = 2;

            // 
            // btnRestaurar
            // 
            this.btnRestaurar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnRestaurar.Location = new System.Drawing.Point(0, 10);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(130, 30);
            this.btnRestaurar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnRestaurar.TabIndex = 0;
            this.btnRestaurar.Text = "Restaurar Selección";
            this.btnRestaurar.UseSelectable = true;
            this.btnRestaurar.Click += new System.EventHandler(this.buttonRestaurar_Click);

            // 
            // btnAbrirUbicacion
            // 
            this.btnAbrirUbicacion.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnAbrirUbicacion.Location = new System.Drawing.Point(140, 10);
            this.btnAbrirUbicacion.Name = "btnAbrirUbicacion";
            this.btnAbrirUbicacion.Size = new System.Drawing.Size(130, 30);
            this.btnAbrirUbicacion.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnAbrirUbicacion.TabIndex = 1;
            this.btnAbrirUbicacion.Text = "Abrir Carpeta";
            this.btnAbrirUbicacion.UseSelectable = true;
            this.btnAbrirUbicacion.Click += new System.EventHandler(this.buttonAbrirUbicacion_Click);

            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnEliminar.Location = new System.Drawing.Point(624, 10);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 30);
            this.btnEliminar.Style = MetroFramework.MetroColorStyle.Red;
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar Copia";
            this.btnEliminar.UseSelectable = true;
            this.btnEliminar.UseStyleColors = true; // Para que tome el rojo
            this.btnEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);

            // 
            // CopiasSeguridadView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelPrincipal);
            this.Name = "CopiasSeguridadView";
            this.Size = new System.Drawing.Size(800, 600);
            this.Load += new System.EventHandler(this.CopiasSeguridadView_Load);
            this.tableLayoutPanelPrincipal.ResumeLayout(false);
            this.panelCrear.ResumeLayout(false);
            this.panelCrear.PerformLayout();
            this.panelHistorial.ResumeLayout(false);
            this.panelHistorial.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGridHistorial)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPrincipal;
        private System.Windows.Forms.Panel panelCrear;
        private System.Windows.Forms.Panel panelHistorial;
        private MetroFramework.Controls.MetroLabel lblTituloCrear;
        private MetroFramework.Controls.MetroLabel lblInstruccion;
        private MetroFramework.Controls.MetroTextBox txtNotas;
        private MetroFramework.Controls.MetroButton btnCrearCopia;
        private MetroFramework.Controls.MetroLabel lblTituloHistorial;
        private MetroFramework.Controls.MetroGrid metroGridHistorial;
        private System.Windows.Forms.Panel panelBotones;
        private MetroFramework.Controls.MetroButton btnRestaurar;
        private MetroFramework.Controls.MetroButton btnAbrirUbicacion;
        private MetroFramework.Controls.MetroButton btnEliminar;
    }
}