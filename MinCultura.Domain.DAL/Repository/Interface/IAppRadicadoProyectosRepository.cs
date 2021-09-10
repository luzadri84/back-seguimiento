using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Models;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IAppRadicadoProyectosRepository<AppRadicadoProyectos>
    {
        int Create(AppRadicadoProyectos Entity);
        ICollection<AppRadicadoProyectos> Get(Expression<Func<AppRadicadoProyectos, bool>> predicate);
    }
}
