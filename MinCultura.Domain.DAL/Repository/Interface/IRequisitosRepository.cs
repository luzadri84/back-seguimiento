using MinCultura.Domain.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IRequisitosRepository<AppRequisitos>
    {
        long Create(List<AppRequisitos> Entity);
        long DeleteAll(decimal ReqId);
        ICollection<AppRequisitos> Get(Expression<Func<AppRequisitos, bool>> predicate);
        ICollection<AppRequisitos> GetAll();
    }
}