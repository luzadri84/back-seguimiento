using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class ConEstadosRepository : BaseRepository<ConEstados>
    {
        public ConEstadosRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<ConEstados, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(ConEstados Entity)
        {
            throw new NotImplementedException();
        }

        public override ConEstados Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<ConEstados> Get()
        {
            return context.ConEstados.ToList();
            //throw new NotImplementedException();
        }

        public override ICollection<ConEstados> Get(Expression<Func<ConEstados, bool>> predicate)
        {
            return context.ConEstados.Where(predicate).ToList();
        }

        public override ICollection<ConEstados> Get(Expression<Func<ConEstados, bool>> predicate, int page, int size, Func<ConEstados, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override ConEstados GetFirst(Expression<Func<ConEstados, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(ConEstados Entity)
        {
            throw new NotImplementedException();
        }
    }
}
