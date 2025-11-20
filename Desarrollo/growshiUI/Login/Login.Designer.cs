namespace growshiUI
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelFondo = new System.Windows.Forms.Panel();
            this.panelTarjeta = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.textBoxUsuario = new MetroFramework.Controls.MetroTextBox();
            this.textBoxContraseña = new MetroFramework.Controls.MetroTextBox();
            this.buttonIniciarSesion = new MetroFramework.Controls.MetroButton();
            this.buttonOlvideMiContraseña = new MetroFramework.Controls.MetroLink();
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.temporizadorBloqueo = new System.Windows.Forms.Timer(this.components);
            this.panelFondo.SuspendLayout();
            this.panelTarjeta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFondo
            // 
            this.panelFondo.Controls.Add(this.panelTarjeta);
            this.panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFondo.Location = new System.Drawing.Point(0, 30);
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.Size = new System.Drawing.Size(900, 570);
            this.panelFondo.TabIndex = 0;
            this.panelFondo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFondo_Paint);
            this.panelFondo.Resize += new System.EventHandler(this.panelFondo_Resize);
            // 
            // panelTarjeta
            // 
            this.panelTarjeta.BackColor = System.Drawing.Color.White;
            this.panelTarjeta.Controls.Add(this.lblSubtitulo);
            this.panelTarjeta.Controls.Add(this.lblTitulo);
            this.panelTarjeta.Controls.Add(this.pictureBoxLogo);
            this.panelTarjeta.Controls.Add(this.textBoxUsuario);
            this.panelTarjeta.Controls.Add(this.textBoxContraseña);
            this.panelTarjeta.Controls.Add(this.buttonIniciarSesion);
            this.panelTarjeta.Controls.Add(this.buttonOlvideMiContraseña);
            this.panelTarjeta.Controls.Add(this.progressBar);
            this.panelTarjeta.Location = new System.Drawing.Point(275, 75);
            this.panelTarjeta.Name = "panelTarjeta";
            this.panelTarjeta.Size = new System.Drawing.Size(350, 480);
            this.panelTarjeta.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitulo.Location = new System.Drawing.Point(0, 165);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(350, 20);
            this.lblSubtitulo.TabIndex = 101;
            this.lblSubtitulo.Text = "Inicia sesión en tu cuenta Growshi";
            this.lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 135);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(350, 30);
            this.lblTitulo.TabIndex = 100;
            this.lblTitulo.Text = "Bienvenido";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Image = global::growshiUI.Properties.Resources.LogoGrowshiEsp;
            this.pictureBoxLogo.Location = new System.Drawing.Point(115, 30);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(120, 100);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 99;
            this.pictureBoxLogo.TabStop = false;
            // 
            // textBoxUsuario
            // 
            // 
            // 
            // 
            this.textBoxUsuario.CustomButton.Image = null;
            this.textBoxUsuario.CustomButton.Location = new System.Drawing.Point(242, 2);
            this.textBoxUsuario.CustomButton.Name = "";
            this.textBoxUsuario.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.textBoxUsuario.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxUsuario.CustomButton.TabIndex = 1;
            this.textBoxUsuario.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxUsuario.CustomButton.UseSelectable = true;
            this.textBoxUsuario.CustomButton.Visible = false;
            this.textBoxUsuario.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBoxUsuario.Icon = global::growshiUI.Properties.Resources.Usuario;
            this.textBoxUsuario.IconRight = true;
            this.textBoxUsuario.Lines = new string[0];
            this.textBoxUsuario.Location = new System.Drawing.Point(40, 210);
            this.textBoxUsuario.MaxLength = 32767;
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.PasswordChar = '\0';
            this.textBoxUsuario.PromptText = "Usuario";
            this.textBoxUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxUsuario.SelectedText = "";
            this.textBoxUsuario.SelectionLength = 0;
            this.textBoxUsuario.SelectionStart = 0;
            this.textBoxUsuario.ShortcutsEnabled = true;
            this.textBoxUsuario.Size = new System.Drawing.Size(270, 30);
            this.textBoxUsuario.TabIndex = 0;
            this.textBoxUsuario.UseSelectable = true;
            this.textBoxUsuario.WaterMark = "Usuario";
            this.textBoxUsuario.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxUsuario.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // textBoxContraseña
            // 
            // 
            // 
            // 
            this.textBoxContraseña.CustomButton.Image = null;
            this.textBoxContraseña.CustomButton.Location = new System.Drawing.Point(242, 2);
            this.textBoxContraseña.CustomButton.Name = "";
            this.textBoxContraseña.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.textBoxContraseña.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxContraseña.CustomButton.TabIndex = 1;
            this.textBoxContraseña.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxContraseña.CustomButton.UseSelectable = true;
            this.textBoxContraseña.CustomButton.Visible = false;
            this.textBoxContraseña.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBoxContraseña.Icon = global::growshiUI.Properties.Resources.Candado;
            this.textBoxContraseña.IconRight = true;
            this.textBoxContraseña.Lines = new string[0];
            this.textBoxContraseña.Location = new System.Drawing.Point(40, 260);
            this.textBoxContraseña.MaxLength = 32767;
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.PasswordChar = '●';
            this.textBoxContraseña.PromptText = "Contraseña";
            this.textBoxContraseña.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxContraseña.SelectedText = "";
            this.textBoxContraseña.SelectionLength = 0;
            this.textBoxContraseña.SelectionStart = 0;
            this.textBoxContraseña.ShortcutsEnabled = true;
            this.textBoxContraseña.Size = new System.Drawing.Size(270, 30);
            this.textBoxContraseña.TabIndex = 1;
            this.textBoxContraseña.UseSelectable = true;
            this.textBoxContraseña.WaterMark = "Contraseña";
            this.textBoxContraseña.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxContraseña.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // buttonIniciarSesion
            // 
            this.buttonIniciarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(140)))), ((int)(((byte)(100)))));
            this.buttonIniciarSesion.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.buttonIniciarSesion.ForeColor = System.Drawing.Color.White;
            this.buttonIniciarSesion.Location = new System.Drawing.Point(40, 320);
            this.buttonIniciarSesion.Name = "buttonIniciarSesion";
            this.buttonIniciarSesion.Size = new System.Drawing.Size(270, 40);
            this.buttonIniciarSesion.Style = MetroFramework.MetroColorStyle.White;
            this.buttonIniciarSesion.TabIndex = 2;
            this.buttonIniciarSesion.Text = "ACCEDER";
            this.buttonIniciarSesion.UseCustomBackColor = true;
            this.buttonIniciarSesion.UseCustomForeColor = true;
            this.buttonIniciarSesion.UseSelectable = true;
            this.buttonIniciarSesion.Click += new System.EventHandler(this.buttonIniciarSesion_Click);
            // 
            // buttonOlvideMiContraseña
            // 
            this.buttonOlvideMiContraseña.FontWeight = MetroFramework.MetroLinkWeight.Regular;
            this.buttonOlvideMiContraseña.ForeColor = System.Drawing.Color.DimGray;
            this.buttonOlvideMiContraseña.Location = new System.Drawing.Point(40, 370);
            this.buttonOlvideMiContraseña.Name = "buttonOlvideMiContraseña";
            this.buttonOlvideMiContraseña.Size = new System.Drawing.Size(270, 23);
            this.buttonOlvideMiContraseña.TabIndex = 3;
            this.buttonOlvideMiContraseña.Text = "¿Olvidaste tu contraseña?";
            this.buttonOlvideMiContraseña.UseCustomForeColor = true;
            this.buttonOlvideMiContraseña.UseSelectable = true;
            this.buttonOlvideMiContraseña.Click += new System.EventHandler(this.buttonOlvideMiContraseña_Click);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 475);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(350, 5);
            this.progressBar.Style = MetroFramework.MetroColorStyle.Orange;
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            // 
            // temporizadorBloqueo
            // 
            this.temporizadorBloqueo.Interval = 1000;
            this.temporizadorBloqueo.Tick += new System.EventHandler(this.temporizadorBloqueo_Tick);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelFondo);
            this.DisplayHeader = false;
            this.Name = "Login";
            this.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Growshi Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panelFondo.ResumeLayout(false);
            this.panelTarjeta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel panelFondo;
        private System.Windows.Forms.Panel panelTarjeta;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private MetroFramework.Controls.MetroTextBox textBoxUsuario;
        private MetroFramework.Controls.MetroTextBox textBoxContraseña;
        private MetroFramework.Controls.MetroButton buttonIniciarSesion;
        private MetroFramework.Controls.MetroLink buttonOlvideMiContraseña;
        private MetroFramework.Controls.MetroProgressBar progressBar;
        private System.Windows.Forms.Timer temporizadorBloqueo;
    }
}