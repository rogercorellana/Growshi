namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    partial class RolesYPermisosView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxRoles = new System.Windows.Forms.ListBox();
            this.labelRoles = new System.Windows.Forms.Label();
            this.btnGuardarPermisos = new System.Windows.Forms.Button();
            this.checkedListBoxPermisos = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxRoles);
            this.splitContainer1.Panel1.Controls.Add(this.labelRoles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnGuardarPermisos);
            this.splitContainer1.Panel2.Controls.Add(this.checkedListBoxPermisos);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(704, 647);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 602);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 45);
            this.panel1.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(172, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(91, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Renombrar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Nuevo";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listBoxRoles
            // 
            this.listBoxRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxRoles.FormattingEnabled = true;
            this.listBoxRoles.Location = new System.Drawing.Point(0, 20);
            this.listBoxRoles.Name = "listBoxRoles";
            this.listBoxRoles.Size = new System.Drawing.Size(250, 627);
            this.listBoxRoles.TabIndex = 1;
            this.listBoxRoles.SelectedIndexChanged += new System.EventHandler(this.listBoxRoles_SelectedIndexChanged);
            // 
            // labelRoles
            // 
            this.labelRoles.AutoSize = true;
            this.labelRoles.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoles.Location = new System.Drawing.Point(0, 0);
            this.labelRoles.Name = "labelRoles";
            this.labelRoles.Size = new System.Drawing.Size(154, 20);
            this.labelRoles.TabIndex = 0;
            this.labelRoles.Text = "Roles del Sistema";
            // 
            // btnGuardarPermisos
            // 
            this.btnGuardarPermisos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGuardarPermisos.Location = new System.Drawing.Point(0, 602);
            this.btnGuardarPermisos.Name = "btnGuardarPermisos";
            this.btnGuardarPermisos.Size = new System.Drawing.Size(450, 45);
            this.btnGuardarPermisos.TabIndex = 2;
            this.btnGuardarPermisos.Text = "Guardar Cambios";
            this.btnGuardarPermisos.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxPermisos
            // 
            this.checkedListBoxPermisos.CheckOnClick = true;
            this.checkedListBoxPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxPermisos.FormattingEnabled = true;
            this.checkedListBoxPermisos.Location = new System.Drawing.Point(0, 20);
            this.checkedListBoxPermisos.Name = "checkedListBoxPermisos";
            this.checkedListBoxPermisos.Size = new System.Drawing.Size(450, 627);
            this.checkedListBoxPermisos.TabIndex = 1;
            this.checkedListBoxPermisos.Click += new System.EventHandler(this.q);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione un Rol...";
            // 
            // RolesYPermisosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "RolesYPermisosView";
            this.Size = new System.Drawing.Size(704, 647);
            this.Load += new System.EventHandler(this.RolesYPermisosView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxRoles;
        private System.Windows.Forms.Label labelRoles;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardarPermisos;
        private System.Windows.Forms.CheckedListBox checkedListBoxPermisos;
    }
}
