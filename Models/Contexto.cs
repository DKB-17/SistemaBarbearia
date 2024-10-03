using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;
using SistemaBarbearia.Models;

namespace SistemaBarbearia.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<ServicoAgenda> ServicosAgendas { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Barbeiro> Barbeiros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
    }
}
