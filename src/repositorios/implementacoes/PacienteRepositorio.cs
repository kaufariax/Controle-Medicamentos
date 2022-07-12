using ControleMedicamentos.src.contexto;
using ControleMedicamentos.src.dtos;
using ControleMedicamentos.src.modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.repositorios.implementacoes
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar IPaciente</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 12/07/2022</para>
    /// </summary>
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

        /// <summary>
        /// <para>Resumo: Método assíncrono para salvar um novo paciente</para>
        /// </summary>
        /// <param name="paciente">PacienteDTO</param>
        public async Task NovoPacienteAsync(PacienteDTO paciente)
        {
            await _contexto.Pacientes.AddAsync(new Paciente
            {
                Nome = paciente.Nome
            });

            await _contexto.SaveChangesAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar todos os pacientes</para>
        /// </summary>
        /// <return>Lista Paciente></return>
        public async Task<List<Paciente>> PegarTodosPacientesAsync()
        {
            return await _contexto.Pacientes.ToListAsync();
        }

        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar todos os medicamentos tomados pelo paciente</para>
        /// </summary>
        /// <return>Lista ControleDados></return>
        public async Task<List<ControleDados>> PegarMedicamentosTomadosAsync(string nome)
        {
            return await _contexto.ControleDados
                .Include(cm => cm.Paciente)
                .Include(cm => cm.Medicamento)
                .Where(cm => cm.Paciente.Nome == nome)
                .ToListAsync();
        }

        #endregion
    }
}
