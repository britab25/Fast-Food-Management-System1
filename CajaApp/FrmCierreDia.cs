using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaApp
{
    public partial class FrmCierreDia : Form
    {
        private readonly string _nombreCajero;
        private readonly string _token;
        private readonly int _usuarioId;
        private readonly int _aperturaId;

        public FrmCierreDia(string nombreCajero, string token, int usuarioId, int aperturaId)
        {
            InitializeComponent();
            _nombreCajero = nombreCajero;
            _token = token;
            _usuarioId = usuarioId;
            _aperturaId = aperturaId;
        }

        private async void FrmCierreDia_Load(object sender, EventArgs e)
        {
            lblCajero.Text = $"Cajero: {_nombreCajero}";
            await CargarDatosAperturaYVentasAsync();
        }

        private async Task CargarDatosAperturaYVentasAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                // Obtener historial de apertura para el día actual y usuario
                string urlHistorial = $"http://localhost:5263/api/Caja/HistorialCaja?fecha={DateTime.Today:yyyy-MM-dd}";
                var responseHistorial = await client.GetAsync(urlHistorial);
                if (!responseHistorial.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al obtener historial para la apertura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var jsonHistorial = await responseHistorial.Content.ReadAsStringAsync();
                var historial = JsonSerializer.Deserialize<List<HistorialCajaModel>>(jsonHistorial, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var aperturaHistorial = historial?.Find(h =>
                    h.TipoEvento?.Equals("Apertura", StringComparison.OrdinalIgnoreCase) == true &&
                    h.UsuarioID == _usuarioId
                );

                if (aperturaHistorial == null)
                {
                    MessageBox.Show("No se encontró apertura para el usuario en el día.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var fechaApertura = aperturaHistorial.FechaHora.Date;

                // Obtener ventas del día
                string urlVentas = $"http://localhost:5263/api/Caja/ReporteVentasDia?fecha={fechaApertura:yyyy-MM-dd}";
                var responseVentas = await client.GetAsync(urlVentas);

                decimal totalVentasDia = 0m;
                if (responseVentas.IsSuccessStatusCode)
                {
                    var jsonVentas = await responseVentas.Content.ReadAsStringAsync();
                    var ventas = JsonSerializer.Deserialize<List<VentaDia>>(jsonVentas, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    if (ventas != null)
                    {
                        foreach (var v in ventas)
                            totalVentasDia += v.Total;
                    }
                }
                else
                {
                    MessageBox.Show($"Error al obtener ventas del día: {responseVentas.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCerrarDia_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtMontoFinal.Text, out decimal montoFinal) || montoFinal <= 0)
            {
                MessageBox.Show("Ingrese un monto final válido mayor que cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoFinal.Focus();
                return;
            }

            btnCerrarDia.Enabled = false;

            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var cierreDto = new
                {
                    UsuarioId = _usuarioId,
                    MontoFinal = montoFinal,
                    Observaciones = txtObservacion.Text?.Trim() ?? ""
                };

                string urlCerrarCaja = "http://localhost:5263/api/Caja/CierreCaja";

                var responseCerrar = await client.PostAsJsonAsync(urlCerrarCaja, cierreDto);

                if (responseCerrar.IsSuccessStatusCode)
                {
                    lblEstado.Text = "Cierre de caja registrado correctamente.";
                    lblEstado.ForeColor = Color.Green;
                    btnCerrarDia.Enabled = false;
                }
                else
                {
                    var error = await responseCerrar.Content.ReadAsStringAsync();
                    lblEstado.Text = $"Error: {responseCerrar.StatusCode} - {error}";
                    lblEstado.ForeColor = Color.Red;
                    btnCerrarDia.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = $"Error inesperado: {ex.Message}";
                lblEstado.ForeColor = Color.Red;
                btnCerrarDia.Enabled = true;
            }
        }

        // MODELOS internos usados para deserializar JSON
        private class HistorialCajaModel
        {
            public int HistorialCajaID { get; set; }
            public int UsuarioID { get; set; }
            public DateTime FechaHora { get; set; }
            public string TipoEvento { get; set; }
            public decimal? MontoInicial { get; set; }
            public decimal? MontoFinal { get; set; }
            public string Observaciones { get; set; }
        }

        private class VentaDia
        {
            public int FacturaId { get; set; }
            public int PedidoId { get; set; }
            public DateTime FechaFactura { get; set; }
            public decimal Total { get; set; }
            public string Estado { get; set; }
        }

        private void lblCajero_Click(object sender, EventArgs e)
        {

        }
    }
}
