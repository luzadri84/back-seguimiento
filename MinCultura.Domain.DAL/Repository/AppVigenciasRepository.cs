using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class AppVigenciasRepository : BaseRepository<AppVigencias>
    {
        public AppVigenciasRepository(ConcertacionContext context) : base(context)
        {
        }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<AppVigencias, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(AppVigencias Entity)
        {
            throw new NotImplementedException();
        }

        public override AppVigencias Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<AppVigencias> Get()
        {
            return context.AppVigencias.ToList();
        }

        public override ICollection<AppVigencias> Get(Expression<Func<AppVigencias, bool>> predicate)
        {
            return context.AppVigencias.Where(predicate).ToList();
        }

        public override ICollection<AppVigencias> Get(Expression<Func<AppVigencias, bool>> predicate, int page, int size, Func<AppVigencias, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override AppVigencias GetFirst(Expression<Func<AppVigencias, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(AppVigencias Entity)
        {
            context.AppVigencias.Update(Entity);
            context.SaveChanges();
        }
    }
}
