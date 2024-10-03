using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBarbearia.Models
{
    [Table("Agendas")]
    public class Agenda
    {

        public enum trabalho { Feito, Falta, Remarcado, Cancelado}

        [Display(Name = "ID: ")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Babeiro: ")]
        public Barbeiro barbeiro { get; set; }
        [Display(Name = "Babeiro: ")]
        public int barbeiroID { get; set; }

        [Display(Name = "Cliente: ")]
        public Cliente cliente { get; set; }
        [Display(Name = "Cliente: ")]
        public int clienteId { get; set; }

        [Display(Name = "Horario: ")]
        public Horario horario { get; set; }
        [Display(Name = "Horario: ")]
        public int horarioId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Dia agendado: ")]
        public DateTime diaAgendado { get; set; }

        [Display(Name = "Trabalho")]
        public trabalho trabalhoStatus { get; set; }

        public double valor_total { get; set; }
        public int tempo_total { get; set; }

        public int idCaixa { get; set; }
        public Caixa caixa { get; set; }

        public ICollection<ServicoAgenda> servicosAgendas { get; set; }

    }
}
