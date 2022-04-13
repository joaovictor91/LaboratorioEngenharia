using System.ComponentModel.DataAnnotations;

namespace SistemaWeb.Models
{
    public class Contacs
    {
        [Key]
        public int IdConta { get; set; }

        public string descricao { get; set; }

        public DateTime dataPagamento { get; set; }

        public double valor { get; set; }

        public DateTime dataVencimento { get; set; }

        public string UsuarioId { get; set; }

        public int TipoId { get; set; }
        public virtual Tipo Tipo { get; set; }

        public int ClassificacaoId { get; set; }
        public virtual Classificacao Classificacao { get; set; }

    }
}
