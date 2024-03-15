using Microsoft.AspNetCore.Identity;

namespace Controle_Financeiro.Models
{
    public class Usuario:IdentityUser
    {
        public DateTime DataNascimento { get; set; }
        public Usuario():base()
        {
            
        }
    }
}
