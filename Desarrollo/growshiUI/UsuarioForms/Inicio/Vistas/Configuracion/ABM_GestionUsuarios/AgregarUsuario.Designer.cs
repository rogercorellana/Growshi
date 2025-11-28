namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_GestionUsuarios
{
    partial class AgregarUsuario
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

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.lblNombre = new MetroFramework.Controls.MetroLabel();
            this.txtNombreUsuario = new MetroFramework.Controls.MetroTextBox();
            this.lblPass = new MetroFramework.Controls.MetroLabel();
            this.txtContraseñaUsuario = new MetroFramework.Controls.MetroTextBox();
            this.lblPassRespaldo = new MetroFramework.Controls.MetroLabel();
            this.txtContraseñaRespaldo = new MetroFramework.Controls.MetroTextBox();
            this.btnGuardar = new MetroFramework.Controls.MetroButton();
            this.btnCancelar = new MetroFramework.Controls.MetroButton();

            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelContenedor
            // 
            // Este panel centra el contenido y le da márgenes
            this.panelContenedor.BackColor = System.Drawing.Color.White;
            this.panelContenedor.Controls.Add(this.btnCancelar);
            this.panelContenedor.Controls.Add(this.btnGuardar);
            this.panelContenedor.Controls.Add(this.txtContraseñaRespaldo);
            this.panelContenedor.Controls.Add(this.lblPassRespaldo);
            this.panelContenedor.Controls.Add(this.txtContraseñaUsuario);
            this.panelContenedor.Controls.Add(this.lblPass);
            this.panelContenedor.Controls.Add(this.txtNombreUsuario);
            this.panelContenedor.Controls.Add(this.lblNombre);
            this.panelContenedor.Controls.Add(this.lblTitulo);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Padding = new System.Windows.Forms.Padding(40);
            this.panelContenedor.Size = new System.Drawing.Size(600, 500);
            this.panelContenedor.TabIndex = 0;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80))))); // Verde Growshi
            this.lblTitulo.Location = new System.Drawing.Point(40, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(184, 25);
            this.lblTitulo.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Crear Nuevo Usuario";
            this.lblTitulo.UseCustomForeColor = true;

            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(40, 90);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(129, 19);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre de Usuario:";

            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNombreUsuario.Lines = new string[0];
            this.txtNombreUsuario.Location = new System.Drawing.Point(40, 115);
            this.txtNombreUsuario.MaxLength = 32767;
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.PasswordChar = '\0';
            this.txtNombreUsuario.WaterMark = "Ej: JuanPerez";
            this.txtNombreUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNombreUsuario.SelectedText = "";
            this.txtNombreUsuario.SelectionLength = 0;
            this.txtNombreUsuario.SelectionStart = 0;
            this.txtNombreUsuario.ShortcutsEnabled = true;
            this.txtNombreUsuario.Size = new System.Drawing.Size(350, 30);
            this.txtNombreUsuario.TabIndex = 2;
            this.txtNombreUsuario.UseSelectable = true;
            this.txtNombreUsuario.WaterMark = "Ej: JuanPerez";
            this.txtNombreUsuario.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNombreUsuario.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);

            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(40, 165);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(78, 19);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Contraseña:";

            // 
            // txtContraseñaUsuario
            // 
            this.txtContraseñaUsuario.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtContraseñaUsuario.Lines = new string[0];
            this.txtContraseñaUsuario.Location = new System.Drawing.Point(40, 190);
            this.txtContraseñaUsuario.MaxLength = 32767;
            this.txtContraseñaUsuario.Name = "txtContraseñaUsuario";
            this.txtContraseñaUsuario.WaterMark = "Contraseña segura";
            this.txtContraseñaUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContraseñaUsuario.SelectedText = "";
            this.txtContraseñaUsuario.SelectionLength = 0;
            this.txtContraseñaUsuario.SelectionStart = 0;
            this.txtContraseñaUsuario.ShortcutsEnabled = true;
            this.txtContraseñaUsuario.Size = new System.Drawing.Size(350, 30);
            this.txtContraseñaUsuario.TabIndex = 4;
            this.txtContraseñaUsuario.UseSelectable = true;
            this.txtContraseñaUsuario.WaterMark = "Contraseña segura";
            this.txtContraseñaUsuario.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContraseñaUsuario.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);

            // 
            // lblPassRespaldo
            // 
            this.lblPassRespaldo.AutoSize = true;
            this.lblPassRespaldo.Location = new System.Drawing.Point(40, 240);
            this.lblPassRespaldo.Name = "lblPassRespaldo";
            this.lblPassRespaldo.Size = new System.Drawing.Size(136, 19);
            this.lblPassRespaldo.TabIndex = 5;
            this.lblPassRespaldo.Text = "Contraseña Respaldo:";

            // 
            // txtContraseñaRespaldo
            // 
            this.txtContraseñaRespaldo.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtContraseñaRespaldo.Lines = new string[0];
            this.txtContraseñaRespaldo.Location = new System.Drawing.Point(40, 265);
            this.txtContraseñaRespaldo.MaxLength = 32767;
            this.txtContraseñaRespaldo.Name = "txtContraseñaRespaldo";
            this.txtContraseñaRespaldo.PasswordChar = '●';
            this.txtContraseñaRespaldo.WaterMark = "Para recuperación de cuenta";
            this.txtContraseñaRespaldo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContraseñaRespaldo.SelectedText = "";
            this.txtContraseñaRespaldo.SelectionLength = 0;
            this.txtContraseñaRespaldo.SelectionStart = 0;
            this.txtContraseñaRespaldo.ShortcutsEnabled = true;
            this.txtContraseñaRespaldo.Size = new System.Drawing.Size(350, 30);
            this.txtContraseñaRespaldo.TabIndex = 6;
            this.txtContraseñaRespaldo.UseSelectable = true;
            this.txtContraseñaRespaldo.WaterMark = "Para recuperación de cuenta";
            this.txtContraseñaRespaldo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContraseñaRespaldo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);

            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80))))); // Verde Growshi
            this.btnGuardar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(40, 330);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 40);
            this.btnGuardar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Crear Usuario";
            this.btnGuardar.UseCustomBackColor = true;
            this.btnGuardar.UseCustomForeColor = true;
            this.btnGuardar.UseSelectable = true;
            this.btnGuardar.Click += new System.EventHandler(this.buttonAgregarUsuario_Click);

            // 
            // btnCancelar
            // 
            this.btnCancelar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnCancelar.Location = new System.Drawing.Point(210, 330);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Volver";
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // 
            // AgregarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContenedor);
            this.Name = "AgregarUsuario";
            this.Size = new System.Drawing.Size(600, 500);
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private MetroFramework.Controls.MetroLabel lblNombre;
        private MetroFramework.Controls.MetroTextBox txtNombreUsuario;
        private MetroFramework.Controls.MetroLabel lblPass;
        private MetroFramework.Controls.MetroTextBox txtContraseñaUsuario;
        private MetroFramework.Controls.MetroLabel lblPassRespaldo;
        private MetroFramework.Controls.MetroTextBox txtContraseñaRespaldo;
        private MetroFramework.Controls.MetroButton btnGuardar;
        private MetroFramework.Controls.MetroButton btnCancelar;
    }
}