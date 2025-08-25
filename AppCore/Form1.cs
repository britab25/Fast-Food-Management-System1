using AppCore.Models;
using System.Net.Http.Json;

namespace AppCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var loginRequest = new
            {
                UsuarioLogin = txtUsuario.Text,
                ClaveHash = txtPassword.Text // Si usas hash, aquí debes generarlo
            };

            var client = new HttpClient();
            var response = await client.PostAsJsonAsync("http://localhost:5263/api/Usuario/Login", loginRequest);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Login exitoso!");
                // Si el login es exitoso, mostramos el formulario de menú
                MenuFrm menuForm = new MenuFrm();
                menuForm.Show();
                this.Hide(); // Oculta el formulario de login
                             // Aquí podrías usar la información recibida (UsuarioId, Nombre, Rol, etc.)
            }
            else
            {
                MessageBox.Show("Credenciales inválidas o error del servidor.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
