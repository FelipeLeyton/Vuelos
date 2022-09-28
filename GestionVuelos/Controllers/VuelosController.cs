
using GestionVuelos.Interfaces;
using GestionVuelos.Logica;
using GestionVuelos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionVuelos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        [HttpGet]
        public IActionResult ConsultarVuelo()
        {
            IVuelos iVuelos = new VuelosLogica();
            Response response = iVuelos.ConsultarVuelos();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult RegistrarVuelo(RegistroVuelosModel registroVuelos)
        {
            IVuelos iVuelos = new VuelosLogica();
            Response response = iVuelos.RegistrarVuelos(registroVuelos);
            return Ok(response);
        }
    }
}
