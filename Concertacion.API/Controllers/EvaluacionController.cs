using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinCultura.Domain.Common.DTO;

using MinCultura.Domain.Service.Interface;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Concertacion.API.Controllers
{
    /// <summary>
    /// Controller encargado de realizar la evaluación proyecto
    /// </summary>
    [Produces("application/json")]
    [Route("api/evaluacion")]
    [ApiController]
    [SwaggerTag("Módulo de evaluación de proyectos.")]
    [Authorize]
    public class EvaluacionController : ControllerBaseAPI
    {
        private readonly IEvaluacionService _evaluacionService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="evaluacionService"></param>
        public EvaluacionController(IEvaluacionService evaluacionService)
        {
            _evaluacionService = evaluacionService;
        }

        /// <summary>
        /// Consultar proyectos por estado
        /// </summary>
        /// <param name="estado">Estado del proyecto</param>
        /// <returns>Proponente</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/estado/{estado}")]
        [Authorize]
        public IActionResult ProyectoByEstado(string estado)
        {
            try
            {
                var proyectos = _evaluacionService.GetProyectoByEstado(estado);
                if (proyectos == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen proyectos relacionados con el estado ingresado"
                            }
                        })
                    });
                }
                return Ok(proyectos);
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


        /// <summary>
        /// Consultar evaluacion de requisitos por proyecto
        /// </summary>
        /// <param name="proId">Id del proyecto</param>
        /// <returns>Lista de requisitos evaluados</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{proId}/evaluacionrequisitos")]
        [Authorize]
        public IActionResult ProyectoByEvaluacionRequisitos(decimal proId)
        {
            try
            {
                var evaluacionRequisitos = _evaluacionService.GetProyectoByEvaluacionRequisitos(proId);
                if (evaluacionRequisitos == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen evaluación de registro relacionados con el proyecto ingresado"
                            }
                        })
                    });
                }
                return Ok(evaluacionRequisitos);
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


        /// <summary>
        /// Consultar proyecto
        /// </summary>
        /// <param name="proId">Id del proyecto</param>
        /// <returns>proyecto</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{proId}")]
        [Authorize]
        public IActionResult Proyecto(decimal proId)
        {
            try
            {
                var proyecto = _evaluacionService.GetProyectoById(proId);
                if (proyecto  == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen proyectos relacionados con el estado ingresado"
                            }
                        })
                    });
                }
                return Ok(proyecto);
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

        /// <summary>
        /// Método para actualizar la información de los requisitos del proyecto.
        /// </summary>
        /// <param name="evaluacionForma">Lista de evaluación de requisitos</param>
        /// <returns>Respuesta de la actualización</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("evaluacionforma")]
        public IActionResult EvaluacionForma(List<EvaluacionRequisitosDto> evaluacionForma)
        {
            string userCreo = string.Empty;
            try
            {
                userCreo = GetUserName();
                var respuesta = _evaluacionService.CrearEvaluacionForma(evaluacionForma, userCreo);
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


        /// <summary>
        /// Método que permite enviar correo especificando los documentos que no cumplen .
        /// </summary>
        /// <param name="proyecto">proyecto</param>
        /// <returns>Respuesta del envío del correo</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/correorequisitos")]
        [Authorize]
        public IActionResult EnvioCorreoEvaluacion([FromBody] ProyectoDto proyecto)
        {
            try
            {
                var respuesta = _evaluacionService.EnviarCorreoSolicitudDocumento(proyecto);
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

        /// <summary>
        /// Método que permite cambiar estado del proyecto
        /// </summary>
        /// <param name="proId"></param>
        /// <returns>Retorna true o false </returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/estado")]
        [Authorize]
        public IActionResult CambiarEstadoProyecto([FromBody]decimal proId)
        {
            try
            {
                var respuesta = _evaluacionService.CambiarEstadoProyecto(proId);
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

        /// <summary>
        /// Obtener el Id del usuario autenticado
        /// </summary>
        /// <returns>Id User</returns>
        [NonAction]
        public string GetUserName()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var securityToken = tokenHandler.ReadToken(authHeader) as JwtSecurityToken;
            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == "User").Value;
            return stringClaimValue;
        }
    }
}
