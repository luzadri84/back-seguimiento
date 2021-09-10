
using MinCultura.Domain.Common.DTO;

namespace MinCultura.Domain.Service.Interface
{
    public interface IEnvioProyectoService
    {
        RespuestaEnvioDto EnviarProyecto(decimal id, string usuario);
    }
}
