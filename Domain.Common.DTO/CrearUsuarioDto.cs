namespace MinCultura.Domain.Common.DTO
{
    public class CrearUsuarioDto
    {
        /// <summary>
        /// Indica el tipo de entidad, tabla: [dbo].[APP_TIPOS_ENTIDADES]
        /// </summary>
        public int TipIdEntidad { get; set; }
        /// <summary>
        /// Indica si es departamental o nacional
        /// </summary>
        public decimal TipoEntidad { get; set; }
        /// <summary>
        /// NIT de la entidad que se va asociar en la tabla: dbo.APP_TIPO_ENTIDAD_USUARIO
        /// </summary>
        public string Nit { get; set; }
        /// <summary>
        /// Correo del usuario a registrar para guardar en la tabla: Seguridad.CUENTAUSUARIO
        /// </summary>
        public string Correo { get; set; }
        /// <summary>
        /// Contrasena del usuario a registrar para guardar en la tabla: Seguridad.CUENTAUSUARIO
        /// </summary>
        public string Contrasena { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string NombreUsuario { get; set; }

    }
}
