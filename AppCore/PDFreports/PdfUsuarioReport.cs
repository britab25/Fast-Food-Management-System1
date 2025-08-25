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
    internal class PdfUsuarioReport
    {
        public static void Generar(List<Usuario> usuarios)
        {
            var doc = new PdfDocument();
            doc.Info.Title = "Reporte de Usuarios";

            var page = doc.AddPage();
            page.Orientation = PdfSharp.PageOrientation.Landscape;

            var gfx = XGraphics.FromPdfPage(page);
            var fontTitulo = new XFont("Verdana", 16, XFontStyleEx.Bold);
            var font = new XFont("Verdana", 10, XFontStyleEx.Regular);

            int y = 40;
            gfx.DrawString("Reporte de Usuarios", fontTitulo, XBrushes.Black,
                new XRect(0, y, page.Width, 20), XStringFormats.TopCenter);
            y += 40;

            string[] encabezados = { "ID", "Nombre", "Usuario", "Rol" };
            int x = 20;
            int spacing = (int)(page.Width - 40) / encabezados.Length;

            foreach (var h in encabezados)
            {
                gfx.DrawString(h, font, XBrushes.Black, new XRect(x, y, spacing, 20), XStringFormats.TopLeft);
                x += spacing;
            }
            y += 25;

            foreach (var u in usuarios)
            {
                x = 20;
                string[] datos =
                {
                u.UsuarioId.ToString(),
                u.Nombre,
                u.UsuarioLogin,
                u.Rol
            };

                foreach (var d in datos)
                {
                    gfx.DrawString(d, font, XBrushes.Black, new XRect(x, y, spacing, 20), XStringFormats.TopLeft);
                    x += spacing;
                }

                y += 25;
                if (y > page.Height - 50)
                {
                    page = doc.AddPage();
                    page.Orientation = PdfSharp.PageOrientation.Landscape;
                    gfx = XGraphics.FromPdfPage(page);
                    y = 40;
                }
            }

            string ruta = "ReporteUsuarios.pdf";
            doc.Save(ruta);
            Process.Start("explorer", ruta);
        }

    
    }
}
