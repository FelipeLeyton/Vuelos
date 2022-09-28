using GestionVuelosApi.Interfaces;
using GestionVuelosApi.Logica;
using GestionVuelosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionVuelosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CiudadesController : Controller
    {
        [HttpGet]
        public IActionResult ConsultarCiudades()
        {
            IVuelos iVuelos = new VuelosLogica();
            Response response = iVuelos.ConsultarCiudades();
            return Ok(response);
        }
    }
}
