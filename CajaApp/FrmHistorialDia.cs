using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CajaApp.FrmImprimirRecibo;

namespace CajaApp
{
    public partial class FrmHistorialDia : Form
    {
        private readonly string _token;

        public FrmHistorialDia(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private async void FrmHistorialDia_Load(object sender, EventArgs e)
        {
            dtpFechaHistorial.Value = DateTime.Today;
            await CargarHistorialAsync();
        }

        private async void btnCargarHistorial_Click(object sender, EventArgs e)
        {
            await CargarHistorialAsync();
        }

        private async Task CargarHistorialAsync()
        {
            btnCargarHistorial.Enabled = false;
            DateTime fecha = dtpFechaHistorial.Value.Date;

            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                client.Timeout = TimeSpan.FromSeconds(30);

                // Historial caja
                string urlHistorial = $"http://localhost:5263/api/Caja/HistorialCaja?fecha={fecha:yyyy-MM-dd}";
                var responseHistorial = await client.GetAsync(urlHistorial);
                List<HistorialCajaModel> historial = null;
                if (responseHistorial.IsSuccessStatusCode)
                {
                    var json = await responseHistorial.Content.ReadAsStringAsync();
                    historial = JsonSerializer.Deserialize<List<HistorialCajaModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    var errorContent = await responseHistorial.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al obtener historial de caja: {responseHistorial.StatusCode}\nDetalles: {errorContent}");
                }

                // Ventas del día
                string urlVentas = $"http://localhost:5263/api/Caja/ReporteVentasDia?fecha={fecha:yyyy-MM-dd}";
                var responseVentas = await client.GetAsync(urlVentas);
                List<VentaDia> ventas = null;
                if (responseVentas.IsSuccessStatusCode)
                {
                    var json = await responseVentas.Content.ReadAsStringAsync();
                    ventas = JsonSerializer.Deserialize<List<VentaDia>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    var errorContent = await responseVentas.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al obtener ventas: {responseVentas.StatusCode}\nDetalles: {errorContent}");
                }

                // Mostrar historial y ventas
                dgvAperturasCierres.DataSource = historial ?? new List<HistorialCajaModel>();
                dgvVentasDia.DataSource = ventas ?? new List<VentaDia>();

                // Totales
                decimal totalAperturas = 0m, totalCierres = 0m;
                if (historial != null)
                {
                    foreach (var h in historial)
                    {
                        if (h.TipoEvento?.Equals("Apertura", StringComparison.OrdinalIgnoreCase) == true)
                            totalAperturas += h.MontoInicial ?? 0;
                        else if (h.TipoEvento?.Equals("Cierre", StringComparison.OrdinalIgnoreCase) == true)
                            totalCierres += h.MontoFinal ?? 0;
                    }
                }

                decimal totalVentas = 0m;
                if (ventas != null)
                {
                    foreach (var v in ventas)
                        totalVentas += v.Total;
                }

                lblTotalAperturas.Text = $"Total Aperturas: {totalAperturas:C2}";
                lblTotalCierres.Text = $"Total Cierres: {totalCierres:C2}";
                lblTotalVentas.Text = $"Total Ventas: {totalVentas:C2}";
                lblFechaSeleccionada.Text = $"Historial para el día: {fecha:dd/MM/yyyy}";

                dgvAperturasCierres.AutoResizeColumns();
                dgvVentasDia.AutoResizeColumns();

                // Facturas del día
                string urlFacturas = "http://localhost:5263/api/Factura/ListarFacturas";
                var responseFacturas = await client.GetAsync(urlFacturas);

                if (responseFacturas.IsSuccessStatusCode)
                {
                    var json = await responseFacturas.Content.ReadAsStringAsync();
                    var facturas = JsonSerializer.Deserialize<List<FacturaModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (facturas != null)
                    {
                        var facturasFiltradas = facturas.FindAll(f =>
                            f.FechaFactura.Date == fecha &&
                            (f.Estado.Equals("Completado", StringComparison.OrdinalIgnoreCase) ||
                             f.Estado.Equals("Finalizado", StringComparison.OrdinalIgnoreCase))
                        );

                        dgvVentasDia.DataSource = facturasFiltradas;

                        decimal totalFacturas = 0m;
                        foreach (var f in facturasFiltradas)
                        {
                            totalFacturas += f.Total;
                        }

                        lblTotalVentas.Text = $"Total Ventas: {totalFacturas:C2}";
                    }
                }
                else
                {
                    var errorContent = await responseFacturas.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al obtener facturas: {responseFacturas.StatusCode}\nDetalles: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCargarHistorial.Enabled = true;
            }
        }

        // MODELOS INTERNOS

        private class FacturaModel
        {
            public int FacturaId { get; set; }
            public int PedidoId { get; set; }
            public DateTime FechaFactura { get; set; }
            public decimal Total { get; set; }
            public string Estado { get; set; }
        }

        private class HistorialCajaModel
        {
            public int HistorialCajaID { get; set; }
            public int UsuarioID { get; set; }
            public DateTime FechaHora { get; set; }
            public string TipoEvento { get; set; }
            public decimal? MontoInicial { get; set; }
            public decimal? MontoFinal { get; set; }
            public string Observaciones { get; set; }
        }

        private class VentaDia
        {
            public int FacturaId { get; set; }
            public int PedidoId { get; set; }
            public DateTime FechaFactura { get; set; }
            public decimal Total { get; set; }
            public string Estado { get; set; }
        }

        private void btnImprimirReporte_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFechaHistorial.Value.Date;

            var historial = dgvAperturasCierres.DataSource as List<HistorialCajaModel> ?? new List<HistorialCajaModel>();
            var ventas = dgvVentasDia.DataSource as List<FacturaModel> ?? new List<FacturaModel>();

            decimal totalAperturas = 0m;
            decimal totalCierres = 0m;
            foreach (var h in historial)
            {
                if (h.TipoEvento?.Equals("Apertura", StringComparison.OrdinalIgnoreCase) == true)
                    totalAperturas += h.MontoInicial ?? 0;

                if (h.TipoEvento?.Equals("Cierre", StringComparison.OrdinalIgnoreCase) == true)
                    totalCierres += h.MontoFinal ?? 0;
            }

            decimal totalVentas = 0m;
            foreach (var v in ventas)
                totalVentas += v.Total;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                float y = 20;
                Font fontTitle = new Font("Arial", 14, FontStyle.Bold);
                Font font = new Font("Consolas", 10);
                Brush brush = Brushes.Black;

                ev.Graphics.DrawString($"REPORTE DE VENTAS DEL DÍA - {fecha:dd/MM/yyyy}", fontTitle, brush, 20, y);
                y += 40;

                ev.Graphics.DrawString($"Total Aperturas: {totalAperturas:C2}", font, brush, 20, y);
                y += 25;
                ev.Graphics.DrawString($"Total Cierres: {totalCierres:C2}", font, brush, 20, y);
                y += 25;
                ev.Graphics.DrawString($"Total Ventas: {totalVentas:C2}", font, brush, 20, y);
                y += 35;

                ev.Graphics.DrawString("Detalle de Ventas:", fontTitle, brush, 20, y);
                y += 30;

                ev.Graphics.DrawString("FacturaID  PedidoID  Fecha            Total      Estado", font, brush, 20, y);
                y += 20;
                ev.Graphics.DrawString("------------------------------------------------------------", font, brush, 20, y);
                y += 20;
                
                foreach (var venta in ventas)
                {
                    string linea = $"{venta.FacturaId,-10} {venta.PedidoId,-9} {venta.FechaFactura:dd/MM/yyyy HH:mm}  {venta.Total,10:C2}  {venta.Estado}";
                    ev.Graphics.DrawString(linea, font, brush, 20, y);
                    y += 20;

                    if (y > ev.MarginBounds.Bottom - 40)
                    {
                        ev.HasMorePages = true;
                        return;
                    }
                }

                ev.HasMorePages = false;
            };

            PrintDialog dialog = new PrintDialog { Document = pd };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void dgvVentasDia_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}
