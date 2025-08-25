using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public class PedidoCreado
    {
        public int? PedidoID { get; set; }
        public int? ClienteID { get; set; }
        public string Estado { get; set; }
        public decimal? Total { get; set; }
        public DateTime? FechaPedido { get; set; }
    }
}
