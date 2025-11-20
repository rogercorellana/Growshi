namespace growshiUI.UsuarioForms.Inicio.Vistas.MisCultivos
{
    partial class CultivoSlotView
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelFondo;
        private System.Windows.Forms.Label lblTexto;
        private System.Windows.Forms.PictureBox picIcono;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelFondo = new System.Windows.Forms.Panel();
            this.lblTexto = new System.Windows.Forms.Label();
            this.picIcono = new System.Windows.Forms.PictureBox();
            this.panelFondo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcono)).BeginInit();
            this.SuspendLayout();

            // 
            // panelFondo
            // 
            this.panelFondo.BackColor = System.Drawing.Color.WhiteSmoke; // Color base suave
            this.panelFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFondo.Controls.Add(this.picIcono);
            this.panelFondo.Controls.Add(this.lblTexto);
            this.panelFondo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.Padding = new System.Windows.Forms.Padding(10);
            this.panelFondo.TabIndex = 0;

            // 
            // lblTexto
            // 
            this.lblTexto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTexto.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTexto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); // Fuente moderna
            this.lblTexto.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.lblTexto.Location = new System.Drawing.Point(10, 150);
            this.lblTexto.Name = "lblTexto";
            this.lblTexto.Size = new System.Drawing.Size(180, 40);
            this.lblTexto.TabIndex = 1;
            this.lblTexto.Text = "Agregar Cultivo";
            this.lblTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // picIcono
            // 
            this.picIcono.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIcono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picIcono.BackColor = System.Drawing.Color.Transparent;
            this.picIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom; // Para que la imagen se ajuste
            this.picIcono.Name = "picIcono";
            this.picIcono.TabIndex = 0;
            this.picIcono.TabStop = false;

            // 
            // CultivoSlotView
            // 
            this.Controls.Add(this.panelFondo);
            this.Name = "CultivoSlotView";
            this.Size = new System.Drawing.Size(200, 200); // Tamaño por defecto
            this.panelFondo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcono)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
