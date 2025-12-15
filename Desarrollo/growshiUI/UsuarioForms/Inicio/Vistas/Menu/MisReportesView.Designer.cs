namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    partial class MisReportesView
    {
        private System.ComponentModel.IContainer components = null;

        // Estructura Principal
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelMainScroll;

        // --- SECCIÓN 1: KPI / ALERTAS ---
        private System.Windows.Forms.Panel panelResumenContainer;
        private System.Windows.Forms.TableLayoutPanel tblResumen; // <--- CAMBIO CLAVE: TABLA

        // --- SECCIÓN 2: GRÁFICOS ---
        private System.Windows.Forms.Panel panelChartsContainer;
        private System.Windows.Forms.TableLayoutPanel tblLayoutCharts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperatura;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHumedad;

        // --- SECCIÓN 3: GRID ---
        private System.Windows.Forms.Panel panelGridContainer;
        private MetroFramework.Controls.MetroGrid dgvMediciones;

        // Controles Header
        private MetroFramework.Controls.MetroButton btnExportarPdf;
        private MetroFramework.Controls.MetroComboBox cmbFiltroTiempo;
        private MetroFramework.Controls.MetroComboBox cmbPlantas;
        private MetroFramework.Controls.MetroLabel lblPlanta;
        private MetroFramework.Controls.MetroLabel lblTitulo;
        private MetroFramework.Controls.MetroLabel lblAnalisisInfo;

        // Espaciadores visuales
        private System.Windows.Forms.Panel spacer1;
        private System.Windows.Forms.Panel spacer2;

        // Variables lógicas (necesarias para referencia)
        private System.Windows.Forms.Label lblTotalAlertasTemp;
        private System.Windows.Forms.Label lblTotalAlertasHum;
        private System.Windows.Forms.Label lblTotalAlertasLuz;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnExportarPdf = new MetroFramework.Controls.MetroButton();
            this.cmbFiltroTiempo = new MetroFramework.Controls.MetroComboBox();
            this.cmbPlantas = new MetroFramework.Controls.MetroComboBox();
            this.lblPlanta = new MetroFramework.Controls.MetroLabel();
            this.lblAnalisisInfo = new MetroFramework.Controls.MetroLabel();
            this.lblTitulo = new MetroFramework.Controls.MetroLabel();
            this.panelMainScroll = new System.Windows.Forms.Panel();
            this.panelGridContainer = new System.Windows.Forms.Panel();
            this.dgvMediciones = new MetroFramework.Controls.MetroGrid();
            this.spacer2 = new System.Windows.Forms.Panel();
            this.panelChartsContainer = new System.Windows.Forms.Panel();
            this.tblLayoutCharts = new System.Windows.Forms.TableLayoutPanel();
            this.chartTemperatura = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartHumedad = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.spacer1 = new System.Windows.Forms.Panel();
            this.panelResumenContainer = new System.Windows.Forms.Panel();
            this.tblResumen = new System.Windows.Forms.TableLayoutPanel();
            this.panelHeader.SuspendLayout();
            this.panelMainScroll.SuspendLayout();
            this.panelGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMediciones)).BeginInit();
            this.panelChartsContainer.SuspendLayout();
            this.tblLayoutCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperatura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHumedad)).BeginInit();
            this.panelResumenContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.btnExportarPdf);
            this.panelHeader.Controls.Add(this.cmbFiltroTiempo);
            this.panelHeader.Controls.Add(this.cmbPlantas);
            this.panelHeader.Controls.Add(this.lblPlanta);
            this.panelHeader.Controls.Add(this.lblAnalisisInfo);
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 110);
            this.panelHeader.TabIndex = 0;
            // 
            // btnExportarPdf
            // 
            this.btnExportarPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarPdf.Location = new System.Drawing.Point(850, 15);
            this.btnExportarPdf.Name = "btnExportarPdf";
            this.btnExportarPdf.Size = new System.Drawing.Size(130, 35);
            this.btnExportarPdf.TabIndex = 0;
            this.btnExportarPdf.Text = "Exportar PDF";
            this.btnExportarPdf.UseSelectable = true;
            this.btnExportarPdf.Click += new System.EventHandler(this.BtnExportarPdf_Click);
            // 
            // cmbFiltroTiempo
            // 
            this.cmbFiltroTiempo.ItemHeight = 23;
            this.cmbFiltroTiempo.Location = new System.Drawing.Point(570, 15);
            this.cmbFiltroTiempo.Name = "cmbFiltroTiempo";
            this.cmbFiltroTiempo.Size = new System.Drawing.Size(180, 29);
            this.cmbFiltroTiempo.TabIndex = 1;
            this.cmbFiltroTiempo.UseSelectable = true;
            // 
            // cmbPlantas
            // 
            this.cmbPlantas.ItemHeight = 23;
            this.cmbPlantas.Location = new System.Drawing.Point(354, 15);
            this.cmbPlantas.Name = "cmbPlantas";
            this.cmbPlantas.Size = new System.Drawing.Size(200, 29);
            this.cmbPlantas.TabIndex = 2;
            this.cmbPlantas.UseSelectable = true;
            // 
            // lblPlanta
            // 
            this.lblPlanta.AutoSize = true;
            this.lblPlanta.Location = new System.Drawing.Point(300, 20);
            this.lblPlanta.Name = "lblPlanta";
            this.lblPlanta.Size = new System.Drawing.Size(48, 19);
            this.lblPlanta.TabIndex = 3;
            this.lblPlanta.Text = "Planta:";
            // 
            // lblAnalisisInfo
            // 
            this.lblAnalisisInfo.AutoSize = true;
            this.lblAnalisisInfo.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblAnalisisInfo.ForeColor = System.Drawing.Color.DimGray;
            this.lblAnalisisInfo.Location = new System.Drawing.Point(24, 45);
            this.lblAnalisisInfo.Name = "lblAnalisisInfo";
            this.lblAnalisisInfo.Size = new System.Drawing.Size(101, 15);
            this.lblAnalisisInfo.TabIndex = 4;
            this.lblAnalisisInfo.Text = "Seleccione planta...";
            this.lblAnalisisInfo.UseCustomForeColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblTitulo.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(172, 25);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Reporte de Cultivo";
            // 
            // panelMainScroll
            // 
            this.panelMainScroll.AutoScroll = true;
            this.panelMainScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panelMainScroll.Controls.Add(this.panelGridContainer);
            this.panelMainScroll.Controls.Add(this.spacer2);
            this.panelMainScroll.Controls.Add(this.panelChartsContainer);
            this.panelMainScroll.Controls.Add(this.spacer1);
            this.panelMainScroll.Controls.Add(this.panelResumenContainer);
            this.panelMainScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainScroll.Location = new System.Drawing.Point(0, 110);
            this.panelMainScroll.Name = "panelMainScroll";
            this.panelMainScroll.Size = new System.Drawing.Size(1000, 590);
            this.panelMainScroll.TabIndex = 1;
            // 
            // panelGridContainer
            // 
            this.panelGridContainer.BackColor = System.Drawing.Color.White;
            this.panelGridContainer.Controls.Add(this.dgvMediciones);
            this.panelGridContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGridContainer.Location = new System.Drawing.Point(0, 500);
            this.panelGridContainer.Name = "panelGridContainer";
            this.panelGridContainer.Padding = new System.Windows.Forms.Padding(15);
            this.panelGridContainer.Size = new System.Drawing.Size(983, 400);
            this.panelGridContainer.TabIndex = 4;
            // 
            // dgvMediciones
            // 
            this.dgvMediciones.AllowUserToResizeRows = false;
            this.dgvMediciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMediciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvMediciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMediciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMediciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMediciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMediciones.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMediciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMediciones.EnableHeadersVisualStyles = false;
            this.dgvMediciones.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvMediciones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvMediciones.Location = new System.Drawing.Point(15, 15);
            this.dgvMediciones.Name = "dgvMediciones";
            this.dgvMediciones.ReadOnly = true;
            this.dgvMediciones.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMediciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMediciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMediciones.RowTemplate.Height = 30;
            this.dgvMediciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMediciones.Size = new System.Drawing.Size(953, 370);
            this.dgvMediciones.TabIndex = 0;
            // 
            // spacer2
            // 
            this.spacer2.BackColor = System.Drawing.Color.Transparent;
            this.spacer2.Dock = System.Windows.Forms.DockStyle.Top;
            this.spacer2.Location = new System.Drawing.Point(0, 485);
            this.spacer2.Name = "spacer2";
            this.spacer2.Size = new System.Drawing.Size(983, 15);
            this.spacer2.TabIndex = 3;
            // 
            // panelChartsContainer
            // 
            this.panelChartsContainer.BackColor = System.Drawing.Color.White;
            this.panelChartsContainer.Controls.Add(this.tblLayoutCharts);
            this.panelChartsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelChartsContainer.Location = new System.Drawing.Point(0, 105);
            this.panelChartsContainer.Name = "panelChartsContainer";
            this.panelChartsContainer.Padding = new System.Windows.Forms.Padding(10);
            this.panelChartsContainer.Size = new System.Drawing.Size(983, 380);
            this.panelChartsContainer.TabIndex = 2;
            // 
            // tblLayoutCharts
            // 
            this.tblLayoutCharts.ColumnCount = 2;
            this.tblLayoutCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLayoutCharts.Controls.Add(this.chartTemperatura, 0, 0);
            this.tblLayoutCharts.Controls.Add(this.chartHumedad, 1, 0);
            this.tblLayoutCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutCharts.Location = new System.Drawing.Point(10, 10);
            this.tblLayoutCharts.Name = "tblLayoutCharts";
            this.tblLayoutCharts.RowCount = 1;
            this.tblLayoutCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutCharts.Size = new System.Drawing.Size(963, 360);
            this.tblLayoutCharts.TabIndex = 0;
            // 
            // chartTemperatura
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTemperatura.ChartAreas.Add(chartArea1);
            this.chartTemperatura.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartTemperatura.Legends.Add(legend1);
            this.chartTemperatura.Location = new System.Drawing.Point(3, 3);
            this.chartTemperatura.Name = "chartTemperatura";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTemperatura.Series.Add(series1);
            this.chartTemperatura.Size = new System.Drawing.Size(475, 354);
            this.chartTemperatura.TabIndex = 0;
            // 
            // chartHumedad
            // 
            chartArea2.Name = "ChartArea1";
            this.chartHumedad.ChartAreas.Add(chartArea2);
            this.chartHumedad.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartHumedad.Legends.Add(legend2);
            this.chartHumedad.Location = new System.Drawing.Point(484, 3);
            this.chartHumedad.Name = "chartHumedad";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartHumedad.Series.Add(series2);
            this.chartHumedad.Size = new System.Drawing.Size(476, 354);
            this.chartHumedad.TabIndex = 1;
            // 
            // spacer1
            // 
            this.spacer1.BackColor = System.Drawing.Color.Transparent;
            this.spacer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.spacer1.Location = new System.Drawing.Point(0, 90);
            this.spacer1.Name = "spacer1";
            this.spacer1.Size = new System.Drawing.Size(983, 15);
            this.spacer1.TabIndex = 1;
            // 
            // panelResumenContainer
            // 
            this.panelResumenContainer.Controls.Add(this.tblResumen);
            this.panelResumenContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResumenContainer.Location = new System.Drawing.Point(0, 0);
            this.panelResumenContainer.Name = "panelResumenContainer";
            this.panelResumenContainer.Padding = new System.Windows.Forms.Padding(20, 15, 20, 5);
            this.panelResumenContainer.Size = new System.Drawing.Size(983, 90);
            this.panelResumenContainer.TabIndex = 0;
            // 
            // tblResumen
            // 
            this.tblResumen.ColumnCount = 3;
            this.tblResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tblResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblResumen.Location = new System.Drawing.Point(20, 15);
            this.tblResumen.Name = "tblResumen";
            this.tblResumen.RowCount = 1;
            this.tblResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblResumen.Size = new System.Drawing.Size(943, 70);
            this.tblResumen.TabIndex = 0;
            // 
            // MisReportesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMainScroll);
            this.Controls.Add(this.panelHeader);
            this.Name = "MisReportesView";
            this.Size = new System.Drawing.Size(1000, 700);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMainScroll.ResumeLayout(false);
            this.panelGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMediciones)).EndInit();
            this.panelChartsContainer.ResumeLayout(false);
            this.tblLayoutCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperatura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHumedad)).EndInit();
            this.panelResumenContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}