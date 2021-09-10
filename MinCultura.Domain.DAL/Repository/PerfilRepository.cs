using System;
using MinCultura.Domain.DAL.Repository.Base;
using MinCultura.Domain.DAL.Models;
using System.Linq.Expressions;
using System.Collections.Generic;
using MinCultura.Domain.DAL.Context;
using System.Linq;

namespace MinCultura.Domain.DAL.Repository
{
    public class PerfilRepository : BaseRepository<Perfil>
    {
        public PerfilRepository(ConcertacionContext context) : base(context)
        {
        }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<Perfil, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(Perfil Entity)
        {
            throw new NotImplementedException();
        }

        public override Perfil Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<Perfil> Get()
        {
            throw new NotImplementedException();
        }

        public override ICollection<Perfil> Get(Expression<Func<Perfil, bool>> predicate)
        {
            return context.Perfil.Where(predicate).ToList();
        }

        public override ICollection<Perfil> Get(Expression<Func<Perfil, bool>> predicate, int page, int size, Func<Perfil, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override Perfil GetFirst(Expression<Func<Perfil, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(Perfil Entity)
        {
            throw new NotImplementedException();
        }
    }
}
