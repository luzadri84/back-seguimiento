using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class PerfilesCuentausuarioRepository : BaseRepository<PerfilesCuentausuario>
    {
        public PerfilesCuentausuarioRepository(ConcertacionContext context) : base(context)
        {
        }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<PerfilesCuentausuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(PerfilesCuentausuario Entity)
        {
            context.PerfilesCuentausuario.Add(Entity);
            context.SaveChanges();
            return Entity.Cuentausuarioid;
        }

        public override PerfilesCuentausuario Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<PerfilesCuentausuario> Get()
        {
            throw new NotImplementedException();
        }

        public override ICollection<PerfilesCuentausuario> Get(Expression<Func<PerfilesCuentausuario, bool>> predicate)
        {
            return context.PerfilesCuentausuario.Where(predicate).ToList();
        }

        public override ICollection<PerfilesCuentausuario> Get(Expression<Func<PerfilesCuentausuario, bool>> predicate, int page, int size, Func<PerfilesCuentausuario, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override PerfilesCuentausuario GetFirst(Expression<Func<PerfilesCuentausuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(PerfilesCuentausuario Entity)
        {
            throw new NotImplementedException();
        }
    }
}
