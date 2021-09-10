using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class ConActividadesRepository : BaseRepository<ConActividades>
    {
        public ConActividadesRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<ConActividades, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(ConActividades Entity)
        {
            throw new NotImplementedException();
        }

        public override ConActividades Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<ConActividades> Get()
        {
            return context.ConActividades.ToList();
            //throw new NotImplementedException();
        }

        public override ICollection<ConActividades> Get(Expression<Func<ConActividades, bool>> predicate)
        {
            return context.ConActividades.Where(predicate).ToList();
        }

        public override ICollection<ConActividades> Get(Expression<Func<ConActividades, bool>> predicate, int page, int size, Func<ConActividades, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override ConActividades GetFirst(Expression<Func<ConActividades, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(ConActividades Entity)
        {
            throw new NotImplementedException();
        }
    }
}
