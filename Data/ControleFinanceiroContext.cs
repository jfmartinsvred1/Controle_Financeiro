using Controle_Financeiro.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Controle_Financeiro.Data
{
    public class ControleFinanceiroContext:IdentityDbContext<Usuario>
    {
        public ControleFinanceiroContext(DbContextOptions<ControleFinanceiroContext> opts): base (opts) 
        {

        }

        public DbSet<Receita> Tb_Receitas { get; set; }
        public DbSet<Despesa> Tb_Despesas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
