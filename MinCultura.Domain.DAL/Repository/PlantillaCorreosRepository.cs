using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class PlantillaCorreosRepository : BaseRepository<PlantillaCorreos>
    {
        public PlantillaCorreosRepository(ConcertacionContext context) : base(context)
        {
        }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<PlantillaCorreos, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(PlantillaCorreos Entity)
        {
            throw new NotImplementedException();
        }

        public override PlantillaCorreos Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<PlantillaCorreos> Get()
        {
            throw new NotImplementedException();
        }

        public override ICollection<PlantillaCorreos> Get(Expression<Func<PlantillaCorreos, bool>> predicate)
        {
            return context.PlantillaCorreos.Where(predicate).ToList();
        }

        public override ICollection<PlantillaCorreos> Get(Expression<Func<PlantillaCorreos, bool>> predicate, int page, int size, Func<PlantillaCorreos, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override PlantillaCorreos GetFirst(Expression<Func<PlantillaCorreos, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(PlantillaCorreos Entity)
        {
            throw new NotImplementedException();
        }
    }
}
