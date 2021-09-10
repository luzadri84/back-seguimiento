using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.DAL.Repository
{
    public class AppTipoDocumentosValoresRepository : IAppTipoDocumentosValoresRepository<AppTipoDocumentosValores>
    {
        private readonly ConcertacionContext context = null;
        public AppTipoDocumentosValoresRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public long Create(AppTipoDocumentosValores Entity)
        {
            context.AppTipoDocumentosValores.Add(Entity);
            return context.SaveChanges();
        }
              
        public ICollection<AppTipoDocumentosValores> Get(Expression<Func<AppTipoDocumentosValores, bool>> predicate)
        {
            return context.AppTipoDocumentosValores.Where(predicate).ToList();
        }

        public long DeleteAll(decimal idProyecto, decimal tdoId)
        {
            context.AppTipoDocumentosValores.RemoveRange(Get(p => p.ProId == idProyecto && p.TdoId == tdoId));
            return context.SaveChanges(); 
        }

    }
}
