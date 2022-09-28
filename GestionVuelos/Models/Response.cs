namespace GestionVuelos.Models
{
    public class Response
    {
        public int Respuesta { get; set; }
        public string? Mensaje { get; set; }
        public object? Data { get; set; }

        public Response()
        {
            Respuesta = 0;
        }
    }
}
