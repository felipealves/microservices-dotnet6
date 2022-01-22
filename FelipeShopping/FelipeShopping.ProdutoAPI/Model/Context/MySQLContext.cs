using FelipeShopping.ProdutoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FelipeShopping.ProdutoAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
