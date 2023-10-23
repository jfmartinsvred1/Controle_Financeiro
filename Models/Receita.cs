using System.ComponentModel.DataAnnotations;

namespace Controle_Financeiro.Models
{
    public class Receita
    {
        [Key]
        [Required]
        public int Id_Receita { get; set; }
        [Required]
        public string Descricao_Receita { get; set; }
        [Required]
        public double Valor_Receita { get; set; }
        [Required]
        public DateTime Data_Receita { get; set; }
    }
}
