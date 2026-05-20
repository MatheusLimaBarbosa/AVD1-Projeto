using System.ComponentModel.DataAnnotations;

namespace Academico.Models
{
    public class Professor
    {
        public int ProfessorID { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Titulacao { get; set; } = string.Empty;

     
        public string Cep { get; set; } = string.Empty;

        public string Endereco { get; set; } = string.Empty;

        public string Complemento { get; set; } = string.Empty;

        public string Bairro { get; set; } = string.Empty;

        public string Municipio { get; set; } = string.Empty;

        public string Uf { get; set; } = string.Empty;
    }
}