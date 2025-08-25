using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaApp
{
    public partial class FrmImprimirRecibo : Form
    {
        private readonly string _nombreCajero;
        private readonly string _token;
        private readonly int _usuarioId;
        private DetalleFacturaModel facturaActual;

        public FrmImprimirRecibo(string nombreCajero, string token, int UsuarioId)
        {
            InitializeComponent();
            _nombreCajero = nombreCajero;
            _token = token;
            _usuarioId = UsuarioId;
        }

        private async void FrmImprimirRecibo_Load(object sender, EventArgs e)
        {
            await CargarFacturasAsync();
        }

        private async Task CargarFacturasAsync()
        {
            btnSeleccionarFactura.Enabled = false;
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                string url = "http://localhost:5263/api/Factura/ListarFacturas";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var facturas = JsonSerializer.Deserialize<List<FacturaModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    dgvFacturas.DataSource = facturas;
                    facturaActual = null;
                    dgvDetalle.DataSource = null;
                    lblTotal.Text = "Total:";
                    lblEstado.Text = "Estado:";
                    lblFechaFactura.Text = "Fecha:";
                }
                else
                {
                    MessageBox.Show($"Error al cargar facturas: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al cargar facturas: " + ex.Message);
            }
            finally
            {
                btnSeleccionarFactura.Enabled = true;
            }
        }

        public class DetalleFacturaResumen
        {
            public int PedidoId { get; set; }
            public string Estado { get; set; }
            public string FechaFactura { get; set; }
            public string NombreCliente { get; set; }
        }

        private async Task CargarDetalleFacturaAsync(int facturaId)
        {
            btnSeleccionarFactura.Enabled = false;
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                string url = $"http://localhost:5263/api/Factura/ConsultarFacturaPorFactura/{facturaId}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    facturaActual = JsonSerializer.Deserialize<DetalleFacturaModel>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (facturaActual != null)
                    {
                        dgvDetalle.Columns.Clear();
                        dgvDetalle.AutoGenerateColumns = true;

                        var resumen = new List<DetalleFacturaResumen>
                        {
                            new DetalleFacturaResumen
                            {
                                PedidoId = facturaActual.PedidoId,
                                Estado = facturaActual.Estado,
                                FechaFactura = facturaActual.FechaFactura.ToString("g"),
                                NombreCliente = facturaActual.NombreCliente
                            }
                        };

                        dgvDetalle.DataSource = resumen;

                        lblTotal.Text = $"Total: {facturaActual.Total:C2}";
                        lblEstado.Text = $"Estado: {facturaActual.Estado}";
                        lblFechaFactura.Text = $"Fecha: {facturaActual.FechaFactura:g}";
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el detalle de la factura.");
                        dgvDetalle.DataSource = null;
                    }
                }
                else
                {
                    MessageBox.Show($"Error al obtener detalle de factura: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al obtener detalle: " + ex.Message);
            }
            finally
            {
                btnSeleccionarFactura.Enabled = true;
            }
        }

        private async Task CambiarEstadoFactura(string nuevoEstado)
        {
            if (facturaActual == null)
            {
                MessageBox.Show("Seleccione y actualice una factura primero.");
                return;
            }

            btnMarcarCompletado.Enabled = false;
            btnMarcarPendiente.Enabled = false;

            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var contenido = JsonContent.Create(new { Estado = nuevoEstado });
                var response = await client.PutAsync($"http://localhost:5263/api/Factura/ActualizarEstadoFactura/{facturaActual.FacturaId}", contenido);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Estado actualizado correctamente.");

                    // Guardar el Id ANTES de limpiar o recargar
                    int facturaId = facturaActual.FacturaId;

                    await CargarFacturasAsync();

                    facturaActual = null;

                    await CargarDetalleFacturaAsync(facturaId);
                }
                else
                {
                    MessageBox.Show($"Error al actualizar estado: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al actualizar estado: " + ex.Message);
            }
            finally
            {
                btnMarcarCompletado.Enabled = true;
                btnMarcarPendiente.Enabled = true;
            }
        }


        private async void btnSeleccionarFactura_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.CurrentRow?.DataBoundItem is FacturaModel facturaSeleccionada)
            {
                await CargarDetalleFacturaAsync(facturaSeleccionada.FacturaId);
            }
            else
            {
                MessageBox.Show("Seleccione una factura válida.");
            }
        }

        private async void btnMarcarPendiente_Click(object sender, EventArgs e)
        {
            await CambiarEstadoFactura("Pendiente");
        }

        private async void btnMarcarCompletado_Click(object sender, EventArgs e)
        {
            await CambiarEstadoFactura("Completado");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (facturaActual == null)
            {
                MessageBox.Show("Seleccione una factura usando el botón 'Seleccionar'.");
                return;
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                float y = 20;
                Font font = new Font("Consolas", 10);
                Brush brush = Brushes.Black;

                ev.Graphics.DrawString("------ RECIBO DE VENTA ------", new Font("Arial", 14, FontStyle.Bold), brush, 20, y);
                y += 30;
                ev.Graphics.DrawString($"Factura ID: {facturaActual.FacturaId}", font, brush, 20, y); y += 20;
                ev.Graphics.DrawString($"Pedido ID: {facturaActual.PedidoId}", font, brush, 20, y); y += 20;
                ev.Graphics.DrawString($"Fecha: {facturaActual.FechaFactura:g}", font, brush, 20, y); y += 20;
                ev.Graphics.DrawString($"Estado: {facturaActual.Estado}", font, brush, 20, y); y += 20;
                ev.Graphics.DrawString($"Cliente: {facturaActual.NombreCliente}", font, brush, 20, y); y += 20;
                y += 10;

                ev.Graphics.DrawString("Producto        Cant  Precio  Subtotal", font, brush, 20, y); y += 20;
                ev.Graphics.DrawString("----------------------------------------", font, brush, 20, y); y += 20;

                if (facturaActual.DetalleProductos != null)
                {
                    foreach (var p in facturaActual.DetalleProductos)
                    {
                        string producto = p.Producto.PadRight(14);
                        string cantidad = p.Cantidad.ToString().PadLeft(4);
                        string precio = p.PrecioUnitario.ToString("0.00").PadLeft(7);
                        string subtotal = p.Subtotal.ToString("0.00").PadLeft(9);
                        ev.Graphics.DrawString($"{producto} {cantidad} {precio} {subtotal}", font, brush, 20, y);
                        y += 20;
                    }
                }

                y += 10;
                ev.Graphics.DrawString($"TOTAL: {facturaActual.Total:C2}", new Font("Arial", 12, FontStyle.Bold), brush, 20, y);
            };

            PrintDialog dialog = new PrintDialog { Document = pd };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        // MODELOS
        public class FacturaModel
        {
            public int FacturaId { get; set; }
            public int PedidoId { get; set; }
            public DateTime FechaFactura { get; set; }
            public decimal Total { get; set; }
            public string Estado { get; set; }
        }

        public class DetalleFacturaModel
        {
            public int FacturaId { get; set; }
            public int PedidoId { get; set; }
            public DateTime FechaFactura { get; set; }
            public decimal Total { get; set; }
            public string Estado { get; set; }
            public string NombreCliente { get; set; }
            public List<DetalleProducto> DetalleProductos { get; set; }
        }

        public class DetalleProducto
        {
            public string Producto { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal Subtotal { get; set; }
        }

        private void btnActualizarRecibo_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }
    }
}
