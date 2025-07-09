using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro.Models
{
    public class Pessoa
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Esse campo deve conter entre 3 e 200 caracteres.")]
        public string Nome { get; set; }

        [StringLength(20, MinimumLength = 6, ErrorMessage = "Esse campo deve conter entre 6 e 20 caracteres.")]
        public string Telefome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salario { get; set; }

        [StringLength(20, ErrorMessage = "Esse campo deve conter até 20 caracteres.")]
        public string Genero { get; set; }

        public Guid? CidadeId { get; set; }

        public Pessoa() 
        { 
            Id = Guid.NewGuid();
        }

        //Relacionamento Entity Framework
        public Cidade cidade { get; set; }
    }
}
