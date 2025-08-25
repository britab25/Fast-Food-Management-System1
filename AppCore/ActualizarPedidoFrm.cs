using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCore
{
    public partial class ActualizarPedidoFrm : Form
    {
        public ActualizarPedidoFrm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPedidoID1.Text.Trim(), out int pedidoId))
            {
                MessageBox.Show("ID de pedido inválido.");
                return;
            }

            string nuevoEstado = txtNuevoEstado.Text.Trim();
            if (string.IsNullOrWhiteSpace(nuevoEstado))
            {
                MessageBox.Show("Por favor ingresa un nuevo estado.");
                return;
            }

            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/Pedido/") };

                // Obtener primero el pedido actual para recuperar ClienteID y Total
                var getResponse = await client.GetAsync($"ConsultarPedidoPorPedido/{pedidoId}");

                if (!getResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("No se pudo obtener el pedido para actualizar.");
                    return;
                }

                var pedidoExistenteJson = await getResponse.Content.ReadAsStringAsync();
                dynamic pedidoExistente = JsonConvert.DeserializeObject(pedidoExistenteJson);

                var pedidoActualizado = new
                {
                    ClienteID = (int)pedidoExistente.clienteID,
                    Total = (decimal)pedidoExistente.total,
                    Estado = nuevoEstado
                };

                var content = new StringContent(JsonConvert.SerializeObject(pedidoActualizado), Encoding.UTF8, "application/json");

                var putResponse = await client.PutAsync($"ActualizarPedidoPorPedido/{pedidoId}", content);

                if (putResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Pedido actualizado correctamente.");
                }
                else
                {
                    string error = await putResponse.Content.ReadAsStringAsync();
                    MessageBox.Show("Error al actualizar el pedido:\n" + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado:\n" + ex.Message);
            }
        }

        private void ActualizarPedidoFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
