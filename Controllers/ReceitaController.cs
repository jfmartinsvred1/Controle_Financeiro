using AutoMapper;
using Controle_Financeiro.Data;
using Controle_Financeiro.Data.DTOS;
using Controle_Financeiro.Models;
using Controle_Financeiro.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controle_Financeiro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ReceitaController:ControllerBase
    {
        
        private ReceitaService _receitaService;

        public ReceitaController(ReceitaService receitaService)
        {
           
            _receitaService = receitaService;
        }

        [HttpPost]
        public IActionResult AdicionaReceita([FromBody] CreateReceitaDto receitaDto)
        {
            _receitaService.AdicionaReceita(receitaDto);
            return Ok("Receita adicionada com sucesso!");

        }
        [HttpGet]
        
        public IEnumerable<ReadReceitaDto> GetReceita() 
        {
            return _receitaService.RetornaReceitas();

        }

        [HttpGet("{id}")]

        public IActionResult GetReceitaId(int id)
        {
            return Ok(_receitaService.RetornaReceitaId(id));
        }

        [HttpPut("{id}")]

        public IActionResult AtualizaReceita(int id, [FromBody] UpdateReceitaDto updateReceitaDto)
        {
            
            _receitaService.AtualizaReceita(id, updateReceitaDto);
            return Ok("Atualizado com sucesso!");


        }
        [HttpDelete("{id}")]

        public IActionResult DeletarReceita(int id)
        {
            _receitaService.DeletaReceita(id);
            return Ok("Deletada com sucesso!");
        }
        [HttpGet("/receita/descricao={desc}")]
        public IEnumerable<ReadReceitaDto> GetReceitaPorDesc(string desc)
        {
            return _receitaService.RetornaReceitaPorDesc(desc);
            
        }
        [HttpGet("/receita/{ano}/{mes}")]
        public IEnumerable<ReadReceitaDto> GetReceitaPorMesEAno(int ano,int mes)
        {
            return _receitaService.RetornaReceitaPorMesEAno(ano,mes);
            
        }

    }

}
