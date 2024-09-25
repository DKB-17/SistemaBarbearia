using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBarbearia.Models
{
    [Table("Estados")]
    public class Estado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(2, ErrorMessage = "Tamanho maximo de 2 caracteres")]
        [Display(Name = "UF")]
        public string uf { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Tamanho maximo de 50 caracteres")]
        [Display(Name = "Estado")]
        public string nome { get; set; }

    }
}
