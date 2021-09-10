using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Models;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface IAppTipoDocumentosValoresRepository<AppTipoDocumentosValores>
    {
        ICollection<AppTipoDocumentosValores> Get(Expression<Func<AppTipoDocumentosValores, bool>> predicate);
        long Create(AppTipoDocumentosValores Entity);
        long DeleteAll(decimal idProyecto, decimal tdoId);
    }
}
