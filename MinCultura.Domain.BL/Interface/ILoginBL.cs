using System;
using System.Collections.ObjectModel;
using MinCultura.Domain.Common.DTO;

namespace MinCultura.Domain.BL.Interface
{
    public interface ILoginBL
    {
        /// <summary>
        /// Metodo con las validaciones de autenticación
        /// </summary>
        /// <param name="login">Información del login</param>
        /// <returns>Usuario</returns>
        CuentaUsuarioDto Login(UserLoginDto login);

        /// <summary>
        /// Método para crear un usuario y asociarlo a una Entidad
        /// </summary>
        /// <param name="usuario">Información del usuario a crear</param>
        /// <returns>Respuesta Usuario creado si cumple con los requisitos de la convocatoria</returns>
        CrearUsuarioRespuestaDto CrearUsuario(CrearUsuarioDto crear);

        /// <summary>
        /// Método para actualizar un usuario y asociarlo a una Entidad
        /// </summary>
        /// <param name="usuario">Información del usuario a actualizar</param>
        /// <returns>Respuesta Usuario actualizado si cumple con los requisitos de la convocatoria</returns>
        bool ActualizarUsuario(CuentaUsuarioDto actualizar);

        /// <summary>
        /// Método para solocitar la recuperación de la clave de un usuario
        /// </summary>
        /// </summary>
        /// <param name="usuario">Información del usuario que desea recuperar la clave</param>
        /// <returns>Respuesta positiva si logró realizar el proceso de recuperación del correo electrónico y false en caso contrario</returns>
        RespuestaDto RecuperarClave(ForgotDto usuario);

        /// <summary>
        /// Valida si el enlace envíado para cambiar la contraseña es valido y no ha caducado
        /// </summary>
        /// <param name="guid">Número único de identificación de la solicitud de cambio de clave</param>
        /// <returns>True si es valido</returns>
        RespuestaDto ValidarLink(string guid);

        /// <summary>
        /// Cambiar la contraseña de un usuario
        /// </summary>
        /// <param name="data">Datos requeridos para el cambio de clave</param>
        /// <returns>True si el proceso se realizó correctamente</returns>
        RespuestaDto CambiarClave(ChangePasswordDto guid);

        /// <summary>
        /// Valida si el enlace envíado para confirmar el usuario es valido
        /// </summary>
        /// <param name="guid">Número único de identificación de la solicitud de confirmación del usuario</param>
        /// <returns>True si es valido</returns>
        RespuestaDto ConfirmarUsuario(string guid);

        /// <summary>
        /// Lista Usuarios por perfil
        /// </summary>
        /// <param name="crear"></param>
        /// <returns></returns>
        Collection<FuncionarioDto> getFuncionarios(int idPerfil);



    }
}
