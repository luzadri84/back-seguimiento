
using System.Collections.ObjectModel;
using MinCultura.Domain.Common.DTO;

namespace MinCultura.Domain.BL.Interface
{
    public interface IServicioBL
    {
        Collection<ServicioDto> Get(int cuentaUsuarioId);
    }
}
