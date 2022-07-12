using ControleMedicamentos.src.dtos;
using ControleMedicamentos.src.modelos;
using ControleMedicamentos.src.repositorios;
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

        [HttpPost("registerdados")]

        public async Task<ActionResult> NovoRegistroDadosAsync([FromBody] ControleDadosDTO controleDados)
        {
            try
            {
                await _repositorio.NovoRegistroDadosAsync(controleDados);
                return Created($"api/ControleDados", controleDados);
            }
            catch(Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        #endregion
    }
}
