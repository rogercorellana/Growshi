namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion.ABM_GestionUsuarios
{
    partial class ModificarPermisosPorUsuario
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();

            // Paneles Principales
            this.panelColUsuario = new System.Windows.Forms.Panel();
            this.panelColAsignados = new System.Windows.Forms.Panel();
            this.panelColDisponibles = new System.Windows.Forms.Panel();
            this.panelColBotones = new System.Windows.Forms.Panel();

            // Marcos para los Grids (El borde elegante)
            this.marcoUsuario = new System.Windows.Forms.Panel();
            this.marcoAsignados = new System.Windows.Forms.Panel();
            this.marcoDisponibles = new System.Windows.Forms.Panel();

            // Grids
            this.metroGridUsuarios = new MetroFramework.Controls.MetroGrid();
            this.metroGridAsignados = new MetroFramework.Controls.MetroGrid();
            this.metroGridDisponibles = new MetroFramework.Controls.MetroGrid();

            // Labels
            this.lblTitulo1 = new MetroFramework.Controls.MetroLabel();
            this.lblTitulo2 = new MetroFramework.Controls.MetroLabel();
            this.lblTitulo3 = new MetroFramework.Controls.MetroLabel();

            // Botones Centrales
            this.btnAgregar = new System.Windows.Forms.Button(); // Usamos Button normal para poder redondearlo facil
            this.btnQuitar = new System.Windows.Forms.Button();

            this.tableLayoutPanel1.SuspendLayout();
            this.panelColUsuario.SuspendLayout();
            this.panelColAsignados.SuspendLayout();
            this.panelColDisponibles.SuspendLayout();
            this.panelColBotones.SuspendLayout();

            this.marcoUsuario.SuspendLayout();
            this.marcoAsignados.SuspendLayout();
            this.marcoDisponibles.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.metroGridUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridAsignados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridDisponibles)).BeginInit();
            this.SuspendLayout();

            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F)); // Columna estrecha para botones
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.panelColUsuario, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelColAsignados, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelColBotones, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelColDisponibles, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 650);
            this.tableLayoutPanel1.TabIndex = 0;

            // 
            // --- COLUMNA 1: USUARIOS ---
            // 
            this.panelColUsuario.Controls.Add(this.marcoUsuario);
            this.panelColUsuario.Controls.Add(this.lblTitulo1);
            this.panelColUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelColUsuario.Padding = new System.Windows.Forms.Padding(10);
            this.panelColUsuario.Location = new System.Drawing.Point(3, 3);
            this.panelColUsuario.Name = "panelColUsuario";
            this.panelColUsuario.Size = new System.Drawing.Size(330, 644);
            this.panelColUsuario.TabIndex = 0;

            this.lblTitulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo1.Location = new System.Drawing.Point(10, 10);
            this.lblTitulo1.Name = "lblTitulo1";
            this.lblTitulo1.Size = new System.Drawing.Size(310, 30);
            this.lblTitulo1.TabIndex = 0;
            this.lblTitulo1.Text = "1. Seleccionar Usuario";

            // Marco (Borde Fino)
            this.marcoUsuario.BackColor = System.Drawing.Color.Silver; // Color del borde
            this.marcoUsuario.Controls.Add(this.metroGridUsuarios);
            this.marcoUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marcoUsuario.Padding = new System.Windows.Forms.Padding(1); // Grosor del borde
            this.marcoUsuario.Location = new System.Drawing.Point(10, 40);
            this.marcoUsuario.Name = "marcoUsuario";
            this.marcoUsuario.Size = new System.Drawing.Size(310, 594);
            this.marcoUsuario.TabIndex = 1;

            this.metroGridUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGridUsuarios.Location = new System.Drawing.Point(1, 1);
            this.metroGridUsuarios.Name = "metroGridUsuarios";
            this.metroGridUsuarios.Size = new System.Drawing.Size(308, 592);
            this.metroGridUsuarios.TabIndex = 0;
            this.metroGridUsuarios.SelectionChanged += new System.EventHandler(this.metroGridUsuarios_SelectionChanged);

            // 
            // --- COLUMNA 2: ASIGNADOS ---
            // 
            this.panelColAsignados.Controls.Add(this.marcoAsignados);
            this.panelColAsignados.Controls.Add(this.lblTitulo2);
            this.panelColAsignados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelColAsignados.Padding = new System.Windows.Forms.Padding(10);
            this.panelColAsignados.Location = new System.Drawing.Point(339, 3);
            this.panelColAsignados.Name = "panelColAsignados";
            this.panelColAsignados.Size = new System.Drawing.Size(330, 644);
            this.panelColAsignados.TabIndex = 1;

            this.lblTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo2.Location = new System.Drawing.Point(10, 10);
            this.lblTitulo2.Name = "lblTitulo2";
            this.lblTitulo2.Size = new System.Drawing.Size(310, 30);
            this.lblTitulo2.TabIndex = 0;
            this.lblTitulo2.Text = "Roles Asignados";

            this.marcoAsignados.BackColor = System.Drawing.Color.Silver;
            this.marcoAsignados.Controls.Add(this.metroGridAsignados);
            this.marcoAsignados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marcoAsignados.Padding = new System.Windows.Forms.Padding(1);
            this.marcoAsignados.Location = new System.Drawing.Point(10, 40);
            this.marcoAsignados.Name = "marcoAsignados";
            this.marcoAsignados.Size = new System.Drawing.Size(310, 594);
            this.marcoAsignados.TabIndex = 1;

            this.metroGridAsignados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGridAsignados.Location = new System.Drawing.Point(1, 1);
            this.metroGridAsignados.Name = "metroGridAsignados";
            this.metroGridAsignados.Size = new System.Drawing.Size(308, 592);
            this.metroGridAsignados.TabIndex = 0;

            // 
            // --- COLUMNA 3: BOTONES CENTRALES ---
            // 
            this.panelColBotones.Controls.Add(this.btnQuitar);
            this.panelColBotones.Controls.Add(this.btnAgregar);
            this.panelColBotones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelColBotones.Location = new System.Drawing.Point(675, 3);
            this.panelColBotones.Name = "panelColBotones";
            this.panelColBotones.Size = new System.Drawing.Size(74, 644);
            this.panelColBotones.TabIndex = 2;

            // Botón Agregar (Flecha Izquierda)
            this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.None; // CENTRADO MÁGICO
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI Symbol", 14F, System.Drawing.FontStyle.Bold);
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(12, 250); // Posición vertical aprox
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(50, 50); // Redondo
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "◄";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);

            // Botón Quitar (Flecha Derecha)
            this.btnQuitar.Anchor = System.Windows.Forms.AnchorStyles.None; // CENTRADO MÁGICO
            this.btnQuitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79))))); // Rojo suave
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Segoe UI Symbol", 14F, System.Drawing.FontStyle.Bold);
            this.btnQuitar.ForeColor = System.Drawing.Color.White;
            this.btnQuitar.Location = new System.Drawing.Point(12, 310);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(50, 50); // Redondo
            this.btnQuitar.TabIndex = 1;
            this.btnQuitar.Text = "►";
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);

            // 
            // --- COLUMNA 4: DISPONIBLES ---
            // 
            this.panelColDisponibles.Controls.Add(this.marcoDisponibles);
            this.panelColDisponibles.Controls.Add(this.lblTitulo3);
            this.panelColDisponibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelColDisponibles.Padding = new System.Windows.Forms.Padding(10);
            this.panelColDisponibles.Location = new System.Drawing.Point(755, 3);
            this.panelColDisponibles.Name = "panelColDisponibles";
            this.panelColDisponibles.Size = new System.Drawing.Size(442, 644);
            this.panelColDisponibles.TabIndex = 3;

            this.lblTitulo3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo3.ForeColor = System.Drawing.Color.Gray;
            this.lblTitulo3.Location = new System.Drawing.Point(10, 10);
            this.lblTitulo3.Name = "lblTitulo3";
            this.lblTitulo3.Size = new System.Drawing.Size(422, 30);
            this.lblTitulo3.TabIndex = 0;
            this.lblTitulo3.Text = "Roles Disponibles";
            this.lblTitulo3.UseCustomForeColor = true;

            this.marcoDisponibles.BackColor = System.Drawing.Color.Silver;
            this.marcoDisponibles.Controls.Add(this.metroGridDisponibles);
            this.marcoDisponibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marcoDisponibles.Padding = new System.Windows.Forms.Padding(1);
            this.marcoDisponibles.Location = new System.Drawing.Point(10, 40);
            this.marcoDisponibles.Name = "marcoDisponibles";
            this.marcoDisponibles.Size = new System.Drawing.Size(422, 594);
            this.marcoDisponibles.TabIndex = 1;

            this.metroGridDisponibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGridDisponibles.Location = new System.Drawing.Point(1, 1);
            this.metroGridDisponibles.Name = "metroGridDisponibles";
            this.metroGridDisponibles.Size = new System.Drawing.Size(420, 592);
            this.metroGridDisponibles.TabIndex = 0;

            // 
            // ModificarPermisosPorUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ModificarPermisosPorUsuario";
            this.Size = new System.Drawing.Size(1200, 650);
            this.Load += new System.EventHandler(this.ModificarPermisosPorUsuario_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelColUsuario.ResumeLayout(false);
            this.panelColAsignados.ResumeLayout(false);
            this.panelColDisponibles.ResumeLayout(false);
            this.panelColBotones.ResumeLayout(false);
            this.marcoUsuario.ResumeLayout(false);
            this.marcoAsignados.ResumeLayout(false);
            this.marcoDisponibles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGridUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridAsignados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridDisponibles)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelColUsuario;
        private System.Windows.Forms.Panel panelColAsignados;
        private System.Windows.Forms.Panel panelColDisponibles;
        private System.Windows.Forms.Panel panelColBotones;

        // Controles
        private MetroFramework.Controls.MetroLabel lblTitulo1;
        private MetroFramework.Controls.MetroLabel lblTitulo2;
        private MetroFramework.Controls.MetroLabel lblTitulo3;

        private System.Windows.Forms.Panel marcoUsuario;
        private System.Windows.Forms.Panel marcoAsignados;
        private System.Windows.Forms.Panel marcoDisponibles;

        private MetroFramework.Controls.MetroGrid metroGridUsuarios;
        private MetroFramework.Controls.MetroGrid metroGridAsignados;
        private MetroFramework.Controls.MetroGrid metroGridDisponibles;

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
    }
}
