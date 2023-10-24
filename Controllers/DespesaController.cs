using AutoMapper;
using Controle_Financeiro.Data.DTOS;
using Controle_Financeiro.Data;
using Controle_Financeiro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controle_Financeiro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DespesaController : ControllerBase
    {
        private ControleFinanceiroContext _context;
        private IMapper _mapper;

        public DespesaController(ControleFinanceiroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaDespesa([FromBody] CreateDespesaDto despesaDto)
        {
            var despesa = _mapper.Map<Despesa>(despesaDto);
            var tentativa = _context.Tb_Despesas.Where(p => p.Descricao_Despesa == despesa.Descricao_Despesa &&
            p.Data_Despesa.Month == despesa.Data_Despesa.Month);
            if (tentativa.Count() == 0)
            {
                var cat = RetornaCategoria(despesa.NomeCategoria);
                despesa.NomeCategoria = cat;
                _context.Tb_Despesas.Add(despesa);
                _context.SaveChanges();
                return Ok("Despesa adicionada com sucesso!");
            }
            else
            {
                return BadRequest("Já foi registrado essa Despesa!");
            }

        }
        [HttpGet]

        public IEnumerable<ReadDespesaDto> GetDespesa()
        {
            var context = _context.Tb_Despesas;
            var despesas=_mapper.Map<List<ReadDespesaDto>>(context);
            return despesas;
        }

        [HttpGet("{id}")]

        public IActionResult GetDespesaId(int id)
        {
            var despesa = _context.Tb_Despesas.FirstOrDefault(p => p.Id_Despesa == id);
            if (despesa == null) return NotFound("A Despesa não exite!");
            else
            {
                var despesaDto = _mapper.Map<ReadDespesaDto>(despesa);
                return Ok(despesaDto);
            }
        }

        [HttpPut("{id}")]

        public IActionResult AtualizaDespesa(int id, [FromBody] UpdateDespesaDto updateDespesaDto)
        {
            var despesa = _context.Tb_Despesas.FirstOrDefault(p => p.Id_Despesa == id);

            if (despesa == null) return NotFound("Não exite essa despesa.");

            var tentativa = _context.Tb_Despesas.FirstOrDefault(r => r.Descricao_Despesa.ToUpper() == updateDespesaDto.Descricao_Despesa.ToUpper()
            && r.Data_Despesa.Month == updateDespesaDto.Data_Despesa.Month);

            if (tentativa != null) return BadRequest("Já exite essa despesa cadastrada!");
            _mapper.Map(updateDespesaDto, despesa);
            _context.SaveChanges();
            return Ok(despesa);


        }
        [HttpDelete("{id}")]

        public IActionResult DeletarDespesa(int id)
        {
            var despesa = _context.Tb_Despesas.FirstOrDefault(p => p.Id_Despesa == id);
            if (despesa == null) return NotFound("Não exite essa despesa cadastrada!");

            _context.Remove(despesa);
            _context.SaveChanges();
            return Ok("Despesa deletada com sucesso!");
        }

        [HttpGet("/despesas/descricao={descricao}")]
        public IEnumerable<ReadDespesaDto> GetDespesaPorDesc(string descricao)
        {
            var despesas = _context.Tb_Despesas;
            List<Despesa> despesasRetorna=new List<Despesa>();

            foreach (var despesa in despesas)
            {
                if (despesa.Descricao_Despesa.Contains(descricao))
                {
                    despesasRetorna.Add(despesa);
                }
            }
            return  _mapper.Map<List<ReadDespesaDto>>(despesasRetorna);
        }
        [HttpGet("/despesa/{ano}/{mes}")]
        public IEnumerable<ReadDespesaDto> GetDespesasPorAnoEMes(int ano, int mes) 
        {
            var list=new List<ReadDespesaDto>();
            var listDespesasDb = _context.Tb_Despesas;
            foreach(var despesas in listDespesasDb)
            {
                if(despesas.Data_Despesa.Month==mes&&despesas.Data_Despesa.Year==ano)
                {
                    list.Add(_mapper.Map<ReadDespesaDto>(despesas));
                }
            }
            return list;
        }
        internal string RetornaCategoria(string categoria)
        {
            var cat = _context.Categorias;
            var nomeReturn = "";
            foreach(var c in cat)
            {
                if (c.NomeCategoria.ToUpper() == categoria.ToUpper())
                {
                    nomeReturn= c.NomeCategoria;
                }
            }
            if(nomeReturn != "")
            {
                return nomeReturn;
            }
            return "Outros";
            

        }

    }
}
