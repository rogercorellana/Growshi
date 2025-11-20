namespace growshiUI.UsuarioForms
{
    partial class InicioUsuario
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

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
            this.MenuStrip_inicioMenuItem.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.MenuStrip_inicioMenuItem.Size = new System.Drawing.Size(67, 36);
            this.MenuStrip_inicioMenuItem.Text = "Inicio";
            this.MenuStrip_inicioMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);

            // 
            // MenuStrip_misCultivosMenuItem
            // 
            this.MenuStrip_misCultivosMenuItem.Name = "MenuStrip_misCultivosMenuItem";
            this.MenuStrip_misCultivosMenuItem.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.MenuStrip_misCultivosMenuItem.Size = new System.Drawing.Size(107, 36);
            this.MenuStrip_misCultivosMenuItem.Text = "Mis Cultivos";
            this.MenuStrip_misCultivosMenuItem.Click += new System.EventHandler(this.MenuStrip_misCultivosMenuItem_Click);

            // 
            // MenuStrip_historialMenuItem
            // 
            this.MenuStrip_historialMenuItem.Name = "MenuStrip_historialMenuItem";
            this.MenuStrip_historialMenuItem.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.MenuStrip_historialMenuItem.Size = new System.Drawing.Size(83, 36);
            this.MenuStrip_historialMenuItem.Text = "Historial";
            this.MenuStrip_historialMenuItem.Click += new System.EventHandler(this.MenuStrip_historialMenuItem_Click);

            // 
            // MenuStrip_reportesMenuItem
            // 
            this.MenuStrip_reportesMenuItem.Name = "MenuStrip_reportesMenuItem";
            this.MenuStrip_reportesMenuItem.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.MenuStrip_reportesMenuItem.Size = new System.Drawing.Size(86, 36);
            this.MenuStrip_reportesMenuItem.Text = "Reportes";
            this.MenuStrip_reportesMenuItem.Click += new System.EventHandler(this.MenuStrip_reportesMenuItem_Click);

            // 
            // MenuStrip_configuracionMenuItem
            // 
            this.MenuStrip_configuracionMenuItem.Name = "MenuStrip_configuracionMenuItem";
            this.MenuStrip_configuracionMenuItem.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.MenuStrip_configuracionMenuItem.ShowShortcutKeys = false;
            this.MenuStrip_configuracionMenuItem.Size = new System.Drawing.Size(119, 36);
            this.MenuStrip_configuracionMenuItem.Text = "Configuración";
            this.MenuStrip_configuracionMenuItem.Click += new System.EventHandler(this.configuraciónToolStripMenuItem_Click);

            // 
            // MenuStrip_miCuentaMenuItem
            // 
            this.MenuStrip_miCuentaMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right; // A la derecha
            this.MenuStrip_miCuentaMenuItem.Name = "MenuStrip_miCuentaMenuItem";
            this.MenuStrip_miCuentaMenuItem.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.MenuStrip_miCuentaMenuItem.Size = new System.Drawing.Size(96, 36);
            this.MenuStrip_miCuentaMenuItem.Text = "Mi Cuenta";

            // 
            // MenuStrip_idiomaMenuItem
            // 
            this.MenuStrip_idiomaMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right; // A la derecha
            this.MenuStrip_idiomaMenuItem.Name = "MenuStrip_idiomaMenuItem";
            this.MenuStrip_idiomaMenuItem.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.MenuStrip_idiomaMenuItem.Size = new System.Drawing.Size(76, 36);
            this.MenuStrip_idiomaMenuItem.Text = "Idioma";
            this.MenuStrip_idiomaMenuItem.Click += new System.EventHandler(this.idiomaToolStripMenuItem_Click);

            // 
            // menuStripGlobal
            // 
            this.menuStripGlobal.BackColor = System.Drawing.Color.White; // Fondo blanco limpio
            this.menuStripGlobal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); // Fuente moderna
            this.menuStripGlobal.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStripGlobal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStrip_inicioMenuItem,
            this.MenuStrip_misCultivosMenuItem,
            this.MenuStrip_historialMenuItem,
            this.MenuStrip_reportesMenuItem,
            this.MenuStrip_configuracionMenuItem,
            this.MenuStrip_miCuentaMenuItem,
            this.MenuStrip_idiomaMenuItem});
            this.menuStripGlobal.Location = new System.Drawing.Point(20, 60); // Ajustado al padding de MetroForm
            this.menuStripGlobal.Name = "menuStripGlobal";
            this.menuStripGlobal.Padding = new System.Windows.Forms.Padding(0);
            this.menuStripGlobal.RenderMode = System.Windows.Forms.ToolStripRenderMode.System; // Estilo plano sin bordes 3D
            this.menuStripGlobal.Size = new System.Drawing.Size(960, 36); // Altura mayor para toque moderno
            this.menuStripGlobal.TabIndex = 4;
            this.menuStripGlobal.Text = "menuStripGlobal";

            // 
            // panelInicio
            // 
            this.panelInicio.BackColor = System.Drawing.Color.WhiteSmoke; // Fondo gris muy claro para el contenido
            this.panelInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInicio.Location = new System.Drawing.Point(20, 96); // Debajo del menú
            this.panelInicio.Name = "panelInicio";
            this.panelInicio.Padding = new System.Windows.Forms.Padding(10); // Margen interno
            this.panelInicio.Size = new System.Drawing.Size(960, 584);
            this.panelInicio.TabIndex = 5;

            // 
            // InicioUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panelInicio);
            this.Controls.Add(this.menuStripGlobal);
            this.DisplayHeader = true; // Mostrar Título de la App
            this.MainMenuStrip = this.menuStripGlobal;
            this.Name = "InicioUsuario";
            this.Padding = new System.Windows.Forms.Padding(20, 60, 20, 20); // Padding estándar de MetroForm
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Green; // Verde Growshi en el título
            this.Text = "Growshi Dashboard";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
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