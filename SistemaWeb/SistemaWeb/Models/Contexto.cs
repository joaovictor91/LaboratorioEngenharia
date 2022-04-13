using Microsoft.EntityFrameworkCore;
using SistemaWeb.Models;

namespace SistemaWeb.Models
{
    public class Contexto: DbContext
    {

        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<SistemaWeb.Models.Contacs> Contacs { get; set; }
        public DbSet<SistemaWeb.Models.Classificacao> Classificacao { get; set; }
        public DbSet<SistemaWeb.Models.Tipo> Tipo { get; set; }

    }
}
