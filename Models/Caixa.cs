using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBarbearia.Models
{
    [Table("Caixas")]
    public class Caixa
    {
        public int id { get; set; }
        public DateOnly dia { get; set; }
        public double lucro { get; set; }

        public ICollection<Agenda> Agendas { get; set; } = new List<Agenda>();
    }
}
