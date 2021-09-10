using System;
namespace MinCultura.Domain.Common.DTO
{
    public class ZonaGeograficaDto
    {
        public string ZonId { get; set; }
        public string ZonNombre { get; set; }
        public string ZonPadreId { get; set; }
        public decimal? ZonPoblacion { get; set; }
        public decimal? ZonPoblacionsinic { get; set; }
        public byte? ZonDistrito { get; set; }
        public double? ZonLatitud { get; set; }
        public double? ZonLongitud { get; set; }
        public string ZonCategoria { get; set; }
    }
}
