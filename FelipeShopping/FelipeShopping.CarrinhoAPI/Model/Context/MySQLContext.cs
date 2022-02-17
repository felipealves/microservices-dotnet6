using Microsoft.EntityFrameworkCore;

namespace FelipeShopping.CarrinhoAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<CarrinhoHeader> CarrinhoHeaders { get; set; }

        public DbSet<CarrinhoDetail> CarrinhoDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
