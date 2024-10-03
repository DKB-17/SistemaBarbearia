using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Humanizer;
using SistemaBarbearia.Controllers;

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
        public TimeOnly inicio { get; set; }

        [Display(Name = "Fim: ")]
        public TimeOnly fim { get; set; }
    }
}
