using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class ConSeguimientosRepository : BaseRepository<ConSeguimientos>
    {
        public ConSeguimientosRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<ConSeguimientos, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(ConSeguimientos Entity)
        {
            context.ConSeguimientos.Add(Entity);
            context.SaveChanges();
            return (long)Entity.SegId;
        }

        public override ConSeguimientos Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<ConSeguimientos> Get()
        {
            return context.ConSeguimientos.ToList();
            //throw new NotImplementedException();
        }

        public override ICollection<ConSeguimientos> Get(Expression<Func<ConSeguimientos, bool>> predicate)
        {
            return context.ConSeguimientos.Where(predicate).ToList();
        }

        public override ICollection<ConSeguimientos> Get(Expression<Func<ConSeguimientos, bool>> predicate, int page, int size, Func<ConSeguimientos, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override ConSeguimientos GetFirst(Expression<Func<ConSeguimientos, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(ConSeguimientos Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.ConSeguimientos.Update(Entity);
            context.SaveChanges();
        }
    }
}
