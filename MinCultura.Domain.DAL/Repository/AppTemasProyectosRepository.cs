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
    public class AppTemasProyectosRepository: IAppTemasProyectosRepository<AppTemasProyectos>
    {
        private readonly ConcertacionContext context = null;
        public AppTemasProyectosRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public int Create(List<AppTemasProyectos> Entity)
        {
            context.AppTemasProyectos.AddRange(Entity);
            int res = context.SaveChanges();
            return res;
        }

        public int DeleteAll(List<AppTemasProyectos> Entity)
        {
            context.AppTemasProyectos.RemoveRange(Entity);
            int res =context.SaveChanges();
            return res;
        }

        public ICollection<AppTemasProyectos> Get()
        {
            return context.AppTemasProyectos.ToList();
        }

        public ICollection<AppTemasProyectos> Get(Expression<Func<AppTemasProyectos, bool>> predicate)
        {
            return context.AppTemasProyectos.Where(predicate).ToList();
        }

        public int Update(AppTemasProyectos Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppTemasProyectos.Update(Entity);
            int res = context.SaveChanges();
            return res;
        }


    }
}
