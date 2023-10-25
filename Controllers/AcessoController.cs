using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Financeiro.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AcessoController:ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "IdadeMinima")]
        public ActionResult Get()
        {
            return Ok("Acesso Permitido");
        }
    }
}
