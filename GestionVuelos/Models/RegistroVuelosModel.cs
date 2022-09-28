namespace GestionVuelos.Models
{
    public class RegistroVuelosModel
    {
        public int IdCiudadOrigen { get; set; }
        public int IdCiudadDestino { get; set; }
        public DateTime Fecha { get; set; }
        public string? HoraSalida { get; set; }
        public string? HoraLlegada { get; set; }
        public string? NumeroVuelo { get; set; }
        public int IdAerolinea { get; set; }
        public int IdEstado { get; set; }
    }
}
