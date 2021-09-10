using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.Service.Interface;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace Concertacion.API.Controllers
{

    /// <summary>
    /// Controller encargado de realizar el envío del proyecto al personal evaluador del MC
    /// </summary>
    [Produces("application/json")]
    [Route("api/negocio")]
    [ApiController]
    [SwaggerTag("Módulo Enviar proyecto")]
    [Authorize]
    public class EnviarController : ControllerBaseAPI
    {

        private readonly IEnvioProyectoService _envioProyectoService;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="envioProyectoService"></param>
        public EnviarController(IEnvioProyectoService envioProyectoService)
        {
            _envioProyectoService = envioProyectoService;
        }

        /// <summary>
        /// Método encargado de validar que toda la información del proyecto este correctamente diligenciada.
        /// Si toda la información existe, realiza el radicado del proyecto y cambia el estado del mismo,
        /// en caso contrario retorna los errores encontrados.
        /// </summary>
        /// <param name="id">Id del proyecto</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{id}/enviar")]
        public IActionResult Enviar(decimal? id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }
                RespuestaEnvioDto respuesta = _envioProyectoService.EnviarProyecto(Convert.ToDecimal(id), GetUserName());
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RespuestaErrorDto()
                {
                    Estado = StatusCodes.Status500InternalServerError,
                    Errores = new List<ErrorDto>(new[]
                    {
                        new ErrorDto()
                        {
                            Codigo = StatusCodes.Status500InternalServerError.ToString(),
                            Descripcion = ex.Message
                        }
                    })
                });
            }
        }

    }
}
