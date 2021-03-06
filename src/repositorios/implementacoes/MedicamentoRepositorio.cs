using ControleMedicamentos.src.contexto;
using ControleMedicamentos.src.dtos;
using ControleMedicamentos.src.modelos;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.repositorios.implementacoes
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar IMedicamento</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão: 1.1</para>
    /// <para>Data: 10/07/2022</para>
    /// </summary>
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

        /// <summary>
        /// <para>Resumo: Método assíncrono para salvar um novo medicamento</para>
        /// </summary>
        /// <param name="medicamento">MedicamentoDTO</param>
        public async Task NovoMedicamentoAsync(MedicamentoDTO medicamento)
        {
            await _contexto.Medicamentos.AddAsync(new Medicamento
            {
                Nome = medicamento.Nome
            });

            await _contexto.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar todos os medicamentos</para>
        /// </summary>
        /// <return>Lista de Medicamento></return>
        public async Task<List<Medicamento>> PegarTodosMedicamentosAsync()
        {
            return await _contexto.Medicamentos.ToListAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar todos os pacientes que tomaram o remédio</para>
        /// </summary>
        /// <return>Lista de Evento de Medicação></return>
        public async Task<List<EventoMedicacao>> PegarControlePacientesAsync(string nomeDoMedicamento)
        {
            return await _contexto.EventoMedicacao
                .Include(cm => cm.Medicamento)
                .Include(cm => cm.Paciente)
                .Where(cm => cm.Medicamento.Nome.Contains(nomeDoMedicamento))
                .ToListAsync();
        }

        /// <summary>
        /// <para>Resumo: Método para pegar a quantidade de pacientes que tomaram o medicamento</para>
        /// </summary>
        /// <return>Medicamento e quantidade de pacientes que tomaram></return>
        public IEnumerable PegarQuantidadePacientesTomaram(string nomeDoMedicamento)
        {
            var lista = _contexto.EventoMedicacao
            .Include(cm => cm.Medicamento)
            .Include(cm => cm.Paciente)
            .Where(cm => cm.Medicamento.Nome.Contains(nomeDoMedicamento))
            .ToList()
            .DistinctBy(x => x.Paciente.Nome)
            .GroupBy(m => m.Medicamento.Nome)
            .Select(s => new
            {
                Medicamento = s.Key,
                Quantidade = s.Count()
            });

            return lista;
        }

        #endregion
    }
}
