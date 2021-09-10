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
    public class AppProponentesRepository : IAppProponentesRepository<AppProponentes>
    {
        private readonly ConcertacionContext context = null;
        public AppProponentesRepository(ConcertacionContext context) 
        {
            this.context = context;
        }

        public long Create(AppProponentes Entity)
        {
            context.AppProponentes.Add(Entity);
            context.SaveChanges();
            return (long)Entity.ProId;
        }

        public ICollection<AppProponentes> Get()
        {
            return context.AppProponentes.ToList();
        }

        public ICollection<AppProponentes> Get(Expression<Func<AppProponentes, bool>> predicate)
        {
            return context.AppProponentes.Include(p => p.Tip).Include(p => p.AppProyectos).Where(predicate).ToList();
        }

        public void Update(AppProponentes Entity)
        {
            context.AppProponentes.Update(Entity);
            context.SaveChanges();
        }
    }
}
