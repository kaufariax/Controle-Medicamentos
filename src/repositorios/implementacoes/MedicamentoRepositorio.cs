using ControleMedicamentos.src.contexto;
using ControleMedicamentos.src.modelos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.repositorios.implementacoes
{
    public class MedicamentoRepositorio : IMedicamento
    {
        #region Atributos

        private readonly CM_Contexto _contexto;

        #endregion

        #region Contrutores

        public MedicamentoRepositorio(CM_Contexto contexto)
        {
            _contexto = contexto;
        }

        #endregion

        #region Métodos

        public async Task NovoMedicamentoAsync(Medicamento medicamento)
        {
            await _contexto.Medicamentos.AddAsync(new Medicamento
            {
                Nome = medicamento.Nome
            });

            await _contexto.SaveChangesAsync();
        }

        public async Task<List<Medicamento>> PegarTodosMedicamentosAsync()
        {
            return await _contexto.Medicamentos.ToListAsync();
        }

        public async Task<List<ControleDados>> PegarControlePacientesAsync(string nome)
        {
            return await _contexto.ControleDados
                .Include(cm => cm.Paciente)
                .Where(cm => cm.Medicamento.Nome.Contains(nome))
                .ToListAsync();
        }

        #endregion
    }
}
