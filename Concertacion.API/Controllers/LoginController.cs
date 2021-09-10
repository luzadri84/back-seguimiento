using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.Service.Interface;
using Swashbuckle.AspNetCore.Annotations;

namespace Concertacion.API.Controllers
{
    /// <summary>
    /// Controller encargado de realizar la autenticación del API
    /// </summary>
    [Produces("application/json")]
    [Route("api/seguridad")]
    [ApiController]
    [SwaggerTag("Módulo Autenticación")]
    public class LoginController : ControllerBaseAPI
    {

        private readonly IAdministracionService _administracionService;
        private readonly IConfiguration _configuration;

        public LoginController (IConfiguration configuration, IAdministracionService administracionService)
        {
            _configuration = configuration;
            _administracionService = administracionService;
        }

        /// <summary>
        /// Método con las validaciones de autenticación
        /// </summary>
        /// <param name="login">Información del login</param>
        /// <returns>Usuario</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("autenticar")]
        public IActionResult Login(UserLoginDto login)
        {
            try
            {
                var usuario = _administracionService.Login(login);

                if (usuario == null)
                {
                    return BadRequest();
                }

                //TODO incluir el ID del proponente
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Cuentausuariousuario),
                    new Claim("UserId", usuario.Cuentausuarioid.ToString()),
                    new Claim("User", usuario.Cuentausuariousuario),
                    new Claim("ProponenteId", "0")
                };

                var expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration.GetSection("expiresToken").Value));

                return Ok(new
                {
                    usuario,
                    token = BuildToken(claims, expires),
                });
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
        /// Método para crear un usuario y asociarlo a una Entidad
        /// </summary>
        /// <param name="usuario">Información del usuario a crear</param>
        /// <returns>Respuesta Usuario creado si cumple con los requisitos de la convocatoria</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("usuario")]
        public IActionResult Usuario(CrearUsuarioDto usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest();
                }
                var usuarioRespuesta = _administracionService.CrearUsuario(usuario);
                return Ok(usuarioRespuesta);
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
        /// Método para actualizar la información del usuario autenticado
        /// </summary>
        /// <param name="usuario">Información del usuario a actualizar</param>
        /// <returns>Respuesta Usuario actualizado</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("usuario")]
        [Authorize]
        public IActionResult ActualizarUsuario(CuentaUsuarioDto usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest();
                }
                var usuarioRespuesta = _administracionService.ActualizarUsuario(usuario);
                return Ok(usuarioRespuesta);
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
        /// Método para solocitar la recuperación de la clave de un usuario
        /// </summary>
        /// <param name="usuario">Información del usuario que desea recuperar la clave</param>
        /// <returns>Respuesta positiva si logró realizar el proceso de recuperación del correo electrónico y false en caso contrario</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("usuario/recuperar")]
        public IActionResult RecuperarClave(ForgotDto usuario)
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest();
                }
                var usuarioRespuesta = _administracionService.RecuperarClave(usuario);
                return Ok(usuarioRespuesta);
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
        /// Valida si el enlace envíado para cambiar la contraseña es valido y no ha caducado
        /// </summary>
        /// <param name="guid">Número único de identificación de la solicitud de cambio de clave</param>
        /// <returns>True si es valido y habilita el frontend para el cambio</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("usuario/{guid}/linkvalido")]
        public IActionResult RecuperarClave(string guid)
        {
            try
            {
                if (guid == null)
                {
                    return BadRequest();
                }
                var usuarioRespuesta = _administracionService.ValidarLink(guid);
                return Ok(usuarioRespuesta);
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
        /// Valida si el enlace envíado para confirmar el usuario es valido y realiza el proceso de activación del usuario
        /// </summary>
        /// <param name="guid">Número único de identificación de la solicitud de confirmación del usuario</param>
        /// <returns>True si es valido y activa el usuario para permitir el ingreso</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("usuario/{guid}/confirmar")]
        public IActionResult ConfirmarUsuario(string guid)
        {
            try
            {
                if (guid == null)
                {
                    return BadRequest();
                }
                var usuarioRespuesta = _administracionService.ConfirmarUsuario(guid);
                return Ok(usuarioRespuesta);
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
        /// Cambiar la contraseña de un usuario
        /// </summary>
        /// <param name="data">Datos requeridos para el cambio de clave</param>
        /// <returns>True si el proceso se realizó correctamente</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("usuario/cambiar")]
        public IActionResult CambiarClave(ChangePasswordDto data)
        {
            try
            {
                if (data == null)
                {
                    return BadRequest();
                }
                var usuarioRespuesta = _administracionService.CambiarClave(data);
                return Ok(usuarioRespuesta);
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
        /// Construir calim token
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        private string BuildToken(Claim[] claims, DateTime expires)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:SECRET").Value));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            var payload = new JwtPayload
            (
                _configuration.GetSection("JWT:VALID_ISSUER").Value,
                _configuration.GetSection("JWT:VALID_AUDIENCE").Value,
                claims,
                DateTime.Now,
                expires
            );
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
