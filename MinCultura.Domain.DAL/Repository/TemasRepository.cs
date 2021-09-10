using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository
{
    public class TemasRepository: BaseRepository<AppTemas>
    {

            public TemasRepository(ConcertacionContext context) : base(context) { }

            public override int Count()
            {
                throw new NotImplementedException();
            }

            public override int Count(Expression<Func<AppTemas, bool>> predicate)
            {
                throw new NotImplementedException();
            }

            public override long Create(AppTemas Entity)
            {
                throw new NotImplementedException();
            }

            public override AppTemas Get(long id)
            {
                throw new NotImplementedException();
            }

            public override ICollection<AppTemas> Get()
            {
                //return context.AppLineas.ToList();
                throw new NotImplementedException();
            }

            public override ICollection<AppTemas> Get(Expression<Func<AppTemas, bool>> predicate)
            {
                return context.AppTemas.Where(predicate).ToList();
            }

            public override ICollection<AppTemas> Get(Expression<Func<AppTemas, bool>> predicate, int page, int size, Func<AppTemas, object> filterAttribute, bool descending)
            {
                throw new NotImplementedException();
            }

            public override AppTemas GetFirst(Expression<Func<AppTemas, bool>> predicate)
            {
                throw new NotImplementedException();
            }

            public override void Update(AppTemas Entity)
            {
                throw new NotImplementedException();
            }
        }
    }

