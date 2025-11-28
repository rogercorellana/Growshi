namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_RolesYPermisos
{
    partial class ModificarFamilia
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxPermisoIDAntes = new System.Windows.Forms.TextBox();
            this.textBoxNombreDescriptivoAntes = new System.Windows.Forms.TextBox();
            this.buttonModificarFamilia = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPermisoIDDespues = new System.Windows.Forms.TextBox();
            this.textBoxNombreDescriptivoDespues = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxNombreDescriptivoDespues);
            this.groupBox1.Controls.Add(this.textBoxPermisoIDDespues);
            this.groupBox1.Controls.Add(this.textBoxPermisoIDAntes);
            this.groupBox1.Controls.Add(this.textBoxNombreDescriptivoAntes);
            this.groupBox1.Controls.Add(this.buttonModificarFamilia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 394);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar Familia";
            // 
            // textBoxPermisoIDAntes
            // 
            this.textBoxPermisoIDAntes.Location = new System.Drawing.Point(152, 129);
            this.textBoxPermisoIDAntes.Name = "textBoxPermisoIDAntes";
            this.textBoxPermisoIDAntes.Size = new System.Drawing.Size(203, 20);
            this.textBoxPermisoIDAntes.TabIndex = 2;
            // 
            // textBoxNombreDescriptivoAntes
            // 
            this.textBoxNombreDescriptivoAntes.Location = new System.Drawing.Point(152, 171);
            this.textBoxNombreDescriptivoAntes.Name = "textBoxNombreDescriptivoAntes";
            this.textBoxNombreDescriptivoAntes.Size = new System.Drawing.Size(203, 20);
            this.textBoxNombreDescriptivoAntes.TabIndex = 4;
            // 
            // buttonModificarFamilia
            // 
            this.buttonModificarFamilia.Location = new System.Drawing.Point(540, 218);
            this.buttonModificarFamilia.Name = "buttonModificarFamilia";
            this.buttonModificarFamilia.Size = new System.Drawing.Size(124, 23);
            this.buttonModificarFamilia.TabIndex = 0;
            this.buttonModificarFamilia.Text = "Modificar";
            this.buttonModificarFamilia.UseVisualStyleBackColor = true;
            this.buttonModificarFamilia.Click += new System.EventHandler(this.buttonModificarFamilia_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripcion Corta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "PermisoID";
            // 
            // textBoxPermisoIDDespues
            // 
            this.textBoxPermisoIDDespues.Location = new System.Drawing.Point(461, 129);
            this.textBoxPermisoIDDespues.Name = "textBoxPermisoIDDespues";
            this.textBoxPermisoIDDespues.Size = new System.Drawing.Size(203, 20);
            this.textBoxPermisoIDDespues.TabIndex = 5;
            // 
            // textBoxNombreDescriptivoDespues
            // 
            this.textBoxNombreDescriptivoDespues.Location = new System.Drawing.Point(461, 171);
            this.textBoxNombreDescriptivoDespues.Name = "textBoxNombreDescriptivoDespues";
            this.textBoxNombreDescriptivoDespues.Size = new System.Drawing.Size(203, 20);
            this.textBoxNombreDescriptivoDespues.TabIndex = 6;
            // 
            // ModificarFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificarFamilia";
            this.Size = new System.Drawing.Size(742, 394);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxNombreDescriptivoDespues;
        private System.Windows.Forms.TextBox textBoxPermisoIDDespues;
        private System.Windows.Forms.TextBox textBoxPermisoIDAntes;
        private System.Windows.Forms.TextBox textBoxNombreDescriptivoAntes;
        private System.Windows.Forms.Button buttonModificarFamilia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
