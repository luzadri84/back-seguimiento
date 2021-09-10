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
    public class AppBeneficiariosRepository : BaseRepository<AppBeneficiarios>
    {
        public AppBeneficiariosRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<AppBeneficiarios, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(AppBeneficiarios Entity)
        {
            context.AppBeneficiarios.Add(Entity);
            context.SaveChanges();
            return (long)Entity.BenId;
        }

        public override AppBeneficiarios Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<AppBeneficiarios> Get()
        {
            return context.AppBeneficiarios.ToList();
            //throw new NotImplementedException();
        }

        public override ICollection<AppBeneficiarios> Get(Expression<Func<AppBeneficiarios, bool>> predicate)
        {
            return context.AppBeneficiarios.Where(predicate).ToList();
        }

        public override ICollection<AppBeneficiarios> Get(Expression<Func<AppBeneficiarios, bool>> predicate, int page, int size, Func<AppBeneficiarios, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override AppBeneficiarios GetFirst(Expression<Func<AppBeneficiarios, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(AppBeneficiarios Entity)
        {
            foreach (var _entity in context.ChangeTracker.Entries())
            {
                _entity.State = EntityState.Detached;
            }
            context.AppBeneficiarios.Update(Entity);
            context.SaveChanges();
        }
    }
}
