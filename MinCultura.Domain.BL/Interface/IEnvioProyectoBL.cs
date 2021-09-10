
using MinCultura.Domain.Common.DTO;

namespace MinCultura.Domain.BL.Interface
{
    public interface IEnvioProyectoBL
    {
        RespuestaEnvioDto EnviarProyecto(decimal id, string usuario);
    }
}
