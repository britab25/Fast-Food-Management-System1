using IntegrationLayer.Models;
using System.Text.Json;

namespace IntegrationLayer.Data
{
    public class BackupQueueService
    {
        private readonly string _filePath = "Data/BackupQueue.json";

        public async Task GuardarTransaccionAsync(FacturaModel factura)
        {
            List<FacturaModel> transacciones = new();

            if (File.Exists(_filePath))
            {
                var json = await File.ReadAllTextAsync(_filePath);
                if (!string.IsNullOrEmpty(json))
                    transacciones = JsonSerializer.Deserialize<List<FacturaModel>>(json) ?? new();
            }

            transacciones.Add(factura);

            var output = JsonSerializer.Serialize(transacciones, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, output);
        }
    }
}
