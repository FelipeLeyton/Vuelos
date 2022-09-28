using GestionVuelosApi.Interfaces;
using GestionVuelosApi.Logica;
using GestionVuelosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionVuelosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadosController : ControllerBase
    {
        [HttpGet]
        public IActionResult ConsultarEstados()
        {
            IVuelos iVuelos = new VuelosLogica();
            Response response = iVuelos.ConsultarEstados();
            return Ok(response);
        }
    }
}
