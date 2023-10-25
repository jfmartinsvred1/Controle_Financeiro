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
