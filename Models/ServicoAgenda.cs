namespace SistemaBarbearia.Models
{
    public class ServicoAgenda
    {
        public int desconto { get; set; }

        public int agendaID { get; set; }
        public Agenda agenda { get; set; }

        public int servicoID { get; set; }
        public Servico Servico { get; set; }
    }
}
