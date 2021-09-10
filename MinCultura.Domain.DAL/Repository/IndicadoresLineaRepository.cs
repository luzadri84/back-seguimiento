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
    public class IndicadoresLineaRepository:IAppIndicadoresLineaRepository<AppIndicadoresLinea>
    {
        private readonly ConcertacionContext context = null;
        public IndicadoresLineaRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public int Create(AppIndicadoresLinea Entity)
        {
            context.AppIndicadoresLinea.Add(Entity);
            return context.SaveChanges();
        }


        public int DeleteAll(List<AppIndicadoresLinea> Entity)
        {
            context.AppIndicadoresLinea.RemoveRange(Entity);
            return context.SaveChanges();
        }

        public int Delete(AppIndicadoresLinea Entity)
        {
            context.AppIndicadoresLinea.Remove(Entity);
            return context.SaveChanges();
        }

        public ICollection<AppIndicadoresLinea> Get()
        {
            return context.AppIndicadoresLinea.ToList();
        }

        public ICollection<AppIndicadoresLinea> Get(Expression<Func<AppIndicadoresLinea, bool>> predicate)
        {

            return context.AppIndicadoresLinea.Where(predicate).ToList();
        }

        public int Update(AppIndicadoresLinea Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppIndicadoresLinea.Update(Entity);
            return context.SaveChanges();
        }
    }
}
