using MinCultura.Domain.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IAppTemasProyectosRepository<AppTemasProyectos>
    {
        ICollection<AppTemasProyectos> Get();
        ICollection<AppTemasProyectos> Get(Expression<Func<AppTemasProyectos, bool>> predicate);
        int Create(List<AppTemasProyectos> Entity);
        int DeleteAll(List<AppTemasProyectos> Entity);
        int Update(AppTemasProyectos Entity);
    }
}
