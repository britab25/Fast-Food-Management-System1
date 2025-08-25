using AppCore.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.PDFreports
{
    internal class PdfProveedorReport
    {
        public static void Generar(List<Proveedor> proveedores)
        {
            var documento = new PdfDocument();
            documento.Info.Title = "Reporte de Proveedores";

            var pagina = documento.AddPage();
            pagina.Orientation = PdfSharp.PageOrientation.Landscape;
            var gfx = XGraphics.FromPdfPage(pagina);
            var fuenteTitulo = new XFont("Verdana", 16, XFontStyleEx.Bold);
            var fuente = new XFont("Verdana", 10, XFontStyleEx.Regular);

            int y = 40;
            gfx.DrawString("Reporte de Proveedores", fuenteTitulo, XBrushes.Black, new XRect(0, y, pagina.Width, 20), XStringFormats.TopCenter);
            y += 40;

            string[] encabezados = { "Código", "Nombre", "Descripción" };
            int[] anchos = { 80, 150, 300 };
            int x = 40;

            for (int i = 0; i < encabezados.Length; i++)
            {
                gfx.DrawString(encabezados[i], fuente, XBrushes.Black, new XRect(x, y, anchos[i], 20), XStringFormats.TopLeft);
                x += anchos[i];
            }
            y += 25;

            foreach (var p in proveedores)
            {
                x = 40;
                string[] valores =
                {
                p.CodigoProveedor.ToString(),
                p.NombreProveedor,
                p.Descripcion
            };

                for (int i = 0; i < valores.Length; i++)
                {
                    gfx.DrawString(valores[i], fuente, XBrushes.Black, new XRect(x, y, anchos[i], 20), XStringFormats.TopLeft);
                    x += anchos[i];
                }

                y += 25;
                if (y > pagina.Height - 50)
                {
                    pagina = documento.AddPage();
                    pagina.Orientation = PdfSharp.PageOrientation.Landscape;
                    gfx = XGraphics.FromPdfPage(pagina);
                    y = 40;
                }
            }

            string ruta = "ProveedoresReporte.pdf";
            documento.Save(ruta);
            Process.Start("explorer", ruta);
        }
    }
}
