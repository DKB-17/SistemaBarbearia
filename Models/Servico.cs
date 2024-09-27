using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaBarbearia.Models
{
    [Table("Servicos")]
    public class Servico
    {
        [Display(Name = "ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }


        [Display(Name = "Valor: ")]
        public float valor { get; set; }
    }
}
