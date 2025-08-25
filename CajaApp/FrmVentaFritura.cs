using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaApp
{
    public partial class FrmVentaFritura : Form
    {
        private readonly string _token;
        private List<Producto> productosDisponibles = new();
        private List<ProductoVenta> productosEnVenta = new();

        public FrmVentaFritura(string token)
        {
            InitializeComponent();
            _token = token;
        }

        private async void FrmVentaFritura_Load(object sender, EventArgs e)
        {
            await CargarProductosAsync();
            InicializarGrid();
            ActualizarTotal();
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                btnAgregarProducto.Enabled = false;
                Cursor = Cursors.WaitCursor;

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var response = await client.GetAsync("http://localhost:5263/api/Producto/ObtenerProductos");

                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al obtener productos: {response.StatusCode}\n{error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var productos = await response.Content.ReadFromJsonAsync<List<Producto>>();

                if (productos == null || productos.Count == 0)
                {
                    MessageBox.Show("No se encontraron productos disponibles.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                productosDisponibles = productos;
                cmbProductos.DataSource = null;
                cmbProductos.DataSource = productosDisponibles;
                cmbProductos.DisplayMember = "Nombre";
                cmbProductos.ValueMember = "ProductoId";
                cmbProductos.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAgregarProducto.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void InicializarGrid()
        {
            dgvOrden.Columns.Clear();
            dgvOrden.Columns.Add("Nombre", "Producto");
            dgvOrden.Columns.Add("Cantidad", "Cantidad");
            dgvOrden.Columns.Add("Stock", "Stock");
            dgvOrden.Columns.Add("Precio", "Precio");

            dgvOrden.AllowUserToAddRows = false;
            dgvOrden.ReadOnly = true;
            dgvOrden.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrden.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ActualizarListaVenta()
        {
            var tabla = new DataTable();
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Cantidad", typeof(int));
            tabla.Columns.Add("Stock", typeof(int));
            tabla.Columns.Add("Precio", typeof(decimal));

            foreach (var p in productosEnVenta)
            {
                var productoOriginal = productosDisponibles.FirstOrDefault(prod => prod.ProductoId == p.ProductoId);
                int stockActual = productoOriginal?.Stock ?? p.Stock;

                tabla.Rows.Add(p.Nombre, p.Cantidad, stockActual, p.Precio);
            }

            dgvOrden.DataSource = tabla;
            dgvOrden.Columns["Precio"].DefaultCellStyle.Format = "C2";
            foreach (DataGridViewColumn col in dgvOrden.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un producto.");
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida.");
                return;
            }

            var producto = (Producto)cmbProductos.SelectedItem;
            int cantidadEnVenta = productosEnVenta.Where(p => p.ProductoId == producto.ProductoId).Sum(p => p.Cantidad);
            int stockDisponible = producto.Stock - cantidadEnVenta;

            if (cantidad > stockDisponible)
            {
                MessageBox.Show($"Cantidad mayor que el stock disponible. Stock restante: {stockDisponible}");
                return;
            }

            var productoEnVenta = productosEnVenta.FirstOrDefault(p => p.ProductoId == producto.ProductoId);
            if (productoEnVenta != null)
            {
                productoEnVenta.Cantidad += cantidad;
            }
            else
            {
                productosEnVenta.Add(new ProductoVenta
                {
                    ProductoId = producto.ProductoId,
                    Nombre = producto.Nombre,
                    Precio = producto.Precio,
                    Cantidad = cantidad,
                    Stock = producto.Stock,
                    Categoria = producto.Categoria,
                    Descripcion = producto.Descripcion,
                    CodigoInventario = producto.CodigoInventario,
                    CodigoProveedor = producto.CodigoProveedor
                });
            }

            txtCantidad.Clear();
            cmbProductos.SelectedIndex = -1;

            ActualizarListaVenta();
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            decimal total = productosEnVenta.Sum(p => p.Precio * p.Cantidad);
            lblTotal.Text = $"Total: RD${total:0.00}";
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e) { }
        private void dgvOrden_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblTotal_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        public class Producto
        {
            public int ProductoId { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public string Categoria { get; set; }
            public int Stock { get; set; }
            public string Descripcion { get; set; }
            public int CodigoInventario { get; set; }
            public int CodigoProveedor { get; set; }
        }

        public class ProductoVenta
        {
            public int ProductoId { get; set; }
            public string Nombre { get; set; } = "";
            public decimal Precio { get; set; }
            public int Cantidad { get; set; }
            public int Stock { get; set; }
            public string Categoria { get; set; }
            public string Descripcion { get; set; }
            public int CodigoInventario { get; set; }
            public int CodigoProveedor { get; set; }
        }

        private async void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (productosEnVenta.Count == 0)
            {
                MessageBox.Show("No hay productos seleccionados para la venta.");
                return;
            }

            string nombreCliente = txtNombreCliente.Text.Trim();
            if (string.IsNullOrEmpty(nombreCliente))
            {
                MessageBox.Show("Ingrese el nombre del cliente.");
                return;
            }

            btnConfirmarVenta.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                // Obtener o registrar cliente y obtener ClienteID
                int? clienteId = await ObtenerORegistrarClienteAsync(nombreCliente);
                if (clienteId == null)
                {
                    MessageBox.Show("No se pudo obtener o registrar el cliente.");
                    return;
                }

                decimal total = productosEnVenta.Sum(p => p.Precio * p.Cantidad);

                // 1. Registrar pedido enviando ClienteID
                var pedidoDto = new
                {
                    ClienteID = clienteId.Value,
                    Total = total,
                    Estado = "Pagado"
                };

                var pedidoResponse = await client.PostAsJsonAsync("http://localhost:5263/api/Pedido/RegistrarPedido", pedidoDto);
                if (!pedidoResponse.IsSuccessStatusCode)
                {
                    string error = await pedidoResponse.Content.ReadAsStringAsync();
                    MessageBox.Show("Error al registrar pedido: " + error);
                    return;
                }

                var pedidoContent = await pedidoResponse.Content.ReadFromJsonAsync<PedidoResponseDto>();
                if (pedidoContent == null || pedidoContent.PedidoID == 0)
                {
                    MessageBox.Show("No se pudo obtener el ID del pedido.");
                    return;
                }

                int pedidoId = pedidoContent.PedidoID;

                // 2. Registrar detalles del pedido
                foreach (var producto in productosEnVenta)
                {
                    var detalle = new
                    {
                        PedidoId = pedidoId,
                        ProductoId = producto.ProductoId,
                        Cantidad = producto.Cantidad,
                        PrecioUnitario = producto.Precio
                    };

                    var detalleResponse = await client.PostAsJsonAsync("http://localhost:5263/api/Pedido/RegistrarDetalle", detalle);
                    if (!detalleResponse.IsSuccessStatusCode)
                    {
                        string error = await detalleResponse.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al registrar detalle del producto {producto.Nombre}: {error}");
                        return;
                    }

                    // Actualizar stock local y remoto
                    var original = productosDisponibles.FirstOrDefault(p => p.ProductoId == producto.ProductoId);
                    if (original != null)
                    {
                        original.Stock -= producto.Cantidad;

                        var productoActualizado = new
                        {
                            ProductoId = original.ProductoId,
                            Nombre = original.Nombre,
                            Precio = original.Precio,
                            Categoria = original.Categoria,
                            Stock = original.Stock,
                            Descripcion = original.Descripcion,
                            CodigoInventario = original.CodigoInventario,
                            CodigoProveedor = original.CodigoProveedor
                        };

                        var response = await client.PutAsJsonAsync($"http://localhost:5263/api/Producto/ActualizarProducto/{original.ProductoId}", productoActualizado);
                        if (!response.IsSuccessStatusCode)
                        {
                            string error = await response.Content.ReadAsStringAsync();
                            MessageBox.Show($"Error al actualizar stock del producto {original.Nombre}: {error}");
                            return;
                        }
                    }
                }

                // 3. Registrar factura
                var facturaNueva = new
                {
                    PedidoID = pedidoId,
                    Total = total,
                    Estado = "Completado",
                    NombreCliente = nombreCliente
                };

                var facturaResponse = await client.PostAsJsonAsync("http://localhost:5263/api/Factura/RegistrarFactura", facturaNueva);
                if (!facturaResponse.IsSuccessStatusCode)
                {
                    string error = await facturaResponse.Content.ReadAsStringAsync();
                    MessageBox.Show("Error al registrar factura: " + error);
                    return;
                }

                MessageBox.Show("Venta confirmada, pedido y factura registrados, stock actualizado.");

                // Limpiar y actualizar
                productosEnVenta.Clear();
                ActualizarListaVenta();
                ActualizarTotal();
                txtNombreCliente.Clear();

                // Recargar productos para reflejar nuevo stock
                await CargarProductosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
            finally
            {
                btnConfirmarVenta.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private async Task<int?> ObtenerORegistrarClienteAsync(string nombre)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            try
            {
                // Obtener lista clientes
                var clientes = await client.GetFromJsonAsync<List<Cliente>>("http://localhost:5263/api/Cliente/ListarClientes");

                // Buscar cliente existente (case-insensitive)
                var clienteExistente = clientes?.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
                if (clienteExistente != null)
                    return clienteExistente.ClienteId;

                // Crear nuevo cliente (solo nombre)
                var nuevoCliente = new
                {
                    Nombre = nombre,
                    Apellido = (string?)null,
                    TipoDocumento = (string?)null,
                    NumeroDocumento = (string?)null,
                    Telefono = (string?)null,
                    Email = (string?)null,
                    Direccion = (string?)null
                };

                var response = await client.PostAsJsonAsync("http://localhost:5263/api/Cliente/RegistrarCliente", nuevoCliente);
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Error al registrar cliente: " + error);
                    return null;
                }

                var clienteCreado = await response.Content.ReadFromJsonAsync<Cliente>();
                return clienteCreado?.ClienteId;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al registrar cliente: " + ex.Message);
                return null;
            }
        }

        public class PedidoResponseDto
        {
            public int PedidoID { get; set; }
            public int ClienteID { get; set; }
            public string Estado { get; set; }
            public decimal Total { get; set; }
            public DateTime FechaPedido { get; set; }
        }

        public class Cliente
        {
            public int ClienteId { get; set; }
            public string Nombre { get; set; }
        }

    }
}
