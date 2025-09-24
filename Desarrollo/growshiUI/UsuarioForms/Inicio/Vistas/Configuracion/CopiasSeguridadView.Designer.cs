namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    partial class CopiasSeguridadView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopiasSeguridadView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCrearCopia = new System.Windows.Forms.Button();
            this.textBoxNotasCopia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonAbrirUbicacion = new System.Windows.Forms.Button();
            this.buttonRestaurar = new System.Windows.Forms.Button();
            this.dataGridViewHistorial = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(662, 528);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonCrearCopia);
            this.panel1.Controls.Add(this.textBoxNotasCopia);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(639, 180);
            this.panel1.TabIndex = 0;
            // 
            // buttonCrearCopia
            // 
            this.buttonCrearCopia.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonCrearCopia.FlatAppearance.BorderSize = 0;
            this.buttonCrearCopia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCrearCopia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCrearCopia.ForeColor = System.Drawing.Color.White;
            this.buttonCrearCopia.Image = ((System.Drawing.Image)(resources.GetObject("buttonCrearCopia.Image")));
            this.buttonCrearCopia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCrearCopia.Location = new System.Drawing.Point(463, 108);
            this.buttonCrearCopia.Name = "buttonCrearCopia";
            this.buttonCrearCopia.Size = new System.Drawing.Size(157, 31);
            this.buttonCrearCopia.TabIndex = 4;
            this.buttonCrearCopia.Text = "Realizar Copia Ahora";
            this.buttonCrearCopia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCrearCopia.UseVisualStyleBackColor = false;
            this.buttonCrearCopia.Click += new System.EventHandler(this.buttonCrearCopia_Click);
            // 
            // textBoxNotasCopia
            // 
            this.textBoxNotasCopia.Location = new System.Drawing.Point(15, 77);
            this.textBoxNotasCopia.Name = "textBoxNotasCopia";
            this.textBoxNotasCopia.Size = new System.Drawing.Size(605, 25);
            this.textBoxNotasCopia.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(15, 40);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 15, 0, 5);
            this.label3.Size = new System.Drawing.Size(327, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "Añade una nota descriptiva para esta copia (opcional):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nueva Copia de Seguridad";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dataGridViewHistorial);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 199);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(15);
            this.panel2.Size = new System.Drawing.Size(639, 312);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonEliminar);
            this.panel3.Controls.Add(this.buttonAbrirUbicacion);
            this.panel3.Controls.Add(this.buttonRestaurar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(15, 247);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(609, 50);
            this.panel3.TabIndex = 2;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminar.Location = new System.Drawing.Point(433, 8);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(100, 34);
            this.buttonEliminar.TabIndex = 2;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = false;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonAbrirUbicacion
            // 
            this.buttonAbrirUbicacion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonAbrirUbicacion.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonAbrirUbicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbrirUbicacion.Location = new System.Drawing.Point(250, 8);
            this.buttonAbrirUbicacion.Name = "buttonAbrirUbicacion";
            this.buttonAbrirUbicacion.Size = new System.Drawing.Size(122, 34);
            this.buttonAbrirUbicacion.TabIndex = 1;
            this.buttonAbrirUbicacion.Text = "Abrir Ubicacion";
            this.buttonAbrirUbicacion.UseVisualStyleBackColor = false;
            this.buttonAbrirUbicacion.Click += new System.EventHandler(this.buttonAbrirUbicacion_Click);
            // 
            // buttonRestaurar
            // 
            this.buttonRestaurar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRestaurar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestaurar.Location = new System.Drawing.Point(85, 8);
            this.buttonRestaurar.Name = "buttonRestaurar";
            this.buttonRestaurar.Size = new System.Drawing.Size(111, 34);
            this.buttonRestaurar.TabIndex = 0;
            this.buttonRestaurar.Text = "Restaurar";
            this.buttonRestaurar.UseVisualStyleBackColor = false;
            this.buttonRestaurar.Click += new System.EventHandler(this.buttonRestaurar_Click);
            // 
            // dataGridViewHistorial
            // 
            this.dataGridViewHistorial.AllowUserToAddRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewHistorial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewHistorial.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHistorial.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewHistorial.Location = new System.Drawing.Point(15, 50);
            this.dataGridViewHistorial.Name = "dataGridViewHistorial";
            this.dataGridViewHistorial.RowHeadersVisible = false;
            this.dataGridViewHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHistorial.Size = new System.Drawing.Size(609, 247);
            this.dataGridViewHistorial.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label2.Size = new System.Drawing.Size(291, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "Copias de Seguridad Realizadas";
            // 
            // CopiasSeguridadView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CopiasSeguridadView";
            this.Size = new System.Drawing.Size(669, 546);
            this.Load += new System.EventHandler(this.CopiasSeguridadView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxNotasCopia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCrearCopia;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewHistorial;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonAbrirUbicacion;
        private System.Windows.Forms.Button buttonRestaurar;
    }
}
