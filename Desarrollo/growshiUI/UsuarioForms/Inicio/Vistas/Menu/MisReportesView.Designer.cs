namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    partial class MisReportesView
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMetricas;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cmbFiltroTiempo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.cmbFiltroTiempo = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.chartMetricas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMetricas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFiltros.Controls.Add(this.cmbFiltroTiempo);
            this.panelFiltros.Controls.Add(this.lblTitulo);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.panelFiltros.Size = new System.Drawing.Size(600, 50);
            this.panelFiltros.TabIndex = 1;
            // 
            // cmbFiltroTiempo
            // 
            this.cmbFiltroTiempo.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbFiltroTiempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroTiempo.Items.AddRange(new object[] {
            "Última Semana",
            "Último Mes",
            "Todo el Historial"});
            this.cmbFiltroTiempo.Location = new System.Drawing.Point(430, 10);
            this.cmbFiltroTiempo.Name = "cmbFiltroTiempo";
            this.cmbFiltroTiempo.Size = new System.Drawing.Size(150, 21);
            this.cmbFiltroTiempo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(268, 21);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Evolución de Nutrientes (pH y EC)";
            // 
            // chartMetricas
            // 
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.Name = "ChartArea1";
            this.chartMetricas.ChartAreas.Add(chartArea1);
            this.chartMetricas.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chartMetricas.Legends.Add(legend1);
            this.chartMetricas.Location = new System.Drawing.Point(0, 50);
            this.chartMetricas.Name = "chartMetricas";
            this.chartMetricas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chartMetricas.Series.Add(series1);
            this.chartMetricas.Series.Add(series2);
            this.chartMetricas.Size = new System.Drawing.Size(600, 350);
            this.chartMetricas.TabIndex = 0;
            // 
            // MisReportesView
            // 
            this.Controls.Add(this.chartMetricas);
            this.Controls.Add(this.panelFiltros);
            this.Name = "MisReportesView";
            this.Size = new System.Drawing.Size(600, 400);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMetricas)).EndInit();
            this.ResumeLayout(false);

        }
    }
}