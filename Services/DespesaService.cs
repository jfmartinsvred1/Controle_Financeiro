using AutoMapper;
using Controle_Financeiro.Data;
using Controle_Financeiro.Data.DTOS;
using Controle_Financeiro.Models;
using System.Runtime.InteropServices;

namespace Controle_Financeiro.Services.DespesaService
{
    public class DespesaService
    {
        private ControleFinanceiroContext _context;
        private IMapper _mapper;

        public DespesaService(ControleFinanceiroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Cadastra(CreateDespesaDto dto)
        {
            var despesa = _mapper.Map<Despesa>(dto);
            var tentativa = _context.Tb_Despesas.Where(p => p.Descricao_Despesa == despesa.Descricao_Despesa &&
            p.Data_Despesa.Month == despesa.Data_Despesa.Month);
            if (tentativa.Count() != 0)
            {

                throw new ApplicationException("Já foi registrado essa Despesa!");
            }
            else
            {
                var cat = RetornaCategoria(despesa.NomeCategoria);
                despesa.NomeCategoria = cat;
                _context.Tb_Despesas.Add(despesa);
                _context.SaveChanges();
            }
        }
        public IEnumerable<ReadDespesaDto> RetornaDespesas()
        {
            var context = _context.Tb_Despesas;
            var despesas = _mapper.Map<List<ReadDespesaDto>>(context);
            return despesas;
        }
        public ReadDespesaDto RetornaDepesa(int id)
        {
            var despesa = _context.Tb_Despesas.FirstOrDefault(p => p.Id_Despesa == id);
            if (despesa == null)
            {
                throw new ApplicationException("A Despesa não exite!");
            }
                return _mapper.Map<ReadDespesaDto>(despesa);
            
        }
        public Despesa AlteraDespesa(int id,UpdateDespesaDto dto)
        {
            var despesa = _context.Tb_Despesas.FirstOrDefault(p => p.Id_Despesa == id);

            if (despesa == null)
            {
                throw new ApplicationException("Não exite essa despesa.");
            }

            var tentativa = _context.Tb_Despesas.FirstOrDefault(r => r.Descricao_Despesa.ToUpper() == dto.Descricao_Despesa.ToUpper()
            && r.Data_Despesa.Month == dto.Data_Despesa.Month);

            if (tentativa != null) 
            { 
                throw new ApplicationException("Já exite essa despesa cadastrada!"); 
            }
            _mapper.Map(dto, despesa);
            _context.SaveChanges();
            return despesa;
        }
        public void DeleteDespesa(int id)
        {
            var despesa = _context.Tb_Despesas.FirstOrDefault(p => p.Id_Despesa == id);
            if (despesa == null)
            {
                throw new ApplicationException("Não exite essa despesa cadastrada!");
            }

            _context.Remove(despesa);
            _context.SaveChanges();
        }
        public List<ReadDespesaDto> GetDespesaDesc(string desc) 
        {
            var despesas = _context.Tb_Despesas;
            List<Despesa> despesasRetorna = new List<Despesa>();

            foreach (var despesa in despesas)
            {
                if (despesa.Descricao_Despesa.ToUpper().Contains(desc.ToUpper()))
                {
                    despesasRetorna.Add(despesa);
                }
            }
            return _mapper.Map<List<ReadDespesaDto>>(despesasRetorna);
        }
        public List<ReadDespesaDto> RetornaPorAnoEMes(int ano, int mes)
        {
            var list = new List<ReadDespesaDto>();
            var listDespesasDb = _context.Tb_Despesas;
            foreach (var despesas in listDespesasDb)
            {
                if (despesas.Data_Despesa.Month == mes && despesas.Data_Despesa.Year == ano)
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
            foreach (var c in cat)
            {
                if (c.NomeCategoria.ToUpper() == categoria.ToUpper())
                {
                    nomeReturn = c.NomeCategoria;
                }
            }
            if (nomeReturn != "")
            {
                return nomeReturn;
            }
            return "Outros";


        }
    }
}
