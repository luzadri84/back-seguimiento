using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class AppPresupuestoDetalleTipoRepository : BaseRepository<AppPresupuestoDetalleTipo>
    {
        public AppPresupuestoDetalleTipoRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<AppPresupuestoDetalleTipo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(AppPresupuestoDetalleTipo Entity)
        {
            throw new NotImplementedException();
        }

        public override AppPresupuestoDetalleTipo Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<AppPresupuestoDetalleTipo> Get()
        {
            return context.AppPresupuestoDetalleTipo.ToList();
        }

        public override ICollection<AppPresupuestoDetalleTipo> Get(Expression<Func<AppPresupuestoDetalleTipo, bool>> predicate)
        {
            return context.AppPresupuestoDetalleTipo.Where(predicate).ToList();
        }

        public override ICollection<AppPresupuestoDetalleTipo> Get(Expression<Func<AppPresupuestoDetalleTipo, bool>> predicate, int page, int size, Func<AppPresupuestoDetalleTipo, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override AppPresupuestoDetalleTipo GetFirst(Expression<Func<AppPresupuestoDetalleTipo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(AppPresupuestoDetalleTipo Entity)
        {
            throw new NotImplementedException();
        }
    }
}
