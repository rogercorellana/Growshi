using System;
using System.Collections.Generic;
using System.IO;
using BE;
using BLL; // Necesario para IdiomaBLL
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace growshiUI.Reportes
{
    public class GeneradorReportePlan
    {
        private readonly IdiomaBLL _idiomaBLL;

        public GeneradorReportePlan()
        {
            _idiomaBLL = new IdiomaBLL(); // Instanciamos para obtener traducciones
        }

        public void ExportarPdf(PlanCultivo plan, List<EtapaCultivo> etapas, string rutaDestino)
        {
            // 1. Configuración del Documento
            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
            FileStream fs = new FileStream(rutaDestino, FileMode.Create);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();

            // 2. Fuentes y Estilos
            Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLACK);
            Font fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.DARK_GRAY);
            Font fuenteHeaderTabla = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.WHITE);
            Font fuenteCuerpoTabla = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);

            // 3. Encabezado del Reporte (Traducido)
            doc.Add(new Paragraph(_idiomaBLL.Traducir("Reporte_Titulo_Principal"), fuenteTitulo));
            doc.Add(new Paragraph($"{_idiomaBLL.Traducir("Reporte_Lbl_Plan")}: {plan.NombrePlan}", fuenteSubtitulo));
            doc.Add(new Paragraph($"{_idiomaBLL.Traducir("Reporte_Lbl_Fecha")}: {DateTime.Now:dd/MM/yyyy}", fuenteSubtitulo));
            doc.Add(new Chunk("\n")); // Espacio

            // 4. Tabla de Etapas
            PdfPTable tabla = new PdfPTable(6); // 6 Columnas
            tabla.WidthPercentage = 100;

            // Configurar anchos relativos (opcional)
            // tabla.SetWidths(new float[] { 10f, 30f, 15f, 15f, 15f, 15f });

            // --- HEADERS (Traducidos) ---
            AgregarCeldaHeader(tabla, _idiomaBLL.Traducir("Planes_Col_Orden"), fuenteHeaderTabla);
            AgregarCeldaHeader(tabla, _idiomaBLL.Traducir("Planes_Col_Etapa"), fuenteHeaderTabla);
            AgregarCeldaHeader(tabla, _idiomaBLL.Traducir("Planes_Col_Duracion"), fuenteHeaderTabla);
            AgregarCeldaHeader(tabla, "Temp (°C)", fuenteHeaderTabla); // Símbolos universales no requieren tanta traducción
            AgregarCeldaHeader(tabla, "Hum (%)", fuenteHeaderTabla);
            AgregarCeldaHeader(tabla, "pH", fuenteHeaderTabla);

            // --- DATA ---
            foreach (var etapa in etapas)
            {
                AgregarCeldaBody(tabla, etapa.Orden.ToString(), fuenteCuerpoTabla);
                AgregarCeldaBody(tabla, etapa.NombreEtapa, fuenteCuerpoTabla);
                AgregarCeldaBody(tabla, $"{etapa.Duracion} {_idiomaBLL.Traducir("Reporte_Sufijo_Dias")}", fuenteCuerpoTabla); // Ej: "15 days"
                AgregarCeldaBody(tabla, $"{etapa.TempMin}-{etapa.TempMax}", fuenteCuerpoTabla);
                AgregarCeldaBody(tabla, $"{etapa.HumMin}-{etapa.HumMax}", fuenteCuerpoTabla);
                AgregarCeldaBody(tabla, $"{etapa.PhMin}-{etapa.PhMax}", fuenteCuerpoTabla);
            }

            doc.Add(tabla);

            // 5. Pie de página o Info legal
            doc.Add(new Chunk("\n"));
            var footer = new Paragraph(_idiomaBLL.Traducir("Reporte_Footer_GeneradoPor"), FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 8, BaseColor.GRAY));
            footer.Alignment = Element.ALIGN_CENTER;
            doc.Add(footer);

            doc.Close();
            writer.Close();
            fs.Close();
        }

        private void AgregarCeldaHeader(PdfPTable tabla, string texto, Font fuente)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto, fuente));
            celda.BackgroundColor = new BaseColor(0, 177, 89); // Verde Growshi
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.Padding = 5;
            tabla.AddCell(celda);
        }

        private void AgregarCeldaBody(PdfPTable tabla, string texto, Font fuente)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto, fuente));
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.Padding = 5;
            tabla.AddCell(celda);
        }
    }
}