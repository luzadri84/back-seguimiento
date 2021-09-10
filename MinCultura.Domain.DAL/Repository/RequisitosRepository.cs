using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository
{
    public class RequisitosRepository : IRequisitosRepository<AppRequisitos>
    {
        private readonly ConcertacionContext context = null;
        public RequisitosRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public long Create(List<AppRequisitos> Entity)
        {
            context.AppRequisitos.AddRange(Entity);
            return context.SaveChanges();
        }

        public ICollection<AppRequisitos> Get(Expression<Func<AppRequisitos, bool>> predicate)
        {
            return context.AppRequisitos.Where(predicate).ToList();
        }

        public long DeleteAll(decimal ReqId)
        {
            context.AppRequisitos.RemoveRange(Get(r => r.ReqId == ReqId));
            return context.SaveChanges();
        }
        public ICollection<AppRequisitos> GetAll()
        {
            return context.AppRequisitos.ToList();

        }
    }

}

