using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IValoresIndicadorLineaCategoriaMunicipioRepository<AppValoresIndicadoeLineaCategoriaMunicipio>
    {
        ICollection<AppValoresIndicadoeLineaCategoriaMunicipio> Get();
        ICollection<AppValoresIndicadoeLineaCategoriaMunicipio> Get(Expression<Func<AppValoresIndicadoeLineaCategoriaMunicipio, bool>> predicate);
        int Create(List<AppValoresIndicadoeLineaCategoriaMunicipio> Entity);
        int Update(AppValoresIndicadoeLineaCategoriaMunicipio Entity);
        int Delete(AppValoresIndicadoeLineaCategoriaMunicipio Entity);
        int DeleteAll(List<AppValoresIndicadoeLineaCategoriaMunicipio> Entity);
    }
}
