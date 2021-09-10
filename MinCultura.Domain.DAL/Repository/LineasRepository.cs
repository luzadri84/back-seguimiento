using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class LineasRepository: BaseRepository<AppLineas>
    {
        public LineasRepository(ConcertacionContext context) : base(context){}

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<AppLineas, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(AppLineas Entity)
        {
            throw new NotImplementedException();
        }

        public override AppLineas Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<AppLineas> Get()
        {
            //return context.AppLineas.ToList();
            throw new NotImplementedException();
        }

        public override ICollection<AppLineas> Get(Expression<Func<AppLineas, bool>> predicate)
        {
            return context.AppLineas.Where(predicate).ToList();
        }

        public override ICollection<AppLineas> Get(Expression<Func<AppLineas, bool>> predicate, int page, int size, Func<AppLineas, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override AppLineas GetFirst(Expression<Func<AppLineas, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(AppLineas Entity)
        {
            throw new NotImplementedException();
        }
    }
}
