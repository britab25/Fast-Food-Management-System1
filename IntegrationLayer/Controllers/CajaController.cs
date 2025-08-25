using Microsoft.AspNetCore.Mvc;
using IntegrationLayer.Models;

namespace IntegrationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CajaController : ControllerBase
    {
        [HttpPost("registrar-factura")]
        public IActionResult RegistrarFactura([FromBody] FacturaModel factura)
        {
            // Aquí puedes simular enviar al Core o guardar localmente
            return Ok(new { mensaje = "Factura recibida", factura });
        }
    }
}
