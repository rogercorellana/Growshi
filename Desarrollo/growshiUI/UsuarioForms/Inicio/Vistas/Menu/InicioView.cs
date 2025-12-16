using BE;
using BLL; // Asumiremos que BLL tiene los métodos preparados
using Interfaces.IServices;
using Services;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace growshiUI.UsuarioForms.Inicio
{
    public partial class InicioView : UserControl
    {
        #region Campos y Servicios
        // Instancia del cerebro de predicción
        private readonly AdvancedAnalyticsBLL _analyticsBLL;
        private readonly ISessionService<Usuario> _sessionService;
        #endregion

        #region Constructor
        public InicioView()
        {
            InitializeComponent();

            // Inicializar Servicios
            _analyticsBLL = new AdvancedAnalyticsBLL();
            _sessionService = SessionService<Usuario>.GetInstance();

            // 1. Configurar aspecto visual (colores, textos guía)
            ConfigurarEstilosVisuales();

            // 2. Cargar datos desde el DW
            CargarDatosAnalytics();
        }
        #endregion

        #region Configuración de Gráficos (Estilos y Textos Guía)
        private void ConfigurarEstilosVisuales()
        {
            // --- GRÁFICO 1: PRONÓSTICO ---
            chartPronostico.Series.Clear();
            EstilizarChart(chartPronostico,
                "Pronóstico Climático (72 Horas)",
                "GUÍA: Predicción basada en patrones reales de tu cultivo.\nLínea ROJA: Temp Proyectada | Línea AZUL: Humedad Proyectada.\nBusca círculos rojos, indican riesgo de estrés.",
                "Temperatura (°C)");

            // Serie Temp
            var sTemp = chartPronostico.Series.Add("Temp Predicha");
            sTemp.ChartType = SeriesChartType.Spline; // Línea curva suave
            sTemp.BorderWidth = 3;
            sTemp.Color = Color.FromArgb(231, 76, 60); // Rojo suave
            sTemp.ToolTip = "Hora: #VALX\nTemp: #VALY °C";

            // Serie Humedad (Eje Secundario)
            var sHum = chartPronostico.Series.Add("Hum Predicha");
            sHum.ChartType = SeriesChartType.Spline;
            sHum.BorderWidth = 2;
            sHum.Color = Color.FromArgb(52, 152, 219); // Azul
            sHum.YAxisType = AxisType.Secondary;
            sHum.ToolTip = "Hora: #VALX\nHumedad: #VALY %";


            // --- GRÁFICO 2: VPD (RIESGO) ---
            chartVPD.Series.Clear();
            EstilizarChart(chartVPD,
                "Riesgo de Estrés (VPD)",
                "GUÍA: El VPD indica si la planta puede 'transpirar'.\nZonas: Verde = Crecimiento Óptimo. Rojo = Peligro (Hongo o Deshidratación).",
                "VPD (kPa)");

            // Zonas de color en el fondo (Semáforo)
            var areaVPD = chartVPD.ChartAreas[0];
            areaVPD.AxisY.StripLines.Add(new StripLine { Interval = 0, StripWidth = 0.4, BackColor = Color.FromArgb(40, 255, 0, 0), ToolTip = "Riesgo Hongo (Muy Húmedo)" });
            areaVPD.AxisY.StripLines.Add(new StripLine { IntervalOffset = 0.4, StripWidth = 0.8, BackColor = Color.FromArgb(40, 0, 255, 0), ToolTip = "Zona Óptima" });
            areaVPD.AxisY.StripLines.Add(new StripLine { IntervalOffset = 1.2, StripWidth = 10.0, BackColor = Color.FromArgb(40, 255, 165, 0), ToolTip = "Zona Estrés (Muy Seco)" });

            var sVPD = chartVPD.Series.Add("VPD Futuro");
            sVPD.ChartType = SeriesChartType.Area;
            sVPD.Color = Color.FromArgb(180, 155, 89, 182); // Violeta transparente
            sVPD.BorderColor = Color.Purple;
            sVPD.BorderWidth = 2;


            // --- GRÁFICO 3: LUZ (CONSISTENCIA) ---
            chartLuz.Series.Clear();
            EstilizarChart(chartLuz,
                "Consistencia de Iluminación (Histórico)",
                "GUÍA: Promedio de luz real recibida en los últimos días.\nLas barras deben acercarse a la línea punteada (Meta).",
                "Intensidad Promedio (%)");

            chartLuz.ChartAreas[0].AxisY.Maximum = 110; // Espacio extra arriba

            var sLuz = chartLuz.Series.Add("Luz Recibida");
            sLuz.ChartType = SeriesChartType.Column;
            sLuz.Color = Color.Orange;

            var sMeta = chartLuz.Series.Add("Meta Ideal");
            sMeta.ChartType = SeriesChartType.Line;
            sMeta.BorderWidth = 2;
            sMeta.Color = Color.Gray;
            sMeta.BorderDashStyle = ChartDashStyle.Dash;
        }

        // Método mágico para que todos los gráficos se vean iguales y profesionales
        private void EstilizarChart(Chart c, string titulo, string guia, string ejeY)
        {
            c.BackColor = Color.White;
            c.ChartAreas[0].BackColor = Color.WhiteSmoke;

            // Rejillas sutiles
            c.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            c.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            c.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
            c.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 8);

            // Título del Eje Y
            c.ChartAreas[0].AxisY.Title = ejeY;
            c.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 9, FontStyle.Bold);
            c.ChartAreas[0].AxisY.TitleForeColor = Color.DimGray;

            c.Titles.Clear();

            // Título Principal
            var t1 = c.Titles.Add(titulo);
            t1.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            t1.ForeColor = Color.DarkSlateBlue;
            t1.Alignment = ContentAlignment.TopLeft;

            // Subtítulo / Guía (Lo que pediste)
            var t2 = c.Titles.Add(guia);
            t2.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            t2.ForeColor = Color.Gray;
            t2.Alignment = ContentAlignment.TopLeft;
            t2.Docking = Docking.Top;

            // Leyenda a la derecha arriba
            c.Legends[0].Docking = Docking.Top;
            c.Legends[0].Alignment = StringAlignment.Far;
            c.Legends[0].Font = new Font("Segoe UI", 8);
            c.Legends[0].BackColor = Color.Transparent;
        }
        #endregion

        #region Carga de Datos (Conexión BLL)
        private void CargarDatosAnalytics()
        {
            try
            {
                // 1. Obtener y mostrar el texto de IA
                lblInsightTexto.Text = _analyticsBLL.GenerarResumenEjecutivo();

                // 2. Llenar Pronóstico
                var pronostico = _analyticsBLL.ObtenerPronosticoExtendido();
                foreach (var p in pronostico)
                {
                    // Mostramos cada 3 horas para no saturar el eje X
                    if (p.FechaHora.Hour % 3 == 0)
                    {
                        string label = p.FechaHora.ToString("dd/HH") + "hs";
                        chartPronostico.Series["Temp Predicha"].Points.AddXY(label, p.TempPredicha);
                        chartPronostico.Series["Hum Predicha"].Points.AddXY(label, p.HumedadPredicha);

                        // Si hay anomalía, marcamos el punto
                        if (p.EsAnomalia)
                        {
                            var pt = chartPronostico.Series["Temp Predicha"].Points.Last();
                            pt.MarkerStyle = MarkerStyle.Circle;
                            pt.MarkerColor = Color.Red;
                            pt.MarkerSize = 10;
                            pt.Label = "¡ALERTA!";
                            pt.LabelForeColor = Color.Red;
                        }
                    }
                }

                // 3. Llenar VPD
                var vpdData = _analyticsBLL.ObtenerRiesgoVPD();
                foreach (var v in vpdData)
                {
                    chartVPD.Series["VPD Futuro"].Points.AddXY(v.Hora, v.ValorVPD);
                }

                // 4. Llenar Luz
                var luzData = _analyticsBLL.ObtenerAnalisisIluminacion();
                foreach (var d in luzData)
                {
                    int idx = chartLuz.Series["Luz Recibida"].Points.AddXY(d.Dia, d.PromedioLuz);
                    chartLuz.Series["Meta Ideal"].Points.AddXY(d.Dia, d.MetaLuz);

                    // Si la luz fue baja, pintar barra roja
                    if (d.PromedioLuz < 50)
                    {
                        chartLuz.Series["Luz Recibida"].Points[idx].Color = Color.IndianRed;
                        chartLuz.Series["Luz Recibida"].Points[idx].Label = "BAJO";
                        chartLuz.Series["Luz Recibida"].Points[idx].LabelForeColor = Color.DarkRed;
                    }
                }
            }
            catch (Exception ex)
            {
                lblInsightTexto.Text = "Error cargando Dashboard: " + ex.Message;
                lblInsightTexto.ForeColor = Color.Red;
            }
        }
        #endregion
    }
}