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
    public partial class ActualizarProductoFrm : Form
    {
        public ActualizarProductoFrm()
        {
            InitializeComponent();
        }

        private async void Guardarbtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtProductoId.Text.Trim(), out int productoId))
            {
                MessageBox.Show("ID de producto inválido.");
                return;
            }

            var productoActualizado = new
            {
                Nombre = txtNombre.Text.Trim(), 
                Precio = decimal.TryParse(txtPrecio.Text.Trim(), out var precio) ? precio : 0,
                Categoria = txtCategoria.Text.Trim(),
                Stock = int.TryParse(txtStock.Text.Trim(), out var stock) ? stock : 0,
                Descripcion = txtDescripcion.Text.Trim(),
                CodigoProveedor = int.TryParse(txtCodigoProveedor.Text.Trim(), out var proveedor) ? proveedor : 0
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Producto/");

                    var json = JsonConvert.SerializeObject(productoActualizado);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"ActualizarProducto/{productoId}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Producto actualizado correctamente.");
                        this.Close();
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al actualizar el producto:\n{error}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }
    }
}
