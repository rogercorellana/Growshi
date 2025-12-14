namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos
{
    partial class CultivoSlotView
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.PictureBox picIcono;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Se eliminó panelFondo. Los controles se agregan directo al UserControl.
            this.picIcono = new System.Windows.Forms.PictureBox();
            this.lblTexto = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcono
            // 
            this.picIcono.BackColor = System.Drawing.Color.Transparent;
            this.picIcono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIcono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picIcono.Location = new System.Drawing.Point(0, 0);
            this.picIcono.Name = "picIcono";
            // Dejamos espacio abajo para el texto
            this.picIcono.Padding = new System.Windows.Forms.Padding(10, 10, 10, 40);
            this.picIcono.Size = new System.Drawing.Size(150, 150);
            this.picIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcono.TabIndex = 0;
            this.picIcono.TabStop = false;
            // 
            // lblTexto
            // 
            this.lblTexto.BackColor = System.Drawing.Color.Transparent;
            this.lblTexto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTexto.Dock = System.Windows.Forms.DockStyle.Bottom;
            // Usamos una fuente blanca o clara con sombra si es posible para que se lea sobre el fondo
            this.lblTexto.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTexto.ForeColor = System.Drawing.Color.White;
            this.lblTexto.Location = new System.Drawing.Point(0, 110);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(150, 40);
            this.lblTexto.TabIndex = 1;
            this.lblTexto.Text = "Estado";
            this.lblTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CultivoSlotView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // CLAVE: Fondo transparente
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblTexto);
            this.Controls.Add(this.picIcono);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "CultivoSlotView";
            this.Size = new System.Drawing.Size(150, 150);
            ((System.ComponentModel.ISupportInitialize)(this.picIcono)).EndInit();
            this.ResumeLayout(false);
        }
    }
}