namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_RolesYPermisos
{
    partial class AgregarFamilia
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
            this.buttonAgregarFamilia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPermisoID = new System.Windows.Forms.TextBox();
            this.textBoxNombreDescriptivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAgregarFamilia
            // 
            this.buttonAgregarFamilia.Location = new System.Drawing.Point(225, 140);
            this.buttonAgregarFamilia.Name = "buttonAgregarFamilia";
            this.buttonAgregarFamilia.Size = new System.Drawing.Size(124, 23);
            this.buttonAgregarFamilia.TabIndex = 0;
            this.buttonAgregarFamilia.Text = "Crear";
            this.buttonAgregarFamilia.UseVisualStyleBackColor = true;
            this.buttonAgregarFamilia.Click += new System.EventHandler(this.buttonAgregarFamilia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PermisoID";
            // 
            // textBoxPermisoID
            // 
            this.textBoxPermisoID.Location = new System.Drawing.Point(146, 55);
            this.textBoxPermisoID.Name = "textBoxPermisoID";
            this.textBoxPermisoID.Size = new System.Drawing.Size(203, 20);
            this.textBoxPermisoID.TabIndex = 2;
            // 
            // textBoxNombreDescriptivo
            // 
            this.textBoxNombreDescriptivo.Location = new System.Drawing.Point(146, 97);
            this.textBoxNombreDescriptivo.Name = "textBoxNombreDescriptivo";
            this.textBoxNombreDescriptivo.Size = new System.Drawing.Size(203, 20);
            this.textBoxNombreDescriptivo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripcion Corta";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPermisoID);
            this.groupBox1.Controls.Add(this.textBoxNombreDescriptivo);
            this.groupBox1.Controls.Add(this.buttonAgregarFamilia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 210);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crear Familia";
            // 
            // AgregarFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "AgregarFamilia";
            this.Size = new System.Drawing.Size(400, 210);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAgregarFamilia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPermisoID;
        private System.Windows.Forms.TextBox textBoxNombreDescriptivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
