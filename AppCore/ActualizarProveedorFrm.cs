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
    public partial class ActualizarProveedorFrm : Form
    {
        public ActualizarProveedorFrm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCodigoProveedor.Text, out int codigoProveedor))
            {
                MessageBox.Show("El Código del Proveedor debe ser un número válido.");
                return;
            }

            var proveedorDto = new
            {
                NombreProveedor = txtNombreProveedor.Text,
                Descripcion = txtDescripcion.Text
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Proveedor/");

                    var json = JsonConvert.SerializeObject(proveedorDto);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"ActualizarProveedor/{codigoProveedor}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Proveedor actualizado correctamente.");
                        this.Close(); // opcional
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al actualizar el proveedor:\n{error}");
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
