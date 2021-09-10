using MinCultura.Domain.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IAppComponentesRepository<AppComponentes>
    {
        ICollection<AppComponentes> Get();
        ICollection<AppComponentes> Get(Expression<Func<AppComponentes, bool>> predicate);
        int Create(AppComponentes Entity);
        int Update(AppComponentes Entity);
        int Delete(AppComponentes Entity);
    }
}
