using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public class FacturaCreada
    {
        public int FacturaID { get; set; }
        public int PedidoId { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public DateTime FechaFactura { get; set; }
    }
}
