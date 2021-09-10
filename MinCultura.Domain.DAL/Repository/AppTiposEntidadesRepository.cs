using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class AppTiposEntidadesRepository : BaseRepository<AppTiposEntidades>
    {
        public AppTiposEntidadesRepository(ConcertacionContext context) : base(context)
        {
        }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<AppTiposEntidades, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(AppTiposEntidades Entity)
        {
            throw new NotImplementedException();
        }

        public override AppTiposEntidades Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<AppTiposEntidades> Get()
        {
            throw new NotImplementedException();
        }

        public override ICollection<AppTiposEntidades> Get(Expression<Func<AppTiposEntidades, bool>> predicate)
        {
            return context.AppTiposEntidades.Where(predicate).ToList();
        }

        public override ICollection<AppTiposEntidades> Get(Expression<Func<AppTiposEntidades, bool>> predicate, int page, int size, Func<AppTiposEntidades, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override AppTiposEntidades GetFirst(Expression<Func<AppTiposEntidades, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(AppTiposEntidades Entity)
        {
            throw new NotImplementedException();
        }
    }
}
