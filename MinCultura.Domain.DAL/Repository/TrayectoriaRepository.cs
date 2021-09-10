using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class TrayectoriaRepository : BaseRepository<Trayectoria>
    {
        public TrayectoriaRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<Trayectoria, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(Trayectoria Entity)
        {
            throw new NotImplementedException();
        }

        public override Trayectoria Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<Trayectoria> Get()
        {
            //return context.AppLineas.ToList();
            throw new NotImplementedException();
        }

        public override ICollection<Trayectoria> Get(Expression<Func<Trayectoria, bool>> predicate)
        {
            return context.Trayectoria.Where(predicate).ToList();
        }

        public override ICollection<Trayectoria> Get(Expression<Func<Trayectoria, bool>> predicate, int page, int size, Func<Trayectoria, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override Trayectoria GetFirst(Expression<Func<Trayectoria, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(Trayectoria Entity)
        {
            throw new NotImplementedException();
        }
    }
}
