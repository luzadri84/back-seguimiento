using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.DAL.Repository
{
    public class AppPresupuestoDetalleRepository : IAppPresupuestoDetalleRepository<AppPresupuestoDetalle>
    {
        private readonly ConcertacionContext context = null;
        public AppPresupuestoDetalleRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public long Create(List<AppPresupuestoDetalle> Entity)
        {
            context.AppPresupuestoDetalle.AddRange(Entity);
            return context.SaveChanges();
        }
       
        public ICollection<AppPresupuestoDetalle> Get(Expression<Func<AppPresupuestoDetalle, bool>> predicate)
        {
            return context.AppPresupuestoDetalle.Where(predicate).ToList();
        }
       
        public long DeleteAll(decimal idProyecto)
        {
            context.AppPresupuestoDetalle.RemoveRange(Get(p => p.ProId == idProyecto));
            return context.SaveChanges();
        }
    }
}