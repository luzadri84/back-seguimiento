using Microsoft.EntityFrameworkCore;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;
using MinCultura.Domain.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository
{
    public class IndicadoresRepository:IAppIndicadoresRepository<AppIndicadores>
    {
        private readonly ConcertacionContext context = null;
        public IndicadoresRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public int Create(AppIndicadores Entity)
        {
            context.AppIndicadores.Add(Entity);
            return context.SaveChanges();
        }


        public int DeleteAll(List<AppIndicadores> Entity)
        {
            context.AppIndicadores.RemoveRange(Entity);
            return context.SaveChanges();
        }

        public int Delete(AppIndicadores Entity)
        {
            context.AppIndicadores.Remove(Entity);
            return context.SaveChanges();
        }

        public ICollection<AppIndicadores> Get()
        {
            return context.AppIndicadores.ToList();
        }

        public ICollection<AppIndicadores> Get(Expression<Func<AppIndicadores, bool>> predicate)
        {
            return context.AppIndicadores.Where(predicate).ToList();
        }

        public int Update(AppIndicadores Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppIndicadores.Update(Entity);
            return context.SaveChanges();
        }
    }
}
