using ControleMedicamentos.src.dtos;
using ControleMedicamentos.src.repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.controladores
{
    [ApiController]
    [Route("api/EventoMedicacao")]
    [Produces("application/json")]
    public class EventoMedicacaoControlador : ControllerBase
    {

        #region Atributos

        private readonly IEventoMedicacao _repositorio;

        #endregion

        #region Construtores

        public EventoMedicacaoControlador(IEventoMedicacao repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Criar novo evento de medicação
        /// </summary>
        /// <param name="eventoMedicacao">Construtor para criar um evento de medicação</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/EventoMedicacao
        ///     {
        ///      "paciente": {
        ///       "nome": "Kauane Farias"
        ///      },
        ///      "medicamento": {
        ///         "nome": "Paracetamol"
        ///       }
        ///      }
        ///
        /// </remarks>
        /// <response code="201">Retorna evento de medicação criado.</response>
        /// <response code="400">Erro na requisição.</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EventoMedicacaoDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> NovoRegistroMedicacaoAsync([FromBody] EventoMedicacaoDTO eventoMedicacao)
        {
            try
            {
                await _repositorio.NovoRegistroMedicacaoAsync(eventoMedicacao);
                return Created($"api/ControleDados", eventoMedicacao);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        #endregion
    }
}
