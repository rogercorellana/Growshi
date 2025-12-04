namespace growshiUI.Configuracion_ConnString
{
    partial class FormConfiguracion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblServidor = new MetroFramework.Controls.MetroLabel();
            this.cmbServidor = new MetroFramework.Controls.MetroComboBox();
            this.lblBaseDatos = new MetroFramework.Controls.MetroLabel();
            this.cmbBaseDatos = new MetroFramework.Controls.MetroComboBox();
            this.btnGuardar = new MetroFramework.Controls.MetroButton();
            this.btnCancelar = new MetroFramework.Controls.MetroButton();
            this.btnRefrescarServidores = new MetroFramework.Controls.MetroButton();
            this.btnBuscarBDs = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabelInfo = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.btnBuscarBDs);
            this.metroPanel1.Controls.Add(this.btnRefrescarServidores);
            this.metroPanel1.Controls.Add(this.cmbBaseDatos);
            this.metroPanel1.Controls.Add(this.lblBaseDatos);
            this.metroPanel1.Controls.Add(this.cmbServidor);
            this.metroPanel1.Controls.Add(this.lblServidor);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 85);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(354, 150);
            this.metroPanel1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // lblServidor
            // 
            this.lblServidor.AutoSize = true;
            this.lblServidor.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblServidor.Location = new System.Drawing.Point(15, 16);
            this.lblServidor.Name = "lblServidor";
            this.lblServidor.Size = new System.Drawing.Size(127, 19);
            this.lblServidor.Style = MetroFramework.MetroColorStyle.Green;
            this.lblServidor.TabIndex = 2;
            this.lblServidor.Text = "Seleccionar Servidor:";
            this.lblServidor.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lblServidor.UseStyleColors = true; // Hace que el texto sea verde
            // 
            // cmbServidor
            // 
            this.cmbServidor.FormattingEnabled = true;
            this.cmbServidor.ItemHeight = 23;
            this.cmbServidor.Location = new System.Drawing.Point(15, 38);
            this.cmbServidor.Name = "cmbServidor";
            this.cmbServidor.Size = new System.Drawing.Size(275, 29);
            this.cmbServidor.Style = MetroFramework.MetroColorStyle.Green;
            this.cmbServidor.TabIndex = 3;
            this.cmbServidor.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cmbServidor.UseSelectable = true;
            // 
            // btnRefrescarServidores
            // 
            this.btnRefrescarServidores.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnRefrescarServidores.Location = new System.Drawing.Point(296, 38);
            this.btnRefrescarServidores.Name = "btnRefrescarServidores";
            this.btnRefrescarServidores.Size = new System.Drawing.Size(40, 29);
            this.btnRefrescarServidores.TabIndex = 4;
            this.btnRefrescarServidores.Text = "↻";
            this.btnRefrescarServidores.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnRefrescarServidores.UseSelectable = true;
            this.btnRefrescarServidores.Click += new System.EventHandler(this.btnRefrescarServidores_Click);
            // 
            // lblBaseDatos
            // 
            this.lblBaseDatos.AutoSize = true;
            this.lblBaseDatos.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblBaseDatos.Location = new System.Drawing.Point(15, 80);
            this.lblBaseDatos.Name = "lblBaseDatos";
            this.lblBaseDatos.Size = new System.Drawing.Size(98, 19);
            this.lblBaseDatos.Style = MetroFramework.MetroColorStyle.Green;
            this.lblBaseDatos.TabIndex = 5;
            this.lblBaseDatos.Text = "Base de Datos:";
            this.lblBaseDatos.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lblBaseDatos.UseStyleColors = true; // Texto verde
            // 
            // cmbBaseDatos
            // 
            this.cmbBaseDatos.FormattingEnabled = true;
            this.cmbBaseDatos.ItemHeight = 23;
            this.cmbBaseDatos.Location = new System.Drawing.Point(15, 102);
            this.cmbBaseDatos.Name = "cmbBaseDatos";
            this.cmbBaseDatos.Size = new System.Drawing.Size(275, 29);
            this.cmbBaseDatos.Style = MetroFramework.MetroColorStyle.Green;
            this.cmbBaseDatos.TabIndex = 6;
            this.cmbBaseDatos.Theme = MetroFramework.MetroThemeStyle.Light;
            this.cmbBaseDatos.UseSelectable = true;
            this.cmbBaseDatos.Click += new System.EventHandler(this.cmbBaseDatos_Click);
            // 
            // btnBuscarBDs
            // 
            this.btnBuscarBDs.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnBuscarBDs.Location = new System.Drawing.Point(296, 102);
            this.btnBuscarBDs.Name = "btnBuscarBDs";
            this.btnBuscarBDs.Size = new System.Drawing.Size(40, 29);
            this.btnBuscarBDs.TabIndex = 7;
            this.btnBuscarBDs.Text = "▼";
            this.btnBuscarBDs.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnBuscarBDs.UseSelectable = true;
            this.btnBuscarBDs.Click += new System.EventHandler(this.btnBuscarBDs_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnGuardar.Highlight = true;
            this.btnGuardar.Location = new System.Drawing.Point(240, 255);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(137, 40);
            this.btnGuardar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "CONECTAR";
            this.btnGuardar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnGuardar.UseSelectable = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnCancelar.Location = new System.Drawing.Point(23, 255);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.Style = MetroFramework.MetroColorStyle.Red;
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "SALIR";
            this.btnCancelar.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // metroLabelInfo
            // 
            this.metroLabelInfo.AutoSize = true;
            this.metroLabelInfo.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabelInfo.Location = new System.Drawing.Point(23, 60);
            this.metroLabelInfo.Name = "metroLabelInfo";
            this.metroLabelInfo.Size = new System.Drawing.Size(288, 15);
            this.metroLabelInfo.Style = MetroFramework.MetroColorStyle.Green;
            this.metroLabelInfo.TabIndex = 3;
            this.metroLabelInfo.Text = "Detectando configuración de red y servidores locales...";
            this.metroLabelInfo.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // FormConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.metroLabelInfo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfiguracion";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Conexión a Base de Datos";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConfiguracion_FormClosing);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel lblServidor;
        private MetroFramework.Controls.MetroComboBox cmbServidor;
        private MetroFramework.Controls.MetroButton btnRefrescarServidores;
        private MetroFramework.Controls.MetroLabel lblBaseDatos;
        private MetroFramework.Controls.MetroComboBox cmbBaseDatos;
        private MetroFramework.Controls.MetroButton btnBuscarBDs;
        private MetroFramework.Controls.MetroButton btnGuardar;
        private MetroFramework.Controls.MetroButton btnCancelar;
        private MetroFramework.Controls.MetroLabel metroLabelInfo;
    }
}