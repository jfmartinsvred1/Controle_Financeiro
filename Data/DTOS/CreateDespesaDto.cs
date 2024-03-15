using Controle_Financeiro.Models;
using System.ComponentModel.DataAnnotations;

namespace Controle_Financeiro.Data.DTOS
{
    public class CreateDespesaDto
    {
        [Required]
        public string Descricao_Despesa { get; set; }
        [Required]
        public double Valor_Despesa { get; set; }
        [Required]
        public DateTime Data_Despesa { get; set; }
        public string NomeCategoria { get; set; }
    }
}
