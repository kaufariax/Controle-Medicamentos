using ControleMedicamentos.src.dtos;
using ControleMedicamentos.src.modelos;
using ControleMedicamentos.src.repositorios;
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

        [HttpGet("todos")]
        public async Task<ActionResult> PegarTodosPacientesAsync()
        {
            var lista = await _repositorio.PegarTodosPacientesAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        [HttpGet("medicamentos")]
        public async Task<ActionResult> PegarMedicamentosTomadosAsync([FromQuery] string nome)
        {
            var lista = await _repositorio.PegarMedicamentosTomadosAsync(nome);

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> NovoPacienteAsync([FromBody] PacienteDTO paciente)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repositorio.NovoPacienteAsync(paciente);
            return Created($"api/Paciente/nome/{paciente.Nome}", paciente);
        }

        #endregion
    }
}
