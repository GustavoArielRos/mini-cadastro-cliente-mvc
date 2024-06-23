using Microsoft.EntityFrameworkCore;

namespace cadastro_cliente_mvc.Models
{
    public class CadastroClientDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public CadastroClientDbContext(DbContextOptions<CadastroClientDbContext> options) : base(options)
        {

        }
    }
}
