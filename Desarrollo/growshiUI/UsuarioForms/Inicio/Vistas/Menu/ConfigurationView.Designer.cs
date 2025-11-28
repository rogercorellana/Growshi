namespace growshiUI.UsuarioForms.Inicio.Vistas
{
    partial class ConfigurationView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.tableLayoutMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnGestionUsuarios = new MetroFramework.Controls.MetroButton();
            this.btnRolesPermisos = new MetroFramework.Controls.MetroButton();
            this.btnAjusteSistema = new MetroFramework.Controls.MetroButton();
            this.btnCopiaSeguridad = new MetroFramework.Controls.MetroButton();
            this.btnActualizaciones = new MetroFramework.Controls.MetroButton();
            this.panelTituloMenu = new System.Windows.Forms.Panel();
            this.lblMenuTitulo = new System.Windows.Forms.Label();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.lblPlaceholder = new MetroFramework.Controls.MetroLabel();
            this.panelMenu.SuspendLayout();
            this.tableLayoutMenu.SuspendLayout();
            this.panelTituloMenu.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(150)))), ((int)(((byte)(90)))));
            this.panelMenu.Controls.Add(this.tableLayoutMenu);
            this.panelMenu.Controls.Add(this.panelTituloMenu);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(180, 500);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            this.panelMenu.Resize += new System.EventHandler(this.panelMenu_Resize);
            // 
            // tableLayoutMenu
            // 
            this.tableLayoutMenu.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutMenu.ColumnCount = 1;
            this.tableLayoutMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMenu.Controls.Add(this.btnGestionUsuarios, 0, 0);
            this.tableLayoutMenu.Controls.Add(this.btnRolesPermisos, 0, 1);
            this.tableLayoutMenu.Controls.Add(this.btnAjusteSistema, 0, 2);
            this.tableLayoutMenu.Controls.Add(this.btnCopiaSeguridad, 0, 3);
            this.tableLayoutMenu.Controls.Add(this.btnActualizaciones, 0, 4);
            this.tableLayoutMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutMenu.Location = new System.Drawing.Point(0, 80);
            this.tableLayoutMenu.Name = "tableLayoutMenu";
            this.tableLayoutMenu.RowCount = 5;
            this.tableLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutMenu.Size = new System.Drawing.Size(180, 350);
            this.tableLayoutMenu.TabIndex = 1;
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGestionUsuarios.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnGestionUsuarios.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnGestionUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnGestionUsuarios.Location = new System.Drawing.Point(3, 3);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(174, 64);
            this.btnGestionUsuarios.Style = MetroFramework.MetroColorStyle.Green;
            this.btnGestionUsuarios.TabIndex = 0;
            this.btnGestionUsuarios.Text = "Gestión de Usuarios";
            this.btnGestionUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionUsuarios.UseCustomBackColor = true;
            this.btnGestionUsuarios.UseCustomForeColor = true;
            this.btnGestionUsuarios.UseSelectable = true;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // btnRolesPermisos
            // 
            this.btnRolesPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRolesPermisos.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnRolesPermisos.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnRolesPermisos.ForeColor = System.Drawing.Color.White;
            this.btnRolesPermisos.Location = new System.Drawing.Point(3, 73);
            this.btnRolesPermisos.Name = "btnRolesPermisos";
            this.btnRolesPermisos.Size = new System.Drawing.Size(174, 64);
            this.btnRolesPermisos.Style = MetroFramework.MetroColorStyle.Green;
            this.btnRolesPermisos.TabIndex = 1;
            this.btnRolesPermisos.Text = "Roles y Permisos";
            this.btnRolesPermisos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRolesPermisos.UseCustomBackColor = true;
            this.btnRolesPermisos.UseCustomForeColor = true;
            this.btnRolesPermisos.UseSelectable = true;
            this.btnRolesPermisos.Click += new System.EventHandler(this.btnRolesPermisos_Click);
            // 
            // btnAjusteSistema
            // 
            this.btnAjusteSistema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAjusteSistema.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnAjusteSistema.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnAjusteSistema.ForeColor = System.Drawing.Color.White;
            this.btnAjusteSistema.Location = new System.Drawing.Point(3, 143);
            this.btnAjusteSistema.Name = "btnAjusteSistema";
            this.btnAjusteSistema.Size = new System.Drawing.Size(174, 64);
            this.btnAjusteSistema.Style = MetroFramework.MetroColorStyle.Green;
            this.btnAjusteSistema.TabIndex = 2;
            this.btnAjusteSistema.Text = "Ajustes del Sistema";
            this.btnAjusteSistema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAjusteSistema.UseCustomBackColor = true;
            this.btnAjusteSistema.UseCustomForeColor = true;
            this.btnAjusteSistema.UseSelectable = true;
            this.btnAjusteSistema.Click += new System.EventHandler(this.btnAjusteSistema_Click);
            // 
            // btnCopiaSeguridad
            // 
            this.btnCopiaSeguridad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCopiaSeguridad.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnCopiaSeguridad.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnCopiaSeguridad.ForeColor = System.Drawing.Color.White;
            this.btnCopiaSeguridad.Location = new System.Drawing.Point(3, 213);
            this.btnCopiaSeguridad.Name = "btnCopiaSeguridad";
            this.btnCopiaSeguridad.Size = new System.Drawing.Size(174, 64);
            this.btnCopiaSeguridad.Style = MetroFramework.MetroColorStyle.Green;
            this.btnCopiaSeguridad.TabIndex = 3;
            this.btnCopiaSeguridad.Text = "Copias de Seguridad";
            this.btnCopiaSeguridad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopiaSeguridad.UseCustomBackColor = true;
            this.btnCopiaSeguridad.UseCustomForeColor = true;
            this.btnCopiaSeguridad.UseSelectable = true;
            this.btnCopiaSeguridad.Click += new System.EventHandler(this.btnCopiaSeguridad_Click);
            // 
            // btnActualizaciones
            // 
            this.btnActualizaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnActualizaciones.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnActualizaciones.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnActualizaciones.ForeColor = System.Drawing.Color.White;
            this.btnActualizaciones.Location = new System.Drawing.Point(3, 283);
            this.btnActualizaciones.Name = "btnActualizaciones";
            this.btnActualizaciones.Size = new System.Drawing.Size(174, 64);
            this.btnActualizaciones.Style = MetroFramework.MetroColorStyle.Green;
            this.btnActualizaciones.TabIndex = 4;
            this.btnActualizaciones.Text = "Actualizaciones";
            this.btnActualizaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizaciones.UseCustomBackColor = true;
            this.btnActualizaciones.UseCustomForeColor = true;
            this.btnActualizaciones.UseSelectable = true;
            this.btnActualizaciones.Click += new System.EventHandler(this.btnActualizaciones_Click);
            // 
            // panelTituloMenu
            // 
            this.panelTituloMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelTituloMenu.Controls.Add(this.lblMenuTitulo);
            this.panelTituloMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTituloMenu.Location = new System.Drawing.Point(0, 0);
            this.panelTituloMenu.Name = "panelTituloMenu";
            this.panelTituloMenu.Size = new System.Drawing.Size(180, 80);
            this.panelTituloMenu.TabIndex = 0;
            // 
            // lblMenuTitulo
            // 
            this.lblMenuTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMenuTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuTitulo.ForeColor = System.Drawing.Color.White;
            this.lblMenuTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblMenuTitulo.Name = "lblMenuTitulo";
            this.lblMenuTitulo.Padding = new System.Windows.Forms.Padding(20, 20, 0, 0);
            this.lblMenuTitulo.Size = new System.Drawing.Size(180, 80);
            this.lblMenuTitulo.TabIndex = 0;
            this.lblMenuTitulo.Text = "Configuración";
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContenido.Controls.Add(this.lblPlaceholder);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(180, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Padding = new System.Windows.Forms.Padding(30);
            this.panelContenido.Size = new System.Drawing.Size(720, 500);
            this.panelContenido.TabIndex = 1;
            // 
            // lblPlaceholder
            // 
            this.lblPlaceholder.AutoSize = true;
            this.lblPlaceholder.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPlaceholder.ForeColor = System.Drawing.Color.Gray;
            this.lblPlaceholder.Location = new System.Drawing.Point(30, 40);
            this.lblPlaceholder.Name = "lblPlaceholder";
            this.lblPlaceholder.Size = new System.Drawing.Size(272, 25);
            this.lblPlaceholder.TabIndex = 0;
            this.lblPlaceholder.Text = "Seleccione una opción del menú...";
            this.lblPlaceholder.UseCustomForeColor = true;
            // 
            // ConfigurationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelMenu);
            this.Name = "ConfigurationView";
            this.Size = new System.Drawing.Size(900, 500);
            this.panelMenu.ResumeLayout(false);
            this.tableLayoutMenu.ResumeLayout(false);
            this.panelTituloMenu.ResumeLayout(false);
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Panel panelTituloMenu;
        private System.Windows.Forms.Label lblMenuTitulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMenu;
        private MetroFramework.Controls.MetroButton btnGestionUsuarios;
        private MetroFramework.Controls.MetroButton btnRolesPermisos;
        private MetroFramework.Controls.MetroButton btnAjusteSistema;
        private MetroFramework.Controls.MetroButton btnCopiaSeguridad;
        private MetroFramework.Controls.MetroButton btnActualizaciones;
        private MetroFramework.Controls.MetroLabel lblPlaceholder;
    }
}