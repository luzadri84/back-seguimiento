using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using MinCultura.Domain.Common.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Concertacion.API.Controllers
{
    /// <summary>
    /// Clase abstracta para los controladores que manejen autenticación por token
    /// </summary>
    public class ControllerBaseAPI : ControllerBase
    {
        /// <summary>
        /// Obtiene el valor de la Claim por su key
        /// </summary>
        /// <param name="key">Llave a obtener</param>
        /// <returns></returns>
        [NonAction]
        public string GetClaim(string key)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var securityToken = tokenHandler.ReadToken(authHeader) as JwtSecurityToken;
            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == key).Value;
            return stringClaimValue;
        }

        /// <summary>
        /// Obtener el Id del usuario autenticado
        /// </summary>
        /// <returns>Id User</returns>
        [NonAction]
        public int GetUserId()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var securityToken = tokenHandler.ReadToken(authHeader) as JwtSecurityToken;
            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == "UserId").Value;
            return Convert.ToInt32(stringClaimValue);
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

        /// <summary>
        /// Obtener proponente asociado al usuario
        /// </summary>
        /// <returns></returns>
        [NonAction]
        public decimal GetProponenteId()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var securityToken = tokenHandler.ReadToken(authHeader) as JwtSecurityToken;

            var stringClaimValue = securityToken.Claims.First(claim => claim.Type == "ProponenteId").Value;
            return Convert.ToDecimal(stringClaimValue);
        }

        /// <summary>
        /// Maneja la respuesta de error causado por un error del sistema
        /// </summary>
        /// <param name="error">Mensaje de error</param>
        /// <param name="errorCode">Código del error</param>
        /// <returns>Respuesta en json</returns>
        protected ActionResult HandleError(string error, string errorCode = "")
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new RespuestaErrorDto()
            {
                Estado = StatusCodes.Status500InternalServerError,
                Errores = new List<ErrorDto>(new[]
                    {
                        new ErrorDto()
                        {
                            Codigo = errorCode,
                            Descripcion = error
                        }
                    })
            });
        }
    }
}
