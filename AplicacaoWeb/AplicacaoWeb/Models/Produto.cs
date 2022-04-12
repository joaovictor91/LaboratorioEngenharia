using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoWeb.Models
{
    public class Produto
    {
        [Key]
        public int Idproduto { get; set; }

        public string Nome { get; set; }

        public double Valor { get; set; }

        public int FK_Categoria { get; set; }

        [ForeignKey("FK_Categoria")]
        public Categoria Categoria { get; set; }




    }
}
