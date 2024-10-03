using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBarbearia.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Display(Name = "ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(70, ErrorMessage = "Tamanho maximo de 70 caracteres")]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(11)]
        [Display(Name = "Cpf: ")]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(11)]
        [Display(Name = "Telefone: ")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{5})[-. ]?([0-9]{4})$")]
        public string telefone { get; set; }

        public ICollection<Agenda> Agendas { get; set; }
    }
}
