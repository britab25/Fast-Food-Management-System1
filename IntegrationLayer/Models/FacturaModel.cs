namespace IntegrationLayer.Models
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleProducto> Productos { get; set; }
    }

    public class DetalleProducto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
