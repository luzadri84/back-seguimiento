using MinCultura.Domain.Common.DTO;
using System.Collections.ObjectModel;

namespace MinCultura.Domain.BL.Interface
{
    public interface IEnvioCorreoBL
    {
        Collection<EnvioCorreosDto> GetCorreosPendientes();
        void Update(EnvioCorreosDto envioCorreosDto);
    }
}
