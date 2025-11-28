namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    partial class IdiomaView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IdiomaView));
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.layoutPrincipal = new System.Windows.Forms.TableLayoutPanel();

            // Tarjeta Español
            this.cardEspanol = new System.Windows.Forms.Panel();
            this.lblEspanol = new MetroFramework.Controls.MetroLabel();
            this.picEspanol = new System.Windows.Forms.PictureBox();

            // Tarjeta Inglés
            this.cardIngles = new System.Windows.Forms.Panel();
            this.lblIngles = new MetroFramework.Controls.MetroLabel();
            this.picIngles = new System.Windows.Forms.PictureBox();

            // Tarjeta Próximo (Nuevo)
            this.cardProximo = new System.Windows.Forms.Panel();
            this.lblProximo = new MetroFramework.Controls.MetroLabel();
            this.picProximo = new System.Windows.Forms.PictureBox();
            this.lblConstruction = new MetroFramework.Controls.MetroLabel();

            this.layoutPrincipal.SuspendLayout();
            this.cardEspanol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEspanol)).BeginInit();
            this.cardIngles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIngles)).BeginInit();
            this.cardProximo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProximo)).BeginInit();
            this.SuspendLayout();

            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(1260, 60);
            this.lblTitulo.Style = MetroFramework.MetroColorStyle.Green;
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Seleccione un Idioma";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.UseCustomForeColor = true;

            // 
            // layoutPrincipal
            // 
            this.layoutPrincipal.BackColor = System.Drawing.Color.White;
            this.layoutPrincipal.ColumnCount = 5;
            // 5 Columnas: [Margen 5%] [Card 30%] [Card 30%] [Card 30%] [Margen 5%]
            this.layoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.layoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layoutPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));

            this.layoutPrincipal.Controls.Add(this.cardEspanol, 1, 0);
            this.layoutPrincipal.Controls.Add(this.cardIngles, 2, 0);
            this.layoutPrincipal.Controls.Add(this.cardProximo, 3, 0); // Agregamos la 3ra tarjeta

            this.layoutPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutPrincipal.Location = new System.Drawing.Point(0, 60);
            this.layoutPrincipal.Name = "layoutPrincipal";
            this.layoutPrincipal.RowCount = 1;
            this.layoutPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPrincipal.Size = new System.Drawing.Size(1260, 424);
            this.layoutPrincipal.TabIndex = 1;

            // 
            // cardEspanol
            // 
            this.cardEspanol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cardEspanol.BackColor = System.Drawing.Color.White;
            this.cardEspanol.Controls.Add(this.lblEspanol);
            this.cardEspanol.Controls.Add(this.picEspanol);
            this.cardEspanol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardEspanol.Location = new System.Drawing.Point(86, 37);
            this.cardEspanol.Name = "cardEspanol";
            this.cardEspanol.Padding = new System.Windows.Forms.Padding(10);
            this.cardEspanol.Size = new System.Drawing.Size(300, 350);
            this.cardEspanol.TabIndex = 0;
            this.cardEspanol.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);

            // picEspanol
            this.picEspanol.BackColor = System.Drawing.Color.Transparent;
            this.picEspanol.Dock = System.Windows.Forms.DockStyle.Top;
            this.picEspanol.Image = global::growshiUI.Properties.Resources.growshi_Español;
            this.picEspanol.Location = new System.Drawing.Point(10, 10);
            this.picEspanol.Name = "picEspanol";
            this.picEspanol.Size = new System.Drawing.Size(280, 250);
            this.picEspanol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEspanol.TabIndex = 0;
            this.picEspanol.TabStop = false;

            // lblEspanol
            this.lblEspanol.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEspanol.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblEspanol.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblEspanol.Location = new System.Drawing.Point(10, 290);
            this.lblEspanol.Name = "lblEspanol";
            this.lblEspanol.Size = new System.Drawing.Size(280, 50);
            this.lblEspanol.TabIndex = 1;
            this.lblEspanol.Text = "Español";
            this.lblEspanol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // cardIngles
            // 
            this.cardIngles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cardIngles.BackColor = System.Drawing.Color.White;
            this.cardIngles.Controls.Add(this.lblIngles);
            this.cardIngles.Controls.Add(this.picIngles);
            this.cardIngles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardIngles.Location = new System.Drawing.Point(464, 37);
            this.cardIngles.Name = "cardIngles";
            this.cardIngles.Padding = new System.Windows.Forms.Padding(10);
            this.cardIngles.Size = new System.Drawing.Size(300, 350);
            this.cardIngles.TabIndex = 1;
            this.cardIngles.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);

            // picIngles
            this.picIngles.BackColor = System.Drawing.Color.Transparent;
            this.picIngles.Dock = System.Windows.Forms.DockStyle.Top;
            this.picIngles.Image = global::growshiUI.Properties.Resources.growshi_Americano;
            this.picIngles.Location = new System.Drawing.Point(10, 10);
            this.picIngles.Name = "picIngles";
            this.picIngles.Size = new System.Drawing.Size(280, 250);
            this.picIngles.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIngles.TabIndex = 0;
            this.picIngles.TabStop = false;

            // lblIngles
            this.lblIngles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblIngles.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblIngles.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblIngles.Location = new System.Drawing.Point(10, 290);
            this.lblIngles.Name = "lblIngles";
            this.lblIngles.Size = new System.Drawing.Size(280, 50);
            this.lblIngles.TabIndex = 1;
            this.lblIngles.Text = "English";
            this.lblIngles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // cardProximo (Tercera Tarjeta)
            // 
            this.cardProximo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cardProximo.BackColor = System.Drawing.Color.WhiteSmoke; // Fondo Gris para indicar "inactivo"
            this.cardProximo.Controls.Add(this.lblConstruction); // Etiqueta extra
            this.cardProximo.Controls.Add(this.lblProximo);
            this.cardProximo.Controls.Add(this.picProximo);
            this.cardProximo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardProximo.Location = new System.Drawing.Point(842, 37);
            this.cardProximo.Name = "cardProximo";
            this.cardProximo.Padding = new System.Windows.Forms.Padding(10);
            this.cardProximo.Size = new System.Drawing.Size(300, 350);
            this.cardProximo.TabIndex = 2;
            this.cardProximo.Paint += new System.Windows.Forms.PaintEventHandler(this.Card_Paint);

            // picProximo (Reusamos el logo español o un icono genérico)
            this.picProximo.BackColor = System.Drawing.Color.Transparent;
            this.picProximo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picProximo.Image = global::growshiUI.Properties.Resources.growshi_Multicultural; // Usamos el logo base
            this.picProximo.Location = new System.Drawing.Point(10, 10);
            this.picProximo.Name = "picProximo";
            this.picProximo.Size = new System.Drawing.Size(280, 220); // Un poco más chico para que quepa el texto extra
            this.picProximo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProximo.TabIndex = 0;
            this.picProximo.TabStop = false;
            // Truco: Le bajamos la opacidad visualmente usando un color de fondo más oscuro si se pudiera, 
            // pero WhiteSmoke en el panel ya da ese efecto.

            // lblConstruction (Texto pequeño arriba del título)
            this.lblConstruction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblConstruction.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblConstruction.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblConstruction.ForeColor = System.Drawing.Color.Gray;
            this.lblConstruction.Location = new System.Drawing.Point(10, 250);
            this.lblConstruction.Name = "lblConstruction";
            this.lblConstruction.Size = new System.Drawing.Size(280, 40);
            this.lblConstruction.TabIndex = 2;
            this.lblConstruction.Text = "Espacio reservado para futuro idioma";
            this.lblConstruction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConstruction.UseCustomForeColor = true;

            // lblProximo
            this.lblProximo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblProximo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblProximo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblProximo.ForeColor = System.Drawing.Color.DimGray; // Texto gris oscuro
            this.lblProximo.Location = new System.Drawing.Point(10, 290);
            this.lblProximo.Name = "lblProximo";
            this.lblProximo.Size = new System.Drawing.Size(280, 50);
            this.lblProximo.TabIndex = 1;
            this.lblProximo.Text = "Próximamente";
            this.lblProximo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProximo.UseCustomForeColor = true;

            // 
            // IdiomaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.layoutPrincipal);
            this.Controls.Add(this.lblTitulo);
            this.Name = "IdiomaView";
            this.Size = new System.Drawing.Size(1260, 484);
            this.layoutPrincipal.ResumeLayout(false);
            this.cardEspanol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEspanol)).EndInit();
            this.cardIngles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIngles)).EndInit();
            this.cardProximo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProximo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblTitulo;
        private System.Windows.Forms.TableLayoutPanel layoutPrincipal;

        private System.Windows.Forms.Panel cardEspanol;
        private MetroFramework.Controls.MetroLabel lblEspanol;
        private System.Windows.Forms.PictureBox picEspanol;

        private System.Windows.Forms.Panel cardIngles;
        private MetroFramework.Controls.MetroLabel lblIngles;
        private System.Windows.Forms.PictureBox picIngles;

        // Nuevos controles para la tercera tarjeta
        private System.Windows.Forms.Panel cardProximo;
        private MetroFramework.Controls.MetroLabel lblProximo;
        private MetroFramework.Controls.MetroLabel lblConstruction;
        private System.Windows.Forms.PictureBox picProximo;
    }
}