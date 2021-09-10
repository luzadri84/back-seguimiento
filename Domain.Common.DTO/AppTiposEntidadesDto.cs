using System;

namespace MinCultura.Domain.Common.DTO
{
    public class AppTiposEntidadesDto
    {
        public int TipId { get; set; }
        public string TipNombre { get; set; }
        public decimal VigId { get; set; }
        public decimal TipTipId { get; set; }
        public short? TipNumeroProyectos { get; set; }
        public DateTime FecCreo { get; set; }
        public string UsuCreo { get; set; }
        public bool TipRecursosEntidad { get; set; }
    }

}