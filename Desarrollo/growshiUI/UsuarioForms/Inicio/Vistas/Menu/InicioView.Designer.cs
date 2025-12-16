namespace growshiUI.UsuarioForms.Inicio
{
    partial class InicioView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();

            this.mainScrollPanel = new System.Windows.Forms.Panel();
            this.contentTable = new System.Windows.Forms.TableLayoutPanel();

            // Header: Panel de Inteligencia (Insight)
            this.panelInsight = new System.Windows.Forms.Panel();
            this.lblInsightTitulo = new System.Windows.Forms.Label();
            this.lblInsightTexto = new System.Windows.Forms.Label();

            // Gráfico 1: Pronóstico Principal
            this.chartPronostico = new System.Windows.Forms.DataVisualization.Charting.Chart();

            // Contenedor Inferior (Para poner VPD y Luz lado a lado)
            this.bottomLayout = new System.Windows.Forms.TableLayoutPanel();
            this.chartVPD = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLuz = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.mainScrollPanel.SuspendLayout();
            this.contentTable.SuspendLayout();
            this.panelInsight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPronostico)).BeginInit();
            this.bottomLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVPD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLuz)).BeginInit();
            this.SuspendLayout();

            // 
            // mainScrollPanel (El panel que permite hacer Scroll)
            // 
            this.mainScrollPanel.AutoScroll = true;
            this.mainScrollPanel.BackColor = System.Drawing.Color.White;
            this.mainScrollPanel.Controls.Add(this.contentTable);
            this.mainScrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainScrollPanel.Location = new System.Drawing.Point(0, 0);
            this.mainScrollPanel.Name = "mainScrollPanel";
            this.mainScrollPanel.Size = new System.Drawing.Size(950, 700);
            this.mainScrollPanel.TabIndex = 0;

            // 
            // contentTable (La tabla que estira el contenido)
            // 
            this.contentTable.AutoSize = true;
            this.contentTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contentTable.ColumnCount = 1;
            this.contentTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contentTable.RowCount = 3;
            // FILA 1: Insight (130px de alto)
            this.contentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            // FILA 2: Pronóstico Gigante (550px de alto)
            this.contentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 550F));
            // FILA 3: Gráficos Secundarios (500px de alto)
            this.contentTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 500F));

            this.contentTable.Controls.Add(this.panelInsight, 0, 0);
            this.contentTable.Controls.Add(this.chartPronostico, 0, 1);
            this.contentTable.Controls.Add(this.bottomLayout, 0, 2);
            this.contentTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.contentTable.Location = new System.Drawing.Point(0, 0);
            this.contentTable.Name = "contentTable";
            this.contentTable.Padding = new System.Windows.Forms.Padding(20);
            this.contentTable.Size = new System.Drawing.Size(933, 1220); // Altura virtual total
            this.contentTable.TabIndex = 0;

            // 
            // panelInsight (Fondo Azul Suave)
            // 
            this.panelInsight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.panelInsight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInsight.Controls.Add(this.lblInsightTexto);
            this.panelInsight.Controls.Add(this.lblInsightTitulo);
            this.panelInsight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInsight.Margin = new System.Windows.Forms.Padding(5);
            this.panelInsight.Name = "panelInsight";
            this.panelInsight.Size = new System.Drawing.Size(883, 120);
            this.panelInsight.TabIndex = 0;

            // 
            // lblInsightTitulo
            // 
            this.lblInsightTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInsightTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblInsightTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblInsightTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblInsightTitulo.Name = "lblInsightTitulo";
            this.lblInsightTitulo.Padding = new System.Windows.Forms.Padding(15, 15, 0, 0);
            this.lblInsightTitulo.Size = new System.Drawing.Size(881, 40);
            this.lblInsightTitulo.TabIndex = 0;
            this.lblInsightTitulo.Text = "🧠 GROWSHI AI INSIGHT";

            // 
            // lblInsightTexto
            // 
            this.lblInsightTexto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInsightTexto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblInsightTexto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblInsightTexto.Location = new System.Drawing.Point(0, 40);
            this.lblInsightTexto.Name = "lblInsightTexto";
            this.lblInsightTexto.Padding = new System.Windows.Forms.Padding(15, 5, 15, 0);
            this.lblInsightTexto.Size = new System.Drawing.Size(881, 78);
            this.lblInsightTexto.TabIndex = 1;
            this.lblInsightTexto.Text = "Conectando con Data Warehouse para análisis predictivo...";

            // 
            // chartPronostico
            // 
            chartArea1.Name = "ChartArea1";
            // Estilo base limpio
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(230, 230, 230);
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.chartPronostico.ChartAreas.Add(chartArea1);
            this.chartPronostico.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Font = new System.Drawing.Font("Segoe UI", 9F);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            this.chartPronostico.Legends.Add(legend1);
            this.chartPronostico.Location = new System.Drawing.Point(25, 155);
            this.chartPronostico.Margin = new System.Windows.Forms.Padding(5, 5, 5, 30); // Margen inferior grande
            this.chartPronostico.Name = "chartPronostico";
            this.chartPronostico.Size = new System.Drawing.Size(883, 515);
            this.chartPronostico.TabIndex = 1;
            this.chartPronostico.Text = "Pronóstico Extendido";

            // 
            // bottomLayout (Tabla dividida en 2 columnas)
            // 
            this.bottomLayout.ColumnCount = 2;
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.bottomLayout.Controls.Add(this.chartVPD, 0, 0);
            this.bottomLayout.Controls.Add(this.chartLuz, 1, 0);
            this.bottomLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomLayout.Location = new System.Drawing.Point(23, 703);
            this.bottomLayout.Name = "bottomLayout";
            this.bottomLayout.RowCount = 1;
            this.bottomLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottomLayout.Size = new System.Drawing.Size(887, 494);
            this.bottomLayout.TabIndex = 2;

            // 
            // chartVPD
            // 
            chartArea2.Name = "ChartArea1";
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(230, 230, 230);
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.chartVPD.ChartAreas.Add(chartArea2);
            this.chartVPD.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chartVPD.Legends.Add(legend2);
            this.chartVPD.Location = new System.Drawing.Point(3, 3);
            this.chartVPD.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3); // Margen derecho
            this.chartVPD.Name = "chartVPD";
            this.chartVPD.Size = new System.Drawing.Size(425, 488);
            this.chartVPD.TabIndex = 0;
            this.chartVPD.Text = "Análisis de Riesgo";

            // 
            // chartLuz
            // 
            chartArea3.Name = "ChartArea1";
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(230, 230, 230);
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.chartLuz.ChartAreas.Add(chartArea3);
            this.chartLuz.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chartLuz.Legends.Add(legend3);
            this.chartLuz.Location = new System.Drawing.Point(458, 3);
            this.chartLuz.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3); // Margen izquierdo
            this.chartLuz.Name = "chartLuz";
            this.chartLuz.Size = new System.Drawing.Size(426, 488);
            this.chartLuz.TabIndex = 1;
            this.chartLuz.Text = "Calidad Iluminación";

            // 
            // InicioView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainScrollPanel);
            this.Name = "InicioView";
            this.Size = new System.Drawing.Size(950, 700);

            this.mainScrollPanel.ResumeLayout(false);
            this.mainScrollPanel.PerformLayout();
            this.contentTable.ResumeLayout(false);
            this.panelInsight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPronostico)).EndInit();
            this.bottomLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVPD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLuz)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Componentes Declarados
        private System.Windows.Forms.Panel mainScrollPanel;
        private System.Windows.Forms.TableLayoutPanel contentTable;

        private System.Windows.Forms.Panel panelInsight;
        private System.Windows.Forms.Label lblInsightTitulo;
        private System.Windows.Forms.Label lblInsightTexto;

        private System.Windows.Forms.DataVisualization.Charting.Chart chartPronostico;

        private System.Windows.Forms.TableLayoutPanel bottomLayout;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVPD;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLuz;
    }
}