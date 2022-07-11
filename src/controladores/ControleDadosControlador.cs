using ControleMedicamentos.src.modelos;
using ControleMedicamentos.src.repositorios;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("registerdados")]

        public async Task<ActionResult> NovoRegistroDadosAsync([FromBody] ControleDados controleDados)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repositorio.NovoRegistroDadosAsync(controleDados);
            return Created($"api/ControleDados", controleDados);
        }

        #endregion
    }
}
