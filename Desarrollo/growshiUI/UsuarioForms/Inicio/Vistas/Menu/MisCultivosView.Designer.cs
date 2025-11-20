namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    partial class MisCultivosView
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TableLayoutPanel gridLayout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.gridLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();

            // 
            // gridLayout (La grilla responsive)
            // 
            this.gridLayout.ColumnCount = 2;
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gridLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gridLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLayout.Location = new System.Drawing.Point(0, 0);
            this.gridLayout.RowCount = 2;
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gridLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.gridLayout.Name = "gridLayout";
            this.gridLayout.Padding = new System.Windows.Forms.Padding(20); // Margen externo
            this.gridLayout.TabIndex = 0;

            // 
            // MisCultivosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridLayout);
            this.Name = "MisCultivosView";
            this.Size = new System.Drawing.Size(600, 500);
            this.ResumeLayout(false);
        }
    }
}