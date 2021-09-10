using System;
namespace MinCultura.Domain.Common.DTO
{
    public class ServicioDto
    {
        public byte Servicioid { get; set; }
        public byte IdPadre;
        public string Serviciovista { get; set; }
        public string Servicionombre { get; set; }
        public string Jerarquia;
        public string Serviciotipo { get; set; }
        public int? Servicionivel { get; set; }
        public bool Servicioreferenciareporte { get; set; }
        public bool Servicioactivo { get; set; }
        public bool Serviciohabilitado { get; set; }
        public string Servicioicono { get; set; }
    }
}
