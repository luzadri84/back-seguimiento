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
    public partial class ProyectoActividadesObligatoriasRepository: IProyectoActividadesObligatoriasRepository<AppProyectoActividadesObligatorias>
    {
        private readonly ConcertacionContext context = null;
        public ProyectoActividadesObligatoriasRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public long Create(AppProyectoActividadesObligatorias Entity)
        {
            context.AppProyectoActividadesObligatorias.Add(Entity);
            return context.SaveChanges();
        }


        public int Delete(AppProyectoActividadesObligatorias Entity)
        {
            context.AppProyectoActividadesObligatorias.Remove(Entity);
            return context.SaveChanges();
        }

        public ICollection<AppProyectoActividadesObligatorias> Get()
        {
            return context.AppProyectoActividadesObligatorias.ToList();
        }

        public ICollection<AppProyectoActividadesObligatorias> Get(Expression<Func<AppProyectoActividadesObligatorias, bool>> predicate)
        {
            return context.AppProyectoActividadesObligatorias.Include(p => p.ActObl).Where(predicate).ToList();
        }
       
        public int Update(AppProyectoActividadesObligatorias Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppProyectoActividadesObligatorias.Update(Entity);
            return context.SaveChanges(); ;
        }
    }
}
