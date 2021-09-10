
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository.Interface
{
   public interface IEvaluacionRequisitosRepository<AppEvaluacionRequisitos>
    {
        ICollection<AppEvaluacionRequisitos> Get(Expression<Func<AppEvaluacionRequisitos, bool>> predicate);
        int Delete(AppEvaluacionRequisitos Entity);
        int Create(AppEvaluacionRequisitos Entity);
        int DeleteAll(List<AppEvaluacionRequisitos> Entity);
        int Update(AppEvaluacionRequisitos Entity);
    }
}
