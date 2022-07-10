using ControleMedicamentos.src.contexto;
using ControleMedicamentos.src.modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.repositorios.implementacoes
{
    public class ControleDadosRepositorio : IControleDados
    {
        #region Atributos

        private readonly CM_Contexto _contexto;

        #endregion

        #region Construtores

        public ControleDadosRepositorio(CM_Contexto contexto)
        {
            _contexto = contexto;
        }

        #endregion

        #region Métodos

        public async Task NovoRegistroDadosAsync(ControleDados controleDados)
        {
            await _contexto.ControleDados.AddAsync(new ControleDados
            {
                Paciente = await _contexto.Pacientes.FirstOrDefaultAsync(p => p.Nome == controleDados.Paciente.Nome),
                Medicamento = await _contexto.Medicamentos.FirstOrDefaultAsync(m => m.Nome == controleDados.Medicamento.Nome)
            });
            await _contexto.SaveChangesAsync();
        }

        #endregion
    }
}
