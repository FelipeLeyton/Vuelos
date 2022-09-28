namespace GestionVuelosApi.Models
{
    public class VuelosModel
    {
        public int Id { get; set; }
        public string? CiudadOrigen { get; set; }
        public string? CiudadDestino { get; set; }
        public DateTime Fecha { get; set; }
        public string? HoraSalida { get; set; }
        public string? HoraLlegada { get; set; }
        public string? NumeroVuelo { get; set; }
        public string? Aerolinea { get; set; }
        public string? Estado { get; set; }
    }
}
