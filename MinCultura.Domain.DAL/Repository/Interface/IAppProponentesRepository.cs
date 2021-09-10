using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Models;
namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IAppProponentesRepository<AppProponentes>
    {
        ICollection<AppProponentes> Get();
        ICollection<AppProponentes> Get(Expression<Func<AppProponentes, bool>> predicate);
        long Create(AppProponentes Entity);
        void Update(AppProponentes Entity);
    }
}
