using Microsoft.EntityFrameworkCore;
using UsuarioCRUDApi.Business.Models.Usuarios;

namespace UsuarioCRUDApi.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                    .Property(s => s.Nome)
                    .HasMaxLength(100)
                    .IsRequired();

            modelBuilder.Entity<Usuario>()
                    .Property(s => s.Sobrenome)
                    .HasMaxLength(100)
                    .IsRequired();

            modelBuilder.Entity<Usuario>()
                    .Property(s => s.Email)
                    .HasMaxLength(100)
                    .IsRequired();

            modelBuilder.Entity<Usuario>()
                    .Property(s => s.DataNascimento)
                    .HasMaxLength(100)
                    .IsRequired();

            modelBuilder.Entity<Usuario>()
                    .Property(s => s.Escolaridade)
                    .HasMaxLength(100);
        }
    }
}
