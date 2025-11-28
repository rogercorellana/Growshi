using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using BLL; 
using Services; 

namespace growshiUI.UsuarioForms.Inicio.Vistas.Menu
{
    public partial class MisReportesView : UserControl
    {
        private Button btnExportarPdf;

        private IdiomaBLL _idiomaBLL = new IdiomaBLL();

        private class ItemFiltro
        {
            public string Clave { get; set; } 
            public string Texto { get; set; } 
            public override string ToString() => Texto;
        }

        public MisReportesView()
        {
            InitializeComponent();
            ConfigurarBotonExportar();

            CargarComboFiltros();
            TraducirInterfaz();
            ConfigurarSeries(); 

            this.Load += MisReportesView_Load;
            this.cmbFiltroTiempo.SelectedIndexChanged += (s, e) => CargarDatos();

            IdiomaService.GetInstance().IdiomaCambiado += () => {
                TraducirInterfaz();
                CargarComboFiltros(); 
                ConfigurarSeries(); 
                CargarDatos(); 
            };
        }

        private void MisReportesView_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void TraducirInterfaz()
        {
            lblTitulo.Text = _idiomaBLL.Traducir("lbl_titulo_reportes");
            if (btnExportarPdf != null) btnExportarPdf.Text = _idiomaBLL.Traducir("btn_exportar_pdf");
        }

        private void CargarComboFiltros()
        {
            int indexSeleccionado = cmbFiltroTiempo.SelectedIndex;

            cmbFiltroTiempo.Items.Clear();

            cmbFiltroTiempo.Items.Add(new ItemFiltro { Clave = "filtro_ultima_semana", Texto = _idiomaBLL.Traducir("filtro_ultima_semana") });
            cmbFiltroTiempo.Items.Add(new ItemFiltro { Clave = "filtro_ultimo_mes", Texto = _idiomaBLL.Traducir("filtro_ultimo_mes") });
            cmbFiltroTiempo.Items.Add(new ItemFiltro { Clave = "filtro_todo_historial", Texto = _idiomaBLL.Traducir("filtro_todo_historial") });

            if (indexSeleccionado >= 0 && indexSeleccionado < cmbFiltroTiempo.Items.Count)
                cmbFiltroTiempo.SelectedIndex = indexSeleccionado;
            else
                cmbFiltroTiempo.SelectedIndex = 0; 
        }

        private void ConfigurarBotonExportar()
        {
            btnExportarPdf = new Button();
            btnExportarPdf.Size = new Size(120, 30);
            btnExportarPdf.BackColor = Color.FromArgb(0, 174, 219);
            btnExportarPdf.ForeColor = Color.White;
            btnExportarPdf.FlatStyle = FlatStyle.Flat;
            btnExportarPdf.Cursor = Cursors.Hand;

            btnExportarPdf.Dock = DockStyle.Right;

            btnExportarPdf.Click += BtnExportarPdf_Click;

            this.panelFiltros.Controls.Add(btnExportarPdf);
            this.panelFiltros.Controls.SetChildIndex(btnExportarPdf, 0);
        }

        private void ConfigurarSeries()
        {
            if (chartMetricas.Series.Count < 2) return;

            // SERIE 1: pH
            var seriePH = chartMetricas.Series[0];
            seriePH.Name = _idiomaBLL.Traducir("serie_ph"); 
            seriePH.ChartType = SeriesChartType.Spline;
            seriePH.BorderWidth = 3;
            seriePH.Color = System.Drawing.Color.FromArgb(255, 87, 34);
            seriePH.MarkerStyle = MarkerStyle.Circle;

            // SERIE 2: Electroconductividad
            var serieEC = chartMetricas.Series[1];
            serieEC.Name = _idiomaBLL.Traducir("serie_ec"); 
            serieEC.ChartType = SeriesChartType.Spline;
            serieEC.BorderWidth = 3;
            serieEC.Color = System.Drawing.Color.FromArgb(33, 150, 243);
            serieEC.MarkerStyle = MarkerStyle.Square;

            // Ejes Traducidos
            serieEC.YAxisType = AxisType.Secondary;
            chartMetricas.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chartMetricas.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chartMetricas.ChartAreas[0].AxisY2.Title = _idiomaBLL.Traducir("eje_escala_ec");
            chartMetricas.ChartAreas[0].AxisY.Title = _idiomaBLL.Traducir("eje_escala_ph");
        }

        private void CargarDatos()
        {
            chartMetricas.Series[0].Points.Clear();
            chartMetricas.Series[1].Points.Clear();

            Random rnd = new Random();
            DateTime fechaBase = DateTime.Now.AddDays(-30);

            string nombreSeriePH = chartMetricas.Series[0].Name;
            string nombreSerieEC = chartMetricas.Series[1].Name;

            for (int i = 0; i < 30; i++)
            {
                DateTime fecha = fechaBase.AddDays(i);

                double ph = 5.5 + (rnd.NextDouble() * 1.5);
                double ec = 0.8 + (rnd.NextDouble() * 1.2);

                chartMetricas.Series[nombreSeriePH].Points.AddXY(fecha, ph);
                chartMetricas.Series[nombreSerieEC].Points.AddXY(fecha, ec);
            }
        }

        private void BtnExportarPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo PDF|*.pdf";
            saveFileDialog.Title = _idiomaBLL.Traducir("titulo_guardar_reporte");
            saveFileDialog.FileName = $"Reporte_Nutrientes_{DateTime.Now:yyyyMMdd}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GenerarReportePDF(saveFileDialog.FileName);

                    string msgExito = _idiomaBLL.Traducir("msg_reporte_exito");
                    string tituloExito = _idiomaBLL.Traducir("titulo_exito");
                    MessageBox.Show(msgExito, tituloExito, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    string formatoError = _idiomaBLL.Traducir("msg_error_generar_reporte");
                    string tituloError = _idiomaBLL.Traducir("titulo_error");
                    MessageBox.Show(string.Format(formatoError, ex.Message), tituloError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GenerarReportePDF(string rutaArchivo)
        {
            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));

            doc.Open();

            iTextSharp.text.Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
            iTextSharp.text.Font fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
            iTextSharp.text.Font fuenteHeaderTabla = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);

            // 1. Título del Reporte Traducido
            string tituloReporte = _idiomaBLL.Traducir("pdf_titulo_reporte");
            doc.Add(new Paragraph(tituloReporte, fuenteTitulo));

            // 2. Fecha de Emisión Traducida
            string lblFecha = _idiomaBLL.Traducir("pdf_fecha_emision");
            doc.Add(new Paragraph($"{lblFecha} {DateTime.Now:dd/MM/yyyy HH:mm}", fuenteNormal));

            // 3. Filtro Aplicado Traducido
            string lblFiltro = _idiomaBLL.Traducir("pdf_filtro_aplicado");
            // Obtenemos el texto del combo (que ya es un objeto ItemFiltro traducido)
            string filtroActual = cmbFiltroTiempo.SelectedItem?.ToString() ?? "General";
            doc.Add(new Paragraph($"{lblFiltro} {filtroActual}", fuenteNormal));

            doc.Add(new Chunk("\n")); // Espacio

            // 4. Gráfico (Imagen)
            using (MemoryStream ms = new MemoryStream())
            {
                chartMetricas.SaveImage(ms, ChartImageFormat.Png);
                iTextSharp.text.Image imagenGrafico = iTextSharp.text.Image.GetInstance(ms.GetBuffer());

                if (imagenGrafico.Width > 500)
                    imagenGrafico.ScaleToFit(500, 400);

                imagenGrafico.Alignment = Element.ALIGN_CENTER;
                doc.Add(imagenGrafico);
            }
            doc.Add(new Chunk("\n"));

            // 5. Tabla de Datos
            PdfPTable tabla = new PdfPTable(3);
            tabla.WidthPercentage = 100;

            // Encabezados de Tabla Traducidos
            string[] headers = {
                _idiomaBLL.Traducir("pdf_col_fecha"),
                _idiomaBLL.Traducir("serie_ph"),
                _idiomaBLL.Traducir("serie_ec")
            };

            foreach (var header in headers)
            {
                PdfPCell celda = new PdfPCell(new Phrase(header, fuenteHeaderTabla));
                celda.BackgroundColor = new BaseColor(0, 174, 219);
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                tabla.AddCell(celda);
            }

            // Datos 
            // Usamos índices fijos 0 y 1 porque ya sabemos el orden, independientemente del nombre traducido
            var puntosPH = chartMetricas.Series[0].Points;
            var puntosEC = chartMetricas.Series[1].Points;

            for (int i = 0; i < puntosPH.Count; i++)
            {
                // Fecha
                tabla.AddCell(new PdfPCell(new Phrase(DateTime.FromOADate(puntosPH[i].XValue).ToString("dd/MM/yyyy"), fuenteNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });

                // pH
                tabla.AddCell(new PdfPCell(new Phrase(puntosPH[i].YValues[0].ToString("N2"), fuenteNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });

                // EC
                tabla.AddCell(new PdfPCell(new Phrase(puntosEC[i].YValues[0].ToString("N2"), fuenteNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });
            }

            doc.Add(tabla);
            doc.Close();
        }
    }
}