using AutoMapper;
using Controle_Financeiro.Data.DTOS;
using Controle_Financeiro.Data;
using Controle_Financeiro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Controle_Financeiro.Services;
using Controle_Financeiro.Services.DespesaService;

namespace Controle_Financeiro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    
    public class DespesaController : ControllerBase
    {
        
        private DespesaService _despesaService;

        public DespesaController(DespesaService despesaService)
        {
            _despesaService = despesaService;
        }

        [HttpPost]
        
        public IActionResult AdicionaDespesa([FromBody] CreateDespesaDto despesaDto)
        {
            _despesaService.Cadastra(despesaDto);
            return Ok("Despesa adicionada com sucesso!");

        }
        [HttpGet]

        public IEnumerable<ReadDespesaDto> GetDespesa()
        {
            return _despesaService.RetornaDespesas();

        }

        [HttpGet("{id}")]

        public IActionResult GetDespesaId(int id)
        {
            return Ok(_despesaService.RetornaDepesa(id));
        }

        [HttpPut("{id}")]

        public IActionResult AtualizaDespesa(int id, [FromBody] UpdateDespesaDto updateDespesaDto)
        {
            var despesa=_despesaService.AlteraDespesa(id, updateDespesaDto);
            return Ok(despesa);


        }
        [HttpDelete("{id}")]

        public IActionResult DeletarDespesa(int id)
        {
            _despesaService.DeleteDespesa(id);
            return Ok("Despesa deletada com sucesso!");
        }

        [HttpGet("/despesas/descricao={descricao}")]
        public IEnumerable<ReadDespesaDto> GetDespesaPorDesc(string descricao)
        {
            
            return  _despesaService.GetDespesaDesc(descricao);
        }
        [HttpGet("/despesa/{ano}/{mes}")]
        public IEnumerable<ReadDespesaDto> GetDespesasPorAnoEMes(int ano, int mes) 
        {
            
            return _despesaService.RetornaPorAnoEMes(ano,mes);
        }
        

    }
}
