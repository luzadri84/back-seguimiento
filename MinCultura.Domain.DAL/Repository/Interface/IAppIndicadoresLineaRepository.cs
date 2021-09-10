using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IAppIndicadoresLineaRepository<AppIndicadoresLinea>
    {
        ICollection<AppIndicadoresLinea> Get();
        ICollection<AppIndicadoresLinea> Get(Expression<Func<AppIndicadoresLinea, bool>> predicate);
        int Create(AppIndicadoresLinea Entity);
        int Update(AppIndicadoresLinea Entity);
        int Delete(AppIndicadoresLinea Entity);
        int DeleteAll(List<AppIndicadoresLinea> Entity);
    }
}
