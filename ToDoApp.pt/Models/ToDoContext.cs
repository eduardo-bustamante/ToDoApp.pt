using Microsoft.EntityFrameworkCore;

namespace ToDoApp.pt.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        public DbSet<ToDo> ToDos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Situacao> Situacoes { get; set; } = null!;

        //seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(

            new Categoria { CategoriaId = "tarefa", Nome = "Tarefa" },
            new Categoria { CategoriaId = "casa", Nome = "Casa" },
            new Categoria { CategoriaId = "ex", Nome = "Exercicio" },
            new Categoria { CategoriaId = "compra", Nome = "Compra" },
            new Categoria { CategoriaId = "contato", Nome = "Contato" }
            );

            modelBuilder.Entity<Situacao>().HasData(
            new Situacao { SituacaoId = "aberto", Nome = "Aberto" },
            new Situacao { SituacaoId = "concluido", Nome = "Concluido" }
            );
        }
    }
}
