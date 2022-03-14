

using Microsoft.EntityFrameworkCore;
using ProjetoInicial.Models.Entidades;

namespace ProjetoInicial.Data
{
    public class UsuarioContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            =>
            optionsBuilder.UseMySQL("server= localhost; database=dbo; user=root;password=root;");
    }
}
