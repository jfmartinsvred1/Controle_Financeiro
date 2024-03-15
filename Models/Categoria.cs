using System.ComponentModel.DataAnnotations;

namespace Controle_Financeiro.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        [MaxLength(15)]
        public string NomeCategoria { get; set; }
        public ICollection<Despesa> Despesas { get; set; }
    }
}
