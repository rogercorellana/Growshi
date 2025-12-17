using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BE;
using BLL;
using Interfaces.IBE;
using Interfaces.IServices;
using Services;

namespace growshiUI.UsuarioForms.Inicio
{
    public partial class InicioView : UserControl
    {
        #region Campos y Servicios

        private readonly AdvancedAnalyticsBLL _analyticsBLL;
        private readonly ISessionService<Usuario> _sessionService;
        private readonly IdiomaBLL _idiomaBLL;
        private readonly BitacoraBLL _bitacoraBLL;
        private readonly IBitacoraService _bitacoraService;
        private readonly Usuario _usuarioActual;

        #endregion

        #region Constructor e Inicialización

        public InicioView()
        {
            InitializeComponent();

            // 1. Inicializar Servicios
            _analyticsBLL = new AdvancedAnalyticsBLL();
            _sessionService = SessionService<Usuario>.GetInstance();
            _idiomaBLL = new IdiomaBLL();
            _bitacoraBLL = new BitacoraBLL();
            _bitacoraService = BitacoraService.GetInstance();
            _usuarioActual = _sessionService.UsuarioLogueado;

            // 2. Suscripción a eventos
            this.Load += InicioView_Load;
            IdiomaService.GetInstance().IdiomaCambiado += RecargarIdioma;
        }

        private void InicioView_Load(object sender, EventArgs e)
        {
        

            // Configurar y Cargar
            ConfigurarEstilosVisuales();
            CargarDatosAnalytics();
        }

        private void RecargarIdioma()
        {
            // Al cambiar idioma, recargamos estilos (textos) y datos
            ConfigurarEstilosVisuales();
            CargarDatosAnalytics();
        }

        // Importante: Desuscribirse al cerrar
        protected override void OnHandleDestroyed(EventArgs e)
        {
            IdiomaService.GetInstance().IdiomaCambiado -= RecargarIdioma;
            base.OnHandleDestroyed(e);
        }

        #endregion

        #region Configuración de Gráficos (Estilos y Textos Guía)

        private void ConfigurarEstilosVisuales()
        {
            // Textos traducidos
            lblInsightTitulo.Text = _idiomaBLL.Traducir("Inicio_Lbl_InsightTitulo") ?? "🧠 GROWSHI AI INSIGHT";

            // --- GRÁFICO 1: PRONÓSTICO ---
            chartPronostico.Series.Clear();
            EstilizarChart(chartPronostico,
                _idiomaBLL.Traducir("Inicio_Chart_PronosticoTitulo"),
                _idiomaBLL.Traducir("Inicio_Chart_PronosticoGuia"),
                _idiomaBLL.Traducir("Inicio_Chart_EjeY_Temp"));

            // Serie Temp
            var sTemp = chartPronostico.Series.Add(_idiomaBLL.Traducir("Inicio_Serie_TempPredicha"));
            sTemp.ChartType = SeriesChartType.Spline;
            sTemp.BorderWidth = 3;
            sTemp.Color = Color.FromArgb(231, 76, 60);
            sTemp.ToolTip = _idiomaBLL.Traducir("Inicio_Tooltip_Temp");

            // Serie Humedad
            var sHum = chartPronostico.Series.Add(_idiomaBLL.Traducir("Inicio_Serie_HumPredicha"));
            sHum.ChartType = SeriesChartType.Spline;
            sHum.BorderWidth = 2;
            sHum.Color = Color.FromArgb(52, 152, 219);
            sHum.YAxisType = AxisType.Secondary;
            sHum.ToolTip = _idiomaBLL.Traducir("Inicio_Tooltip_Hum");


            // --- GRÁFICO 2: VPD (RIESGO) ---
            chartVPD.Series.Clear();
            EstilizarChart(chartVPD,
                _idiomaBLL.Traducir("Inicio_Chart_VPDTitulo"),
                _idiomaBLL.Traducir("Inicio_Chart_VPDGuia"),
                "VPD (kPa)");

            var areaVPD = chartVPD.ChartAreas[0];
            areaVPD.AxisY.StripLines.Clear(); // Limpiar antes de agregar por si se recarga
            areaVPD.AxisY.StripLines.Add(new StripLine { Interval = 0, StripWidth = 0.4, BackColor = Color.FromArgb(40, 255, 0, 0), ToolTip = _idiomaBLL.Traducir("Inicio_VPD_RiesgoHongo") });
            areaVPD.AxisY.StripLines.Add(new StripLine { IntervalOffset = 0.4, StripWidth = 0.8, BackColor = Color.FromArgb(40, 0, 255, 0), ToolTip = _idiomaBLL.Traducir("Inicio_VPD_Optimo") });
            areaVPD.AxisY.StripLines.Add(new StripLine { IntervalOffset = 1.2, StripWidth = 10.0, BackColor = Color.FromArgb(40, 255, 165, 0), ToolTip = _idiomaBLL.Traducir("Inicio_VPD_RiesgoSeco") });

            var sVPD = chartVPD.Series.Add(_idiomaBLL.Traducir("Inicio_Serie_VPDFuturo"));
            sVPD.ChartType = SeriesChartType.Area;
            sVPD.Color = Color.FromArgb(180, 155, 89, 182);
            sVPD.BorderColor = Color.Purple;
            sVPD.BorderWidth = 2;


            // --- GRÁFICO 3: LUZ (CONSISTENCIA) ---
            chartLuz.Series.Clear();
            EstilizarChart(chartLuz,
                _idiomaBLL.Traducir("Inicio_Chart_LuzTitulo"),
                _idiomaBLL.Traducir("Inicio_Chart_LuzGuia"),
                _idiomaBLL.Traducir("Inicio_Chart_EjeY_Intensidad"));

            chartLuz.ChartAreas[0].AxisY.Maximum = 110;

            var sLuz = chartLuz.Series.Add(_idiomaBLL.Traducir("Inicio_Serie_LuzRecibida"));
            sLuz.ChartType = SeriesChartType.Column;
            sLuz.Color = Color.Orange;

            var sMeta = chartLuz.Series.Add(_idiomaBLL.Traducir("Inicio_Serie_MetaIdeal"));
            sMeta.ChartType = SeriesChartType.Line;
            sMeta.BorderWidth = 2;
            sMeta.Color = Color.Gray;
            sMeta.BorderDashStyle = ChartDashStyle.Dash;
        }

        private void EstilizarChart(Chart c, string titulo, string guia, string ejeY)
        {
            c.BackColor = Color.White;
            c.ChartAreas[0].BackColor = Color.WhiteSmoke;

            c.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            c.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            c.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 8);
            c.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 8);

            c.ChartAreas[0].AxisY.Title = ejeY;
            c.ChartAreas[0].AxisY.TitleFont = new Font("Segoe UI", 9, FontStyle.Bold);
            c.ChartAreas[0].AxisY.TitleForeColor = Color.DimGray;

            c.Titles.Clear();

            var t1 = c.Titles.Add(titulo);
            t1.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            t1.ForeColor = Color.DarkSlateBlue;
            t1.Alignment = ContentAlignment.TopLeft;

            var t2 = c.Titles.Add(guia);
            t2.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            t2.ForeColor = Color.Gray;
            t2.Alignment = ContentAlignment.TopLeft;
            t2.Docking = Docking.Top;

            c.Legends[0].Docking = Docking.Top;
            c.Legends[0].Alignment = StringAlignment.Far;
            c.Legends[0].Font = new Font("Segoe UI", 8);
            c.Legends[0].BackColor = Color.Transparent;
        }

        #endregion

        #region Carga de Datos (Analytics)

        private void CargarDatosAnalytics()
        {
            try
            {
                // 1. Obtener y mostrar el texto de IA
                lblInsightTexto.Text = _analyticsBLL.GenerarResumenEjecutivo();

                // 2. Llenar Pronóstico
                var pronostico = _analyticsBLL.ObtenerPronosticoExtendido();
                string serieTemp = _idiomaBLL.Traducir("Inicio_Serie_TempPredicha"); // Nombres traducidos
                string serieHum = _idiomaBLL.Traducir("Inicio_Serie_HumPredicha");

                foreach (var p in pronostico)
                {
                    if (p.FechaHora.Hour % 3 == 0)
                    {
                        string label = p.FechaHora.ToString("dd/HH") + "hs";
                        chartPronostico.Series[serieTemp].Points.AddXY(label, p.TempPredicha);
                        chartPronostico.Series[serieHum].Points.AddXY(label, p.HumedadPredicha);

                        if (p.EsAnomalia)
                        {
                            var pt = chartPronostico.Series[serieTemp].Points.Last();
                            pt.MarkerStyle = MarkerStyle.Circle;
                            pt.MarkerColor = Color.Red;
                            pt.MarkerSize = 10;
                            pt.Label = _idiomaBLL.Traducir("Inicio_Chart_Alerta");
                            pt.LabelForeColor = Color.Red;
                        }
                    }
                }

                // 3. Llenar VPD
                var vpdData = _analyticsBLL.ObtenerRiesgoVPD();
                string serieVPD = _idiomaBLL.Traducir("Inicio_Serie_VPDFuturo");
                foreach (var v in vpdData)
                {
                    chartVPD.Series[serieVPD].Points.AddXY(v.Hora, v.ValorVPD);
                }

                // 4. Llenar Luz
                var luzData = _analyticsBLL.ObtenerAnalisisIluminacion();
                string serieLuz = _idiomaBLL.Traducir("Inicio_Serie_LuzRecibida");
                string serieMeta = _idiomaBLL.Traducir("Inicio_Serie_MetaIdeal");

                foreach (var d in luzData)
                {
                    int idx = chartLuz.Series[serieLuz].Points.AddXY(d.Dia, d.PromedioLuz);
                    chartLuz.Series[serieMeta].Points.AddXY(d.Dia, d.MetaLuz);

                    if (d.PromedioLuz < 50)
                    {
                        chartLuz.Series[serieLuz].Points[idx].Color = Color.IndianRed;
                        chartLuz.Series[serieLuz].Points[idx].Label = _idiomaBLL.Traducir("Inicio_Chart_Bajo");
                        chartLuz.Series[serieLuz].Points[idx].LabelForeColor = Color.DarkRed;
                    }
                }
            }
            catch (Exception ex)
            {
                lblInsightTexto.Text = string.Format(_idiomaBLL.Traducir("Inicio_Msg_ErrorCarga"), ex.Message);
                lblInsightTexto.ForeColor = Color.Red;
            }
        }

        

        #endregion
    }
}