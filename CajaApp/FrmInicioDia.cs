using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows.Forms;

namespace CajaApp
{
    public partial class FrmInicioDia : Form
    {
        private readonly string _nombreCajero;
        private readonly string _token;
        private readonly int _usuarioId;

        public FrmInicioDia(string nombreCajero, string token, int usuarioId)
        {
            InitializeComponent();
            _nombreCajero = nombreCajero;
            _token = token;
            _usuarioId = usuarioId;

            lblCajero.Text = $"Cajero: {_nombreCajero}";
        }

        private async void btnIniciarDia_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMontoInicial.Text, out decimal montoInicial) || montoInicial <= 0)
            {
                MessageBox.Show("Ingrese un monto inicial válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoInicial.Focus();
                return;
            }

            try
            {
                btnIniciarDia.Enabled = false;
                Cursor = Cursors.WaitCursor;

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var aperturaDto = new
                {
                    UsuarioId = _usuarioId,
                    MontoInicial = montoInicial,
                    Observaciones = txtObservaciones.Text.Trim()
                };

                string url = "http://localhost:5263/api/Caja/AperturaCaja";

                var response = await client.PostAsJsonAsync(url, aperturaDto);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Inicio del día (apertura de caja) registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FrmPrincipal frmPrincipal = new FrmPrincipal(_nombreCajero, _token, _usuarioId);
                    frmPrincipal.Show();

                    this.Hide();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error del servidor: {response.StatusCode}\n{error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de conexión HTTP: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnIniciarDia.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void FrmInicioDia_Load(object sender, EventArgs e)
        {
            // Si necesitas algo al cargar
            timer1.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaHora_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
