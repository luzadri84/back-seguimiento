using Microsoft.EntityFrameworkCore;
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
    public class EvaluacionRequisitosRepository: IEvaluacionRequisitosRepository<AppEvaluacionRequisitos>
    {
        private readonly ConcertacionContext context = null;
        public EvaluacionRequisitosRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public int Create(AppEvaluacionRequisitos Entity)
        {
            context.AppEvaluacionRequisitos.AddRange(Entity);
            return context.SaveChanges();
        }

        public ICollection<AppEvaluacionRequisitos> Get(Expression<Func<AppEvaluacionRequisitos, bool>> predicate)
        {
            return context.AppEvaluacionRequisitos.Where(predicate).ToList();
        }

        public int DeleteAll(List<AppEvaluacionRequisitos> Entity)
        {
            context.AppEvaluacionRequisitos.RemoveRange(Entity);
            return context.SaveChanges();
        }

        public int Delete(AppEvaluacionRequisitos Entity)
        {
            context.AppEvaluacionRequisitos.Remove(Entity);
            return context.SaveChanges();
        }

        public int Update(AppEvaluacionRequisitos Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppEvaluacionRequisitos.Update(Entity);
            return context.SaveChanges();
        }
    }
}
