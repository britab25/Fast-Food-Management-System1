using System.Net.Http.Json;
using System.Windows.Forms;

namespace CajaApp
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
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
                ClaveHash = clave
            };

            try
            {
                btnLogin.Enabled = false;
                Cursor = Cursors.WaitCursor;

                using var client = new HttpClient();

                var response = await client.PostAsJsonAsync("http://localhost:5263/api/Usuario/Login", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();

                    if (loginResponse != null)
                    {
                        MessageBox.Show("Login exitoso!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Abrir FrmPrincipal después del login exitoso
                        FrmPrincipal formPrincipal = new FrmPrincipal(
                            loginResponse.Nombre,
                            loginResponse.Token,
                            loginResponse.UsuarioId
                        );
                        formPrincipal.Show();
                        this.Hide();

                        formPrincipal.FormClosed += (s, args) => this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo procesar la respuesta del servidor.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Login fallido: {response.StatusCode}\n{error}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de conexión HTTP: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                Cursor = Cursors.Default;
            }
        }


        private void FrmLogin_Load(object sender, System.EventArgs e)
        {
            // Nada necesario aquí por ahora
        }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
    }
}
