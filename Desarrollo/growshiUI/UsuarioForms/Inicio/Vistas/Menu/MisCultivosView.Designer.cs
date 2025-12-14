namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    partial class MisCultivosView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MisCultivosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            // Importante: Aquí estableceremos la imagen por código, o puedes hacerlo en el diseñador visual
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DoubleBuffered = true; // IMPORTANTE: Reduce el parpadeo gráfico
            this.Name = "MisCultivosView";
            this.Size = new System.Drawing.Size(800, 600); // Ajusta al tamaño deseado
            this.ResumeLayout(false);
        }
    }
}