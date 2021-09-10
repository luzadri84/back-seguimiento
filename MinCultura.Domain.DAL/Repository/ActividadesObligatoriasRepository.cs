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
    public class ActividadesObligatoriasRepository: IActividadesObligatoriasRepository<AppActividadesObligatorias>
    {
        private readonly ConcertacionContext context = null;
        public ActividadesObligatoriasRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public long Create(List<AppActividadesObligatorias> Entity)
        {
            context.AppActividadesObligatorias.AddRange(Entity);
            return context.SaveChanges();
        }


        public int Delete(AppActividadesObligatorias Entity)
        {
            context.AppActividadesObligatorias.Remove(Entity);
            return context.SaveChanges();
        }

        public ICollection<AppActividadesObligatorias> Get()
        {
            return context.AppActividadesObligatorias.ToList();
        }

        public ICollection<AppActividadesObligatorias> Get(Expression<Func<AppActividadesObligatorias, bool>> predicate)
        {
            return context.AppActividadesObligatorias.Where(predicate).ToList();
        }

        public void Update(AppActividadesObligatorias Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppActividadesObligatorias.Update(Entity);
            context.SaveChanges();
        }
    }
}
