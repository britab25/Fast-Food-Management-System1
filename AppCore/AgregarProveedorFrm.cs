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
    public partial class AgregarProveedorFrm : Form
    {
        public AgregarProveedorFrm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var proveedor = new
            {
                NombreProveedor = txtNombreProveedor.Text,
                Descripcion = txtDescripcion.Text
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Proveedor/");

                    var json = JsonConvert.SerializeObject(proveedor);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("RegistrarProveedor", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Proveedor registrado exitosamente.");
                        this.Close(); // Cierra la ventana actual
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al registrar el proveedor:\n{errorContent}");
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
