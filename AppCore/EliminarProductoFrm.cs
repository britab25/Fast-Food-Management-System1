using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCore
{
    public partial class EliminarProductoFrm : Form
    {

        public EliminarProductoFrm()
        {
            InitializeComponent();
        }

        private readonly string apiBaseUrl = "http://localhost:5263/api/Producto/";

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProductoId.Text.Trim(), out int productoId))
            {
                MessageBox.Show("Ingrese un ID válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult != DialogResult.Yes)
                return;

            btnEliminar.Enabled = false;

            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(apiBaseUrl);  // ¡Con barra al final!
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync($"EliminarProducto/{productoId}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Producto eliminado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtProductoId.Clear();
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Producto no encontrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al eliminar: {error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión o servidor:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnEliminar.Enabled = true;
            }
        }


        private void txtProductoId_TextChanged(object sender, EventArgs e)
        {
            // Validación opcional en tiempo real
        }
    }
}
