namespace growshiUI.UsuarioForms.Inicio.Vistas.Configuracion
{
    partial class RolesYPermisosView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();

            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();

            // --- COLUMNA 1: FAMILIAS ---
            this.panelFamilia = new System.Windows.Forms.Panel();
            this.marcoFamilia = new System.Windows.Forms.Panel();
            this.metroGridFamilia = new MetroFramework.Controls.MetroGrid();
            this.panelBotonesFamilia = new System.Windows.Forms.Panel();
            this.btnEliminarFamilia = new MetroFramework.Controls.MetroButton();
            this.btnRenombrarFamilia = new MetroFramework.Controls.MetroButton();
            this.btnNuevaFamilia = new MetroFramework.Controls.MetroButton();
            this.lblFamilia = new MetroFramework.Controls.MetroLabel();

            // --- COLUMNA 2: ASOCIADOS ---
            this.panelAsociados = new System.Windows.Forms.Panel();
            this.marcoAsociados = new System.Windows.Forms.Panel();
            this.metroGridAsociados = new MetroFramework.Controls.MetroGrid();
            this.lblAsociados = new MetroFramework.Controls.MetroLabel();

            // --- COLUMNA 3: FLECHAS ---
            this.panelFlechas = new System.Windows.Forms.Panel();
            this.btnQuitarPermiso = new System.Windows.Forms.Button();
            this.btnAgregarPermiso = new System.Windows.Forms.Button();

            // --- COLUMNA 4: SISTEMA ---
            this.panelSistema = new System.Windows.Forms.Panel();
            this.marcoSistema = new System.Windows.Forms.Panel();
            this.metroGridSistema = new MetroFramework.Controls.MetroGrid();
            this.lblSistema = new MetroFramework.Controls.MetroLabel();

            this.tableLayoutPanelMain.SuspendLayout();

            this.panelFamilia.SuspendLayout();
            this.marcoFamilia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridFamilia)).BeginInit();
            this.panelBotonesFamilia.SuspendLayout();

            this.panelAsociados.SuspendLayout();
            this.marcoAsociados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridAsociados)).BeginInit();

            this.panelFlechas.SuspendLayout();

            this.panelSistema.SuspendLayout();
            this.marcoSistema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroGridSistema)).BeginInit();

            this.SuspendLayout();

            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 4;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F)); // Familias
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F)); // Asignados
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F)); // Flechas
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F)); // Disponibles

            this.tableLayoutPanelMain.Controls.Add(this.panelFamilia, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelAsociados, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelFlechas, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelSistema, 3, 0);

            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1000, 600);
            this.tableLayoutPanelMain.TabIndex = 0;

            // 
            // --- PANEL 1: FAMILIAS ---
            // 
            this.panelFamilia.Controls.Add(this.marcoFamilia);
            this.panelFamilia.Controls.Add(this.panelBotonesFamilia);
            this.panelFamilia.Controls.Add(this.lblFamilia);
            this.panelFamilia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFamilia.Padding = new System.Windows.Forms.Padding(10);
            this.panelFamilia.Location = new System.Drawing.Point(3, 3);
            this.panelFamilia.Name = "panelFamilia";
            this.panelFamilia.Size = new System.Drawing.Size(294, 594);
            this.panelFamilia.TabIndex = 0;

            this.lblFamilia.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFamilia.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblFamilia.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblFamilia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.lblFamilia.Location = new System.Drawing.Point(10, 10);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(274, 30);
            this.lblFamilia.Text = "Familias de Roles";
            this.lblFamilia.UseCustomForeColor = true;

            // Botones Gestión (Abajo)
            this.panelBotonesFamilia.Controls.Add(this.btnEliminarFamilia);
            this.panelBotonesFamilia.Controls.Add(this.btnRenombrarFamilia);
            this.panelBotonesFamilia.Controls.Add(this.btnNuevaFamilia);
            this.panelBotonesFamilia.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotonesFamilia.Location = new System.Drawing.Point(10, 464);
            this.panelBotonesFamilia.Name = "panelBotonesFamilia";
            this.panelBotonesFamilia.Size = new System.Drawing.Size(274, 120);
            this.panelBotonesFamilia.TabIndex = 1;

            this.btnNuevaFamilia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevaFamilia.Location = new System.Drawing.Point(0, 0);
            this.btnNuevaFamilia.Name = "btnNuevaFamilia";
            this.btnNuevaFamilia.Size = new System.Drawing.Size(274, 35);
            this.btnNuevaFamilia.Style = MetroFramework.MetroColorStyle.Green;
            this.btnNuevaFamilia.Text = "+ Nueva Familia";
            this.btnNuevaFamilia.Click += new System.EventHandler(this.btnNuevaFamilia_Click);

            this.btnRenombrarFamilia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRenombrarFamilia.Location = new System.Drawing.Point(0, 35);
            this.btnRenombrarFamilia.Name = "btnRenombrarFamilia";
            this.btnRenombrarFamilia.Size = new System.Drawing.Size(274, 35);
            this.btnRenombrarFamilia.Style = MetroFramework.MetroColorStyle.Orange;
            this.btnRenombrarFamilia.Text = "Renombrar";
            this.btnRenombrarFamilia.Click += new System.EventHandler(this.btnRenombrarFamilia_Click);

            this.btnEliminarFamilia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEliminarFamilia.Location = new System.Drawing.Point(0, 70);
            this.btnEliminarFamilia.Name = "btnEliminarFamilia";
            this.btnEliminarFamilia.Size = new System.Drawing.Size(274, 35);
            this.btnEliminarFamilia.Style = MetroFramework.MetroColorStyle.Red;
            this.btnEliminarFamilia.Text = "Eliminar";
            this.btnEliminarFamilia.Click += new System.EventHandler(this.btnEliminarFamilia_Click);

            // Grid Familia (Marco)
            this.marcoFamilia.BackColor = System.Drawing.Color.Silver;
            this.marcoFamilia.Controls.Add(this.metroGridFamilia);
            this.marcoFamilia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marcoFamilia.Padding = new System.Windows.Forms.Padding(1);
            this.marcoFamilia.Location = new System.Drawing.Point(10, 40);
            this.marcoFamilia.Name = "marcoFamilia";
            this.marcoFamilia.Size = new System.Drawing.Size(274, 424); // Se ajusta sobre los botones
            this.marcoFamilia.TabIndex = 2;

            this.metroGridFamilia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGridFamilia.Location = new System.Drawing.Point(1, 1);
            this.metroGridFamilia.Name = "metroGridFamilia";
            this.metroGridFamilia.SelectionChanged += new System.EventHandler(this.metroGridFamilia_SelectionChanged);

            // 
            // --- PANEL 2: ASOCIADOS ---
            // 
            this.panelAsociados.Controls.Add(this.marcoAsociados);
            this.panelAsociados.Controls.Add(this.lblAsociados);
            this.panelAsociados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAsociados.Padding = new System.Windows.Forms.Padding(10);
            this.panelAsociados.Location = new System.Drawing.Point(303, 3);
            this.panelAsociados.Name = "panelAsociados";
            this.panelAsociados.Size = new System.Drawing.Size(294, 594);
            this.panelAsociados.TabIndex = 1;

            this.lblAsociados.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAsociados.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblAsociados.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblAsociados.Location = new System.Drawing.Point(10, 10);
            this.lblAsociados.Name = "lblAsociados";
            this.lblAsociados.Size = new System.Drawing.Size(274, 30);
            this.lblAsociados.Text = "Permisos Asignados";

            this.marcoAsociados.BackColor = System.Drawing.Color.Silver;
            this.marcoAsociados.Controls.Add(this.metroGridAsociados);
            this.marcoAsociados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marcoAsociados.Padding = new System.Windows.Forms.Padding(1);
            this.marcoAsociados.Location = new System.Drawing.Point(10, 40);
            this.marcoAsociados.Name = "marcoAsociados";
            this.marcoAsociados.Size = new System.Drawing.Size(274, 544);

            this.metroGridAsociados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGridAsociados.Location = new System.Drawing.Point(1, 1);
            this.metroGridAsociados.Name = "metroGridAsociados";

            // 
            // --- PANEL 3: FLECHAS ---
            // 
            this.panelFlechas.Controls.Add(this.btnQuitarPermiso);
            this.panelFlechas.Controls.Add(this.btnAgregarPermiso);
            this.panelFlechas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFlechas.Location = new System.Drawing.Point(603, 3);
            this.panelFlechas.Name = "panelFlechas";
            this.panelFlechas.Size = new System.Drawing.Size(94, 594);
            this.panelFlechas.TabIndex = 2;

            this.btnAgregarPermiso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarPermiso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnAgregarPermiso.FlatAppearance.BorderSize = 0;
            this.btnAgregarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPermiso.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPermiso.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPermiso.Location = new System.Drawing.Point(22, 230);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(50, 50);
            this.btnAgregarPermiso.TabIndex = 0;
            this.btnAgregarPermiso.Text = "◄";
            this.btnAgregarPermiso.UseVisualStyleBackColor = false;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarPermiso_Click);

            this.btnQuitarPermiso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnQuitarPermiso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnQuitarPermiso.FlatAppearance.BorderSize = 0;
            this.btnQuitarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarPermiso.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnQuitarPermiso.ForeColor = System.Drawing.Color.White;
            this.btnQuitarPermiso.Location = new System.Drawing.Point(22, 300);
            this.btnQuitarPermiso.Name = "btnQuitarPermiso";
            this.btnQuitarPermiso.Size = new System.Drawing.Size(50, 50);
            this.btnQuitarPermiso.TabIndex = 1;
            this.btnQuitarPermiso.Text = "►";
            this.btnQuitarPermiso.UseVisualStyleBackColor = false;
            this.btnQuitarPermiso.Click += new System.EventHandler(this.btnQuitarPermiso_Click);

            // 
            // --- PANEL 4: DISPONIBLES ---
            // 
            this.panelSistema.Controls.Add(this.marcoSistema);
            this.panelSistema.Controls.Add(this.lblSistema);
            this.panelSistema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSistema.Padding = new System.Windows.Forms.Padding(10);
            this.panelSistema.Location = new System.Drawing.Point(703, 3);
            this.panelSistema.Name = "panelSistema";
            this.panelSistema.Size = new System.Drawing.Size(294, 594);
            this.panelSistema.TabIndex = 3;

            this.lblSistema.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSistema.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblSistema.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblSistema.ForeColor = System.Drawing.Color.Gray;
            this.lblSistema.Location = new System.Drawing.Point(10, 10);
            this.lblSistema.Name = "lblSistema";
            this.lblSistema.Size = new System.Drawing.Size(274, 30);
            this.lblSistema.Text = "Permisos Disponibles";
            this.lblSistema.UseCustomForeColor = true;

            this.marcoSistema.BackColor = System.Drawing.Color.Silver;
            this.marcoSistema.Controls.Add(this.metroGridSistema);
            this.marcoSistema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marcoSistema.Padding = new System.Windows.Forms.Padding(1);
            this.marcoSistema.Location = new System.Drawing.Point(10, 40);
            this.marcoSistema.Name = "marcoSistema";
            this.marcoSistema.Size = new System.Drawing.Size(274, 544);

            this.metroGridSistema.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroGridSistema.Location = new System.Drawing.Point(1, 1);
            this.metroGridSistema.Name = "metroGridSistema";

            // 
            // RolesYPermisosView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "RolesYPermisosView";
            this.Size = new System.Drawing.Size(1000, 600);
            this.Load += new System.EventHandler(this.RolesYPermisosView_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);

            this.panelFamilia.ResumeLayout(false);
            this.marcoFamilia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGridFamilia)).EndInit();
            this.panelBotonesFamilia.ResumeLayout(false);

            this.panelAsociados.ResumeLayout(false);
            this.marcoAsociados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGridAsociados)).EndInit();

            this.panelFlechas.ResumeLayout(false);

            this.panelSistema.ResumeLayout(false);
            this.marcoSistema.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroGridSistema)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;

        // Panel 1
        private System.Windows.Forms.Panel panelFamilia;
        private System.Windows.Forms.Panel marcoFamilia;
        private MetroFramework.Controls.MetroGrid metroGridFamilia;
        private System.Windows.Forms.Panel panelBotonesFamilia;
        private MetroFramework.Controls.MetroButton btnNuevaFamilia;
        private MetroFramework.Controls.MetroButton btnRenombrarFamilia;
        private MetroFramework.Controls.MetroButton btnEliminarFamilia;
        private MetroFramework.Controls.MetroLabel lblFamilia;

        // Panel 2
        private System.Windows.Forms.Panel panelAsociados;
        private System.Windows.Forms.Panel marcoAsociados;
        private MetroFramework.Controls.MetroGrid metroGridAsociados;
        private MetroFramework.Controls.MetroLabel lblAsociados;

        // Panel 3 (Flechas)
        private System.Windows.Forms.Panel panelFlechas;
        private System.Windows.Forms.Button btnAgregarPermiso;
        private System.Windows.Forms.Button btnQuitarPermiso;

        // Panel 4
        private System.Windows.Forms.Panel panelSistema;
        private System.Windows.Forms.Panel marcoSistema;
        private MetroFramework.Controls.MetroGrid metroGridSistema;
        private MetroFramework.Controls.MetroLabel lblSistema;
    }
}