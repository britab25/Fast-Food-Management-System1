using AppCore.Models;
using AppCore.PDFreports;
using AppCore.PDFreports;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;// Si la clase Cliente está en esa carpeta
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AppCore
{
    public partial class MenuFrm : Form
    {
        public MenuFrm()
        {
            InitializeComponent();
            dataGridViewClientes.AutoGenerateColumns = true;
            dataGridViewClientes2.AutoGenerateColumns = true;
            dataGridViewUsuarios.AutoGenerateColumns = true;
            dataGridViewUsuarios2.AutoGenerateColumns = true;
        }


        public async Task BuscarCliente(string numeroDocumento)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Cliente/");

                    HttpResponseMessage response = await client.GetAsync(numeroDocumento);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();  // Leemos el contenido como una cadena

                        var cliente = JsonConvert.DeserializeObject<Cliente>(jsonString); // Deserializamos el JSON a Cliente

                        MostrarCliente(cliente);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el cliente con el número de documento proporcionado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al buscar el cliente: {ex.Message}");
            }
        }

        private async Task ListarClientesAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/");
                    HttpResponseMessage response = await client.GetAsync("api/Cliente/ListarClientes");

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);

                        dataGridViewClientes2.AutoGenerateColumns = true;
                        dataGridViewClientes2.DataSource = clientes;
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron obtener los clientes.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar clientes: {ex.Message}");
            }
        }


        public void MostrarCliente(Cliente cliente)
        {
            // Limpiar las filas previas
            dataGridViewClientes.Rows.Clear();

            // Añadir una nueva fila con los datos del cliente
            dataGridViewClientes.Rows.Add(cliente.Nombre, cliente.Apellido, cliente.NumeroDocumento, cliente.Telefono, cliente.Email);
        }


        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new EliminarClienteFrm())
            {
                actualizarForm.ShowDialog();
            }
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            string numeroDocumento = txtNumeroDocumento.Text.Trim();

            if (string.IsNullOrWhiteSpace(numeroDocumento))
            {
                MessageBox.Show("Por favor ingresa un número de documento.");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Cliente/");
                    HttpResponseMessage response = await client.GetAsync(numeroDocumento);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        Cliente cliente = JsonConvert.DeserializeObject<Cliente>(json);

                        // Configurar DataGridView manualmente si no tiene columnas
                        if (dataGridViewClientes.Columns.Count == 0)
                        {
                            dataGridViewClientes.AutoGenerateColumns = false;
                            dataGridViewClientes.Columns.Add("ClienteId", "ID");
                            dataGridViewClientes.Columns.Add("TipoDocumento", "Tipo Documento");
                            dataGridViewClientes.Columns.Add("NumeroDocumento", "Nro Documento");
                            dataGridViewClientes.Columns.Add("Nombre", "Nombre");
                            dataGridViewClientes.Columns.Add("Apellido", "Apellido");
                            dataGridViewClientes.Columns.Add("Email", "Email");
                            dataGridViewClientes.Columns.Add("Telefono", "Teléfono");
                            dataGridViewClientes.Columns.Add("Direccion", "Dirección");
                            dataGridViewClientes.Columns.Add("FechaRegistro", "Registro");
                        }

                        // Limpiar y agregar los datos
                        dataGridViewClientes.Rows.Clear();
                        dataGridViewClientes.Rows.Add(
                            cliente.ClienteId,
                            cliente.TipoDocumento,
                            cliente.NumeroDocumento,
                            cliente.Nombre,
                            cliente.Apellido,
                            cliente.Email,
                            cliente.Telefono,
                            cliente.Direccion,
                            cliente.FechaRegistro.ToString("yyyy-MM-dd")
                        );
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al buscar el cliente: {ex.Message}");
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            await ListarClientesAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new AgregarClienteFrm1cs())
            {
                actualizarForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var agregarForm = new AgregarClienteFrm())
            {
                agregarForm.ShowDialog(); // Abre como modal
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void CargarUsuarios()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Usuario/");
                    HttpResponseMessage response = await client.GetAsync("ListarUsuarios");

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(json);

                        dataGridViewUsuarios2.AutoGenerateColumns = true;
                        dataGridViewUsuarios2.DataSource = usuarios;
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron cargar los usuarios.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener usuarios: {ex.Message}");
            }
        }
        private async void button7_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
        }


        private void button10_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new AgregarUsuario())
            {
                actualizarForm.ShowDialog();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new ActualizarUsuario())
            {
                actualizarForm.ShowDialog();
            }

        }

        private void dataGridViewClientes2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public async Task BuscarUsuarioPorId(int id)
        {
            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/Usuario/") };
                var response = await client.GetAsync(id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var usuario = JsonConvert.DeserializeObject<Usuario>(json);
                    dataGridViewUsuarios.AutoGenerateColumns = true;
                    dataGridViewUsuarios.DataSource = new List<Usuario> { usuario };
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Usuario no encontrado.");
                    dataGridViewUsuarios.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Error al buscar usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private async void button6_Click(object sender, EventArgs e)
        {

            if (int.TryParse(txtUsuarioId.Text.Trim(), out int id))
            {
                await BuscarUsuarioPorId(id); // <--- Aquí se pasa la variable 'id'
            }
            else
            {
                MessageBox.Show("Ingrese un ID válido.");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new EliminarUsuario())
            {
                actualizarForm.ShowDialog();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new EliminarProveedorFrm())
            {
                actualizarForm.ShowDialog();
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new AgregarProveedorFrm())
            {
                actualizarForm.ShowDialog();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new ActualizarProveedorFrm())
            {
                actualizarForm.ShowDialog();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button14_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(txtBuscarProductoId.Text, out int codigoProveedor))
            {
                MessageBox.Show("Ingresa un ID válido.");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Proveedor/");
                    HttpResponseMessage response = await client.GetAsync($"ConsultarProveedorPorID/{codigoProveedor}");

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var proveedor = JsonConvert.DeserializeObject<Proveedor>(json);

                        dataGridViewProveedores.AutoGenerateColumns = true;
                        dataGridViewProveedores.DataSource = new List<Proveedor> { proveedor };
                    }
                    else
                    {
                        MessageBox.Show("Proveedor no encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Proveedor/");
                    HttpResponseMessage response = await client.GetAsync("ListarProveedores");

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        var proveedores = JsonConvert.DeserializeObject<List<Proveedor>>(json);

                        dataGridViewProveedor1.AutoGenerateColumns = true;
                        dataGridViewProveedor1.DataSource = proveedores;
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener la lista de proveedores.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button20_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new AgregarProductoFrmcs())
            {
                actualizarForm.ShowDialog();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new ActualizarProductoFrm())
            {
                actualizarForm.ShowDialog();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new EliminarProductoFrm())
            {
                actualizarForm.ShowDialog();
            }
        }

        public async Task ListarProductos()
        {
            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/Producto/") };
                var response = await client.GetAsync("ObtenerProductos");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var productos = JsonConvert.DeserializeObject<List<Producto>>(json);
                    dataGridViewProductos2.AutoGenerateColumns = true;
                    dataGridViewProductos2.DataSource = productos;
                }
                else
                {
                    MessageBox.Show("Error al listar productos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public class Pedido
        {
            public int PedidoId { get; set; }
            public int ClienteId { get; set; }
            public DateTime FechaPedido { get; set; }
            public string Estado { get; set; }
            public decimal Total { get; set; }
        }



        public async Task BuscarProductoPorId(int id)
        {
            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/Producto/") };
                var response = await client.GetAsync($"ConsultarProductoPorID/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var producto = JsonConvert.DeserializeObject<Producto>(json);
                    dataGridViewProductos.AutoGenerateColumns = true;
                    dataGridViewProductos.DataSource = new List<Producto> { producto };
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Producto no encontrado.");
                    dataGridViewProductos.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Error al buscar el producto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private async void button16_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBuscarId.Text.Trim(), out int productoId))
            {
                await BuscarProductoPorId(productoId);
            }
            else
            {
                MessageBox.Show("ID de producto inválido.");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ListarProductos();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new AgregarPedidoFrm())
            {
                actualizarForm.ShowDialog();
            }

        }

        public async Task BuscarPedidosPorCliente(int clienteId)
        {
            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/Pedido/") };
                var response = await client.GetAsync($"ConsultarPedidosPorCliente/{clienteId}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var pedidos = JsonConvert.DeserializeObject<List<Pedido>>(json);

                    dataGridViewPedidos.AutoGenerateColumns = true;
                    dataGridViewPedidos.DataSource = pedidos;
                }
                else
                {
                    MessageBox.Show("No se encontraron pedidos para este cliente.");
                    dataGridViewPedidos.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener pedidos:\n" + ex.Message);
            }
        }

        private void MenuFrm_Load(object sender, EventArgs e)
        {

        }

        private async void button26_Click(object sender, EventArgs e)
        {

            if (int.TryParse(txtClienteId1.Text.Trim(), out int clienteId))
            {
                await BuscarPedidosPorCliente(clienteId);
            }
            else
            {
                MessageBox.Show("Por favor ingresa un ID de cliente válido.");
            }
        }

        public async Task BuscarPedidoPorId(int pedidoId)
        {
            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/Pedido/") };
                var response = await client.GetAsync($"ConsultarPedidoPorPedido/{pedidoId}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var pedido = JsonConvert.DeserializeObject<Pedido>(json);

                    if (pedido != null)
                    {
                        dataGridViewPedidos2.AutoGenerateColumns = true;
                        dataGridViewPedidos2.DataSource = new List<Pedido> { pedido };
                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Pedido no encontrado.");
                    dataGridViewPedidos.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Error al buscar pedido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:\n" + ex.Message);
            }
        }



        private async void button31_Click(object sender, EventArgs e)
        {

            if (int.TryParse(txtPedidoID2.Text.Trim(), out int pedidoId))
            {
                await BuscarPedidoPorId(pedidoId);
            }
            else
            {
                MessageBox.Show("Por favor ingresa un ID de pedido válido.");
            }
        }

        public async Task ListarTodosLosPedidos()
        {
            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/Pedido") };
                var response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var pedidos = JsonConvert.DeserializeObject<List<Pedido>>(json);

                    if (pedidos != null)
                    {
                        dataGridViewPedidos3.AutoGenerateColumns = true;
                        dataGridViewPedidos3.DataSource = pedidos;
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron pedidos.");
                        dataGridViewPedidos3.DataSource = null;
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener los pedidos.");
                    dataGridViewPedidos3.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:\n" + ex.Message);
            }
        }


        private async void button27_Click(object sender, EventArgs e)
        {
            await ListarTodosLosPedidos();
        }

        public class DetallePedido
        {
            public int DetallePedidoID { get; set; }
            public int PedidoID { get; set; }
            public int ProductoID { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
        }

        public void CargarDetallesPorPedidoID(int pedidoId)
        {
            string connectionString = "Server=MSI\\MYSQLSERVER;Database=TiendaFriturasDB;Trusted_Connection=True;TrustServerCertificate=True;";
            var detalles = new List<DetallePedido>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("sp_ConsultarDetallePorPedidoID", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PedidoID", pedidoId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        detalles.Add(new DetallePedido
                        {
                            DetallePedidoID = reader.GetInt32(0),
                            PedidoID = reader.GetInt32(1),
                            ProductoID = reader.GetInt32(2),
                            Cantidad = reader.GetInt32(3),
                            PrecioUnitario = reader.GetDecimal(4)
                        });
                    }
                }
            }

            dataGridViewDetalles2.AutoGenerateColumns = true;
            dataGridViewDetalles2.DataSource = detalles;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPedidoIdBusqueda.Text.Trim(), out int pedidoId))
            {
                MessageBox.Show("ID de pedido inválido.");
                return;
            }

            CargarDetallesPorPedidoID(pedidoId);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new ActualizarPedidoFrm())
            {
                actualizarForm.ShowDialog();
            }

        }

        private void button28_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new EliminarPedidoFrm())
            {
                actualizarForm.ShowDialog();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new AgregarFacturaFrm())
            {
                actualizarForm.ShowDialog();
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            using (var actualizarForm = new EliminarFacturaFrm())
            {
                actualizarForm.ShowDialog();
            }
        }



        private async void button21_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBuscarFacturaId.Text.Trim(), out int facturaId))
            {
                MessageBox.Show("Ingrese un ID de factura válido.");
                return;
            }

            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/Factura/") };
                var response = await client.GetAsync($"ConsultarFacturaPorFactura/{facturaId}");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var factura = JsonConvert.DeserializeObject<FacturaCreada>(json);
                    dataGridViewFacturas.DataSource = new List<FacturaCreada> { factura };

                    dataGridViewFacturas.DataSource = new List<dynamic> { factura };
                }
                else
                {
                    MessageBox.Show("Factura no encontrada.");
                    dataGridViewFacturas.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la factura:\n" + ex.Message);
            }
        }

        private async void button22_Click(object sender, EventArgs e)
        {
            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/Factura/") };
                var response = await client.GetAsync("ListarFacturas");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var lista = JsonConvert.DeserializeObject<List<dynamic>>(json);

                    dataGridViewFacturas2.DataSource = lista;
                }
                else
                {
                    MessageBox.Show("No se pudieron obtener las facturas.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:\n" + ex.Message);
            }
        }

        private async void button24_Click(object sender, EventArgs e)
        {
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5263/api/");

                var response = await client.GetAsync("Cliente/ListarClientes");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var clientes = JsonConvert.DeserializeObject<List<Cliente>>(json);

                if (clientes != null && clientes.Any())
                {
                    PdfClienteReport.Generar(clientes);
                }
                else
                {
                    MessageBox.Show("No se encontraron clientes para generar el reporte.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte:\n" + ex.Message);
            }
        }

        private async void button33_Click(object sender, EventArgs e)
        {
            using var http = new HttpClient();
            var facturas = await http.GetFromJsonAsync<List<FacturaCreada>>("http://localhost:5263/api/Factura/ListarFacturas");
            PdfFacturaReport.Generar(facturas);
        }

        private async void button35_Click(object sender, EventArgs e)
        {
            using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/") };
            var response = await client.GetAsync("api/Pedido/ObtenerPedidos");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var pedidos = JsonConvert.DeserializeObject<List<AppCore.MenuFrm.Pedido>>(json);

                var pedidosConvertidos = pedidos.Select(p => new AppCore.Models.PedidoCreado
                {
                    PedidoID = p.PedidoId,
                    ClienteID = p.ClienteId,
                    Estado = p.Estado,
                    Total = p.Total,
                    FechaPedido = p.FechaPedido
                }).ToList();

                PdfPedidoReport.Generar(pedidosConvertidos);
            }
            else
            {
                MessageBox.Show("No se pudieron obtener los pedidos.");
            }
        }

        private async void button34_Click(object sender, EventArgs e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://localhost:5263");

                    var response = await httpClient.GetAsync("/api/Producto/ObtenerProductos");

                    if (response.IsSuccessStatusCode)
                    {
                        var contenido = await response.Content.ReadAsStringAsync();
                        var productos = JsonConvert.DeserializeObject<List<Producto>>(contenido);

                        PdfProductoReport.Generar(productos);
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron obtener los productos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void button37_Click(object sender, EventArgs e)
        {
            using var http = new HttpClient();
            var proveedores = await http.GetFromJsonAsync<List<Proveedor>>("http://localhost:5263/api/Proveedor/ListarProveedores");
            PdfProveedorReport.Generar(proveedores);
        }

        private async void button36_Click(object sender, EventArgs e)
        {
            using var http = new HttpClient();
            var usuarios = await http.GetFromJsonAsync<List<Usuario>>("http://localhost:5263/api/Usuario/ListarUsuarios");
            PdfUsuarioReport.Generar(usuarios);
        }
    }


}

