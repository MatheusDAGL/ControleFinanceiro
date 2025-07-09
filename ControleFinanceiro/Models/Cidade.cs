using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models
{
    public class Cidade
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O nome da cidade deve conter entre 3 e 200 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo Sigla deve ter 2 caracteres.")]
        public string EstadoSigla { get; set; }

       public Cidade()
        {
           Id = Guid.NewGuid();
        }
        //Relacionamento do Entity Framework
        public Estado Estado { get; set; }
    }

}
