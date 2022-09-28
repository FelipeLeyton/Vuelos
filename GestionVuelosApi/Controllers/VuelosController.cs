using GestionVuelosApi.Interfaces;
using GestionVuelosApi.Logica;
using GestionVuelosApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionVuelosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VuelosController : Controller
    {
        [HttpGet]
        public IActionResult ConsultarVuelos()
        {
            IVuelos iVuelos = new VuelosLogica();
            Response response = iVuelos.ConsultarVuelos();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult ConsultarVuelosById(int id)
        {
            IVuelos iVuelos = new VuelosLogica();
            Response response = iVuelos.ConsultarVuelosById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult RegistrarVuelo(RegistroVuelosModel registroVuelo)
        {
            IVuelos iVuelos = new VuelosLogica();
            Response response = iVuelos.RegistrarVuelo(registroVuelo);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult EditarVuelo(RegistroVuelosModel EditarVuelo)
        {
            IVuelos iVuelos = new VuelosLogica();
            Response response = iVuelos.EditarVuelo(EditarVuelo);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult EliminarVuelo(int id)
        {
            IVuelos iVuelos = new VuelosLogica();
            Response response = iVuelos.EliminarVuelo(id);
            return Ok(response);
        }
    }
}
