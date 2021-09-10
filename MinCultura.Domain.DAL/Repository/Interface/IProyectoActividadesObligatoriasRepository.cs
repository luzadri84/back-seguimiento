using MinCultura.Domain.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IProyectoActividadesObligatoriasRepository<AppProyectoActividadesObligatorias>
    {
        ICollection<AppProyectoActividadesObligatorias> Get();
        ICollection<AppProyectoActividadesObligatorias> Get(Expression<Func<AppProyectoActividadesObligatorias, bool>> predicate);
        long Create(AppProyectoActividadesObligatorias Entity);
        int Update(AppProyectoActividadesObligatorias Entity);
        int Delete(AppProyectoActividadesObligatorias Entity);
    }
}
