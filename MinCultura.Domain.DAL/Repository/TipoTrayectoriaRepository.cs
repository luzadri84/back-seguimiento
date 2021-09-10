using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class TipoTrayectoriaRepository : BaseRepository<TipoTrayectoria>
    {
        public TipoTrayectoriaRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<TipoTrayectoria, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(TipoTrayectoria Entity)
        {
            throw new NotImplementedException();
        }

        public override TipoTrayectoria Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<TipoTrayectoria> Get()
        {
            return context.TipoTrayectoria.ToList();
            //throw new NotImplementedException();
        }

        public override ICollection<TipoTrayectoria> Get(Expression<Func<TipoTrayectoria, bool>> predicate)
        {
            return context.TipoTrayectoria.Where(predicate).ToList();
        }

        public override ICollection<TipoTrayectoria> Get(Expression<Func<TipoTrayectoria, bool>> predicate, int page, int size, Func<TipoTrayectoria, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override TipoTrayectoria GetFirst(Expression<Func<TipoTrayectoria, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(TipoTrayectoria Entity)
        {
            throw new NotImplementedException();
        }
    }
}
