using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.DAL.Repository
{
    public class TrayectoriaProyectoRepository : ITrayectoriaProyectoRepository<TrayectoriaProyecto>
    {
        private readonly ConcertacionContext context = null;
        public TrayectoriaProyectoRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public long Create(List<TrayectoriaProyecto> Entity)
        {
            context.TrayectoriaProyecto.AddRange(Entity);
            return context.SaveChanges();
        }
              
        public ICollection<TrayectoriaProyecto> Get(Expression<Func<TrayectoriaProyecto, bool>> predicate)
        {
            return context.TrayectoriaProyecto.Where(predicate).ToList();
        }

        public long DeleteAll(decimal IdProyecto)
        {
            context.TrayectoriaProyecto.RemoveRange(Get(p => p.PRO_ID == IdProyecto));
            return context.SaveChanges();
        }

    }
}
