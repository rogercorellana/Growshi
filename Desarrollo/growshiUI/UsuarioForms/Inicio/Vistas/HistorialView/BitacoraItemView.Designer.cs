namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    partial class BitacoraItemView
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
            this.pnlIndicador = new MetroFramework.Controls.MetroPanel();
            this.lblHora = new MetroFramework.Controls.MetroLabel();
            this.lblFecha = new MetroFramework.Controls.MetroLabel();
            this.lblModulo = new MetroFramework.Controls.MetroLabel();
            this.lblMensaje = new MetroFramework.Controls.MetroLabel();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlIndicador
            // 
            this.pnlIndicador.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlIndicador.HorizontalScrollbarBarColor = true;
            this.pnlIndicador.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlIndicador.HorizontalScrollbarSize = 10;
            this.pnlIndicador.Location = new System.Drawing.Point(0, 0);
            this.pnlIndicador.Name = "pnlIndicador";
            this.pnlIndicador.Size = new System.Drawing.Size(6, 75);
            this.pnlIndicador.TabIndex = 0;
            this.pnlIndicador.UseCustomBackColor = true;
            this.pnlIndicador.VerticalScrollbarBarColor = true;
            this.pnlIndicador.VerticalScrollbarHighlightOnWheel = false;
            this.pnlIndicador.VerticalScrollbarSize = 10;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblHora.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblHora.Location = new System.Drawing.Point(15, 10);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(59, 25);
            this.lblHora.TabIndex = 1;
            this.lblHora.Text = "14:30";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFecha.Location = new System.Drawing.Point(18, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(43, 15);
            this.lblFecha.TabIndex = 2;
            this.lblFecha.Text = "15/OCT";
            this.lblFecha.UseCustomForeColor = true;
            // 
            // lblModulo
            // 
            this.lblModulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModulo.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblModulo.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblModulo.Location = new System.Drawing.Point(450, 10);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(140, 25);
            this.lblModulo.TabIndex = 3;
            this.lblModulo.Text = "SEGURIDAD";
            this.lblModulo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblModulo.UseCustomForeColor = true;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.Location = new System.Drawing.Point(90, 10);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(354, 55);
            this.lblMensaje.TabIndex = 4;
            this.lblMensaje.Text = "Descripción del evento ocurrida en el sistema...";
            this.lblMensaje.WrapToLine = true;
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSeparator.Location = new System.Drawing.Point(6, 74);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(594, 1);
            this.pnlSeparator.TabIndex = 5;
            // 
            // BitacoraItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlSeparator);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.lblModulo);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.pnlIndicador);
            this.Name = "BitacoraItemView";
            this.Size = new System.Drawing.Size(600, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlIndicador;
        private MetroFramework.Controls.MetroLabel lblHora;
        private MetroFramework.Controls.MetroLabel lblFecha;
        private MetroFramework.Controls.MetroLabel lblModulo;
        private MetroFramework.Controls.MetroLabel lblMensaje;
        private System.Windows.Forms.Panel pnlSeparator;
    }
}