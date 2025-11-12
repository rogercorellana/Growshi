namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    partial class GestionUsuariosView
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
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonModificarPermisosUsuario = new System.Windows.Forms.Button();
            this.buttonAdministrarSuscripcion = new System.Windows.Forms.Button();
            this.textBoxBuscarUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEditarUsuario = new System.Windows.Forms.Button();
            this.buttonEliminarUsuario = new System.Windows.Forms.Button();
            this.buttonAgregarUsuario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.AllowUserToAddRows = false;
            this.dataGridViewUsuarios.AllowUserToDeleteRows = false;
            this.dataGridViewUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(0, 61);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.ReadOnly = true;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(1200, 470);
            this.dataGridViewUsuarios.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonModificarPermisosUsuario);
            this.panel1.Controls.Add(this.buttonAdministrarSuscripcion);
            this.panel1.Controls.Add(this.textBoxBuscarUsuario);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonEditarUsuario);
            this.panel1.Controls.Add(this.buttonEliminarUsuario);
            this.panel1.Controls.Add(this.buttonAgregarUsuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 61);
            this.panel1.TabIndex = 1;
            // 
            // buttonModificarPermisosUsuario
            // 
            this.buttonModificarPermisosUsuario.Location = new System.Drawing.Point(883, 21);
            this.buttonModificarPermisosUsuario.Name = "buttonModificarPermisosUsuario";
            this.buttonModificarPermisosUsuario.Size = new System.Drawing.Size(125, 23);
            this.buttonModificarPermisosUsuario.TabIndex = 6;
            this.buttonModificarPermisosUsuario.Text = "Modificar Permisos";
            this.buttonModificarPermisosUsuario.UseVisualStyleBackColor = true;
            this.buttonModificarPermisosUsuario.Click += new System.EventHandler(this.buttonModificarPermisosUsuario_Click);
            // 
            // buttonAdministrarSuscripcion
            // 
            this.buttonAdministrarSuscripcion.Location = new System.Drawing.Point(1014, 21);
            this.buttonAdministrarSuscripcion.Name = "buttonAdministrarSuscripcion";
            this.buttonAdministrarSuscripcion.Size = new System.Drawing.Size(162, 23);
            this.buttonAdministrarSuscripcion.TabIndex = 5;
            this.buttonAdministrarSuscripcion.Text = "Administrar Suscripcion";
            this.buttonAdministrarSuscripcion.UseVisualStyleBackColor = true;
            // 
            // textBoxBuscarUsuario
            // 
            this.textBoxBuscarUsuario.Location = new System.Drawing.Point(74, 18);
            this.textBoxBuscarUsuario.Name = "textBoxBuscarUsuario";
            this.textBoxBuscarUsuario.Size = new System.Drawing.Size(100, 20);
            this.textBoxBuscarUsuario.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Buscar: ";
            // 
            // buttonEditarUsuario
            // 
            this.buttonEditarUsuario.Location = new System.Drawing.Point(459, 18);
            this.buttonEditarUsuario.Name = "buttonEditarUsuario";
            this.buttonEditarUsuario.Size = new System.Drawing.Size(125, 23);
            this.buttonEditarUsuario.TabIndex = 2;
            this.buttonEditarUsuario.Text = "Editar Seleccionado";
            this.buttonEditarUsuario.UseVisualStyleBackColor = true;
            this.buttonEditarUsuario.Click += new System.EventHandler(this.buttonEditarUsuario_Click);
            // 
            // buttonEliminarUsuario
            // 
            this.buttonEliminarUsuario.Location = new System.Drawing.Point(328, 18);
            this.buttonEliminarUsuario.Name = "buttonEliminarUsuario";
            this.buttonEliminarUsuario.Size = new System.Drawing.Size(125, 23);
            this.buttonEliminarUsuario.TabIndex = 1;
            this.buttonEliminarUsuario.Text = "Desactivar";
            this.buttonEliminarUsuario.UseVisualStyleBackColor = true;
            this.buttonEliminarUsuario.Click += new System.EventHandler(this.buttonEliminarUsuario_Click);
            // 
            // buttonAgregarUsuario
            // 
            this.buttonAgregarUsuario.Location = new System.Drawing.Point(197, 18);
            this.buttonAgregarUsuario.Name = "buttonAgregarUsuario";
            this.buttonAgregarUsuario.Size = new System.Drawing.Size(125, 23);
            this.buttonAgregarUsuario.TabIndex = 0;
            this.buttonAgregarUsuario.Text = "Agregar Nuevo";
            this.buttonAgregarUsuario.UseVisualStyleBackColor = true;
            this.buttonAgregarUsuario.Click += new System.EventHandler(this.buttonAgregarUsuario_Click);
            // 
            // GestionUsuariosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewUsuarios);
            this.Controls.Add(this.panel1);
            this.Name = "GestionUsuariosView";
            this.Size = new System.Drawing.Size(1200, 531);
            this.Load += new System.EventHandler(this.GestionUsuariosView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAgregarUsuario;
        private System.Windows.Forms.TextBox textBoxBuscarUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEditarUsuario;
        private System.Windows.Forms.Button buttonEliminarUsuario;
        private System.Windows.Forms.Button buttonAdministrarSuscripcion;
        private System.Windows.Forms.Button buttonModificarPermisosUsuario;
    }
}
