using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class MisReportesView : UserControl
    {
        public MisReportesView()
        {
            InitializeComponent();
            ConfigurarSeries();
            this.Load += MisReportesView_Load;
            this.cmbFiltroTiempo.SelectedIndexChanged += (s, e) => CargarDatos();
        }

        private void MisReportesView_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void ConfigurarSeries()
        {

            // SERIE 1: pH
            var seriePH = chartMetricas.Series[0];
            seriePH.Name = "pH (Acidez)";
            seriePH.ChartType = SeriesChartType.Spline;
            seriePH.BorderWidth = 3;
            seriePH.Color = System.Drawing.Color.FromArgb(255, 87, 34);
            seriePH.MarkerStyle = MarkerStyle.Circle;

            // SERIE 2: Electroconductividad
            var serieEC = chartMetricas.Series[1];
            serieEC.Name = "EC (Nutrientes)";
            serieEC.ChartType = SeriesChartType.Spline;
            serieEC.BorderWidth = 3;
            serieEC.Color = System.Drawing.Color.FromArgb(33, 150, 243); 
            serieEC.MarkerStyle = MarkerStyle.Square;

            // TRUCO PRO: Usar un eje Y secundario para EC porque es una escala más chica (0-3) vs pH (0-14)
            serieEC.YAxisType = AxisType.Secondary;
            chartMetricas.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chartMetricas.ChartAreas[0].AxisY2.MajorGrid.Enabled = false; 
            chartMetricas.ChartAreas[0].AxisY2.Title = "Escala EC";
            chartMetricas.ChartAreas[0].AxisY.Title = "Escala pH";
        }

        private void CargarDatos()
        {
            chartMetricas.Series[0].Points.Clear();
            chartMetricas.Series[1].Points.Clear();

            Random rnd = new Random();
            DateTime fechaBase = DateTime.Now.AddDays(-30);

            for (int i = 0; i < 30; i++)
            {
                DateTime fecha = fechaBase.AddDays(i);

                double ph = 5.5 + (rnd.NextDouble() * 1.5); // pH entre 5.5 y 7.0
                double ec = 0.8 + (rnd.NextDouble() * 1.2); // EC entre 0.8 y 2.0

                chartMetricas.Series["pH (Acidez)"].Points.AddXY(fecha, ph);
                chartMetricas.Series["EC (Nutrientes)"].Points.AddXY(fecha, ec);
            }
        }
    }
}