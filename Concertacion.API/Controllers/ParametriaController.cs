using HeyRed.Mime;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.Service.Interface;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IO;

namespace Concertacion.API.Controllers
{
    /// <summary>
    /// Controller encargado administrar y gestionar listas del sistema y tablas paramétricas
    /// </summary>
    [Produces("application/json")]
    [Route("api/parametria")]
    [ApiController]
    [SwaggerTag("Módulo Parametricas y Divipola")]
    public class ParametriaController : ControllerBaseAPI
    {
        private readonly IAdministracionService _administracionService;
        private readonly ITrayectoriaProyectoService _TrayectoriaProyectoDTOService;
        private readonly IConfiguration _configuration;
        private readonly IFormulariosServicice _formulariosService;

        public ParametriaController(IConfiguration configuration, IAdministracionService administracionService, ITrayectoriaProyectoService trayectoriaService, IFormulariosServicice formulariosService)
        {
            _administracionService = administracionService;
            _TrayectoriaProyectoDTOService = trayectoriaService;
            _configuration = configuration;
            _formulariosService = formulariosService;
        }

        /// <summary>
        /// Consultar departamentos de Colombia
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
       // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("departamentos")]
        //[Authorize]
        public IActionResult Departamentos()
        {
            try
            {
                var departamentos = _administracionService.GetDepartamento();
                if (departamentos.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen municipios relacionados con el código ingresado"
                            }
                        })
                    });
                }
                return Ok(departamentos);
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
        /// Consultar municipios por departamento
        /// </summary>
        /// <returns>Listado de municipios</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
       // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("departamentos/{id}/municipios")]
        //[Authorize]
        public IActionResult Municipios(string id)
        {
            try
            {
                var municipios = _administracionService.GetMunicipiosByDepartamento(id);
                if (municipios.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen municipios relacionados con el código ingresado"
                            }
                        })
                    });
                }
                return Ok(municipios);
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
        /// Consultar servicios por usuarios para la construcción del menu del sistema
        /// </summary>
        /// <returns>Listado de servicios configurados al usuario</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("menu")]
        [Authorize]
        public IActionResult Servicios()
        {
            try
            {
                var servicios = _administracionService.GetServicios(GetUserId());
                if (servicios.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen servicios configurados al usuario autenticado"
                            }
                        })
                    });
                }
                return Ok(servicios);
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
        /// Consultar las vigencias configuradas en el sistema
        /// </summary>
        /// <returns>Listado de vigencias</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("vigencia")]
        //[Authorize]
        public IActionResult Vigencia()
        {
            try
            {
                var vigencias = _administracionService.GetAppVigencias();
                if (vigencias.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen vigencias configuradas."
                            }
                        })
                    });
                }
                return Ok(vigencias);
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
        /// Consultar los tipos de entidad configuradas en el sistema por la vigencia actual: $Current_year + 1
        /// </summary>
        /// <returns>Listado de tipos de entidad</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("tiposentidad")]
        public IActionResult TiposEntidad()
        {
            try
            {
                var tiposEntidad = _administracionService.GetTiposEntidades();
                if (tiposEntidad.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen tipos de entidad configuradas para la vigencia en curso."
                            }
                        })
                    });
                }
                return Ok(tiposEntidad);
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
        /// Consultar los indicadores por línes
        /// </summary>
        /// <returns>Listado de vigencias</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("linea/{id}/indicadores")]
        [Authorize]
        public IActionResult InidcadoresByLinea(decimal id)
        {
            try
            {
                var indicadores = _administracionService.GetIndicadoresByLinea(id);
                return Ok(indicadores);
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
        /// Consultar los indicadores
        /// </summary>
        /// <returns>Listado indicadores</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("indicadores")]
        [Authorize]
        public IActionResult Indicadores()
        {
            try
            {
                var indicadores = _administracionService.GetIndicadores();
                return Ok(indicadores);
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
        /// Consultar las vigencias configuradas en el sistema
        /// </summary>
        /// <returns>Listado de vigencias</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("lineas")]
        [Authorize]
        public IActionResult Lineas()
        {
            try
            {
                var lineas = _administracionService.GetLineas();
                if (lineas.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen líneas."
                            }
                        })
                    });
                }
                return Ok(lineas);
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
        /// Consultar las áreas configuradas en el sistema
        /// </summary>
        /// <returns>Listado de áreas</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("areas")]
        [Authorize]
        public IActionResult Areas()
        {
            try
            {
                var areas = _administracionService.GetAreas();
                if (areas.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen líneas."
                            }
                        })
                    });
                }
                return Ok(areas);
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
        /// Consultar entidades financieras
        /// </summary>
        /// <returns>Lista de entidades financieras</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("entidadesfinancieras")]
        [Authorize]
        public IActionResult EntidadesFinancieras()
        {
            try
            {
                var entFinancieras = _administracionService.GetEntidadesFinancieras();
                if (entFinancieras.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen entidades financieras"
                            }
                        })
                    });
                }
                return Ok(entFinancieras);
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
        /// Consultar temas por línea
        /// </summary>
        /// <returns>Lista de temas por línea</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("linea/{id}/temas")]
        [Authorize]
        public IActionResult TemasbyLinea(int id)
        {
            try
            {
                var temas = _administracionService.GetTemasByLinea(id);
                return Ok(temas);
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
        /// Consultar actividades obligatorias
        /// </summary>
        /// <returns>Lista de actividades obligatorias</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("actividadesobligatorias")]
        [Authorize]
        public IActionResult ActividadesObligatorias()
        {
            try
            {
                var actividadesObligatorias = _administracionService.GetActividadesObligatorias();
                if (actividadesObligatorias.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen actividades obligatorias"
                            }
                        })
                    });
                }
                return Ok(actividadesObligatorias);
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
        /// Consulta la trayectoria de la vigencia activa
        /// </summary>
        /// <returns>Listado de preguntas</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("trayectorias")]
        [Authorize]
        public IActionResult Trayectorias()
        {
            try
            {
                var trayectorias = _administracionService.GetTrayectoria();
                if (trayectorias.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen preguntas de trayectoria."
                            }
                        })
                    });
                }
                return Ok(trayectorias);
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
        /// Consulta la trayectoria de la vigencia activa por tipo
        /// </summary>
        /// <returns>Listado de preguntas</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("trayectorias/{tipo}")]
        [Authorize]
        public IActionResult Trayectorias(int tipo)
        {
            try
            {
                var trayectorias = _administracionService.GetTrayectoria(tipo);
                if (trayectorias.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen preguntas de trayectoria."
                            }
                        })
                    });
                }
                return Ok(trayectorias);
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
        /// Consulta el tipo de trayectoria
        /// </summary>
        /// <returns>Listado de tipo de trayectoria</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("tipotrayectorias")]
        [Authorize]
        public IActionResult TipoTrayectorias()
        {
            try
            {
                var tipotrayectorias = _administracionService.GetTipoTrayectoria();
                if (tipotrayectorias.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen preguntas de trayectoria."
                            }
                        })
                    });
                }
                return Ok(tipotrayectorias);
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
        /// Consulta la trayectoria
        /// </summary>
        /// <returns>Listado de tipo de trayectoria</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{id}/trayectorias")]
        [Authorize]
        public IActionResult ConsultaTrayectoria(decimal id)
        {
            try
            {
                var trayectorias = _TrayectoriaProyectoDTOService.GetTrayectoriasProyecto(id);
                return Ok(trayectorias);
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
        /// lista la parametrización de los tipos de presupuesto
        /// </summary>
        /// <returns>Parametrización tipo de titulos</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("tipopresupuesto")]
        [Authorize]
        public IActionResult TipoPresupuesto()
        {
            try
            {
                var presupuesto = _administracionService.GetAppPresupuestoDetalleTipoTitulos();
                if (presupuesto.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                    {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = "No existen parametrización para el presupuesto."
                            }
                        })
                    });
                }
                return Ok(presupuesto);
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
        /// lista la parametrización del dedetalle de la parametrizacion
        /// </summary>
        /// <returns>dedetalle de la parametrizacion de presupuesto</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("detallepresupuesto")]
        [Authorize]
        public IActionResult ConsultaPresupuestoDetalleTipo()
        {
            try
            {
                var presupuesto = _administracionService.GetAppPresupuestoDetalleTipo();
                if (presupuesto.Count == 0)
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
                return Ok(presupuesto);
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
        /// lista el detalle del presupuesto
        /// </summary>
        /// <returns>dedetalle de la parametrizacion de presupuesto</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{id}/presupuesto")]
        [Authorize]
        public IActionResult ConsultaPresupuestoDetalle(decimal id)
        {
            try
            {
                var presupuesto = _administracionService.GetAppPresupuestoDetalle(id);
                return Ok(presupuesto);
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
        /// Consultar los indicadores por categoria del municipio
        /// </summary>
        /// <returns>Listado de indicadores por categorias del municipio</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("indicadoreslineacategoriamunicipio")]
        [Authorize]
        public IActionResult GetAppIndicadorLineaCategoriaMunicipio()
        {
            try
            {
                var ilcm = _administracionService.GetAppIndicadorLineaCategoriaMunicipio();
                return Ok(ilcm);
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
        /// lista de los documentos a cargar
        /// </summary>
        /// <returns>documentos</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("documentos/{id}")]
        [Authorize]
        public IActionResult ConsultaDocumentos(int id)
        {
            try
            {
                var documentos = _administracionService.GetappTipoDocumentosValores(id);
                return Ok(documentos);
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
        /// Salvar documento
        /// </summary>
        /// <returns>documentos</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("documentos/{idProd}/{idTdo}/{docAnterior}/{cantidadHojas}")]
        [Authorize]
        public IActionResult CargarDocumento(IFormFile file, int idProd, int idTdo, string docAnterior, int cantidadHojas)
        {
            try
            {
                AppTipoDocumentosValoresDto documento = new AppTipoDocumentosValoresDto();
                documento.ProId = idProd;
                documento.TdoId = idTdo;
                documento.TdvNombre = idTdo.ToString() + "_" + file.FileName;
                documento.TdvNumeroPaginas = cantidadHojas;
                documento.TdvRutaAdjunto = idProd + "/";
                documento.FecCreo = DateTime.Now;
                documento.UsuCreo = GetUserName();

                var path = _configuration.GetSection("rutaDocumentos").Value + idProd.ToString();
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                if (System.IO.File.Exists(path + "\\" + docAnterior))
                    System.IO.File.Delete(path + "\\" + docAnterior);

                using (var fileStream = System.IO.File.Create(Path.Combine(path, documento.TdvNombre)))
                {
                    file.CopyTo(fileStream);
                }

                string extension = Path.GetExtension(file.FileName);
                int numberOfPages = 0;
                if (extension.Equals(".pdf"))
                {
                    PdfReader pdfReader = new PdfReader(path + "/" + documento.TdvNombre);
                    numberOfPages = pdfReader.NumberOfPages;
                    documento.TdvNumeroPaginas = numberOfPages;
                    pdfReader.Close();
                }
                return Ok(_TrayectoriaProyectoDTOService.CrearDocumento(documento));
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
        /// Descargar documento
        /// </summary>
        /// <returns>documentos</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("documentos/{idProd}/{nombreArchivo}/descargar")]
        [Authorize]
        public IActionResult DescargarDocumento(int idProd, string nombreArchivo)
        {
            try
            {
                string ruta = _configuration.GetSection("rutaDocumentos").Value + idProd.ToString() + "/" + nombreArchivo;
                if (System.IO.File.Exists(ruta))
                {
                    using (FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                    {
                        byte[] archivo = new byte[fs.Length];
                        fs.Read(archivo, 0, (int)fs.Length);
                        fs.Close();
                        return File(archivo, GetMimeType(nombreArchivo), nombreArchivo);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new RespuestaErrorDto()
                    {
                        Estado = StatusCodes.Status404NotFound,
                        Errores = new List<ErrorDto>(new[]
                        {
                            new ErrorDto()
                            {
                                Codigo = StatusCodes.Status404NotFound.ToString(),
                                Descripcion = $"No existe el archivo {nombreArchivo}"
                            }
                        })
                    });
                }
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
        /// Consultar Beneficiarios por Id
        /// </summary>
        /// <param name="id">Id del proyecto</param>
        /// <returns>Beneficiario</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{id}/beneficiario")]
        [Authorize]
        public IActionResult Beneficiarios(decimal id)
        {
            try
            {
                var beneficiarios = _formulariosService.ConsultarBeneficiarios(id);
                return Ok(beneficiarios);
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
        /// Consultar los proyectos inscritos es una convocatoria
        /// </summary>
        /// <param name="idVigencia">idVigencia</param>
        /// <param name="depId">idVigencia</param>
        /// <param name="munId">idVigencia</param>
        /// <returns>proyectos</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
       // [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("proyecto/{idVigencia}/{depId}/{munId}/{proyecto}/{proponente}/{nroRadicacion}/resultado")]
        //[Authorize]
        public IActionResult Resultado(int idVigencia, string depId, string munId,string proyecto, string proponente, string nroRadicacion)
        {
            try
            {
                var resultado =  _administracionService.GetResultadoConvocatoria(idVigencia, depId,  munId,  proyecto,  proponente,  nroRadicacion);
                return Ok(resultado);
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
        /// Consultar Beneficiarios por Id
        /// </summary>
        /// <param name="id">Id del perfil</param>
        /// <returns>Beneficiario</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("Usuario/{id}/Funcionarios")]
        //[Authorize]
        public IActionResult Funcionarios(int id)
        {
            try
            {
                var beneficiarios = _administracionService.getFuncionarios(id);
                return Ok(beneficiarios);
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
        /// Consultar requisitos por tipo de entidad
        /// </summary>
        /// <param name="id">Id del tipo de entidad</param>
        /// <returns>Lista de requisitos</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("requisitos/tipoentidad/{id}")]
        [Authorize]
        public IActionResult RequisitosByTipoEntidad(int id)
        {
            try
            {
                var requisitos = _administracionService.GetRequisitos(id);
                return Ok(requisitos);
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
        /// Consultar las zonas
        /// </summary>
        /// <returns>Lista de zonas</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("zonas")]
        //[Authorize]
        public IActionResult Zonas()
        {
            try
            {
                var requisitos = _administracionService.GetZonas();
                return Ok(requisitos);
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
        /// Consultar los estados
        /// </summary>
        /// <returns>Lista de zonas</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("estados")]
        //[Authorize]
        public IActionResult Estados()
        {
            try
            {
                var requisitos = _administracionService.GetEstados();
                return Ok(requisitos);
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
        /// Consultar los estados
        /// </summary>
        /// <returns>Lista de zonas</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("actividades")]
        //[Authorize]
        public IActionResult Actividades()
        {
            try
            {
                var requisitos = _administracionService.GetActividades();
                return Ok(requisitos);
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

        /// Obtener el MimeType dada la extensión del archivo
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetMimeType(string fileName)
        {
            return MimeTypesMap.GetMimeType(fileName);
        }

    }
}