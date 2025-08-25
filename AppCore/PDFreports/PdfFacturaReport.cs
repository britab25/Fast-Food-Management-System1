using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace AppCore.PDFreports
{
    internal class PdfFacturaReport
    {
        // Reporte de Facturas
  
            public static void Generar(List<FacturaCreada> facturas)
            {
                var doc = new PdfDocument();
                doc.Info.Title = "Reporte de Facturas";
                var page = doc.AddPage();
                page.Orientation = PageOrientation.Landscape;
                var gfx = XGraphics.FromPdfPage(page);
                var fontTitle = new XFont("Verdana", 16, XFontStyleEx.Bold);
                var font = new XFont("Verdana", 10, XFontStyleEx.Regular);

                int y = 40;
                gfx.DrawString("Reporte de Facturas", fontTitle, XBrushes.Black, new XRect(0, y, page.Width, 20), XStringFormats.TopCenter);
                y += 40;

                string[] headers = { "ID", "Pedido ID", "Total", "Estado", "Fecha" };
                int[] widths = { 40, 60, 60, 100, 100 };
                int x = 20;

                foreach (var h in headers)
                {
                    gfx.DrawString(h, font, XBrushes.Black, new XRect(x, y, widths[Array.IndexOf(headers, h)], 20), XStringFormats.TopLeft);
                    x += widths[Array.IndexOf(headers, h)];
                }
                y += 25;

                foreach (var f in facturas)
                {
                    x = 20;
                    gfx.DrawString(f.FacturaID.ToString(), font, XBrushes.Black, new XRect(x, y, widths[0], 20), XStringFormats.TopLeft); x += widths[0];
                    gfx.DrawString(f.PedidoId.ToString(), font, XBrushes.Black, new XRect(x, y, widths[1], 20), XStringFormats.TopLeft); x += widths[1];
                    gfx.DrawString(f.Total.ToString("C"), font, XBrushes.Black, new XRect(x, y, widths[2], 20), XStringFormats.TopLeft); x += widths[2];
                    gfx.DrawString(f.Estado, font, XBrushes.Black, new XRect(x, y, widths[3], 20), XStringFormats.TopLeft); x += widths[3];
                    gfx.DrawString(f.FechaFactura.ToShortDateString(), font, XBrushes.Black, new XRect(x, y, widths[4], 20), XStringFormats.TopLeft);
                    y += 25;
                }

                var path = "FacturasReporte.pdf";
                doc.Save(path);
                Process.Start("explorer", path);
            }
        }

       
}
