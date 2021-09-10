using System;

namespace MinCultura.Domain.Common.DTO
{
    public class ProyectoActividadesObligatoriasDto
    {
        public decimal? PaoId { get; set; }
        public decimal ProId { get; set; }
        public decimal ActId { get; set; }
        public DateTime ActFechaInicio { get; set; }
        public DateTime ActFechaFinal { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }
        public virtual ActividadesObligatoriasDto ActObl { get; set; }
    }
}
