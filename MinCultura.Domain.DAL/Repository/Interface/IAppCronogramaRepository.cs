using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IAppCronogramaRepository<AppCronograma>
    {
        ICollection<AppCronograma> Get();
        ICollection<AppCronograma> Get(Expression<Func<AppCronograma, bool>> predicate);
        int Create(List<AppCronograma> Entity);
        int Update(AppCronograma Entity);
        int Delete(AppCronograma Entity);
        int DeleteAll(List<AppCronograma> Entity);
    }
}
