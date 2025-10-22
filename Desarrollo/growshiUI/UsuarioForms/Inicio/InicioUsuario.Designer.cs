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
            this.MenuStrip_inicioMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_misCultivosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_historialMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_reportesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_configuracionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_miCuentaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripGlobal = new System.Windows.Forms.MenuStrip();
            this.MenuStrip_idiomaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelInicio = new System.Windows.Forms.Panel();
            this.menuStripGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip_inicioMenuItem
            // 
            this.MenuStrip_inicioMenuItem.Name = "MenuStrip_inicioMenuItem";
            this.MenuStrip_inicioMenuItem.Size = new System.Drawing.Size(48, 20);
            this.MenuStrip_inicioMenuItem.Text = "Inicio";
            this.MenuStrip_inicioMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // MenuStrip_misCultivosMenuItem
            // 
            this.MenuStrip_misCultivosMenuItem.Name = "MenuStrip_misCultivosMenuItem";
            this.MenuStrip_misCultivosMenuItem.Size = new System.Drawing.Size(84, 20);
            this.MenuStrip_misCultivosMenuItem.Text = "Mis Cultivos";
            // 
            // MenuStrip_historialMenuItem
            // 
            this.MenuStrip_historialMenuItem.Name = "MenuStrip_historialMenuItem";
            this.MenuStrip_historialMenuItem.Size = new System.Drawing.Size(63, 20);
            this.MenuStrip_historialMenuItem.Text = "Historial";
            // 
            // MenuStrip_reportesMenuItem
            // 
            this.MenuStrip_reportesMenuItem.Name = "MenuStrip_reportesMenuItem";
            this.MenuStrip_reportesMenuItem.Size = new System.Drawing.Size(65, 20);
            this.MenuStrip_reportesMenuItem.Text = "Reportes";
            // 
            // MenuStrip_configuracionMenuItem
            // 
            this.MenuStrip_configuracionMenuItem.Name = "MenuStrip_configuracionMenuItem";
            this.MenuStrip_configuracionMenuItem.ShowShortcutKeys = false;
            this.MenuStrip_configuracionMenuItem.Size = new System.Drawing.Size(95, 20);
            this.MenuStrip_configuracionMenuItem.Text = "Configuración";
            this.MenuStrip_configuracionMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);
            // 
            // MenuStrip_miCuentaMenuItem
            // 
            this.MenuStrip_miCuentaMenuItem.Name = "MenuStrip_miCuentaMenuItem";
            this.MenuStrip_miCuentaMenuItem.Size = new System.Drawing.Size(74, 20);
            this.MenuStrip_miCuentaMenuItem.Text = "Mi Cuenta";
            // 
            // menuStripGlobal
            // 
            this.menuStripGlobal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStrip_inicioMenuItem,
            this.MenuStrip_misCultivosMenuItem,
            this.MenuStrip_historialMenuItem,
            this.MenuStrip_reportesMenuItem,
            this.MenuStrip_configuracionMenuItem,
            this.MenuStrip_miCuentaMenuItem,
            this.MenuStrip_idiomaMenuItem});
            this.menuStripGlobal.Location = new System.Drawing.Point(0, 0);
            this.menuStripGlobal.Name = "menuStripGlobal";
            this.menuStripGlobal.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStripGlobal.Size = new System.Drawing.Size(916, 24);
            this.menuStripGlobal.TabIndex = 4;
            this.menuStripGlobal.Text = "menuStrip1";
            // 
            // MenuStrip_idiomaMenuItem
            // 
            this.MenuStrip_idiomaMenuItem.Name = "MenuStrip_idiomaMenuItem";
            this.MenuStrip_idiomaMenuItem.Size = new System.Drawing.Size(56, 20);
            this.MenuStrip_idiomaMenuItem.Text = "Idioma";
            this.MenuStrip_idiomaMenuItem.Click += new System.EventHandler(this.idiomaToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_inicioMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_misCultivosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_historialMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_reportesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_configuracionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_miCuentaMenuItem;
        private System.Windows.Forms.MenuStrip menuStripGlobal;
        private System.Windows.Forms.Panel panelInicio;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_idiomaMenuItem;
    }
}