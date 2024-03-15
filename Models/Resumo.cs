namespace Controle_Financeiro.Models
{
    public class Resumo
    {
        public double TotReceita { get; set; }
        public double TotDespesa { get; set; }
        public double SaldoFinal { get; set; }

        public List<ResumoCategoria> ResumoCategoria { get; set; }
    }
}
