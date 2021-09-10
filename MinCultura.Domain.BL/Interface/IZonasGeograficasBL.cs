
using System.Collections.ObjectModel;
using MinCultura.Domain.Common.DTO;

namespace MinCultura.Domain.BL.Interface
{
    public interface IZonasGeograficasBL
    {
        Collection<ZonaGeograficaDto> GetDepartamento();
        Collection<ZonaGeograficaDto> GetMunicipiosByDepartamento(string IdDepartamento);
    }
}
