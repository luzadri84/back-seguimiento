using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IValoresIndicadorRepository<AppValoresIndicador>
    {
        ICollection<AppValoresIndicador> Get();
        ICollection<AppValoresIndicador> Get(Expression<Func<AppValoresIndicador, bool>> predicate);
        int Create(List<AppValoresIndicador> Entity);
        int Update(AppValoresIndicador Entity);
        int Delete(AppValoresIndicador Entity);
        int DeleteAll(List<AppValoresIndicador> Entity);
    }
}
