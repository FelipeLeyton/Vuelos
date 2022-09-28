using GestionVuelosApi.Models;

namespace GestionVuelosApi.Interfaces
{
    public interface IVuelos
    {
        Response RegistrarVuelo(RegistroVuelosModel registroVuelo);
        Response EditarVuelo(RegistroVuelosModel EditarVuelo);
        Response ConsultarVuelos();
        Response ConsultarVuelosById(int id);
        Response ConsultarCiudades();
        Response ConsultarAerolineas();
        Response ConsultarEstados();
        Response EliminarVuelo(int id);
    }
}
