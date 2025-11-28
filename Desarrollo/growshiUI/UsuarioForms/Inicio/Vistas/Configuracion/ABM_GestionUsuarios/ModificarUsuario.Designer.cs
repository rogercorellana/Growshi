namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_GestionUsuarios
{
    partial class ModificarUsuario
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
            this.chkVerPass = new MetroFramework.Controls.MetroCheckBox();
            this.btnCancelar = new MetroFramework.Controls.MetroButton();
            this.btnGuardar = new MetroFramework.Controls.MetroButton();
            this.toggleActivo = new MetroFramework.Controls.MetroToggle();
            this.lblActivo = new MetroFramework.Controls.MetroLabel();
            this.txtIntentos = new MetroFramework.Controls.MetroTextBox();
            this.lblIntentos = new MetroFramework.Controls.MetroLabel();
            this.txtRespaldo = new MetroFramework.Controls.MetroTextBox();
            this.lblRespaldo = new MetroFramework.Controls.MetroLabel();
            this.txtPass = new MetroFramework.Controls.MetroTextBox();
            this.lblPass = new MetroFramework.Controls.MetroLabel();
            this.txtNombre = new MetroFramework.Controls.MetroTextBox();
            this.lblNombre = new MetroFramework.Controls.MetroLabel();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.metroCheckBoxContraseñaRespaldo = new MetroFramework.Controls.MetroCheckBox();
            this.panelContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.Color.White;
            this.panelContenedor.Controls.Add(this.metroCheckBoxContraseñaRespaldo);
            this.panelContenedor.Controls.Add(this.chkVerPass);
            this.panelContenedor.Controls.Add(this.btnCancelar);
            this.panelContenedor.Controls.Add(this.btnGuardar);
            this.panelContenedor.Controls.Add(this.toggleActivo);
            this.panelContenedor.Controls.Add(this.lblActivo);
            this.panelContenedor.Controls.Add(this.txtIntentos);
            this.panelContenedor.Controls.Add(this.lblIntentos);
            this.panelContenedor.Controls.Add(this.txtRespaldo);
            this.panelContenedor.Controls.Add(this.lblRespaldo);
            this.panelContenedor.Controls.Add(this.txtPass);
            this.panelContenedor.Controls.Add(this.lblPass);
            this.panelContenedor.Controls.Add(this.txtNombre);
            this.panelContenedor.Controls.Add(this.lblNombre);
            this.panelContenedor.Controls.Add(this.lblTitulo);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Padding = new System.Windows.Forms.Padding(40);
            this.panelContenedor.Size = new System.Drawing.Size(720, 500);
            this.panelContenedor.TabIndex = 0;
            // 
            // chkVerPass
            // 
            this.chkVerPass.AutoSize = true;
            this.chkVerPass.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.chkVerPass.Location = new System.Drawing.Point(446, 160);
            this.chkVerPass.Name = "chkVerPass";
            this.chkVerPass.Size = new System.Drawing.Size(119, 19);
            this.chkVerPass.TabIndex = 5;
            this.chkVerPass.Text = "Ver Contraseña";
            this.chkVerPass.UseSelectable = true;
            this.chkVerPass.CheckedChanged += new System.EventHandler(this.chkVerPass_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnCancelar.Location = new System.Drawing.Point(570, 420);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGuardar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(430, 420);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 40);
            this.btnGuardar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseCustomBackColor = true;
            this.btnGuardar.UseCustomForeColor = true;
            this.btnGuardar.UseSelectable = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // toggleActivo
            // 
            this.toggleActivo.AutoSize = true;
            this.toggleActivo.Location = new System.Drawing.Point(220, 313);
            this.toggleActivo.Name = "toggleActivo";
            this.toggleActivo.Size = new System.Drawing.Size(80, 17);
            this.toggleActivo.Style = MetroFramework.MetroColorStyle.Green;
            this.toggleActivo.TabIndex = 11;
            this.toggleActivo.Text = "Off";
            this.toggleActivo.UseSelectable = true;
            // 
            // lblActivo
            // 
            this.lblActivo.AutoSize = true;
            this.lblActivo.Location = new System.Drawing.Point(220, 280);
            this.lblActivo.Name = "lblActivo";
            this.lblActivo.Size = new System.Drawing.Size(96, 19);
            this.lblActivo.TabIndex = 10;
            this.lblActivo.Text = "Estado Cuenta:";
            // 
            // txtIntentos
            // 
            // 
            // 
            // 
            this.txtIntentos.CustomButton.Image = null;
            this.txtIntentos.CustomButton.Location = new System.Drawing.Point(122, 2);
            this.txtIntentos.CustomButton.Name = "";
            this.txtIntentos.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtIntentos.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtIntentos.CustomButton.TabIndex = 1;
            this.txtIntentos.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtIntentos.CustomButton.UseSelectable = true;
            this.txtIntentos.CustomButton.Visible = false;
            this.txtIntentos.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtIntentos.Lines = new string[0];
            this.txtIntentos.Location = new System.Drawing.Point(40, 305);
            this.txtIntentos.MaxLength = 32767;
            this.txtIntentos.Name = "txtIntentos";
            this.txtIntentos.PasswordChar = '\0';
            this.txtIntentos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIntentos.SelectedText = "";
            this.txtIntentos.SelectionLength = 0;
            this.txtIntentos.SelectionStart = 0;
            this.txtIntentos.ShortcutsEnabled = true;
            this.txtIntentos.Size = new System.Drawing.Size(150, 30);
            this.txtIntentos.TabIndex = 9;
            this.txtIntentos.UseSelectable = true;
            this.txtIntentos.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtIntentos.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblIntentos
            // 
            this.lblIntentos.AutoSize = true;
            this.lblIntentos.Location = new System.Drawing.Point(40, 280);
            this.lblIntentos.Name = "lblIntentos";
            this.lblIntentos.Size = new System.Drawing.Size(104, 19);
            this.lblIntentos.TabIndex = 8;
            this.lblIntentos.Text = "Intentos Fallidos:";
            // 
            // txtRespaldo
            // 
            this.txtRespaldo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtRespaldo.CustomButton.Image = null;
            this.txtRespaldo.CustomButton.Location = new System.Drawing.Point(372, 2);
            this.txtRespaldo.CustomButton.Name = "";
            this.txtRespaldo.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtRespaldo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtRespaldo.CustomButton.TabIndex = 1;
            this.txtRespaldo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtRespaldo.CustomButton.UseSelectable = true;
            this.txtRespaldo.CustomButton.Visible = false;
            this.txtRespaldo.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtRespaldo.Lines = new string[0];
            this.txtRespaldo.Location = new System.Drawing.Point(40, 230);
            this.txtRespaldo.MaxLength = 32767;
            this.txtRespaldo.Name = "txtRespaldo";
            this.txtRespaldo.PasswordChar = '●';
            this.txtRespaldo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtRespaldo.SelectedText = "";
            this.txtRespaldo.SelectionLength = 0;
            this.txtRespaldo.SelectionStart = 0;
            this.txtRespaldo.ShortcutsEnabled = true;
            this.txtRespaldo.Size = new System.Drawing.Size(400, 30);
            this.txtRespaldo.TabIndex = 7;
            this.txtRespaldo.UseSelectable = true;
            this.txtRespaldo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtRespaldo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblRespaldo
            // 
            this.lblRespaldo.AutoSize = true;
            this.lblRespaldo.Location = new System.Drawing.Point(40, 205);
            this.lblRespaldo.Name = "lblRespaldo";
            this.lblRespaldo.Size = new System.Drawing.Size(136, 19);
            this.lblRespaldo.TabIndex = 6;
            this.lblRespaldo.Text = "Contraseña Respaldo:";
            // 
            // txtPass
            // 
            this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtPass.CustomButton.Image = null;
            this.txtPass.CustomButton.Location = new System.Drawing.Point(372, 2);
            this.txtPass.CustomButton.Name = "";
            this.txtPass.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtPass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPass.CustomButton.TabIndex = 1;
            this.txtPass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPass.CustomButton.UseSelectable = true;
            this.txtPass.CustomButton.Visible = false;
            this.txtPass.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtPass.Lines = new string[0];
            this.txtPass.Location = new System.Drawing.Point(40, 160);
            this.txtPass.MaxLength = 32767;
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPass.SelectedText = "";
            this.txtPass.SelectionLength = 0;
            this.txtPass.SelectionStart = 0;
            this.txtPass.ShortcutsEnabled = true;
            this.txtPass.Size = new System.Drawing.Size(400, 30);
            this.txtPass.TabIndex = 4;
            this.txtPass.UseSelectable = true;
            this.txtPass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(40, 135);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(78, 19);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Contraseña:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.txtNombre.CustomButton.Image = null;
            this.txtNombre.CustomButton.Location = new System.Drawing.Point(372, 2);
            this.txtNombre.CustomButton.Name = "";
            this.txtNombre.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.txtNombre.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNombre.CustomButton.TabIndex = 1;
            this.txtNombre.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNombre.CustomButton.UseSelectable = true;
            this.txtNombre.CustomButton.Visible = false;
            this.txtNombre.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtNombre.Lines = new string[0];
            this.txtNombre.Location = new System.Drawing.Point(40, 90);
            this.txtNombre.MaxLength = 32767;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PasswordChar = '\0';
            this.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNombre.SelectedText = "";
            this.txtNombre.SelectionLength = 0;
            this.txtNombre.SelectionStart = 0;
            this.txtNombre.ShortcutsEnabled = true;
            this.txtNombre.Size = new System.Drawing.Size(400, 30);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.UseSelectable = true;
            this.txtNombre.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNombre.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(40, 65);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(129, 19);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre de Usuario:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblTitulo.Location = new System.Drawing.Point(40, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(164, 25);
            this.lblTitulo.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Modificar Usuario";
            this.lblTitulo.UseCustomForeColor = true;
            // 
            // metroCheckBoxContraseñaRespaldo
            // 
            this.metroCheckBoxContraseñaRespaldo.AutoSize = true;
            this.metroCheckBoxContraseñaRespaldo.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBoxContraseñaRespaldo.Location = new System.Drawing.Point(446, 230);
            this.metroCheckBoxContraseñaRespaldo.Name = "metroCheckBoxContraseñaRespaldo";
            this.metroCheckBoxContraseñaRespaldo.Size = new System.Drawing.Size(119, 19);
            this.metroCheckBoxContraseñaRespaldo.TabIndex = 14;
            this.metroCheckBoxContraseñaRespaldo.Text = "Ver Contraseña";
            this.metroCheckBoxContraseñaRespaldo.UseSelectable = true;
            this.metroCheckBoxContraseñaRespaldo.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
            // 
            // ModificarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContenedor);
            this.Name = "ModificarUsuario";
            this.Size = new System.Drawing.Size(720, 500);
            this.panelContenedor.ResumeLayout(false);
            this.panelContenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private MetroFramework.Controls.MetroTextBox txtNombre;
        private MetroFramework.Controls.MetroLabel lblNombre;
        private MetroFramework.Controls.MetroTextBox txtPass;
        private MetroFramework.Controls.MetroLabel lblPass;
        private MetroFramework.Controls.MetroCheckBox chkVerPass; // NUEVO
        private MetroFramework.Controls.MetroTextBox txtRespaldo;
        private MetroFramework.Controls.MetroLabel lblRespaldo;
        private MetroFramework.Controls.MetroTextBox txtIntentos;
        private MetroFramework.Controls.MetroLabel lblIntentos;
        private MetroFramework.Controls.MetroToggle toggleActivo;
        private MetroFramework.Controls.MetroLabel lblActivo;
        private MetroFramework.Controls.MetroButton btnGuardar;
        private MetroFramework.Controls.MetroButton btnCancelar;
        private MetroFramework.Controls.MetroCheckBox metroCheckBoxContraseñaRespaldo;
    }
}