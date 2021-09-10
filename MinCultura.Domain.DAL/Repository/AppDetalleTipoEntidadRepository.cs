using Microsoft.EntityFrameworkCore;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository
{
    public class AppDetalleTipoEntidadRepository : IAppDetallesTipoEntidadesRepository<AppDetalleTiposEntidades>
    {
        private readonly ConcertacionContext context = null;
        public AppDetalleTipoEntidadRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public int Create(List<AppDetalleTiposEntidades> Entity)
        {
            context.AppDetalleTiposEntidades.AddRange(Entity);
            return context.SaveChanges();
        }


        public int DeleteAll(List<AppDetalleTiposEntidades> Entity)
        {
            context.AppDetalleTiposEntidades.RemoveRange(Entity);
            return context.SaveChanges();
        }

        public int Delete(AppDetalleTiposEntidades Entity)
        {
            context.AppDetalleTiposEntidades.Remove(Entity);
            return context.SaveChanges();
        }

        public ICollection<AppDetalleTiposEntidades> Get()
        {
            return context.AppDetalleTiposEntidades.ToList();
        }

        public ICollection<AppDetalleTiposEntidades> Get(Expression<Func<AppDetalleTiposEntidades, bool>> predicate)
        {
            return context.AppDetalleTiposEntidades.Where(predicate).ToList();
        }

        public int Update(AppDetalleTiposEntidades Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppDetalleTiposEntidades.UpdateRange(Entity);
            return context.SaveChanges();
        }
    }
}
