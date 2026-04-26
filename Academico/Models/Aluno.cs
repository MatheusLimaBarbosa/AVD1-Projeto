using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Aluno
    {
        [Key]
        public int AlunoID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        [StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?\d{2}\)?\s?\d{4,5}-\d{4}$", ErrorMessage = "Telefone inválido.")]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; } = string.Empty;

        public string? Complemento { get; set; }

        [Required]
        public string Bairro { get; set; } = string.Empty;

        [Required]
        public string Municipio { get; set; } = string.Empty;

        [Required]
        public string Uf { get; set; } = string.Empty;

        [Required]
        public string Cep { get; set; } = string.Empty;
    }
}