
using System.Collections.ObjectModel;

namespace MinCultura.Domain.Common.DTO
{
    public class RespuestaEnvioDto
    {
        public bool Resultado { get; set; }
        public string Mensaje { get; set; }
        public Collection<ErrorDto> Errores { get; set; }
    }
}
