using ControleMedicamentos.src.dtos;
using ControleMedicamentos.src.modelos;
using ControleMedicamentos.src.repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.controladores
{
    [ApiController]
    [Route("api/ControleDados")]
    [Produces("application/json")]
    public class ControleDadosControlador : ControllerBase
    {

        #region Atributos

        private readonly IControleDados _repositorio;

        #endregion

        #region Construtores

        public ControleDadosControlador(IControleDados repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Criar novo controle de dados
        /// </summary>
        /// <param name="controleDados">Construtor para criar um controle de dados</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/ControleDados
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
        /// <response code="201">Retorna controle de dados criado</response>
        /// <response code="400">Erro na requisição</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ControleDadosDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> NovoRegistroDadosAsync([FromBody] ControleDadosDTO controleDados)
        {
            try
            {
                await _repositorio.NovoRegistroDadosAsync(controleDados);
                return Created($"api/ControleDados", controleDados);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        #endregion
    }
}
