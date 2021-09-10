using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class EnvioCorreosRepository : BaseRepository<EnvioCorreos>
    {
        public EnvioCorreosRepository(ConcertacionContext context) : base(context)
        {
        }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<EnvioCorreos, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(EnvioCorreos Entity)
        {
            context.EnvioCorreos.Add(Entity);
            context.SaveChanges();
            return Entity.Id;
        }

        public override EnvioCorreos Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<EnvioCorreos> Get()
        {
            throw new NotImplementedException();
        }

        public override ICollection<EnvioCorreos> Get(Expression<Func<EnvioCorreos, bool>> predicate)
        {
            return context.EnvioCorreos.Include(p => p.AdjuntoCorreo).Where(predicate).ToList();
        }

        public override ICollection<EnvioCorreos> Get(Expression<Func<EnvioCorreos, bool>> predicate, int page, int size, Func<EnvioCorreos, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override EnvioCorreos GetFirst(Expression<Func<EnvioCorreos, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(EnvioCorreos Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.EnvioCorreos.Update(Entity);
        }
    }
}
