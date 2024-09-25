using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBarbearia.Models
{
    [Table("Cidades")]
    public class Cidade
    {
        [Display(Name = "ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Nome: ")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(35)]
        public string nome { get; set; }

        [Display(Name = "Estado: ")]
        public Estado estado { get; set; }
        [Display(Name = "Estado: ")]
        public int estadoId { get; set; }
    }
}
