using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using AppCore.Models;

namespace AppCore.PDFreports
{
    public class PdfClienteReport
    {
        
         public static void Generar(List<Cliente> clientes)
        {
            var documento = new PdfDocument();
            documento.Info.Title = "Reporte de Clientes";
            var pagina = documento.AddPage();
            pagina.Orientation = PdfSharp.PageOrientation.Landscape;
            var gfx = XGraphics.FromPdfPage(pagina);
            var fuenteTitulo = new XFont("Verdana", 16, XFontStyleEx.Bold);
            var fuente = new XFont("Verdana", 10, XFontStyleEx.Regular);

            int y = 40;
            gfx.DrawString("Reporte de Clientes", fuenteTitulo, XBrushes.Black, new XRect(0, y, pagina.Width, 20), XStringFormats.TopCenter);
            y += 40;

            string[] encabezados = { "ID", "Tipo Doc", "Num. Doc", "Nombre", "Apellido", "Email", "Teléfono", "Dirección", "Fecha Registro" };
            int[] anchos = { 40, 60, 80, 80, 80, 130, 80, 120, 100 };
            int x = 20;

            for (int i = 0; i < encabezados.Length; i++)
            {
                gfx.DrawString(encabezados[i], fuente, XBrushes.Black, new XRect(x, y, anchos[i], 20), XStringFormats.TopLeft);
                x += anchos[i];
            }

            y += 25;

            foreach (var c in clientes)
            {
                x = 20;
                string[] valores =
                {
                c.ClienteId.ToString(),
                c.TipoDocumento,
                c.NumeroDocumento,
                c.Nombre,
                c.Apellido,
                c.Email,
                c.Telefono,
                c.Direccion,
                c.FechaRegistro.ToShortDateString()
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

            string ruta = "ClientesReporte.pdf";
            documento.Save(ruta);
            Process.Start("explorer", ruta);
        }
    }

}
