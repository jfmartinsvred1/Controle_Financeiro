using Controle_Financeiro.Data;
using Controle_Financeiro.Models;

namespace Controle_Financeiro.Services
{
    public class ResumoService
    {
        private ControleFinanceiroContext _context;

        public ResumoService(ControleFinanceiroContext context)
        {
            _context = context;
        }

        public Resumo RetornaResumoMesAno(int ano, int mes)
        {
            var resumo = new Resumo();
            List<ResumoCategoria> listRe = GetCategorias();
            var despesas = _context.Tb_Despesas;
            var receitas = _context.Tb_Receitas;

            foreach (var desp in despesas)
            {
                if (desp.Data_Despesa.Month == mes && desp.Data_Despesa.Year == ano)
                {
                    resumo.TotDespesa += desp.Valor_Despesa;
                    resumo.SaldoFinal -= desp.Valor_Despesa;
                    foreach (var cat in listRe)
                    {
                        if (cat.NomeCategoria == desp.NomeCategoria)
                        {
                            cat.TotDespesa += desp.Valor_Despesa;
                        }
                    }
                    resumo.ResumoCategoria = listRe;
                }
            }
            foreach (var rec in receitas)
            {
                if (rec.Data_Receita.Month == mes && rec.Data_Receita.Year == ano)
                {
                    resumo.TotReceita += rec.Valor_Receita;
                    resumo.SaldoFinal += rec.Valor_Receita;
                }
            }

            return resumo;
        }
        internal List<ResumoCategoria> GetCategorias()
        {
            var listResumoCat = new List<ResumoCategoria>();
            var dbCat = _context.Categorias.ToList();
            foreach (var c in dbCat)
            {
                var cat = new ResumoCategoria();

                cat.NomeCategoria = c.NomeCategoria;
                listResumoCat.Add(cat);
            }
            return listResumoCat;
        }
    }
}
