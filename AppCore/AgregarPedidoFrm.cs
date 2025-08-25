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
using AppCore.Models;

namespace AppCore
{
    public partial class AgregarPedidoFrm : Form
    {
        public AgregarPedidoFrm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtClienteID.Text.Trim(), out int clienteId))
            {
                MessageBox.Show("ID de cliente inválido.");
                return;
            }

            var nuevoPedido = new
            {
                ClienteID = clienteId,
                Total = 0m,
                Estado = "Pendiente"
            };

            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/Pedido/") };

                var json = JsonConvert.SerializeObject(nuevoPedido);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("RegistrarPedido", content);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<PedidoCreado>(jsonResponse);

                    if (resultado?.PedidoID == null)
                    {
                        MessageBox.Show("El pedido se creó pero no se devolvió el ID.");
                        return;
                    }

                    // Mostrar el formulario de detalle con el pedidoId
                    var detalleForm = new DetallePedidoFrm(resultado.PedidoID.Value);
                    detalleForm.Show();
                    this.Close();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Error al crear pedido:\n" + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:\n" + ex.Message);
            }
        }
    }
}
