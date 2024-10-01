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

        [Required]
        [StringLength(50)]
        [Display(Name = "Descricao: ")]
        public string descricao { get; set; }

        [Required]
        [Display(Name = "Valor: ")]
        public double valor { get; set; }

        [Required]
        [Display(Name = "Tempo: ")]
        public TimeOnly minutos { get; set; }
    }
}
