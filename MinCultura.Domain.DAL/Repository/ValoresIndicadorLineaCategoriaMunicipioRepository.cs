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
    public class ValoresIndicadorLineaCategoriaMunicipioRepository : IValoresIndicadorLineaCategoriaMunicipioRepository<AppValoresIndicadorLineaCategoriaMunicipio>
    {
        private readonly ConcertacionContext context = null;
        public ValoresIndicadorLineaCategoriaMunicipioRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public int Create(List<AppValoresIndicadorLineaCategoriaMunicipio> Entity)
        {
            context.AppValoresIndicadorLineaCategoriaMunicipio.AddRange(Entity);
            return context.SaveChanges();
        }


        public int DeleteAll(List<AppValoresIndicadorLineaCategoriaMunicipio> Entity)
        {
            context.AppValoresIndicadorLineaCategoriaMunicipio.RemoveRange(Entity);
            return context.SaveChanges();
        }

        public int Delete(AppValoresIndicadorLineaCategoriaMunicipio Entity)
        {
            context.AppValoresIndicadorLineaCategoriaMunicipio.Remove(Entity);
            return context.SaveChanges();
        }

        public ICollection<AppValoresIndicadorLineaCategoriaMunicipio> Get()
        {
            return context.AppValoresIndicadorLineaCategoriaMunicipio.ToList();
        }

        public ICollection<AppValoresIndicadorLineaCategoriaMunicipio> Get(Expression<Func<AppValoresIndicadorLineaCategoriaMunicipio, bool>> predicate)
        {
            return context.AppValoresIndicadorLineaCategoriaMunicipio.Where(predicate).ToList();
        }

        public int Update(AppValoresIndicadorLineaCategoriaMunicipio Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppValoresIndicadorLineaCategoriaMunicipio.Update(Entity);
            return context.SaveChanges();
        }
    }
}
