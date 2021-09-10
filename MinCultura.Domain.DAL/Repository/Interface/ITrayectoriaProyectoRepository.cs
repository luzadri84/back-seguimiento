using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Models;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface ITrayectoriaProyectoRepository<TrayectoriaProyeto>
    {
        ICollection<TrayectoriaProyeto> Get(Expression<Func<TrayectoriaProyeto, bool>> predicate);
        long Create(List<TrayectoriaProyecto> Entity);
        long DeleteAll(decimal IdProyecto);
    }
}
