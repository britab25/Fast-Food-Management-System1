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
    public partial class AgregarUsuario : Form
    {
        public AgregarUsuario()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void Guardarbtn_Click(object sender, EventArgs e)
        {
            var nuevoUsuario = new
            {
                UsuarioLogin = txtUsuario.Text.Trim(),
                ClaveHash = txtContrasenaa.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Rol = txtRol.Text.Trim()
            };

            if (string.IsNullOrWhiteSpace(nuevoUsuario.UsuarioLogin) ||
                string.IsNullOrWhiteSpace(nuevoUsuario.ClaveHash) ||
                string.IsNullOrWhiteSpace(nuevoUsuario.Nombre) ||
                string.IsNullOrWhiteSpace(nuevoUsuario.Rol))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            try
            {
                using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5263/api/Usuario/") };
                var json = JsonConvert.SerializeObject(nuevoUsuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("RegistrarUsuario", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario registrado.");
                    this.Close();
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al registrar usuario:\n{err}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }
    }
}
