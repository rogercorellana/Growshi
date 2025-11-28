namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    partial class HistorialView
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelLista = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.White;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitulo.Size = new System.Drawing.Size(700, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Historial de Eventos y Bitácora";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelLista
            // 
            this.panelLista.AutoScroll = true;
            this.panelLista.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLista.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelLista.Location = new System.Drawing.Point(0, 50);
            this.panelLista.Name = "panelLista";
            this.panelLista.Padding = new System.Windows.Forms.Padding(10);
            this.panelLista.Size = new System.Drawing.Size(700, 450);
            this.panelLista.TabIndex = 1;
            this.panelLista.WrapContents = false;
            // 
            // HistorialView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelLista);
            this.Controls.Add(this.lblTitulo);
            this.Name = "HistorialView";
            this.Size = new System.Drawing.Size(700, 500);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.FlowLayoutPanel panelLista;
    }
}