using IntegrationLayer.Models;

namespace IntegrationLayer.Services
{
    public interface ICoreService
    {
        Task<string> EnviarFacturaAsync(FacturaModel factura);
    }
}
