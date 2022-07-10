using ControleMedicamentos.src.contexto;
using ControleMedicamentos.src.modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.repositorios.implementacoes
{
    public class PacienteRepositorio : IPaciente
    {
        #region Atributos

        private readonly CM_Contexto _contexto;

        #endregion

        #region Contrutores

        public PacienteRepositorio(CM_Contexto contexto)
        {
            _contexto = contexto;
        }

        #endregion

        #region Métodos

        public async Task NovoPacienteAsync(Paciente paciente)
        {
            await _contexto.Pacientes.AddAsync(new Paciente
            {
                Nome = paciente.Nome
            });

            await _contexto.SaveChangesAsync();
        }

        public async Task<List<Paciente>> PegarTodosPacientesAsync()
        {
            return await _contexto.Pacientes.ToListAsync();
        }

        public async Task<List<ControleDados>> PegarMedicamentosTomadosAsync(string nome)
        {
            //to-do: medicamentos vinculados ao paciente (verificar)
            return await _contexto.ControleDados
                .Include(cm => cm.Paciente)
                .Include(cm => cm.Medicamento)
                .Where(cm => cm.Paciente.Nome == nome)
                .ToListAsync();
        }

        #endregion
    }
}
