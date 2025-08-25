using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiFrituraV2.Models;

namespace AppCore
{
    public partial class DetallePedidoFrm : Form
    {
        private int _pedidoId;
        public DetallePedidoFrm(int pedidoId)
        {
            InitializeComponent();

            _pedidoId = pedidoId;
            lblPedidoID.Text = pedidoId.ToString();
            dataGridViewDetalles.AutoGenerateColumns = true;

        }

        private void DetallePedidoFrm_Load(object sender, EventArgs e)
        {

        }

        private void CargarDetalles()
        {
            try
            {
                using var connection = new SqlConnection("Server=10.0.0.13,1435;Database=TiendaFriturasDB;User Id=sa;Password=StrongPassw0rd!;TrustServerCertificate=True");
                connection.Open();

                string query = @"
            SELECT 
                dp.PedidoID,
                dp.ProductoID,
                p.Nombre AS Producto,
                dp.Cantidad,
                dp.PrecioUnitario,
                dp.Cantidad * dp.PrecioUnitario AS Subtotal,
                ped.ClienteID,
                ped.Estado,
                ped.Total
            FROM DetallePedidos dp
            JOIN Productos p ON dp.ProductoID = p.ProductoId
            JOIN Pedidos ped ON dp.PedidoID = ped.PedidoID
            WHERE dp.PedidoID = @PedidoID";

                using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PedidoID", _pedidoId);

                using var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);

                dataGridViewDetalles.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProductoID.Text.Trim(), out int productoId))
            {
                MessageBox.Show("ID de producto inválido.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("Server=MSI\\MYSQLSERVER;Database=TiendaFriturasDB;Trusted_Connection=True;TrustServerCertificate=True;"))
                {
                    conn.Open();

                    string query = "SELECT Nombre, Precio FROM Productos WHERE ProductoID = @ProductoID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductoID", productoId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNombreProducto.Text = reader["Nombre"].ToString();
                                txtPrecioUnitario.Text = reader["Precio"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Producto no encontrado.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar producto:\n" + ex.Message);
            }
        }


        private void Anadir_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProductoID.Text.Trim(), out int productoId) ||
        !int.TryParse(txtCantidad.Text.Trim(), out int cantidad) ||
        !decimal.TryParse(txtPrecioUnitario.Text.Trim(), out decimal precioUnitario))
            {
                MessageBox.Show("Datos inválidos. Verifica el ID, cantidad y precio.");
                return;
            }

            string estado = txtEstado.Text.Trim();  // Asumiendo que agregaste un TextBox para el estado
            if (string.IsNullOrEmpty(estado))
            {
                MessageBox.Show("Debe ingresar el estado del pedido.");
                return;
            }

            try
            {
                using var connection = new SqlConnection("Server=MSI\\MYSQLSERVER;Database=TiendaFriturasDB;Trusted_Connection=True;TrustServerCertificate=True;");
                connection.Open();

                // 1. Insertar detalle
                using (var cmdInsert = new SqlCommand("sp_RegistrarDetallePedido", connection))
                {
                    cmdInsert.CommandType = CommandType.StoredProcedure;
                    cmdInsert.Parameters.AddWithValue("@PedidoID", _pedidoId);
                    cmdInsert.Parameters.AddWithValue("@ProductoID", productoId);
                    cmdInsert.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmdInsert.Parameters.AddWithValue("@PrecioUnitario", precioUnitario);

                    cmdInsert.ExecuteNonQuery();
                }

                // 2. Actualizar total y estado
                using (var cmdUpdate = new SqlCommand("sp_ActualizarTotalYEstado", connection))
                {
                    cmdUpdate.CommandType = CommandType.StoredProcedure;
                    cmdUpdate.Parameters.AddWithValue("@PedidoID", _pedidoId);
                    cmdUpdate.Parameters.AddWithValue("@Estado", estado);

                    cmdUpdate.ExecuteNonQuery();
                }

                MessageBox.Show("Detalle añadido y total actualizado.");

                // 3. Recargar DataGridView
                CargarDetalles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }
    }
}
