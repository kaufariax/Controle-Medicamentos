using ControleMedicamentos.src.modelos;
using Microsoft.EntityFrameworkCore;

namespace ControleMedicamentos.src.contexto
{
    /// <summary>
    /// <para>Resumo: Classe contexto, responsavel por carregar contexto e definir DbSets</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão: 1.1</para>
    /// <para>Data: 09/07/2022</para>
    /// </summary>
    public class CM_Contexto : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Medicamento> Medicamentos { get; set; }
        public DbSet<EventoMedicacao> EventoMedicacao { get; set; }

        public CM_Contexto(DbContextOptions<CM_Contexto> opt) : base(opt)
        {

        }
    }
}