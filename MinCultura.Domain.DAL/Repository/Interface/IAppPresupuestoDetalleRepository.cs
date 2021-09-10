
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IAppPresupuestoDetalleRepository<AppPresupuestoDetalle>
    {
        ICollection<AppPresupuestoDetalle> Get(Expression<Func<AppPresupuestoDetalle, bool>> predicate);
        long DeleteAll(decimal idProyecto);
        long Create(List<AppPresupuestoDetalle> Entity);
    }
}
