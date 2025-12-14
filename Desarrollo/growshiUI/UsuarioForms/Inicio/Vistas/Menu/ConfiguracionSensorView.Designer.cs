namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    partial class ConfiguracionSensorView
    {
        private System.ComponentModel.IContainer components = null;

        // Títulos
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private MetroFramework.Controls.MetroLabel lblModo;

        // Controles Izquierda
        private MetroFramework.Controls.MetroComboBox cboTipoConexion;
        private MetroFramework.Controls.MetroPanel pnlUSB;
        private MetroFramework.Controls.MetroLabel lblPuerto;
        private MetroFramework.Controls.MetroComboBox cboPuertos;
        private MetroFramework.Controls.MetroButton btnRefrescar;

        private MetroFramework.Controls.MetroPanel pnlMQTT;
        private MetroFramework.Controls.MetroLabel lblBrokerIP;
        private MetroFramework.Controls.MetroTextBox txtBrokerIP;
        private MetroFramework.Controls.MetroLabel lblTopic;
        private MetroFramework.Controls.MetroTextBox txtTopic;

        // Botones Grandes
        private MetroFramework.Controls.MetroButton btnProbar;
        private MetroFramework.Controls.MetroButton btnGuardar;

        // Terminal Derecha
        private MetroFramework.Controls.MetroLabel lblTerminal;
        private MetroFramework.Controls.MetroTextBox txtTerminal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.lblModo = new MetroFramework.Controls.MetroLabel();
            this.cboTipoConexion = new MetroFramework.Controls.MetroComboBox();
            this.pnlUSB = new MetroFramework.Controls.MetroPanel();
            this.btnRefrescar = new MetroFramework.Controls.MetroButton();
            this.cboPuertos = new MetroFramework.Controls.MetroComboBox();
            this.lblPuerto = new MetroFramework.Controls.MetroLabel();
            this.pnlMQTT = new MetroFramework.Controls.MetroPanel();
            this.txtTopic = new MetroFramework.Controls.MetroTextBox();
            this.lblTopic = new MetroFramework.Controls.MetroLabel();
            this.txtBrokerIP = new MetroFramework.Controls.MetroTextBox();
            this.lblBrokerIP = new MetroFramework.Controls.MetroLabel();
            this.btnProbar = new MetroFramework.Controls.MetroButton();
            this.btnGuardar = new MetroFramework.Controls.MetroButton();
            this.lblTerminal = new MetroFramework.Controls.MetroLabel();
            this.txtTerminal = new MetroFramework.Controls.MetroTextBox();
            this.pnlUSB.SuspendLayout();
            this.pnlMQTT.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblTitulo (Arriba Izquierda)
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(223, 25);
            this.lblTitulo.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Configuración de Entrada";
            this.lblTitulo.UseStyleColors = true;

            // 
            // lblModo
            // 
            this.lblModo.AutoSize = true;
            this.lblModo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblModo.Location = new System.Drawing.Point(30, 70);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(142, 19);
            this.lblModo.TabIndex = 1;
            this.lblModo.Text = "Método de Lectura:";

            // 
            // cboTipoConexion
            // 
            this.cboTipoConexion.FormattingEnabled = true;
            this.cboTipoConexion.ItemHeight = 23;
            this.cboTipoConexion.Items.AddRange(new object[] {
            "Puerto USB (Serial)",
            "WiFi (MQTT)"});
            this.cboTipoConexion.Location = new System.Drawing.Point(180, 65);
            this.cboTipoConexion.Name = "cboTipoConexion";
            this.cboTipoConexion.Size = new System.Drawing.Size(250, 29);
            this.cboTipoConexion.Style = MetroFramework.MetroColorStyle.Green;
            this.cboTipoConexion.TabIndex = 2;
            this.cboTipoConexion.UseSelectable = true;
            this.cboTipoConexion.UseStyleColors = true;
            this.cboTipoConexion.SelectedIndexChanged += new System.EventHandler(this.cboTipoConexion_SelectedIndexChanged);

            // 
            // pnlUSB (Panel de Configuración USB)
            // 
            this.pnlUSB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUSB.Controls.Add(this.btnRefrescar);
            this.pnlUSB.Controls.Add(this.cboPuertos);
            this.pnlUSB.Controls.Add(this.lblPuerto);
            this.pnlUSB.Location = new System.Drawing.Point(30, 115);
            this.pnlUSB.Name = "pnlUSB";
            this.pnlUSB.Size = new System.Drawing.Size(400, 100);
            this.pnlUSB.TabIndex = 3;

            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.lblPuerto.Location = new System.Drawing.Point(20, 35);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(123, 19);
            this.lblPuerto.TabIndex = 0;
            this.lblPuerto.Text = "Puerto Detectado:";

            // 
            // cboPuertos
            // 
            this.cboPuertos.FormattingEnabled = true;
            this.cboPuertos.ItemHeight = 23;
            this.cboPuertos.Location = new System.Drawing.Point(149, 30);
            this.cboPuertos.Name = "cboPuertos";
            this.cboPuertos.Size = new System.Drawing.Size(140, 29);
            this.cboPuertos.TabIndex = 1;
            this.cboPuertos.UseSelectable = true;

            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(295, 30);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(80, 29);
            this.btnRefrescar.TabIndex = 2;
            this.btnRefrescar.Text = "↻ Buscar";
            this.btnRefrescar.UseSelectable = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            // 
            // pnlMQTT (Misma posición que USB, visible según selección)
            // 
            this.pnlMQTT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMQTT.Controls.Add(this.txtTopic);
            this.pnlMQTT.Controls.Add(this.lblTopic);
            this.pnlMQTT.Controls.Add(this.txtBrokerIP);
            this.pnlMQTT.Controls.Add(this.lblBrokerIP);
            this.pnlMQTT.Location = new System.Drawing.Point(30, 115);
            this.pnlMQTT.Name = "pnlMQTT";
            this.pnlMQTT.Size = new System.Drawing.Size(400, 100);
            this.pnlMQTT.TabIndex = 4;
            this.pnlMQTT.Visible = false;

            // 
            // lblBrokerIP
            // 
            this.lblBrokerIP.AutoSize = true;
            this.lblBrokerIP.Location = new System.Drawing.Point(20, 20);
            this.lblBrokerIP.Name = "lblBrokerIP";
            this.lblBrokerIP.Size = new System.Drawing.Size(68, 19);
            this.lblBrokerIP.TabIndex = 0;
            this.lblBrokerIP.Text = "Broker IP:";

            // 
            // txtBrokerIP
            // 
            this.txtBrokerIP.Location = new System.Drawing.Point(110, 18);
            this.txtBrokerIP.Name = "txtBrokerIP";
            this.txtBrokerIP.Size = new System.Drawing.Size(265, 23);
            this.txtBrokerIP.TabIndex = 1;
            this.txtBrokerIP.Text = "127.0.0.1";

            // 
            // lblTopic
            // 
            this.lblTopic.AutoSize = true;
            this.lblTopic.Location = new System.Drawing.Point(20, 55);
            this.lblTopic.Name = "lblTopic";
            this.lblTopic.Size = new System.Drawing.Size(73, 19);
            this.lblTopic.TabIndex = 2;
            this.lblTopic.Text = "Suscripción:";

            // 
            // txtTopic
            // 
            this.txtTopic.Location = new System.Drawing.Point(110, 53);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(265, 23);
            this.txtTopic.TabIndex = 3;
            this.txtTopic.Text = "growshi/slot1/#";

            // 
            // btnProbar (Abajo Izquierda, Grande)
            // 
            this.btnProbar.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnProbar.Location = new System.Drawing.Point(30, 240);
            this.btnProbar.Name = "btnProbar";
            this.btnProbar.Size = new System.Drawing.Size(190, 60);
            this.btnProbar.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnProbar.TabIndex = 5;
            this.btnProbar.Text = "INICIAR PRUEBA";
            this.btnProbar.UseSelectable = true;
            this.btnProbar.UseStyleColors = true;
            this.btnProbar.Click += new System.EventHandler(this.btnProbar_Click);

            // 
            // btnGuardar (Al lado de Probar)
            // 
            this.btnGuardar.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnGuardar.Location = new System.Drawing.Point(240, 240);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(190, 60);
            this.btnGuardar.Style = MetroFramework.MetroColorStyle.Green;
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "GUARDAR CAMBIOS";
            this.btnGuardar.UseSelectable = true;
            this.btnGuardar.UseStyleColors = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // 
            // lblTerminal (Lado Derecho)
            // 
            this.lblTerminal.AutoSize = true;
            this.lblTerminal.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTerminal.Location = new System.Drawing.Point(460, 20);
            this.lblTerminal.Name = "lblTerminal";
            this.lblTerminal.Size = new System.Drawing.Size(225, 19);
            this.lblTerminal.TabIndex = 7;
            this.lblTerminal.Text = "Terminal de Datos Raw (Debug):";

            // 
            // txtTerminal (Pantalla Gigante a la derecha)
            // 
            this.txtTerminal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTerminal.BackColor = System.Drawing.Color.Black;
            this.txtTerminal.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.txtTerminal.ForeColor = System.Drawing.Color.Lime;
            this.txtTerminal.Lines = new string[0];
            this.txtTerminal.Location = new System.Drawing.Point(460, 50);
            this.txtTerminal.MaxLength = 32767;
            this.txtTerminal.Multiline = true;
            this.txtTerminal.Name = "txtTerminal";
            this.txtTerminal.ReadOnly = true;
            this.txtTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTerminal.Size = new System.Drawing.Size(780, 410);
            this.txtTerminal.TabIndex = 8;
            this.txtTerminal.UseCustomBackColor = true;
            this.txtTerminal.UseCustomForeColor = true;
            this.txtTerminal.UseSelectable = true;

            // 
            // ConfiguracionSensorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTerminal);
            this.Controls.Add(this.lblTerminal);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnProbar);
            this.Controls.Add(this.pnlMQTT);
            this.Controls.Add(this.pnlUSB);
            this.Controls.Add(this.cboTipoConexion);
            this.Controls.Add(this.lblModo);
            this.Controls.Add(this.lblTitulo);
            this.Name = "ConfiguracionSensorView";
            this.Size = new System.Drawing.Size(1260, 484);
            this.pnlUSB.ResumeLayout(false);
            this.pnlUSB.PerformLayout();
            this.pnlMQTT.ResumeLayout(false);
            this.pnlMQTT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}