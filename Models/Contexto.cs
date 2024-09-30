using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;
using SistemaBarbearia.Models;

namespace SistemaBarbearia.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<SistemaBarbearia.Models.Cidade> Cidade { get; set; }
        public DbSet<SistemaBarbearia.Models.Agenda> Agenda { get; set; }
        public DbSet<SistemaBarbearia.Models.Barbeiro> Barbeiro { get; set; }
        public DbSet<SistemaBarbearia.Models.Cliente> Cliente { get; set; }
        public DbSet<SistemaBarbearia.Models.Horario> Horario { get; set; }
        public DbSet<SistemaBarbearia.Models.Servico> Servico { get; set; }
    }
}
