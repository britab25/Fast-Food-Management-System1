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
    public partial class ActualizarUsuario : Form
    {
        public ActualizarUsuario()
        {
            InitializeComponent();
        }

        private async void Guardarbtn1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtUsuarioID.Text.Trim(), out int usuarioId))
            {
                MessageBox.Show("ID de usuario inválido.");
                return;
            }

            var usuarioActualizado = new
            {
                Nombre = txtNombre.Text.Trim(),
                Rol = txtRol.Text.Trim(),
                UsuarioLogin = "",  // No lo estás capturando en el form
                ClaveHash = ""      // No lo estás capturando tampoco
            };

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5263/api/Usuario/");

                    var json = JsonConvert.SerializeObject(usuarioActualizado);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(usuarioId.ToString(), content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Usuario actualizado correctamente.");
                        this.Close();
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al actualizar el usuario:\n{error}");
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
