using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class PresupuestoParametrizacionLineasTopeRepository : BaseRepository<PresupuestoParametrizacionLineasTope>
    {
        public PresupuestoParametrizacionLineasTopeRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<PresupuestoParametrizacionLineasTope, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(PresupuestoParametrizacionLineasTope Entity)
        {
            throw new NotImplementedException();
        }

        public override PresupuestoParametrizacionLineasTope Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<PresupuestoParametrizacionLineasTope> Get()
        {
            //return context.AppLineas.ToList();
            return context.PresupuestoParametrizacionLineasTope.ToList();
        }

        public override ICollection<PresupuestoParametrizacionLineasTope> Get(Expression<Func<PresupuestoParametrizacionLineasTope, bool>> predicate)
        {
            return context.PresupuestoParametrizacionLineasTope.Where(predicate).ToList();
        }

        public override ICollection<PresupuestoParametrizacionLineasTope> Get(Expression<Func<PresupuestoParametrizacionLineasTope, bool>> predicate, int page, int size, Func<PresupuestoParametrizacionLineasTope, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override PresupuestoParametrizacionLineasTope GetFirst(Expression<Func<PresupuestoParametrizacionLineasTope, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(PresupuestoParametrizacionLineasTope Entity)
        {
            throw new NotImplementedException();
        }
    }
}
