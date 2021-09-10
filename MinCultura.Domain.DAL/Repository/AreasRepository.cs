using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class AreasRepository : BaseRepository<AppAreas>
    {

        public AreasRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<AppAreas, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(AppAreas Entity)
        {
            throw new NotImplementedException();
        }

        public override AppAreas Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<AppAreas> Get()
        {
            //return context.AppLineas.ToList();
            throw new NotImplementedException();
        }

        public override ICollection<AppAreas> Get(Expression<Func<AppAreas, bool>> predicate)
        {
            return context.AppAreas.Where(predicate).ToList();
        }

        public override ICollection<AppAreas> Get(Expression<Func<AppAreas, bool>> predicate, int page, int size, Func<AppAreas, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override AppAreas GetFirst(Expression<Func<AppAreas, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(AppAreas Entity)
        {
            throw new NotImplementedException();
        }
    }
}

