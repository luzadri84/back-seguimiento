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
    /// Controller encargado administrar y gestionar listas del sistema y tablas paramétricas
    /// </summary>
    [Produces("application/json")]
    [Route("api/negocio")]
    [ApiController]
    [SwaggerTag("Módulo para la administración de de los formularios A, B, adjuntar documentos, enviar el proyecto, entre otros.")]
    [Authorize]
    public class FormulariosController : ControllerBaseAPI
    {
        private readonly IFormulariosServicice _formulariosService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="formulariosService"></param>
        public FormulariosController(IFormulariosServicice formulariosService)
        {
            _formulariosService = formulariosService;
        }

        /// <summary>
        /// Método para actualizar la información del proponente, recibe la información del formulario A
        /// </summary>
        /// <param name="formularioA">Información del proponente y del proyecto</param>
        /// <returns>Respuesta Proponente actualizado o no</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("formularioA")]
        public IActionResult FormularioA(FormularioADto formularioA)
        {
            try
            {
                //Parametros auditoria
                formularioA.Proponente.UsuModifico = GetUserName();
                formularioA.Proponente.FecModifico = DateTime.Now;
                formularioA.Proyecto.UsuCreo = GetUserName();
                formularioA.Proyecto.FecCreo = DateTime.Now;
                formularioA.Proyecto.ProEstado = "D";
                var respuesta = _formulariosService.CrearFormularioA(formularioA);
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
        /// Método para actualizar la información del proponente, recibe la información del formulario A
        /// </summary>
        /// <param name="proponente">Información del proponente y del proyecto</param>
        /// <returns>Respuesta Proponente actualizado o no</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("Proponente")]
        public IActionResult Proponente(ProponenteDto proponente)
        {
            try
            {
                //Parametros auditoria
                proponente.UsuModifico = GetUserName();
                proponente.FecModifico = DateTime.Now;
                proponente.UsuCreo = GetUserName();
                proponente.FecCreo = DateTime.Now;
                var respuesta = _formulariosService.CrearProponente(proponente);
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
        /// Método para actualizar la información del proyecto, recibe la información del formulario B
        /// </summary>
        /// <param name="formularioB">Información del proponente y del proyecto</param>
        /// <returns>Respuesta Proponente actualizado o no</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("formularioB")]
        [Authorize]
        public IActionResult FormularioB(FormularioBDto formularioB)
        {
            try
            {
                //Parametros auditoria
                formularioB.Proyecto.UsuModifico = GetUserName();
                formularioB.Proyecto.FecModifico = DateTime.Now;

               var respuesta = _formulariosService.ActualizarFormularioB(formularioB, GetUserName());
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
        /// Método para actualizar la información del proyecto, recibe la información del formulario B
        /// </summary>
        /// <param name="proyecto">Información del proponente y del proyecto</param>
        /// <returns>Respuesta Proponente actualizado o no</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto")]
        //[Authorize]
        public IActionResult Proyecto(ProyectoDto proyecto)
        {
            try
            {
                //Parametros auditoria
                proyecto.UsuModifico = GetUserName();
                proyecto.FecCreo = DateTime.Now;
                proyecto.UsuCreo = GetUserName();
                proyecto.FecModifico = DateTime.Now;
                proyecto.EntId = 43;

                var respuesta = _formulariosService.ActualizarProyecto(proyecto);
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
        /// Consultar Proponente por Id
        /// </summary>
        /// <param name="id">Id del proponente</param>
        /// <returns>Proponente</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proponente/{id}")]
        [Authorize]
        public IActionResult Proponentes(decimal id)
        {
            try
            {
                var proponente = _formulariosService.GetProponenteById(id);
                if (proponente == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen proponentes relacionados con el Id ingresado"
                            }
                        })
                    });
                }
                return Ok(proponente);
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
        /// Consultar Proyectos por Proponente
        /// </summary>
        /// <param name="id">Id del proponente</param>
        /// <returns>Proyectos asociados al proponente</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proponente/{id}/proyectos")]
        [Authorize]
        public IActionResult ProyectosByProponente(decimal id)
        {
            try
            {
                var proyectos = _formulariosService.GetProyectosByProponente(id);
                
                if (proyectos.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen proyectos relacionados con el Id ingresado"
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
        /// Consultar Proyectos por Proponente
        /// </summary>
        /// <param name="id">Id del proponente</param>
        /// <returns>Proyectos asociados al proponente</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proponente/{id}/proyecto")]
        [Authorize]
        public IActionResult ProyectoByProponente(decimal id)
        {
            try
            {
                var proyecto = _formulariosService.GetProyectosByProponente(id)[0];

                if (proyecto == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen proyectos relacionados con el Id ingresado"
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
        /// Consultar Proyectos por Id
        /// </summary>
        /// <param name="id">Id del proyecto</param>
        /// <returns>Proyecto asociado al id</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{id}")]
        [Authorize]
        public IActionResult ProyectosById(decimal id)
        {
            try
            {
                var proyecto = _formulariosService.GetProyectoById(id);
                if (proyecto == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen proyectos relacionados con el Id ingresado"
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
        /// Consultar temas por proyecto
        /// </summary>
        /// <param name="id">Id del proyecto</param>
        /// <returns>Temas asociados al proyecto</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{id}/temas")]
        [Authorize]
        public IActionResult TemasByProyecto(decimal id)
        {
            try
            {
                var proyecto = _formulariosService.GetTemasByProyecto(id);
                if (proyecto == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen proyectos relacionados con el Id ingresado"
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
        /// Consultar Componente por proyecto
        /// </summary>
        /// <param name="id">Id del proyecto</param>
        /// <returns>Componente del proyecto</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{id}/componente")]
        [Authorize]
        public IActionResult ComponenteByProyecto(decimal id)
        {
            try
            {
                var componente = _formulariosService.GetComponenteByProyecto(id);
                return Ok(componente);
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
        /// Consultar cronograma por proyecto
        /// </summary>
        /// <param name="Id">Id del proyecto</param>
        /// <returns>Lista de cronograma</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{Id}/cronograma")]
        [Authorize]
        public IActionResult Cronograma(decimal Id)
        {
            try
            {
                var cronograma = _formulariosService.GetCronograma(Id);
                return Ok(cronograma);
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
        /// Consultar actividades obligatorias por proyecto
        /// </summary>
        /// <param name="proId">Id del proyecto</param>
        /// <returns>Lista de actividades obligatorias</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{proId}/actividadesobligatorias")]
        [Authorize]
        public IActionResult ActividadesObligatoriasByProyecto(decimal proId)
        {
            try
            {
                var cao = _formulariosService.GetActividadesObligatoriasByProyecto(proId);
                return Ok(cao);
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
        /// Consultar valores inidcador por proyecto
        /// </summary>
        /// <param name="proId">Id del proyecto</param>
        /// <returns>Lista valores inidcadores</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{proId}/valoresindicador")]
        [Authorize]
        public IActionResult ValoresInidcadorByProyecto(decimal proId)
        {
            try
            {
                var vi = _formulariosService.GetValoresIndicadorByProyecto(proId);
                return Ok(vi);
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
        /// Consultar valores inidcador por categoria del municipio por proyecto
        /// </summary>
        /// <param name="proId">Id del proyecto</param>
        /// <returns>Lista valores indicadores por categoria del municipio</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{proId}/valoresindicadorlineacategoriamunicipio")]
        //[Authorize]
        public IActionResult GetValoresIndicadorLineaCategoriaMunicipio(decimal proId)
        {
            try
            {
                var vi = _formulariosService.GetValoresIndicadorLineaCategoriaMunicipio(proId);
                return Ok(vi);
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
        /// Método para actualizar la información del seguimiento
        /// </summary>
        /// <param name="seguimiento">Información de la actividad de seguimiento</param>
        /// <returns>Respuesta Seguimiento actualizado o no</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("seguimiento")]
        public IActionResult Seguimiento(ConSeguimientosDto seguimiento)
        {
            try
            {
                //Parametros auditoria
                seguimiento.UsuCreo = GetUserName();
                seguimiento.SegFechaCreo = DateTime.Now;
                var respuesta = _formulariosService.CrearSeguimiento(seguimiento);
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
