using System.ComponentModel.DataAnnotations;

namespace SistemaWeb.Models
{
    public class Classificacao
    {
        [Key]
        public int Id { get; set; }

        public string nomec { get; set; }

        public string UsuarioId { get; set; }
    }
}
