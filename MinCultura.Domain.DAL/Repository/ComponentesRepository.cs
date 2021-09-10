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
    public class ComponentesRepository: IAppComponentesRepository<AppComponentes>
    {
        private readonly ConcertacionContext context = null;
        public ComponentesRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public int Create(AppComponentes Entity)
        {
            context.AppComponentes.Add(Entity);
            return context.SaveChanges();
        }

        public ICollection<AppComponentes> Get()
        {
            return context.AppComponentes.ToList();
        }

        public ICollection<AppComponentes> Get(Expression<Func<AppComponentes, bool>> predicate)
        {
            return context.AppComponentes.Where(predicate).ToList();
        }

        public int Update(AppComponentes Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppComponentes.Update(Entity);
            return context.SaveChanges();
        }

        public int Delete(AppComponentes Entity)
        {
            context.AppComponentes.Remove(Entity);
            int res = context.SaveChanges();
            return res;
        }
    }

}

