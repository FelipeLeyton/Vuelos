using GestionVuelos.Models;

namespace GestionVuelos.Interfaces
{
    public interface IVuelos
    {
        Response RegistrarVuelos(RegistroVuelosModel registroVuelos);
        Response ConsultarVuelos();
    }
}
