using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IAppProyectosRepository<AppProyectos>
    {
        ICollection<AppProyectos> Get();
        ICollection<AppProyectos> Get(Expression<Func<AppProyectos, bool>> predicate);
        int Create(AppProyectos Entity);
        int Update(AppProyectos Entity);
    }
}
