using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class BasEntidadesFinancierasRepository : BaseRepository<BasEntidadesFinancieras>
    {
        public BasEntidadesFinancierasRepository(ConcertacionContext context) : base(context)
        {
        }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<BasEntidadesFinancieras, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(BasEntidadesFinancieras Entity)
        {
            throw new NotImplementedException();
        }

        public override BasEntidadesFinancieras Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<BasEntidadesFinancieras> Get()
        {
            return context.BasEntidadesFinancieras.ToList();
        }

        public override ICollection<BasEntidadesFinancieras> Get(Expression<Func<BasEntidadesFinancieras, bool>> predicate)
        {
            return context.BasEntidadesFinancieras.Where(predicate).ToList();
        }

        public override ICollection<BasEntidadesFinancieras> Get(Expression<Func<BasEntidadesFinancieras, bool>> predicate, int page, int size, Func<BasEntidadesFinancieras, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override BasEntidadesFinancieras GetFirst(Expression<Func<BasEntidadesFinancieras, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(BasEntidadesFinancieras Entity)
        {
            throw new NotImplementedException();
        }
    }
}
