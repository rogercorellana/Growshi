using System;
using System.Collections.Generic;
using BE;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font.Constants; // Asegurate de tener este using

namespace growshiUI.Reportes
{
    public class GeneradorReportePlan
    {
        public void ExportarPdf(PlanCultivo plan, List<EtapaCultivo> etapas, string rutaArchivo)
        {
            // Usamos un bloque try-catch limpio sin relanzar excepciones genéricas
            // para que el error original llegue a la UI.

            using (PdfWriter writer = new PdfWriter(rutaArchivo))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf, PageSize.A4);
                    document.SetMargins(20, 20, 20, 20);

                    // --- FUENTES SEGURAS ---
                    // Usamos Helvetica estándar. Si falla, iText usará la por defecto.
                    PdfFont fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                    PdfFont fontNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                    Color verdeGrowshi = new DeviceRgb(0, 177, 89);

                    // 1. TÍTULO
                    document.Add(new Paragraph("GROWSHI - Ficha de Cultivo")
                        .SetFont(fontBold).SetFontSize(22).SetFontColor(verdeGrowshi)
                        .SetTextAlignment(TextAlignment.CENTER));

                    // 2. DATOS DEL PLAN (Validamos nulos con ??)
                    string nombrePlan = plan.NombrePlan ?? "Sin Nombre";
                    document.Add(new Paragraph($"Plan: {nombrePlan}")
                        .SetFont(fontBold).SetFontSize(14).SetMarginTop(10));

                    

                    document.Add(new Paragraph("\n"));

                    // 3. TABLA
                    Table table = new Table(UnitValue.CreatePercentArray(new float[] { 3, 1, 2, 2, 2 }));
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    // Cabeceras
                    string[] headers = { "Etapa", "Días", "Temp (°C)", "Humedad (%)", "pH" };
                    foreach (var h in headers)
                    {
                        table.AddHeaderCell(new Cell().Add(new Paragraph(h))
                            .SetBackgroundColor(verdeGrowshi)
                            .SetFontColor(ColorConstants.WHITE)
                            .SetFont(fontBold)
                            .SetTextAlignment(TextAlignment.CENTER));
                    }

                    // Filas (Validamos nulos en strings)
                    foreach (var etapa in etapas)
                    {
                        // Helper para evitar escribir nulls
                        string nombreEtapa = etapa.NombreEtapa ?? "Etapa";

                        table.AddCell(new Paragraph(nombreEtapa).SetFont(fontNormal));
                        table.AddCell(new Paragraph(etapa.Duracion.ToString()).SetFont(fontNormal).SetTextAlignment(TextAlignment.CENTER));
                        table.AddCell(new Paragraph($"{etapa.TempMin}-{etapa.TempMax}").SetFont(fontNormal).SetTextAlignment(TextAlignment.CENTER));
                        table.AddCell(new Paragraph($"{etapa.HumMin}-{etapa.HumMax}").SetFont(fontNormal).SetTextAlignment(TextAlignment.CENTER));
                        table.AddCell(new Paragraph($"{etapa.PhMin}-{etapa.PhMax}").SetFont(fontNormal).SetTextAlignment(TextAlignment.CENTER));
                    }

                    document.Add(table);

                    // 4. FOOTER
                    document.Add(new Paragraph($"\nReporte generado el {DateTime.Now:g}")
                        .SetFontSize(8).SetFontColor(ColorConstants.GRAY).SetTextAlignment(TextAlignment.RIGHT));

                    // IMPORTANTE: Cerrar el documento explícitamente suele ayudar a liberar el archivo antes
                    document.Close();
                }
            }
        }
    }
}