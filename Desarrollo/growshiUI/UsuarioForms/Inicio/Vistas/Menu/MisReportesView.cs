using System;
using System.Collections.Generic;
using System.Drawing; // Para UI (Fuentes, Colores)
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using iTextSharp.text; // Para PDF
using iTextSharp.text.pdf;
using BLL;
using BE;
using Services;
using MetroFramework.Controls;
using BE.DataMining;

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class MisReportesView : UserControl
    {
        private IdiomaBLL _idiomaBLL;
        private MedicionBLL _medicionBLL;
        private PlantaBLL _plantaBLL;

        

        public MisReportesView()
        {
            InitializeComponent();

            // Evitar errores en tiempo de diseño
            if (this.DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                return;
            }

            // Dibujar línea gris en el header
            this.panelHeader.Paint += (s, e) => {
                using (Pen p = new Pen(Color.LightGray))
                {
                    e.Graphics.DrawLine(p, 0, panelHeader.Height - 1, panelHeader.Width, panelHeader.Height - 1);
                }
            };

            // Inicializar BLL (Solo en ejecución)
            _idiomaBLL = new IdiomaBLL();
            _medicionBLL = new MedicionBLL();
            _plantaBLL = new PlantaBLL();

            ConfigurarGraficos();
            CargarComboFiltros();
            CrearTarjetasEnPanel();

            // Suscripción de eventos
            this.Load += MisReportesView_Load;

            // IMPORTANTE: Usamos el nombre correcto del evento aquí
            this.btnExportarPdf.Click += BtnExportarPdf_Click;

            this.cmbFiltroTiempo.SelectedIndexChanged += (s, e) => CargarDatos();
            this.cmbPlantas.SelectedIndexChanged += (s, e) => CargarDatos();
            IdiomaService.GetInstance().IdiomaCambiado += TraducirInterfaz;
        }

        private void MisReportesView_Load(object sender, EventArgs e)
        {
            TraducirInterfaz();
            CargarComboPlantas();
        }

        #region Creación de UI (Tarjetas)

        private void CrearTarjetasEnPanel()
        {
            this.tblResumen.Controls.Clear();

            // Tarjetas más compactas y alineadas
            System.Windows.Forms.Panel card1 = CrearCard("Alertas Temp.", Color.FromArgb(231, 76, 60), out lblTotalAlertasTemp);
            System.Windows.Forms.Panel card2 = CrearCard("Alertas Hum.", Color.FromArgb(52, 152, 219), out lblTotalAlertasHum);
            System.Windows.Forms.Panel card3 = CrearCard("Alertas Luz", Color.FromArgb(241, 196, 15), out lblTotalAlertasLuz);

            // Agregar a la tabla (Columna, Fila)
            this.tblResumen.Controls.Add(card1, 0, 0);
            this.tblResumen.Controls.Add(card2, 1, 0);
            this.tblResumen.Controls.Add(card3, 2, 0);
        }

        private System.Windows.Forms.Panel CrearCard(string titulo, Color color, out Label lblVal)
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
            p.BackColor = Color.White;
            p.BorderStyle = BorderStyle.None;
            p.Margin = new Padding(10, 0, 10, 0); // Margen lateral para efecto "flotante"
            p.Dock = DockStyle.Fill;

            // Barra lateral de color
            System.Windows.Forms.Panel bar = new System.Windows.Forms.Panel();
            bar.Dock = DockStyle.Left;
            bar.Width = 6;
            bar.BackColor = color;
            p.Controls.Add(bar);

            // Título (Arriba)
            MetroLabel lblT = new MetroLabel();
            lblT.Text = titulo.ToUpper();
            lblT.FontSize = MetroFramework.MetroLabelSize.Small;
            lblT.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            lblT.ForeColor = Color.Gray;
            lblT.UseCustomBackColor = true;
            lblT.UseCustomForeColor = true;
            lblT.Dock = DockStyle.Top;
            lblT.Padding = new Padding(10, 10, 0, 0);
            lblT.Height = 30;
            p.Controls.Add(lblT);

            // Valor (Centro)
            lblVal = new Label();
            lblVal.Text = "0";
            lblVal.Font = new System.Drawing.Font("Segoe UI", 26F, FontStyle.Bold);
            lblVal.ForeColor = Color.FromArgb(64, 64, 64);
            lblVal.AutoSize = false;
            lblVal.Dock = DockStyle.Fill;
            lblVal.TextAlign = ContentAlignment.MiddleCenter;

            p.Controls.Add(lblVal);
            lblVal.BringToFront();

            return p;
        }

        #endregion

        #region Configuración y Carga de Datos

        private void TraducirInterfaz()
        {
            lblTitulo.Text = _idiomaBLL.Traducir("lbl_titulo_reporte") ?? "Reporte de Cultivo";
            btnExportarPdf.Text = _idiomaBLL.Traducir("btn_exportar_pdf");
            lblPlanta.Text = _idiomaBLL.Traducir("lbl_seleccionar_planta");
            CargarComboFiltros();
        }

        private void ConfigurarGraficos()
        {
            ConfigurarEstiloChart(chartTemperatura, "Temperatura", Color.FromArgb(231, 76, 60), "Temperatura (°C)");
            ConfigurarEstiloChart(chartHumedad, "Humedad", Color.FromArgb(0, 174, 219), "Humedad (%)");
        }

        private void ConfigurarEstiloChart(Chart chart, string nombreSerie, Color color, string tituloY)
        {
            chart.Series.Clear();
            var s = chart.Series.Add(nombreSerie);
            s.ChartType = SeriesChartType.Point;
            s.BorderWidth = 2;
            s.Color = Color.FromArgb(150, color);
            s.MarkerStyle = MarkerStyle.Circle;
            s.MarkerSize = 6;

            var area = chart.ChartAreas[0];
            area.AxisY.Title = tituloY;
            area.AxisY.LineColor = Color.Silver;
            area.AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            area.AxisX.LineColor = Color.Silver;
            area.AxisX.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            area.AxisX.LabelStyle.Format = "HH:mm";
        }

        private void CargarComboFiltros()
        {
            int savedIdx = cmbFiltroTiempo.SelectedIndex;
            cmbFiltroTiempo.Items.Clear();
            cmbFiltroTiempo.Items.Add(new ItemFiltro { Clave = "semana", Texto = "Última Semana" });
            cmbFiltroTiempo.Items.Add(new ItemFiltro { Clave = "mes", Texto = "Último Mes" });
            cmbFiltroTiempo.Items.Add(new ItemFiltro { Clave = "todo", Texto = "Todo el Historial" });
            cmbFiltroTiempo.SelectedIndex = (savedIdx >= 0) ? savedIdx : 0;
        }

        private void CargarComboPlantas()
        {
            try
            {
                cmbPlantas.Items.Clear();
                cmbPlantas.DisplayMember = "Nombre";
                cmbPlantas.ValueMember = "PlantaID";
                var plantas = _plantaBLL.Listar();
                foreach (var p in plantas) cmbPlantas.Items.Add(p);
                if (cmbPlantas.Items.Count > 0) cmbPlantas.SelectedIndex = 0;
            }
            catch { }
        }

        private void CargarDatos()
        {
            if (cmbPlantas.SelectedItem == null || cmbFiltroTiempo.SelectedItem == null) return;

            if (chartTemperatura.Series.Count > 0) chartTemperatura.Series[0].Points.Clear();
            if (chartHumedad.Series.Count > 0) chartHumedad.Series[0].Points.Clear();

            var serieFunc = chartTemperatura.Series.FindByName("FuncionMatematica");
            if (serieFunc != null) chartTemperatura.Series.Remove(serieFunc);

            lblAnalisisInfo.Text = "Esperando análisis...";
            dgvMediciones.DataSource = null;

            var planta = (Planta)cmbPlantas.SelectedItem;
            var filtro = (ItemFiltro)cmbFiltroTiempo.SelectedItem;

            try
            {
                List<Medicion> datos = _medicionBLL.ObtenerHistorial(planta.PlantaID, filtro.Clave);

                if (datos != null && datos.Count > 0)
                {
                    foreach (var m in datos)
                    {
                        if (chartTemperatura.Series.Count > 0) chartTemperatura.Series[0].Points.AddXY(m.FechaRegistro, m.Temperatura);
                        if (chartHumedad.Series.Count > 0) chartHumedad.Series[0].Points.AddXY(m.FechaRegistro, m.Humedad);
                    }

                    if (datos.Count >= 3)
                    {
                        RealizarAnalisisIngenieria(datos);
                    }
                    else
                    {
                        lblAnalisisInfo.Text = "Datos insuficientes para análisis matemático (mínimo 3).";
                    }

                    lblTotalAlertasTemp.Text = datos.Count(x => x.AlertaTemperatura).ToString();
                    lblTotalAlertasTemp.ForeColor = datos.Any(x => x.AlertaTemperatura) ? Color.Red : Color.Gray;

                    lblTotalAlertasHum.Text = datos.Count(x => x.AlertaHumedad).ToString();
                    lblTotalAlertasHum.ForeColor = datos.Any(x => x.AlertaHumedad) ? Color.DodgerBlue : Color.Gray;

                    lblTotalAlertasLuz.Text = datos.Count(x => x.AlertaLuz).ToString();
                    lblTotalAlertasLuz.ForeColor = datos.Any(x => x.AlertaLuz) ? Color.Orange : Color.Gray;

                    dgvMediciones.DataSource = datos;
                    ConfigurarColumnasGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar datos: " + ex.Message);
            }
        }

        private void ConfigurarColumnasGrid()
        {
            if (dgvMediciones.DataSource == null) return;
            string[] ocultas = { "MedicionID", "PlantaID", "AlertaTemperatura", "AlertaHumedad", "AlertaLuz" };
            foreach (var c in ocultas) if (dgvMediciones.Columns[c] != null) dgvMediciones.Columns[c].Visible = false;

            if (dgvMediciones.Columns["FechaRegistro"] != null)
            {
                dgvMediciones.Columns["FechaRegistro"].HeaderText = "Fecha";
                dgvMediciones.Columns["FechaRegistro"].DefaultCellStyle.Format = "dd/MM HH:mm";
                dgvMediciones.Columns["FechaRegistro"].Width = 120;
            }
        }

        #endregion

        #region Módulo de Ingeniería Matemática 🧠📐

        private class PolinomioCuadratico
        {
            public double A { get; set; }
            public double B { get; set; }
            public double C { get; set; }
            public double Evaluar(double x) => (A * x * x) + (B * x) + C;
            public override string ToString() => $"f(t) = {(A >= 0 ? "+" : "")}{A:F4}t² {(B >= 0 ? "+" : "")}{B:F2}t {(C >= 0 ? "+" : "")}{C:F2}";
        }

        private void RealizarAnalisisIngenieria(List<Medicion> datos)
        {
            try
            {
                long ticksInicial = datos.Min(x => x.FechaRegistro).Ticks;
                var puntosAnalisis = datos.Select(m => new { X = (double)(m.FechaRegistro.Ticks - ticksInicial) / TimeSpan.TicksPerHour, Y = (double)m.Temperatura }).OrderBy(p => p.X).ToList();
                double domMin = puntosAnalisis.First().X;
                double domMax = puntosAnalisis.Last().X;
                double imgMin = puntosAnalisis.Min(p => p.Y);
                double imgMax = puntosAnalisis.Max(p => p.Y);

                var xs = puntosAnalisis.Select(p => p.X).ToList();
                var ys = puntosAnalisis.Select(p => p.Y).ToList();
                PolinomioCuadratico funcion = CalcularRegresionCuadratica(xs, ys);

                Series serieFuncion = new Series("FuncionMatematica") { ChartType = SeriesChartType.Spline, Color = Color.Red, BorderWidth = 2, BorderDashStyle = ChartDashStyle.Dash };
                double paso = (domMax - domMin) / 50.0;
                if (paso <= 0) paso = 0.1;

                for (double t = domMin; t <= domMax; t += paso)
                {
                    serieFuncion.Points.AddXY(new DateTime(ticksInicial + (long)(t * TimeSpan.TicksPerHour)), funcion.Evaluar(t));
                }
                chartTemperatura.Series.Add(serieFuncion);

                int picos = 0, valles = 0;
                for (int i = 1; i < puntosAnalisis.Count - 1; i++)
                {
                    if (puntosAnalisis[i].Y > puntosAnalisis[i - 1].Y && puntosAnalisis[i].Y > puntosAnalisis[i + 1].Y)
                    {
                        picos++;
                        chartTemperatura.Series[0].Points[i].MarkerStyle = MarkerStyle.Triangle;
                        chartTemperatura.Series[0].Points[i].MarkerColor = Color.Gold;
                    }
                    else if (puntosAnalisis[i].Y < puntosAnalisis[i - 1].Y && puntosAnalisis[i].Y < puntosAnalisis[i + 1].Y)
                    {
                        valles++;
                        chartTemperatura.Series[0].Points[i].MarkerStyle = MarkerStyle.Triangle;
                        chartTemperatura.Series[0].Points[i].MarkerColor = Color.Purple;
                    }
                }
                lblAnalisisInfo.Text = $"ANÁLISIS MATEMÁTICO:\n• Función: {funcion}\n• Dominio: [0h ; {domMax:F1}h] | Imagen: [{imgMin}°C ; {imgMax}°C]\n• Puntos Críticos: {picos} Máx, {valles} Mín | Tipo: {(funcion.A < 0 ? "Cóncava" : "Convexa")}";
            }
            catch { lblAnalisisInfo.Text = "Error matemático."; }
        }

        private PolinomioCuadratico CalcularRegresionCuadratica(List<double> x, List<double> y)
        {
            int n = x.Count; double sx = 0, sx2 = 0, sx3 = 0, sx4 = 0, sy = 0, sxy = 0, sx2y = 0;
            for (int i = 0; i < n; i++) { double xi = x[i], yi = y[i], xi2 = xi * xi; sx += xi; sx2 += xi2; sx3 += xi2 * xi; sx4 += xi2 * xi2; sy += yi; sxy += xi * yi; sx2y += xi2 * yi; }
            double[,] M = { { n, sx, sx2, sy }, { sx, sx2, sx3, sxy }, { sx2, sx3, sx4, sx2y } };
            ResolverGauss(M);
            return new PolinomioCuadratico { C = M[0, 3], B = M[1, 3], A = M[2, 3] };
        }

        private void ResolverGauss(double[,] M)
        {
            int n = 3;
            for (int i = 0; i < n; i++)
            {
                double pivot = M[i, i];
                if (Math.Abs(pivot) < 1e-9) continue;
                for (int j = i; j <= n; j++) M[i, j] /= pivot;
                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        double factor = M[k, i];
                        for (int j = i; j <= n; j++) M[k, j] -= factor * M[i, j];
                    }
                }
            }
        }

        #endregion

        #region Exportación PDF

        // Este es el método correcto conectado en el Constructor
        private void BtnExportarPdf_Click(object sender, EventArgs e)
        {
            if (chartTemperatura.Series.Count == 0 || chartTemperatura.Series[0].Points.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
            string nombre = cmbPlantas.Text.Replace(" ", "_");
            sfd.FileName = $"Reporte_Ingenieria_{nombre}_{DateTime.Now:yyyyMMdd}.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    GenerarReportePDF(sfd.FileName);
                    this.Cursor = Cursors.Default;

                    DialogResult res = MessageBox.Show("Reporte generado correctamente.\n¿Desea abrirlo?", "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes) AbrirReporte(sfd.FileName);
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Error al exportar: " + ex.Message);
                }
            }
        }

        private void AbrirReporte(string ruta)
        {
            try { Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true }); }
            catch { }
        }

        private void GenerarReportePDF(string rutaArchivo)
        {
            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
            doc.Open();

            var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
            var fontMono = FontFactory.GetFont(FontFactory.COURIER, 9, BaseColor.DARK_GRAY);

            doc.Add(new Paragraph("Reporte de Ingeniería - Growshi", fontTitulo));
            doc.Add(new Paragraph($"Planta: {cmbPlantas.Text} | Fecha: {DateTime.Now}", FontFactory.GetFont(FontFactory.HELVETICA, 10)));
            doc.Add(new Chunk("\n"));

            PdfPTable tableAnalisis = new PdfPTable(1);
            tableAnalisis.WidthPercentage = 100;
            PdfPCell cellAnalisis = new PdfPCell(new Phrase(lblAnalisisInfo.Text, fontMono));
            cellAnalisis.BackgroundColor = new BaseColor(240, 240, 240);
            cellAnalisis.Padding = 10;
            cellAnalisis.Border = iTextSharp.text.Rectangle.NO_BORDER;
            tableAnalisis.AddCell(cellAnalisis);
            doc.Add(tableAnalisis);

            doc.Add(new Chunk("\n"));

            AgregarGraficoAlPdf(doc, chartTemperatura, "Temperatura & Análisis de Función");
            doc.Add(new Chunk("\n"));
            AgregarGraficoAlPdf(doc, chartHumedad, "Humedad Relativa");

            doc.Add(new Chunk("\n"));
            AgregarTablaAlPdf(doc);

            doc.Close();
        }

        private void AgregarGraficoAlPdf(Document doc, Chart chart, string titulo)
        {
            doc.Add(new Paragraph(titulo, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)));
            using (MemoryStream ms = new MemoryStream())
            {
                chart.SaveImage(ms, ChartImageFormat.Png);
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(ms.GetBuffer());
                if (img.Width > 500) img.ScaleToFit(500, 200);
                else img.ScalePercent(75f);
                img.Alignment = Element.ALIGN_CENTER;
                doc.Add(img);
            }
        }

        private void AgregarTablaAlPdf(Document doc)
        {
            if (dgvMediciones.Columns.Count == 0) return;
            int visibleCols = 0;
            foreach (DataGridViewColumn c in dgvMediciones.Columns) if (c.Visible) visibleCols++;
            if (visibleCols == 0) return;

            PdfPTable t = new PdfPTable(visibleCols);
            t.WidthPercentage = 100;

            var fontHead = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, BaseColor.WHITE);
            var fontCell = FontFactory.GetFont(FontFactory.HELVETICA, 8, BaseColor.BLACK);

            foreach (DataGridViewColumn c in dgvMediciones.Columns)
            {
                if (c.Visible)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(c.HeaderText, fontHead));
                    cell.BackgroundColor = new BaseColor(0, 174, 219);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    t.AddCell(cell);
                }
            }

            foreach (DataGridViewRow r in dgvMediciones.Rows)
            {
                foreach (DataGridViewCell c in r.Cells)
                {
                    if (dgvMediciones.Columns[c.ColumnIndex].Visible)
                    {
                        string val = c.FormattedValue?.ToString() ?? "";
                        PdfPCell cell = new PdfPCell(new Phrase(val, fontCell));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        t.AddCell(cell);
                    }
                }
            }
            doc.Add(t);
        }

        #endregion
    }
}