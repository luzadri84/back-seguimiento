using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class ConZonasRepository : BaseRepository<ConZonas>
    {
        public ConZonasRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<ConZonas, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(ConZonas Entity)
        {
            throw new NotImplementedException();
        }

        public override ConZonas Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<ConZonas> Get()
        {
            return context.ConZonas.ToList();
            //throw new NotImplementedException();
        }

        public override ICollection<ConZonas> Get(Expression<Func<ConZonas, bool>> predicate)
        {
            return context.ConZonas.Where(predicate).ToList();
        }

        public override ICollection<ConZonas> Get(Expression<Func<ConZonas, bool>> predicate, int page, int size, Func<ConZonas, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override ConZonas GetFirst(Expression<Func<ConZonas, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(ConZonas Entity)
        {
            throw new NotImplementedException();
        }
    }
}
