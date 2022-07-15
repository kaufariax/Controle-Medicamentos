using ControleMedicamentos.src.dtos;
using ControleMedicamentos.src.modelos;
using ControleMedicamentos.src.repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleMedicamentos.src.controladores
{ 
    [ApiController]
    [Route("api/Medicamentos")]
    [Produces("application/json")]

    public class MedicamentoControlador : ControllerBase
    {

        #region Atributos

        private readonly IMedicamento _repositorio;

        #endregion

        #region Construtores

        public MedicamentoControlador(IMedicamento repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Pegar todos os medicamentos
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Lista de medicamentos.</response>
        /// <response code="204">Lista vazia.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Medicamento))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("todos")]
        public async Task<ActionResult> PegarTodosMedicamentosAsync()
        {
            var lista = await _repositorio.PegarTodosMedicamentosAsync();

            if (lista.Count == 0) return NoContent();

            return Ok(lista);
        }

        /// <summary>
        /// Pegar lista de pacientes que tomaram o medicamento
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Lista de Controle de Dados com os Pacientes.</response>
        /// <response code="204">Nenhum paciente tomou esse medicamento.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ControleDados))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("pacientes")]
        public async Task<ActionResult> PegarControlePacientesAsync([FromQuery] string nomeDoMedicamento)
        {
            var lista = await _repositorio.PegarControlePacientesAsync(nomeDoMedicamento);

            if (lista.Count == 0) return NoContent();

            return Ok(lista);
        }

        /// <summary>
        /// Pegar quantidade pacientes que tomaram o medicamento
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Lista de Medicamentos que foram tomados e quantidade de pacientes que tomaram.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ControleDados))]
        [HttpGet("quantos_pacientes")]
        public ActionResult QuantosPacientesTomaram()
        {
            var lista = _repositorio.PegarQuantidadePacientesTomaram();

            return Ok(lista);
        }

        /// <summary>
        /// Criar novo Medicamento
        /// </summary>
        /// <param name="medicamento">Construtor para criar um medicamento</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/Medicamentos
        ///     {
        ///        "nome": "Paracetamol"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna medicamento criado.</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(MedicamentoDTO))]
        [HttpPost]
        public async Task<ActionResult> NovoMedicamentoAsync([FromBody] MedicamentoDTO medicamento)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repositorio.NovoMedicamentoAsync(medicamento);
            return Created($"api/Paciente/nome/{medicamento.Nome}", medicamento);
        }

        #endregion
    }
}
