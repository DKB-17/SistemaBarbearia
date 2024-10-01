using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;
using SistemaBarbearia.Models;

namespace SistemaBarbearia.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

<<<<<<< HEAD
        public DbSet<Agenda> Agendas { get; set; }
        public DbSet<Barbeiro> Barbeiros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
=======
        public DbSet<Estado> Estados { get; set; }
        public DbSet<SistemaBarbearia.Models.Cidade> Cidade { get; set; }
        public DbSet<SistemaBarbearia.Models.Agenda> Agenda { get; set; }
        public DbSet<SistemaBarbearia.Models.Barbeiro> Barbeiro { get; set; }
        public DbSet<SistemaBarbearia.Models.Cliente> Cliente { get; set; }
        public DbSet<SistemaBarbearia.Models.Horario> Horario { get; set; }
        public DbSet<SistemaBarbearia.Models.Servico> Servico { get; set; }
>>>>>>> f3f6423bca2b9c7591ba11f097c7f9f559d9e450
    }
}
