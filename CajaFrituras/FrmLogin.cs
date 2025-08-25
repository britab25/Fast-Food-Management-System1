using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace CajaFrituras
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }



        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string usuarioLogin = txtUsuario.Text.Trim();
            string clave = txtClave.Text;

            if (string.IsNullOrEmpty(usuarioLogin) || string.IsNullOrEmpty(clave))
            {
                MessageBox.Show("Debe ingresar usuario y contraseña.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var loginRequest = new
            {
                UsuarioLogin = usuarioLogin,
                ClaveHash = clave // Aquí se envía la contraseña sin hash
            };

            try
            {
                btnLogin.Enabled = false;
                Cursor = Cursors.WaitCursor;

                using var client = new HttpClient();

                var response = await client.PostAsJsonAsync("http://localhost:5263/api/Usuario/Login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Login exitoso!");

                    // Aquí muestras el menú o siguiente formulario
                    //MenuFrm menuForm = new MenuFrm();
                    //menuForm.Show();
                    //this.Hide();
                }
                else
                {
                    MessageBox.Show("Credenciales inválidas o error del servidor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error de conexión: {ex.Message}");
            }
            finally
            {
                btnLogin.Enabled = true;
                Cursor = Cursors.Default;
            }
        }


        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }



}
