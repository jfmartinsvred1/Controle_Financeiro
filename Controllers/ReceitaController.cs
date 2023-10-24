using AutoMapper;
using Controle_Financeiro.Data;
using Controle_Financeiro.Data.DTOS;
using Controle_Financeiro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controle_Financeiro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceitaController:ControllerBase
    {
        private ControleFinanceiroContext _context;
        private IMapper _mapper;

        public ReceitaController(ControleFinanceiroContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaReceita([FromBody] CreateReceitaDto receitaDto)
        {
            var receita = _mapper.Map<Receita>(receitaDto);
            var tentativa=_context.Tb_Receitas.Where(p=>p.Descricao_Receita==receita.Descricao_Receita && 
            p.Data_Receita.Month==receita.Data_Receita.Month);
            if (tentativa.Count()==0)
            {
                _context.Tb_Receitas.Add(receita);
                _context.SaveChanges();
                return Ok("Receita adicionada com sucesso!");
            }
            else
            {
                return BadRequest("Já foi registrado essa receita!");
            }

        }
        [HttpGet]
        
        public IEnumerable<ReadReceitaDto> GetReceita() 
        {
            return _mapper.Map<List<ReadReceitaDto>>(_context.Tb_Receitas);

        }

        [HttpGet("{id}")]

        public IActionResult GetReceitaId(int id)
        {
            var receita=_context.Tb_Receitas.FirstOrDefault(p=>p.Id_Receita==id);
            if (receita==null) return NotFound("A Receita não exite!");
            else
            {
                var receitaDto = _mapper.Map<ReadReceitaDto>(receita);
                return Ok(receitaDto);
            }
        }

        [HttpPut("{id}")]

        public IActionResult AtualizaReceita(int id, [FromBody] UpdateReceitaDto updateReceitaDto)
        {
            var receita = _context.Tb_Receitas.FirstOrDefault(p=> p.Id_Receita==id);

            if (receita == null) return NotFound("Não exite essa receita.");

            var tentativa = _context.Tb_Receitas.FirstOrDefault(r=>r.Descricao_Receita.ToUpper()==updateReceitaDto.Descricao_Receita.ToUpper() 
            && r.Data_Receita.Month==updateReceitaDto.Data_Receita.Month);

            if (tentativa!=null) return BadRequest("Já exite essa receita cadastrada!");
            _mapper.Map(updateReceitaDto, receita);
            _context.SaveChanges();
            return Ok(receita);


        }
        [HttpDelete("{id}")]

        public IActionResult DeletarReceita(int id)
        {
            var receita=_context.Tb_Receitas.FirstOrDefault(p=>p.Id_Receita==id);
            if (receita == null) return NotFound("Não exite essa receita cadastrada!");
            
            _context.Remove(receita);
            _context.SaveChanges();
            return Ok("Receita deletada com sucesso!");
        }
        [HttpGet("/receita/descricao={desc}")]
        public IEnumerable<ReadReceitaDto> GetReceitaPorDesc(string desc)
        {
            var receitas = _context.Tb_Receitas;
            List<ReadReceitaDto> list= new List<ReadReceitaDto>();
            foreach(var receita in receitas)
            {
                if (receita.Descricao_Receita.Contains(desc))
                {
                    list.Add(_mapper.Map<ReadReceitaDto>(receita));
                }
            }
            return list;
        }
        [HttpGet("/receita/{ano}/{mes}")]
        public IEnumerable<ReadReceitaDto> GetReceitaPorMesEAno(int ano,int mes)
        {
            var list= new List<ReadReceitaDto>();
            var receitas= _context.Tb_Receitas;
            foreach(var receita in receitas)
            {
                if(receita.Data_Receita.Month== mes && receita.Data_Receita.Year == ano)
                {
                    list.Add(_mapper.Map<ReadReceitaDto>(receita));
                }
            }
            return list;
        }

    }

}
