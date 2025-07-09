using System.ComponentModel.DataAnnotations;

namespace ControleFinanceiro.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Esse campo deve conter entre 3 e 200 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Esse campo deve conter entre 3 e 20 caracteres.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Esse campo deve conter entre 3 e 20 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Esse campo deve conter entre 3 e 20 caracteres.")]
        public string Funcao { get; set; }
    }
}
