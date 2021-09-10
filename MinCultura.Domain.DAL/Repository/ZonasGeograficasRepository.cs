using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;

using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.DAL.Repository
{
    public class ZonasGeograficasRepository : IZonasGeograficasRepository<BasZonasGeograficas>
    {
        private readonly ConcertacionContext context = null;
        public ZonasGeograficasRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<BasZonasGeograficas, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public long Create(BasZonasGeograficas Entity)
        {
            throw new NotImplementedException();
        }

        public BasZonasGeograficas Get(string id)
        {
            throw new NotImplementedException();
        }

        public ICollection<BasZonasGeograficas> Get()
        {
            throw new NotImplementedException();
        }

        public ICollection<BasZonasGeograficas> Get(Expression<Func<BasZonasGeograficas, bool>> predicate)
        {
            return context.BasZonasGeograficas.Where(predicate).ToList();
        }

        public ICollection<BasZonasGeograficas> Get(Expression<Func<BasZonasGeograficas, bool>> predicate, int page, int size, Func<BasZonasGeograficas, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public BasZonasGeograficas GetFirst(Expression<Func<BasZonasGeograficas, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(BasZonasGeograficas Entity)
        {
            throw new NotImplementedException();
        }
    }
}
