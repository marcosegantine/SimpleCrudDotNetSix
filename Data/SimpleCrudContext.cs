using Microsoft.EntityFrameworkCore;
using SimpleCrudDotNetSix.Models;

namespace SimpleCrudDotNetSix.Data
{
    public class SimpleCrudContext : DbContext

    {
        public SimpleCrudContext(DbContextOptions<SimpleCrudContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//fazer a proteção da tabela para os nomes conforme especificado dentro do metodo.
        {
            var user = modelBuilder.Entity<User>();
            user.ToTable("users");
            user.HasKey(u => u.Id);
            user.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            user.Property(x => x.Name).HasColumnName("name");
            user.Property(x => x.DateOfBirth).HasColumnName("date_of_birth");
            user.Property(x => x.Affiliation).HasColumnName("affiliation");
            user.Property(x => x.IsEmancipated).HasColumnName("is_emancipated");

        }
    }
}
