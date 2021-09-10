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
    public class ValoresIndicadorRepository : IValoresIndicadorRepository<AppValoresIndicador>
    {
        private readonly ConcertacionContext context = null;


        public ValoresIndicadorRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public int Create(List<AppValoresIndicador> Entity)
        {
            context.AppValoresIndicador.AddRange(Entity);
            return context.SaveChanges();
        }


        public int DeleteAll(List<AppValoresIndicador> Entity)
        {
            context.AppValoresIndicador.RemoveRange(Entity);
            return context.SaveChanges();
        }

        public int Delete(AppValoresIndicador Entity)
        {
            context.AppValoresIndicador.Remove(Entity);
            return context.SaveChanges();
        }

        public ICollection<AppValoresIndicador> Get()
        {
            return context.AppValoresIndicador.ToList();
        }

        public ICollection<AppValoresIndicador> Get(Expression<Func<AppValoresIndicador, bool>> predicate)
        {

            return context.AppValoresIndicador.Where(predicate).ToList();
        }

        public int Update(AppValoresIndicador Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppValoresIndicador.Update(Entity);
            return context.SaveChanges();
        }
    }
}
