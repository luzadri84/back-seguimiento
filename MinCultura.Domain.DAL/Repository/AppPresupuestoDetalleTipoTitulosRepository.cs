using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class AppPresupuestoDetalleTipoTitulosRepository : BaseRepository<AppPresupuestoDetalleTipoTitulos>
    {
        public AppPresupuestoDetalleTipoTitulosRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<AppPresupuestoDetalleTipoTitulos, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(AppPresupuestoDetalleTipoTitulos Entity)
        {
            throw new NotImplementedException();
        }

        public override AppPresupuestoDetalleTipoTitulos Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<AppPresupuestoDetalleTipoTitulos> Get()
        {
            return context.AppPresupuestoDetalleTipoTitulos.ToList();
        }

        public override ICollection<AppPresupuestoDetalleTipoTitulos> Get(Expression<Func<AppPresupuestoDetalleTipoTitulos, bool>> predicate)
        {
            return context.AppPresupuestoDetalleTipoTitulos.Where(predicate).ToList();
        }

        public override ICollection<AppPresupuestoDetalleTipoTitulos> Get(Expression<Func<AppPresupuestoDetalleTipoTitulos, bool>> predicate, int page, int size, Func<AppPresupuestoDetalleTipoTitulos, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override AppPresupuestoDetalleTipoTitulos GetFirst(Expression<Func<AppPresupuestoDetalleTipoTitulos, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(AppPresupuestoDetalleTipoTitulos Entity)
        {
            throw new NotImplementedException();
        }
    }
}
