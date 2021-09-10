using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.DAL.Repository
{
    public class AppProyectosRepository : IAppProyectosRepository<AppProyectos>
    {
        private readonly ConcertacionContext context = null;
        public AppProyectosRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public int Create(AppProyectos Entity)
        {
            context.AppProyectos.Add(Entity);
            context.SaveChanges();
            return Convert.ToInt32(Entity.ProId);
        }

        public ICollection<AppProyectos> Get()
        {
            return context.AppProyectos.ToList();
        }

        public ICollection<AppProyectos> Get(Expression<Func<AppProyectos, bool>> predicate)
        {
            return context.AppProyectos.Include(p => p.AppRadicadoProyectos).Where(predicate).ToList();
        }

        public int Update(AppProyectos Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppProyectos.Update(Entity);
            context.SaveChanges();
            return Convert.ToInt32(Entity.ProId);
        }
    }
}
