namespace growshiUI.UsuarioForms.Inicio.Vistas
{
    partial class ConfigurationView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonCopiaSeguridad = new System.Windows.Forms.Button();
            this.buttonAjusteSistema = new System.Windows.Forms.Button();
            this.buttonRolesPermisos = new System.Windows.Forms.Button();
            this.btnGestionUsuarios = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.buttonCopiaSeguridad);
            this.splitContainer1.Panel1.Controls.Add(this.buttonAjusteSistema);
            this.splitContainer1.Panel1.Controls.Add(this.buttonRolesPermisos);
            this.splitContainer1.Panel1.Controls.Add(this.btnGestionUsuarios);
            this.splitContainer1.Size = new System.Drawing.Size(816, 597);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonCopiaSeguridad
            // 
            this.buttonCopiaSeguridad.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCopiaSeguridad.FlatAppearance.BorderSize = 0;
            this.buttonCopiaSeguridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCopiaSeguridad.Location = new System.Drawing.Point(0, 345);
            this.buttonCopiaSeguridad.Name = "buttonCopiaSeguridad";
            this.buttonCopiaSeguridad.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonCopiaSeguridad.Size = new System.Drawing.Size(224, 125);
            this.buttonCopiaSeguridad.TabIndex = 3;
            this.buttonCopiaSeguridad.Text = "Copias de Seguridad";
            this.buttonCopiaSeguridad.UseVisualStyleBackColor = true;
            // 
            // buttonAjusteSistema
            // 
            this.buttonAjusteSistema.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonAjusteSistema.FlatAppearance.BorderSize = 0;
            this.buttonAjusteSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjusteSistema.Location = new System.Drawing.Point(0, 236);
            this.buttonAjusteSistema.Name = "buttonAjusteSistema";
            this.buttonAjusteSistema.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonAjusteSistema.Size = new System.Drawing.Size(224, 109);
            this.buttonAjusteSistema.TabIndex = 2;
            this.buttonAjusteSistema.Text = "Ajustes del Sistema";
            this.buttonAjusteSistema.UseVisualStyleBackColor = true;
            // 
            // buttonRolesPermisos
            // 
            this.buttonRolesPermisos.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonRolesPermisos.FlatAppearance.BorderSize = 0;
            this.buttonRolesPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRolesPermisos.Location = new System.Drawing.Point(0, 127);
            this.buttonRolesPermisos.Name = "buttonRolesPermisos";
            this.buttonRolesPermisos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonRolesPermisos.Size = new System.Drawing.Size(224, 109);
            this.buttonRolesPermisos.TabIndex = 1;
            this.buttonRolesPermisos.Text = "Roles y permisos\n\n";
            this.buttonRolesPermisos.UseVisualStyleBackColor = true;
            this.buttonRolesPermisos.Click += new System.EventHandler(this.buttonRolesPermisos_Click);
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionUsuarios.FlatAppearance.BorderSize = 0;
            this.btnGestionUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionUsuarios.Location = new System.Drawing.Point(0, 0);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGestionUsuarios.Size = new System.Drawing.Size(224, 127);
            this.btnGestionUsuarios.TabIndex = 0;
            this.btnGestionUsuarios.Text = "Gestión de Usuarios";
            this.btnGestionUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(0, 470);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(224, 124);
            this.button1.TabIndex = 4;
            this.button1.Text = "Actualizaciones";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ConfigurationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConfigurationView";
            this.Size = new System.Drawing.Size(816, 597);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button buttonCopiaSeguridad;
        private System.Windows.Forms.Button buttonAjusteSistema;
        private System.Windows.Forms.Button buttonRolesPermisos;
        private System.Windows.Forms.Button button1;
    }
}
