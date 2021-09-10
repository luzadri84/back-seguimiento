using MinCultura.Domain.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IZonasGeograficasRepository<AppBasZonasGeograficas>
    {
        int Count();


        int Count(Expression<Func<BasZonasGeograficas, bool>> predicate);


        long Create(BasZonasGeograficas Entity);


        BasZonasGeograficas Get(string id);


        ICollection<BasZonasGeograficas> Get();


        ICollection<BasZonasGeograficas> Get(Expression<Func<BasZonasGeograficas, bool>> predicate);


        ICollection<BasZonasGeograficas> Get(Expression<Func<BasZonasGeograficas, bool>> predicate, int page, int size, Func<BasZonasGeograficas, object> filterAttribute, bool descending);


        BasZonasGeograficas GetFirst(Expression<Func<BasZonasGeograficas, bool>> predicate);


        void Update(BasZonasGeograficas Entity);
        
    }
}
