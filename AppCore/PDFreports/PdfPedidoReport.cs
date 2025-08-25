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
    public class PdfPedidoReport
    {
       
        public static void Generar(List<PedidoCreado> pedidos)
        {
            var doc = new PdfDocument();
            doc.Info.Title = "Reporte de Pedidos";

            var page = doc.AddPage();
            page.Orientation = PdfSharp.PageOrientation.Landscape;
            var gfx = XGraphics.FromPdfPage(page);
            var titleFont = new XFont("Verdana", 16, XFontStyleEx.Bold);
            var font = new XFont("Verdana", 10, XFontStyleEx.Regular);

            int y = 40;
            gfx.DrawString("Reporte de Pedidos", titleFont, XBrushes.Black, new XRect(0, y, page.Width, 20), XStringFormats.TopCenter);
            y += 40;

            string[] headers = { "PedidoID", "ClienteID", "Estado", "Total", "FechaPedido" };
            int[] widths = { 60, 60, 100, 80, 100 };
            int x = 20;

            for (int i = 0; i < headers.Length; i++)
            {
                gfx.DrawString(headers[i], font, XBrushes.Black, new XRect(x, y, widths[i], 20), XStringFormats.TopLeft);
                x += widths[i];
            }
            y += 25;

            foreach (var p in pedidos)
            {
                x = 20;
                string[] values = {
                p.PedidoID.ToString(),
                p.ClienteID?.ToString() ?? "",
                p.Estado,
                p.Total?.ToString("C") ?? "",
                p.FechaPedido?.ToShortDateString() ?? ""
            };
                for (int i = 0; i < values.Length; i++)
                {
                    gfx.DrawString(values[i], font, XBrushes.Black, new XRect(x, y, widths[i], 20), XStringFormats.TopLeft);
                    x += widths[i];
                }
                y += 25;
            }

            string path = "PedidosReporte.pdf";
            doc.Save(path);
            Process.Start("explorer", path);
        }
    }
}

