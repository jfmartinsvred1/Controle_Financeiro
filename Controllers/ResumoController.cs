using Controle_Financeiro.Data;
using Controle_Financeiro.Models;
using Controle_Financeiro.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Financeiro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ResumoController:ControllerBase
    {
        private ResumoService _resumoService;
        

        public ResumoController(ResumoService resumoService)
        {
            _resumoService = resumoService;
        }

        [HttpGet("/resumo/{ano}/{mes}")]
        public Resumo GetResumoMesAno(int ano, int mes)
        {
            return _resumoService.RetornaResumoMesAno(ano, mes);
            
        }

        
    }
}
