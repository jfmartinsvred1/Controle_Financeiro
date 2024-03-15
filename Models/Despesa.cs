using System.ComponentModel.DataAnnotations;

namespace Controle_Financeiro.Models
{
    public class Despesa
    {
        [Key]
        [Required]
        public int Id_Despesa { get; set; }
        [Required]
        public string Descricao_Despesa { get; set; }
        [Required]
        public double Valor_Despesa { get; set; }
        [Required]
        public DateTime Data_Despesa { get; set; }
    
        public string NomeCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
