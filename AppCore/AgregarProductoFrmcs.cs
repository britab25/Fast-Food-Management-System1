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
    public partial class AgregarProductoFrmcs : Form
    {
        public AgregarProductoFrmcs()
        {
            InitializeComponent();
        }

        private async void Guardarbtn_Click(object sender, EventArgs e)
        {
            var producto = new
            {
                Nombre = txtNombre.Text,
                Precio = decimal.TryParse(txtPrecio.Text, out var precio) ? precio : 0,
                Categoria = txtCategoria.Text,
                Stock = int.TryParse(txtStock.Text, out var stock) ? stock : 0,
                Descripcion = txtDescripcion.Text,
                CodigoProveedor = int.TryParse(txtCodigoProveedor.Text, out var proveedor) ? proveedor : 0
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Producto/");

                    var json = JsonConvert.SerializeObject(producto);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("RegistrarProducto", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Producto registrado exitosamente.");
                        this.Close();
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al registrar el producto:\n{errorContent}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }
    }
}
