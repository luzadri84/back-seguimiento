using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class AppTipoProyectoProponenteRepository : BaseRepository<AppTipoProyectoProponente>
    {
        public AppTipoProyectoProponenteRepository(ConcertacionContext context) : base(context)
        {
        }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<AppTipoProyectoProponente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(AppTipoProyectoProponente Entity)
        {
            throw new NotImplementedException();
        }

        public override AppTipoProyectoProponente Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<AppTipoProyectoProponente> Get()
        {
            throw new NotImplementedException();
        }

        public override ICollection<AppTipoProyectoProponente> Get(Expression<Func<AppTipoProyectoProponente, bool>> predicate)
        {
            return context.AppTipoProyectoProponente.Where(predicate).ToList();
        }

        public override ICollection<AppTipoProyectoProponente> Get(Expression<Func<AppTipoProyectoProponente, bool>> predicate, int page, int size, Func<AppTipoProyectoProponente, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override AppTipoProyectoProponente GetFirst(Expression<Func<AppTipoProyectoProponente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(AppTipoProyectoProponente Entity)
        {
            throw new NotImplementedException();
        }
    }
}
