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
    /// <para>Resumo: Classe responsavel por implementar IControleDados</para>
    /// <para>Criado por: Kauane Farias</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 10/07/2022</para>
    /// </summary>
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

        /// <summary>
        /// <para>Resumo: Método assíncrono para salvar um novo controle de dados</para>
        /// </summary>
        /// <param name="controleDados">Construtor para cadastrar um Controle de Dados</param>
        /// <exception cref="Exception">Nome não pode ser nulo</exception>
        public async Task NovoRegistroDadosAsync(ControleDadosDTO controleDados)
        {
            if (!ExistePacienteNome(controleDados.Paciente.Nome)) throw new Exception("Nome do paciente não encontrado");

            if (!ExisteMedicamentoNome(controleDados.Medicamento.Nome)) throw new Exception("Nome do medicamento não encontrado");

            await _contexto.ControleDados.AddAsync(new ControleDados
            {
                Paciente = await _contexto.Pacientes.FirstOrDefaultAsync(p => p.Nome == controleDados.Paciente.Nome),
                Medicamento = await _contexto.Medicamentos.FirstOrDefaultAsync(m => m.Nome == controleDados.Medicamento.Nome)
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
