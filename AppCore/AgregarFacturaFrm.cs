using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCore
{
    public partial class AgregarFacturaFrm : Form
    {
        public AgregarFacturaFrm()
        {
            InitializeComponent();

            cmbEstado.Items.AddRange(new string[] { "Efectivo", "Tarjeta" });
            cmbEstado.SelectedIndex = 0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPedidoID5.Text.Trim(), out int pedidoId))
            {
                MessageBox.Show("ID de pedido inválido.");
                return;
            }

            try
            {
                using (var connection = new SqlConnection("Server=10.0.0.13,1435;Database=TiendaFriturasDB;User Id=sa;Password=StrongPassw0rd!;TrustServerCertificate=True"))
                {
                    await connection.OpenAsync();

                    string query = "SELECT SUM(Cantidad * PrecioUnitario) FROM DetallePedidos WHERE PedidoID = @PedidoID";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PedidoID", pedidoId);
                        var result = await command.ExecuteScalarAsync();
                        decimal total = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                        txtTotal.Text = total.ToString("0.00"); // Muestra el total calculado
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el total:\n" + ex.Message);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPedidoID5.Text.Trim(), out int pedidoId))
            {
                MessageBox.Show("ID de pedido inválido.");
                return;
            }

            if (!decimal.TryParse(txtTotal.Text.Trim(), out decimal total))
            {
                MessageBox.Show("Total inválido.");
                return;
            }

            string estado = cmbEstado.Text.Trim();
            if (string.IsNullOrWhiteSpace(estado))
            {
                MessageBox.Show("Debe seleccionar un estado.");
                return;
            }

            var nuevaFactura = new
            {
                PedidoID = pedidoId,
                Total = total,
                Estado = estado
            };

            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/Factura/") };

                var json = JsonConvert.SerializeObject(nuevaFactura);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("RegistrarFactura", content);
                if (response.IsSuccessStatusCode)
                {
                    string respuesta = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Factura creada correctamente.");
                    this.Close();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Error al registrar factura:\n" + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:\n" + ex.Message);
            }
        }
    }
}
