using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Models
{
    public class Conta
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [StringLength(200, ErrorMessage = "Esse campo deve conter até 200 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DataVencimento { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataPagamento { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public Situacao situacao { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public Guid PessoaId { get; set; }

        public Conta() 
        {
            Id = Guid.NewGuid();
        }

        //Relacionamento Entity Framework
        public Pessoa pessoa { get; set; }
    }
}
