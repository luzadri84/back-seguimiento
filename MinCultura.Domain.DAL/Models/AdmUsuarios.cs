using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("ADM_USUARIOS")]
    public partial class AdmUsuarios
    {
        [Key]
        [Column("USU_ID", TypeName = "decimal(18, 0)")]
        public decimal UsuId { get; set; }
        [Column("USU_TIPO")]
        public string UsuTipo { get; set; }
        [Column("USU_USUARIO")]
        public string UsuUsuario { get; set; }
        [Column("USU_NOMBRE")]
        public string UsuNombre { get; set; }
        [Column("USU_CARGO")]
        public string UsuCargo { get; set; }
        [Column("USU_DIRECCION")]
        public string UsuDireccion { get; set; }
        [Column("USU_TELEFONO")]
        public string UsuTelefono { get; set; }
        [Column("USU_CORREO_ELECTRONICO")]
        public string UsuCorreoElectronico { get; set; }
        //public int UsuDiasExpiracion { get; set; }
        //public string UsuClave { get; set; }
        //public string UsuCambioClave { get; set; }
        //public DateTime? UsuFechaUltimoIngreso { get; set; }
        //public DateTime? UsuFechaCambioClave { get; set; }
        //public DateTime? UsuFechaCreacion { get; set; }
        //public DateTime? UsuFechaActualizacion { get; set; }
        //public string UsuEstado { get; set; }
        //public int? UsuIntentosFallidosIngreso { get; set; }
        //public string UsuAdministrador { get; set; }
        //public string UsuRevisorEstilo { get; set; }
        //public string UsuGenero { get; set; }
        //public DateTime? UsuFechaNacimiento { get; set; }
        //public int? ZopId { get; set; }
        //public string ZonId { get; set; }
        //public string UsuActividadRelacionadaCultura { get; set; }
        //public string UsuRecibirInfoTemasInteres { get; set; }
        //public decimal? DepId { get; set; }
        //public string UsuFirma { get; set; }
    }
}
