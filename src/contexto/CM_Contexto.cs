using ControleMedicamentos.src.modelos;
using Microsoft.EntityFrameworkCore;

namespace ControleMedicamentos.src.contexto
{
    public class CM_Contexto : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<ControleDados> ControleDados { get; set; }

        public CM_Contexto(DbContextOptions<CM_Contexto> opt) : base(opt)
        {

        }
    }
}