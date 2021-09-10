using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.Service.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace Concertacion.API.Controllers
{
    /// <summary>
    /// Controller encargado de la trayectoria y el presupuesto
    /// </summary>
    [Produces("application/json")]
    [Route("api/negocio")]
    [ApiController]
    [SwaggerTag("Módulo para la administración de la trayectoria y presupuesto del Proyecto")]
    [Authorize]
    public class TrayectoriaProyectoController : ControllerBaseAPI
    {
        private readonly ITrayectoriaProyectoService _trayectoriaProyectoDTOService;
        private readonly IFormulariosServicice _formulariosService;

        public TrayectoriaProyectoController(ITrayectoriaProyectoService trayectoriaService, IFormulariosServicice formulariosService)
        {
            _trayectoriaProyectoDTOService = trayectoriaService;
            _formulariosService = formulariosService;
        }
               
        /// <summary>
        /// Método para insertar la trayectoria del proyecto 
        /// </summary>
        /// <returns>Respuesta trayectoria creada</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("trayectoria")]
        public IActionResult TrayectoriaProyectos(List<TrayectoriaProyectoDTO> trayectoriaProyectos)
        {
            try
            {
                RespuestaDto respuesta = _trayectoriaProyectoDTOService.CrearTrayectorias(trayectoriaProyectos);
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
        /// Método para insertar el presupuesto del proyecto 
        /// </summary>
        /// <returns>Respuesta presupuesto creado o no</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("presupuesto")]
        public IActionResult PresupuestoProyectos(List<AppPresupuestoDetalleDto> presupuestoProyecto)
        {
            try
            {
                string usuario = GetUserName();
                foreach(var item in presupuestoProyecto)
                {
                    item.UsuCreo = usuario;
                }
                RespuestaDto respuesta = _trayectoriaProyectoDTOService.CrearPresupuesto(presupuestoProyecto);
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
        /// Método para actualizar la información de los beneficiario
        /// </summary>
        /// <param name="beneficiarios">Información de los beneficiarios</param>
        /// <returns>Respuesta Proponente actualizado o no</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("beneficiados")]
        public IActionResult Beneficiados(AppBeneficiariosDto beneficiarios)
        {
            try
            {
                //Parametros auditoria
                beneficiarios.UsuModifico = GetUserName();
                beneficiarios.FecModifico = DateTime.Now;
                beneficiarios.UsuCreo = GetUserName();
                beneficiarios.FecCreo = DateTime.Now;

                var respuesta = _formulariosService.CrearBeneficiarios(beneficiarios);
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
