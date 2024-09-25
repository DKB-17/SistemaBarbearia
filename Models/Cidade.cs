using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaBarbearia.Models
{
    [Table("Cidades")]
    public class Cidade
    {
        [Display(Name = "ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(50, ErrorMessage = "Tamanho maximo de 50 caracteres")]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [Display(Name = "Estado: ")]
        public Estado estado { get; set; }
        [Display(Name = "Estado: ")]
        public int estadoId { get; set; }

    }
}
