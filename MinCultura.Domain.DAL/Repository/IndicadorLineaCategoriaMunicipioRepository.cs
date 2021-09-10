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
    public class IndicadorLineaCategoriaMunicipioRepository:IIndicadorLineaCategoriaMunicipioRepository<AppIndicadorLineaCategoriaMunicipio>
    {

        private readonly ConcertacionContext context = null;
        public IndicadorLineaCategoriaMunicipioRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public int Create(AppIndicadorLineaCategoriaMunicipio Entity)
        {
            context.AppIndicadorLineaCategoriaMunicipio.Add(Entity);
            return context.SaveChanges();
        }


        public int DeleteAll(List<AppIndicadorLineaCategoriaMunicipio> Entity)
        {
            context.AppIndicadorLineaCategoriaMunicipio.RemoveRange(Entity);
            return context.SaveChanges();
        }

        public int Delete(AppIndicadorLineaCategoriaMunicipio Entity)
        {
            context.AppIndicadorLineaCategoriaMunicipio.Remove(Entity);
            return context.SaveChanges();
        }

        public ICollection<AppIndicadorLineaCategoriaMunicipio> Get()
        {
            return context.AppIndicadorLineaCategoriaMunicipio.ToList();
        }

        public ICollection<AppIndicadorLineaCategoriaMunicipio> Get(Expression<Func<AppIndicadorLineaCategoriaMunicipio, bool>> predicate)
        {
            return context.AppIndicadorLineaCategoriaMunicipio.Where(predicate).ToList();
        }

        public int Update(AppIndicadorLineaCategoriaMunicipio Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppIndicadorLineaCategoriaMunicipio.Update(Entity);
            return context.SaveChanges();
        }
    }
}
