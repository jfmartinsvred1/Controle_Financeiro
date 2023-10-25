using System.ComponentModel.DataAnnotations;

namespace Controle_Financeiro.Data.DTOS
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        public DateTime DataNascimento { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }

    }
}
