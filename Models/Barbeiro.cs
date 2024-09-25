using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaBarbearia.Models
{
    [Table("Barbeiros")]
    public class Barbeiro
    {
        [Display(Name = "ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Cidade: ")]
        public Cidade cidade { get; set; }
        [Display(Name = "Cidade: ")]
        public int cidadeId { get; set; }

        [Display(Name = "Nome: ")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(35)]
        public string nome { get; set; }

        [Display(Name = "CPF: ")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public char[] cpf { get; set; } = new char[11];

        [Display(Name = "FONE: ")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public char[] telefone { get; set; } = new char[11];
    }
}
