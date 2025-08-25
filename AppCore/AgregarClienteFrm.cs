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
    public partial class AgregarClienteFrm : Form
    {
        public AgregarClienteFrm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AgregarClienteFrm_Load(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private async void Guardarbtn_Click(object sender, EventArgs e)
        {
            var cliente = new
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                TipoDocumento = txtTipoDocumento.Text.Trim(),
                NumeroDocumento = txtNumeroDocumento.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            };

            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }

            if (string.IsNullOrEmpty(cliente.NumeroDocumento))
            {
                MessageBox.Show("El número de documento es obligatorio.");
                return;
            }

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Cliente/");

                    var json = JsonConvert.SerializeObject(cliente);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("RegistrarCliente", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Cliente registrado exitosamente.");
                        this.Close();
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al registrar el cliente:\n{response.StatusCode}\n{errorContent}");
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
        
    
