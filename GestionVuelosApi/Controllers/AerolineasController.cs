using GestionVuelosApi.Interfaces;
using GestionVuelosApi.Logica;
using GestionVuelosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionVuelosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AerolineasController : Controller
    {
        [HttpGet]
        public IActionResult ConsultarAerolineas()
        {
            IVuelos iVuelos = new VuelosLogica();
            Response response = iVuelos.ConsultarAerolineas();
            return Ok(response);
        }
    }
}
