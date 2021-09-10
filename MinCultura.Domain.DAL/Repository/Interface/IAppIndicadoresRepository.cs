using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IAppIndicadoresRepository<AppIndicadores>
    {
        ICollection<AppIndicadores> Get();
        ICollection<AppIndicadores> Get(Expression<Func<AppIndicadores, bool>> predicate);
        int Create(AppIndicadores Entity);
        int Update(AppIndicadores Entity);
        int Delete(AppIndicadores Entity);
        int DeleteAll(List<AppIndicadores> Entity);
    }
}

