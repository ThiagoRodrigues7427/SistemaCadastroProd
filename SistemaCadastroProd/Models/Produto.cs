using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCadastroProd.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CodigoProduto { get; set; }

        [Required]
        public string Descricao { get; set; }

        public string TipoProduto { get; set; }

        [Required]
        public DateTime DataLancamento { get; set; }
        public Decimal Valor { get; set; }
    }
    public enum Produtos
    {
        Celular = 1,
        Tablet = 2,
        Notebook = 3
    }
}
