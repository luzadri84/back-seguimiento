using System;

namespace MinCultura.Domain.Common.DTO
{
    public  class AppDocumentosTipoEntidadesDto
    {
        public decimal TdoId { get; set; }
        public int TipId { get; set; }
        public string TdoNs { get; set; }
        public decimal? TdoOrden { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }
        public string TdoNombre { get; set; }
        public string TdoObservacion { get; set; }
        public bool Obligatorio { get; set; }
    }
}
