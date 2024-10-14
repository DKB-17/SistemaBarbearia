using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBarbearia.Models
{
    [Table("Servicos")]
    public class Servico
    {
        public Servico()
        {
            agendas = new List<Agenda>();
        }

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
        public float valor { get; set; }

        [Required]
        [Display(Name = "Tempo para fazer: ")]
        public TimeOnly minutos { get; set; }

        public List<Agenda> agendas { get; set; }
    }
}
