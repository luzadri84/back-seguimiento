using System;
namespace MinCultura.Domain.Common.DTO
{
    public class AppVigenciasDto
    {
        public decimal VigId { get; set; }
        public string VigNombre { get; set; }
        public DateTime VigFechaInicio { get; set; }
        public DateTime VigFechaFinal { get; set; }
        public string VigEstado { get; set; }
        public int? VigPlazoDocumentacion { get; set; }
        public int? VigDiasExpiracionProyecto { get; set; }
        public int? VigConsecutivo { get; set; }
        public int? VigConsecutivoNac { get; set; }
        public int? VigValorMaximo { get; set; }
    }
}
