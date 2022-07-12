using ControleMedicamentos.src.dtos;
using ControleMedicamentos.src.modelos;
using ControleMedicamentos.src.repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.controladores
{
    [ApiController]
    [Route("api/Pacientes")]
    [Produces("application/json")]
    public class PacienteControlador : ControllerBase
    {
        #region Atributos

        private readonly IPaciente _repositorio;

        #endregion

        #region Construtores

        public PacienteControlador(IPaciente repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Pegar todos os pacientes
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Lista de pacientes</response>
        /// <response code="204">Lista vazia</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Paciente))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("todos")]
        public async Task<ActionResult> PegarTodosPacientesAsync()
        {
            var lista = await _repositorio.PegarTodosPacientesAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }
        /// <summary>
        /// Pegar todos os medicamentos tomados
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Lista de Controle de Dados com os Medicamentos</response>
        /// <response code="204">Lista vazia</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ControleDados))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("medicamentos")]
        public async Task<ActionResult> PegarMedicamentosTomadosAsync([FromQuery] string nome)
        {
            var lista = await _repositorio.PegarMedicamentosTomadosAsync(nome);

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        /// <summary>
        /// Criar novo Paciente
        /// </summary>
        /// <param name="paciente">Construtor para criar um paciente</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/Pacientes
        ///     {
        ///        "nome": "Kauane Farias"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna paciente criado</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Paciente))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> NovoPacienteAsync([FromBody] PacienteDTO paciente)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repositorio.NovoPacienteAsync(paciente);
            return Created($"api/Paciente/nome/{paciente.Nome}", paciente);
        }

        #endregion
    }
}
