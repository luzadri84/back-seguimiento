using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Interface;

namespace MinCultura.Domain.DAL.Repository
{
    public class CuentausuarioRepository : ICuentausuarioRepository<Cuentausuario>
    {
        protected readonly ConcertacionContext context = null;
        public CuentausuarioRepository(ConcertacionContext context)
        {
            this.context = context;
        }

        public long Create(Cuentausuario Entity)
        {
            context.Cuentausuario.Add(Entity);
            context.SaveChanges();
            return Entity.Cuentausuarioid;
        }
        public ICollection<Cuentausuario> Get()
        {
            return context.Cuentausuario.ToList();
        }
        public ICollection<Cuentausuario> Get(Expression<Func<Cuentausuario, bool>> predicate)
        {
            return context.Cuentausuario.Include(p => p.PerfilesCuentausuario).Where(predicate).ToList();
        }

        public void Update(Cuentausuario Entity)
        {
            context.Cuentausuario.Update(Entity);
            context.SaveChanges();
        }
    }
}
