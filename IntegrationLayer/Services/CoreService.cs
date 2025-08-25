using IntegrationLayer.Models;
using System.Text.Json;
using System.Net.Http;
using System.Text;
using IntegrationLayer.Data;

namespace IntegrationLayer.Services
{
    public class CoreService : ICoreService
    {
        private readonly HttpClient _httpClient;
        private readonly BackupQueueService _backupService;

        public CoreService(HttpClient httpClient, BackupQueueService backupService)
        {
            _httpClient = httpClient;
            _backupService = backupService;
        }

        public async Task<string> EnviarFacturaAsync(FacturaModel factura)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(factura), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://core.local/api/factura", content); // Simulado

                if (response.IsSuccessStatusCode)
                    return "Factura enviada al CORE";

                throw new Exception("Error del CORE");
            }
            catch
            {
                await _backupService.GuardarTransaccionAsync(factura);
                return "CORE no disponible. Factura guardada para reintento.";
            }
        }
    }
}
