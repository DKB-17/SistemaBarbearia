using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBarbearia.Models
{
    [Table("Barbeiros")]
    public class Barbeiro
    {
        [Display(Name = "ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(50, ErrorMessage = "Tamanho maximo de 50 caracteres")]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [Display(Name = "Cidade: ")]
        public Cidade cidade { get; set; }
        [Display(Name = "Cidade: ")]
        public int cidadeId { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(11)]
        [Display(Name = "CPF: ")]
        public char[] cpf { get; set; } = new char[11];

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(11)]
        [Display(Name = "FONE: ")]
        public char[] telefone { get; set; } = new char[11];
    }
}
