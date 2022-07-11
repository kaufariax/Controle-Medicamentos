using ControleMedicamentos.src.modelos;
using ControleMedicamentos.src.repositorios;
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

        [HttpGet("todos")]
        public async Task<ActionResult> PegarTodosMedicamentosAsync()
        {
            var lista = await _repositorio.PegarTodosMedicamentosAsync();

            if (lista.Count == 0) return NoContent();

            return Ok(lista);
        }

        [HttpGet("pacientes")]
        public async Task<ActionResult> PegarControlePacientesAsync([FromQuery] string nome)
        {
            var lista = await _repositorio.PegarControlePacientesAsync(nome);

            if (lista.Count == 0) return NoContent();

            return Ok(lista);
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> NovoMedicamentoAsync([FromBody] Medicamento medicamento)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repositorio.NovoMedicamentoAsync(medicamento);
            return Created($"api/Paciente/nome/{medicamento.Nome}", medicamento);
        }

        #endregion
    }
}
