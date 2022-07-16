using ControleMedicamentos.src.contexto;
using ControleMedicamentos.src.dtos;
using ControleMedicamentos.src.modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.repositorios.implementacoes
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar IEventoMedicacao</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão: 1.1</para>
    /// <para>Data: 10/07/2022</para>
    /// </summary>
    public class EventoMedicacaoRepositorio : IEventoMedicacao
    {
        #region Atributos

        private readonly CM_Contexto _contexto;

        #endregion

        #region Construtores

        public EventoMedicacaoRepositorio(CM_Contexto contexto)
        {
            _contexto = contexto;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// <para>Resumo: Método assíncrono para salvar um novo evento de medicação</para>
        /// </summary>
        /// <param name="eventoMedicacao">Construtor para cadastrar um Evento de Medicação</param>
        /// <exception cref="Exception">Nome não pode ser nulo</exception>
        public async Task NovoRegistroMedicacaoAsync(EventoMedicacaoDTO eventoMedicacao)
        {
            if (!ExistePacienteNome(eventoMedicacao.Paciente.Nome)) throw new Exception("Nome do paciente não encontrado");

            if (!ExisteMedicamentoNome(eventoMedicacao.Medicamento.Nome)) throw new Exception("Nome do medicamento não encontrado");

            await _contexto.EventoMedicacao.AddAsync(new EventoMedicacao
            {
                Paciente = await _contexto.Pacientes.FirstOrDefaultAsync(p => p.Nome == eventoMedicacao.Paciente.Nome),
                Medicamento = await _contexto.Medicamentos.FirstOrDefaultAsync(m => m.Nome == eventoMedicacao.Medicamento.Nome)
            });
            await _contexto.SaveChangesAsync();

            bool ExistePacienteNome(string nome)
            {
                var auxiliar = _contexto.Pacientes.FirstOrDefault(p => p.Nome == nome);
                return auxiliar != null;
            }

            bool ExisteMedicamentoNome(string nome)
            {
                var auxiliar = _contexto.Medicamentos.FirstOrDefault(m => m.Nome == nome);
                return auxiliar != null;
            }
        }

        #endregion
    }
}
