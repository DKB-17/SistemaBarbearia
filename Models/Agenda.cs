using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBarbearia.Models
{
    [Table("Agendas")]
    public class Agenda
    {

        public Agenda()
        {
            servicos = new List<Servico>();
        }

        public enum Trabalho {Falta = 0,Feito = 1, Remarcado = 2, Cancelado = 3}

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

        [Display(Name = "Dia agendado: ")]
        public DateOnly diaAgendado { get; set; }

        [Display(Name = "Trabalho")]
        public Trabalho trabalhoStatus { get; set; }

        public double valor_total { get; set; }
        public double tempo_total { get; set; }

        public int idCaixa { get; set; }
        public Caixa caixa { get; set; }

        public List<Servico> servicos { get; set; }

    }
}
