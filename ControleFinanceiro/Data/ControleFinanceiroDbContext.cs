using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro.Data
{
    public class ControleFinanceiroDbContext : DbContext
    {
        public ControleFinanceiroDbContext(DbContextOptions<ControleFinanceiroDbContext> options) : base(options) 
        {

        }

        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
