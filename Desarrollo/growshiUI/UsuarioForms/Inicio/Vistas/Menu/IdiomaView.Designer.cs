namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    partial class IdiomaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IdiomaView));
            this.labelSeleccioneUnIdioma = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelIngles = new System.Windows.Forms.Label();
            this.pictureBoxIngles = new System.Windows.Forms.PictureBox();
            this.panelEspañol = new System.Windows.Forms.Panel();
            this.labelEspañol = new System.Windows.Forms.Label();
            this.pictureBoxEspañol = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIngles)).BeginInit();
            this.panelEspañol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEspañol)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSeleccioneUnIdioma
            // 
            this.labelSeleccioneUnIdioma.AutoSize = true;
            this.labelSeleccioneUnIdioma.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelSeleccioneUnIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSeleccioneUnIdioma.Location = new System.Drawing.Point(0, 0);
            this.labelSeleccioneUnIdioma.Name = "labelSeleccioneUnIdioma";
            this.labelSeleccioneUnIdioma.Size = new System.Drawing.Size(251, 25);
            this.labelSeleccioneUnIdioma.TabIndex = 0;
            this.labelSeleccioneUnIdioma.Text = "Seleccione un Idioma: ";
            this.labelSeleccioneUnIdioma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelEspañol, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(486, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelIngles);
            this.panel1.Controls.Add(this.pictureBoxIngles);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(264, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 200);
            this.panel1.TabIndex = 2;
            // 
            // labelIngles
            // 
            this.labelIngles.AutoSize = true;
            this.labelIngles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelIngles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIngles.Location = new System.Drawing.Point(0, 150);
            this.labelIngles.Name = "labelIngles";
            this.labelIngles.Size = new System.Drawing.Size(58, 20);
            this.labelIngles.TabIndex = 1;
            this.labelIngles.Text = "Ingles";
            this.labelIngles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxIngles
            // 
            this.pictureBoxIngles.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxIngles.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIngles.Image")));
            this.pictureBoxIngles.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxIngles.Name = "pictureBoxIngles";
            this.pictureBoxIngles.Size = new System.Drawing.Size(198, 150);
            this.pictureBoxIngles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxIngles.TabIndex = 0;
            this.pictureBoxIngles.TabStop = false;
            this.pictureBoxIngles.Click += new System.EventHandler(this.pictureBoxIngles_Click);
            // 
            // panelEspañol
            // 
            this.panelEspañol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelEspañol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEspañol.Controls.Add(this.labelEspañol);
            this.panelEspañol.Controls.Add(this.pictureBoxEspañol);
            this.panelEspañol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelEspañol.Location = new System.Drawing.Point(21, 125);
            this.panelEspañol.Name = "panelEspañol";
            this.panelEspañol.Size = new System.Drawing.Size(200, 200);
            this.panelEspañol.TabIndex = 0;
            // 
            // labelEspañol
            // 
            this.labelEspañol.AutoSize = true;
            this.labelEspañol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEspañol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEspañol.Location = new System.Drawing.Point(0, 150);
            this.labelEspañol.Name = "labelEspañol";
            this.labelEspañol.Size = new System.Drawing.Size(74, 20);
            this.labelEspañol.TabIndex = 1;
            this.labelEspañol.Text = "Español";
            this.labelEspañol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxEspañol
            // 
            this.pictureBoxEspañol.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxEspañol.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEspañol.Image")));
            this.pictureBoxEspañol.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxEspañol.Name = "pictureBoxEspañol";
            this.pictureBoxEspañol.Size = new System.Drawing.Size(198, 150);
            this.pictureBoxEspañol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEspañol.TabIndex = 0;
            this.pictureBoxEspañol.TabStop = false;
            this.pictureBoxEspañol.Click += new System.EventHandler(this.pictureBoxEspañol_Click);
            // 
            // IdiomaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.labelSeleccioneUnIdioma);
            this.Name = "IdiomaView";
            this.Size = new System.Drawing.Size(486, 475);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIngles)).EndInit();
            this.panelEspañol.ResumeLayout(false);
            this.panelEspañol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEspañol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSeleccioneUnIdioma;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelEspañol;
        private System.Windows.Forms.Label labelEspañol;
        private System.Windows.Forms.PictureBox pictureBoxEspañol;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelIngles;
        private System.Windows.Forms.PictureBox pictureBoxIngles;
    }
}
