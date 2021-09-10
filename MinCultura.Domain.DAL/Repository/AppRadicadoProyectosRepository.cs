using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.DAL.Repository
{
    public class AppRadicadoProyectosRepository : IAppRadicadoProyectosRepository<AppRadicadoProyectos>
    {
        private readonly ConcertacionContext context = null;

        public AppRadicadoProyectosRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public int Create(AppRadicadoProyectos Entity)
        {
            context.AppRadicadoProyectos.Add(Entity);
            context.SaveChanges();
            return Convert.ToInt32(Entity.NumeroRadicado);
        }

        public ICollection<AppRadicadoProyectos> Get(Expression<Func<AppRadicadoProyectos, bool>> predicate)
        {
            return context.AppRadicadoProyectos.Where(predicate).ToList();
        }

    }
}
