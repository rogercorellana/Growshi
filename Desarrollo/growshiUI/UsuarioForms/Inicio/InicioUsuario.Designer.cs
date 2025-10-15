namespace growshiUI.UsuarioForms
{
    partial class InicioUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inicioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.misCultivosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historialMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miCuentaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripGlobal = new System.Windows.Forms.MenuStrip();
            this.idiomaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelInicio = new System.Windows.Forms.Panel();
            this.menuStripGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // inicioMenuItem
            // 
            this.inicioMenuItem.Name = "inicioMenuItem";
            this.inicioMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioMenuItem.Text = "Inicio";
            this.inicioMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // misCultivosMenuItem
            // 
            this.misCultivosMenuItem.Name = "misCultivosMenuItem";
            this.misCultivosMenuItem.Size = new System.Drawing.Size(84, 20);
            this.misCultivosMenuItem.Text = "Mis Cultivos";
            // 
            // historialMenuItem
            // 
            this.historialMenuItem.Name = "historialMenuItem";
            this.historialMenuItem.Size = new System.Drawing.Size(63, 20);
            this.historialMenuItem.Text = "Historial";
            // 
            // reportesMenuItem
            // 
            this.reportesMenuItem.Name = "reportesMenuItem";
            this.reportesMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesMenuItem.Text = "Reportes";
            // 
            // configuracionMenuItem
            // 
            this.configuracionMenuItem.Name = "configuracionMenuItem";
            this.configuracionMenuItem.ShowShortcutKeys = false;
            this.configuracionMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuracionMenuItem.Text = "Configuración";
            this.configuracionMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // miCuentaMenuItem
            // 
            this.miCuentaMenuItem.Name = "miCuentaMenuItem";
            this.miCuentaMenuItem.Size = new System.Drawing.Size(74, 20);
            this.miCuentaMenuItem.Text = "Mi Cuenta";
            // 
            // menuStripGlobal
            // 
            this.menuStripGlobal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioMenuItem,
            this.misCultivosMenuItem,
            this.historialMenuItem,
            this.reportesMenuItem,
            this.configuracionMenuItem,
            this.miCuentaMenuItem,
            this.idiomaMenuItem});
            this.menuStripGlobal.Location = new System.Drawing.Point(0, 0);
            this.menuStripGlobal.Name = "menuStripGlobal";
            this.menuStripGlobal.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStripGlobal.Size = new System.Drawing.Size(916, 24);
            this.menuStripGlobal.TabIndex = 4;
            this.menuStripGlobal.Text = "menuStrip1";
            // 
            // idiomaMenuItem
            // 
            this.idiomaMenuItem.Name = "idiomaMenuItem";
            this.idiomaMenuItem.Size = new System.Drawing.Size(56, 20);
            this.idiomaMenuItem.Text = "Idioma";
            this.idiomaMenuItem.Click += new System.EventHandler(this.idiomaToolStripMenuItem_Click);
            // 
            // panelInicio
            // 
            this.panelInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInicio.Location = new System.Drawing.Point(0, 24);
            this.panelInicio.Name = "panelInicio";
            this.panelInicio.Size = new System.Drawing.Size(916, 603);
            this.panelInicio.TabIndex = 5;
            // 
            // InicioUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 627);
            this.Controls.Add(this.panelInicio);
            this.Controls.Add(this.menuStripGlobal);
            this.Name = "InicioUsuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InicioUsuario_FormClosing);
            this.Load += new System.EventHandler(this.InicioUsuario_Load);
            this.menuStripGlobal.ResumeLayout(false);
            this.menuStripGlobal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem inicioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem misCultivosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historialMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miCuentaMenuItem;
        private System.Windows.Forms.MenuStrip menuStripGlobal;
        private System.Windows.Forms.Panel panelInicio;
        private System.Windows.Forms.ToolStripMenuItem idiomaMenuItem;
    }
}