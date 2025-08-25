namespace WebApiFrituraV2.Models
{
    public class HistorialCaja
    {
        public int HistorialCajaID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaHora { get; set; }
        public string TipoEvento { get; set; }
        public decimal? MontoInicial { get; set; }
        public decimal? MontoFinal { get; set; }
        public string? Observaciones { get; set; } // <-- ESTA PROPIEDAD DEBE SER NULLABLE

        public Usuario Usuario { get; set; }  // Opcional: si deseas la relación con el usuario
    }

}
