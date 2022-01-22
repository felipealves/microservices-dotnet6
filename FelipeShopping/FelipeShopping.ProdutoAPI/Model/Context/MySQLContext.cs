using FelipeShopping.ProdutoAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FelipeShopping.ProdutoAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var id = 15;
            modelBuilder.Entity<Produto>().HasData(new Produto
            { 
                Id = id,
                Nome = "Felipe_" + id,
                Valor = new decimal(59.99 * id),
                Descricao = "Felipe Descricao_" + id,
                ImagemUrl = "http://felipeproduto.com/" + id,
                CategoriaNome = "Camiseta"
            });
            id++;
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = id,
                Nome = "Felipe_" + id,
                Valor = new decimal(199.99 * id),
                Descricao = "Felipe Descricao_" + id,
                ImagemUrl = "http://felipeproduto.com/" + id,
                CategoriaNome = "Camiseta"
            });
            id++;
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = id,
                Nome = "Felipe_" + id,
                Valor = new decimal(199.99 * id),
                Descricao = "Felipe Descricao_" + id,
                ImagemUrl = "http://felipeproduto.com/" + id,
                CategoriaNome = "Camiseta"
            });
            id++;
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = id,
                Nome = "Felipe_" + id,
                Valor = new decimal(199.99 * id),
                Descricao = "Felipe Descricao_" + id,
                ImagemUrl = "http://felipeproduto.com/" + id,
                CategoriaNome = "Shorts"
            });
            id++;
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = id,
                Nome = "Felipe_" + id,
                Valor = new decimal(199.99 * id),
                Descricao = "Felipe Descricao_" + id,
                ImagemUrl = "http://felipeproduto.com/" + id,
                CategoriaNome = "Shorts"
            });
            id++;
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = id,
                Nome = "Felipe_" + id,
                Valor = new decimal(199.99 * id),
                Descricao = "Felipe Descricao_" + id,
                ImagemUrl = "http://felipeproduto.com/" + id,
                CategoriaNome = "Shorts"
            });
            id++;
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = id,
                Nome = "Felipe_" + id,
                Valor = new decimal(199.99 * id),
                Descricao = "Felipe Descricao_" + id,
                ImagemUrl = "http://felipeproduto.com/" + id,
                CategoriaNome = "Bones"
            });
            id++;
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = id,
                Nome = "Felipe_" + id,
                Valor = new decimal(199.99 * id),
                Descricao = "Felipe Descricao_" + id,
                ImagemUrl = "http://felipeproduto.com/" + id,
                CategoriaNome = "Bones"
            });
            id++;
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = id,
                Nome = "Felipe_" + id,
                Valor = new decimal(199.99 * id),
                Descricao = "Felipe Descricao_" + id,
                ImagemUrl = "http://felipeproduto.com/" + id,
                CategoriaNome = "Bones"
            });
            id++;
            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                Id = id,
                Nome = "Felipe_" + id,
                Valor = new decimal(199.99 * id),
                Descricao = "Felipe Descricao_" + id,
                ImagemUrl = "http://felipeproduto.com/" + id,
                CategoriaNome = "Livro"
            });
            id++;
        }
    }
}
