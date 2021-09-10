using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IIndicadorLineaCategoriaMunicipioRepository<AppIndicadorLineaCategoriaMunicipio>
    {
        ICollection<AppIndicadorLineaCategoriaMunicipio> Get();
        ICollection<AppIndicadorLineaCategoriaMunicipio> Get(Expression<Func<AppIndicadorLineaCategoriaMunicipio, bool>> predicate);
        int Create(AppIndicadorLineaCategoriaMunicipio Entity);
        int Update(AppIndicadorLineaCategoriaMunicipio Entity);
        int Delete(AppIndicadorLineaCategoriaMunicipio Entity);
        int DeleteAll(List<AppIndicadorLineaCategoriaMunicipio> Entity);
    }
}
