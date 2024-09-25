using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBarbearia.Models
{
    [Table("Horarios")]
    public class Horario
    {
        [Display(Name = "ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Inicio: ")]
        public DateTime inicio { get; set; } = DateTime.Now;

        [Display(Name = "Fim: ")]
        public DateTime fim { get; set; }
    }
}
