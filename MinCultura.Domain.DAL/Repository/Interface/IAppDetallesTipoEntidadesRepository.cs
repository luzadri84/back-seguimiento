using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IAppDetallesTipoEntidadesRepository<AppDetalleTiposEntidades>
    {
        ICollection<AppDetalleTiposEntidades> Get();
        ICollection<AppDetalleTiposEntidades> Get(Expression<Func<AppDetalleTiposEntidades, bool>> predicate);
        int Create(List<AppDetalleTiposEntidades> Entity);
        int Update(AppDetalleTiposEntidades Entity);
        int Delete(AppDetalleTiposEntidades Entity);
        int DeleteAll(List<AppDetalleTiposEntidades> Entity);
    }
}
