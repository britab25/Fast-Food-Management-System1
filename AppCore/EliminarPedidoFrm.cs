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
    public partial class EliminarPedidoFrm : Form
    {
        public EliminarPedidoFrm()
        {
            InitializeComponent();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtPedidoId.Text.Trim(), out int pedidoId))
            {
                MessageBox.Show("Por favor ingresa un ID válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"¿Estás seguro de eliminar el pedido con ID {pedidoId}?",
                                          "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using var client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:5263/api/Pedido/");
                    var response = await client.DeleteAsync($"EliminarPedidoPorPedido/{pedidoId}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Pedido eliminado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Opcional: cierra el formulario
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("No se encontró el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Error al eliminar el pedido:\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void txtPedidoId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
