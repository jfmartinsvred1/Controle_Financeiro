using AutoMapper;
using Controle_Financeiro.Data;
using Controle_Financeiro.Data.DTOS;
using Controle_Financeiro.Models;

namespace Controle_Financeiro.Services
{
    public class ReceitaService
    {
        private ControleFinanceiroContext _context;
        private IMapper _mapper;

        public ReceitaService(ControleFinanceiroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void AdicionaReceita(CreateReceitaDto receitaDto) 
        {
            var receita = _mapper.Map<Receita>(receitaDto);
            var tentativa = _context.Tb_Receitas.Where(p => p.Descricao_Receita == receita.Descricao_Receita &&
            p.Data_Receita.Month == receita.Data_Receita.Month);
            if (tentativa.Count() != 0)
            {
                throw new ApplicationException("Receita já cadastrada!");
            }
            _context.Tb_Receitas.Add(receita);
            _context.SaveChanges();
        }

        public IEnumerable<ReadReceitaDto> RetornaReceitas()
        {
            return _mapper.Map<List<ReadReceitaDto>>(_context.Tb_Receitas);
        }

        public void AtualizaReceita(int id, UpdateReceitaDto updateReceitaDto)
        {
            var receita = _context.Tb_Receitas.FirstOrDefault(p => p.Id_Receita == id);

            if (receita == null) { throw new ApplicationException("Não exite essa receita."); }

            var tentativa = _context.Tb_Receitas.FirstOrDefault(r => r.Descricao_Receita.ToUpper() == updateReceitaDto.Descricao_Receita.ToUpper()
            && r.Data_Receita.Month == updateReceitaDto.Data_Receita.Month);

            if (tentativa != null) { throw new ApplicationException("Já exite essa receita cadastrada!"); }
            _mapper.Map(updateReceitaDto, receita);
            _context.SaveChanges();
        }

        public ReadReceitaDto RetornaReceitaId(int id)
        {
            var receita = _context.Tb_Receitas.FirstOrDefault(p => p.Id_Receita == id);
            if (receita == null) { throw new ApplicationException("A Receita não exite!"); }
            else
            {
                var receitaDto = _mapper.Map<ReadReceitaDto>(receita);
                return receitaDto;
            }
        }

        public void DeletaReceita(int id)
        {
            var receita = _context.Tb_Receitas.FirstOrDefault(p => p.Id_Receita == id);
            if (receita == null) { throw new ApplicationException("Não exite essa receita cadastrada!"); }

            _context.Remove(receita);
            _context.SaveChanges();
        }

        public IEnumerable<ReadReceitaDto> RetornaReceitaPorDesc(string desc)
        {
            var receitas = _context.Tb_Receitas;
            List<ReadReceitaDto> list = new List<ReadReceitaDto>();
            foreach (var receita in receitas)
            {
                if (receita.Descricao_Receita.Contains(desc))
                {
                    list.Add(_mapper.Map<ReadReceitaDto>(receita));
                }
            }
            return list;
        }

        public IEnumerable<ReadReceitaDto> RetornaReceitaPorMesEAno(int ano, int mes)
        {
            var list = new List<ReadReceitaDto>();
            var receitas = _context.Tb_Receitas;
            foreach (var receita in receitas)
            {
                if (receita.Data_Receita.Month == mes && receita.Data_Receita.Year == ano)
                {
                    list.Add(_mapper.Map<ReadReceitaDto>(receita));
                }
            }
            return list;
        }
    }
}
