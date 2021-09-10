using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AdmUsuarios
    {
        public decimal UsuId { get; set; }
        public string UsuTipo { get; set; }
        public string UsuUsuario { get; set; }
        public string UsuNombre { get; set; }
        public string UsuCargo { get; set; }
        public string UsuDireccion { get; set; }
        public string UsuTelefono { get; set; }
        public string UsuCorreoElectronico { get; set; }
        public int UsuDiasExpiracion { get; set; }
        public string UsuClave { get; set; }
        public string UsuCambioClave { get; set; }
        public DateTime? UsuFechaUltimoIngreso { get; set; }
        public DateTime? UsuFechaCambioClave { get; set; }
        public DateTime? UsuFechaCreacion { get; set; }
        public DateTime? UsuFechaActualizacion { get; set; }
        public string UsuEstado { get; set; }
        public int? UsuIntentosFallidosIngreso { get; set; }
        public string UsuAdministrador { get; set; }
        public string UsuRevisorEstilo { get; set; }
        public string UsuGenero { get; set; }
        public DateTime? UsuFechaNacimiento { get; set; }
        public int? ZopId { get; set; }
        public string ZonId { get; set; }
        public string UsuActividadRelacionadaCultura { get; set; }
        public string UsuRecibirInfoTemasInteres { get; set; }
        public decimal? DepId { get; set; }
        public string UsuFirma { get; set; }
    }
}
