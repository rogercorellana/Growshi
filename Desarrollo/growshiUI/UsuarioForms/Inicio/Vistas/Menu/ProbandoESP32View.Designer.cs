namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    partial class ProbandoESP32View
    {
        private System.ComponentModel.IContainer components = null;

        // --- Controles ---
        private MetroFramework.Controls.MetroButton btnConectar;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private MetroFramework.Controls.MetroLabel lblTempValor;
        private MetroFramework.Controls.MetroLabel lblHumValor;
        private MetroFramework.Controls.MetroLabel lblInfoID;
        private MetroFramework.Controls.MetroLabel lblEstadoAlerta; // <--- NUEVO
        private MetroFramework.Controls.MetroTextBox txtDebug;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnConectar = new MetroFramework.Controls.MetroButton();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.lblTempValor = new MetroFramework.Controls.MetroLabel();
            this.lblHumValor = new MetroFramework.Controls.MetroLabel();
            this.lblInfoID = new MetroFramework.Controls.MetroLabel();
            this.lblEstadoAlerta = new MetroFramework.Controls.MetroLabel();
            this.txtDebug = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(262, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Dashboard ESP32 - NTP Live";

            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(320, 20);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(140, 30);
            this.btnConectar.TabIndex = 1;
            this.btnConectar.Text = "CONECTAR COM5";
            this.btnConectar.UseSelectable = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);

            // 
            // lblTempValor
            // 
            this.lblTempValor.AutoSize = true;
            this.lblTempValor.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblTempValor.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTempValor.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblTempValor.Location = new System.Drawing.Point(40, 80);
            this.lblTempValor.Name = "lblTempValor";
            this.lblTempValor.Size = new System.Drawing.Size(107, 41);
            this.lblTempValor.TabIndex = 2;
            this.lblTempValor.Text = "--.- °C";
            this.lblTempValor.UseCustomForeColor = true;

            // 
            // lblHumValor
            // 
            this.lblHumValor.AutoSize = true;
            this.lblHumValor.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblHumValor.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblHumValor.ForeColor = System.Drawing.Color.Teal;
            this.lblHumValor.Location = new System.Drawing.Point(250, 80);
            this.lblHumValor.Name = "lblHumValor";
            this.lblHumValor.Size = new System.Drawing.Size(89, 41);
            this.lblHumValor.TabIndex = 3;
            this.lblHumValor.Text = "-- %";
            this.lblHumValor.UseCustomForeColor = true;

            // 
            // lblInfoID
            // 
            this.lblInfoID.AutoSize = true;
            this.lblInfoID.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblInfoID.Location = new System.Drawing.Point(20, 140);
            this.lblInfoID.Name = "lblInfoID";
            this.lblInfoID.Size = new System.Drawing.Size(124, 19);
            this.lblInfoID.TabIndex = 4;
            this.lblInfoID.Text = "Esperando sensor...";

            // 
            // lblEstadoAlerta
            // 
            this.lblEstadoAlerta.AutoSize = true;
            this.lblEstadoAlerta.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblEstadoAlerta.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblEstadoAlerta.Location = new System.Drawing.Point(320, 140);
            this.lblEstadoAlerta.Name = "lblEstadoAlerta";
            this.lblEstadoAlerta.Size = new System.Drawing.Size(117, 25);
            this.lblEstadoAlerta.TabIndex = 6;
            this.lblEstadoAlerta.Text = "ESTADO: --";
            this.lblEstadoAlerta.UseCustomForeColor = true;

            // 
            // txtDebug
            // 
            this.txtDebug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebug.Lines = new string[0];
            this.txtDebug.Location = new System.Drawing.Point(20, 195);
            this.txtDebug.MaxLength = 32767;
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebug.Size = new System.Drawing.Size(447, 80);
            this.txtDebug.TabIndex = 5;
            this.txtDebug.UseSelectable = true;
            this.txtDebug.WaterMark = "Depuración JSON...";

            // 
            // ProbandoESP32View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEstadoAlerta);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.lblInfoID);
            this.Controls.Add(this.lblHumValor);
            this.Controls.Add(this.lblTempValor);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.lblTitulo);
            this.Name = "ProbandoESP32View";
            this.Size = new System.Drawing.Size(487, 295);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}