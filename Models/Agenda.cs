using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBarbearia.Models
{
    [Table("Agendas")]
    public class Agenda
    {
        [Display(Name = "ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Cliente: ")]
        public Cliente cliente { get; set; }
        [Display(Name = "Cliente: ")]
        public int clienteId { get; set; }

        [Display(Name = "Horario: ")]
        public Horario horario { get; set; }
        [Display(Name = "Horario: ")]
        public int horarioId { get; set; }

        [Display(Name = "Servico: ")]
        public Servico servico { get; set; }
        [Display(Name = "Servico: ")]
        public int servicoId { get; set; }

        [Display(Name = "Dia agendado: ")]
        public DateTime diaAgendado { get; set; }

    }
}
