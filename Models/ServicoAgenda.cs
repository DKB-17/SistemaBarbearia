using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBarbearia.Models
{
    [Table("ServicosAgendas")]
    public class ServicoAgenda
    {
        public int id { get; set; }
        public int desconto { get; set; }

        public int agendaID { get; set; }
        public Agenda agenda { get; set; }

        public int servicoID { get; set; }
        public Servico Servico { get; set; }
    }
}
