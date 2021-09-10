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
    public class AppCronogramaRepository : IAppCronogramaRepository<AppCronograma>
    {

        private readonly ConcertacionContext context = null;
        public AppCronogramaRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public int Create(List<AppCronograma> Entity)
        {
            context.AppCronograma.AddRange(Entity);
            return context.SaveChanges();
        }


        public int DeleteAll(List<AppCronograma> Entity)
        {
            context.AppCronograma.RemoveRange(Entity);
            return context.SaveChanges();
        }

        public int Delete(AppCronograma Entity)
        {
            context.AppCronograma.Remove(Entity);
            return context.SaveChanges();
        }

        public ICollection<AppCronograma> Get()
        {
            return context.AppCronograma.ToList();
        }

        public ICollection<AppCronograma> Get(Expression<Func<AppCronograma, bool>> predicate)
        {
            return context.AppCronograma.Where(predicate).ToList();
        }

        public int Update(AppCronograma Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppCronograma.UpdateRange(Entity);
            return context.SaveChanges();
        }
    }
}
