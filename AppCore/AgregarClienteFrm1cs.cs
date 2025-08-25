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
    public partial class AgregarClienteFrm1cs : Form
    {
        public AgregarClienteFrm1cs()
        {
            InitializeComponent();
        }

        private async void Guardarbtn_Click(object sender, EventArgs e)
        {
            string numeroDocumento = txtNumeroDocumento.Text.Trim();

            if (string.IsNullOrWhiteSpace(numeroDocumento))
            {
                MessageBox.Show("Debe ingresar el número de documento del cliente que desea actualizar.");
                return;
            }

            var clienteUpdateDto = new
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Cliente/");

                    string json = JsonConvert.SerializeObject(clienteUpdateDto);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(numeroDocumento, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cliente actualizado exitosamente.");
                        this.Close(); // Cierra el formulario si se desea
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al actualizar el cliente:\n{errorContent}");
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

