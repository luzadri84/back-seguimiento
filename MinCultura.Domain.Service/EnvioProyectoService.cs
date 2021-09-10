
using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.Service.Interface;

namespace MinCultura.Domain.Service
{
    public class EnvioProyectoService : IEnvioProyectoService
    {
        private readonly IEnvioProyectoBL _envioProyectoBL;

        public EnvioProyectoService(IEnvioProyectoBL envioProyectoBL)
        {
            _envioProyectoBL = envioProyectoBL;
        }

        public RespuestaEnvioDto EnviarProyecto(decimal id, string usuario)
        {
            return _envioProyectoBL.EnviarProyecto(id, usuario);
        }
    }
}
