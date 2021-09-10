using MinCultura.Domain.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IActividadesObligatoriasRepository<AppActividadesObligatorias>
    {
        ICollection<AppActividadesObligatorias> Get();
        ICollection<AppActividadesObligatorias> Get(Expression<Func<AppActividadesObligatorias, bool>> predicate);
        long Create(List<AppActividadesObligatorias> Entity);
        void Update(AppActividadesObligatorias Entity);
        int Delete(AppActividadesObligatorias Entity);
    }
}
