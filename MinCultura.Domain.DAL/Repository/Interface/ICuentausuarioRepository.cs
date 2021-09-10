using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Models;

namespace MinCultura.Domain.DAL.Repository.Interface
{
    public interface ICuentausuarioRepository<Cuentausuario>
    {
        ICollection<Cuentausuario> Get(Expression<Func<Cuentausuario, bool>> predicate);
        ICollection<Cuentausuario> Get();
        long Create(Cuentausuario Entity);
        void Update(Cuentausuario Entity);
    }
}
