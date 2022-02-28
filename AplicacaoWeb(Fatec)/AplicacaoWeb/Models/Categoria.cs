using System.ComponentModel.DataAnnotations;

namespace AplicacaoWeb.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }

    }
}
