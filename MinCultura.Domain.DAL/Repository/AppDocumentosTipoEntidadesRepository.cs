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
    public class AppDocumentosTipoEntidadesRepository : BaseRepository<AppDocumentosTipoEntidades>
    {
        public AppDocumentosTipoEntidadesRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<AppDocumentosTipoEntidades, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(AppDocumentosTipoEntidades Entity)
        {
            throw new NotImplementedException();
        }

        public override AppDocumentosTipoEntidades Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<AppDocumentosTipoEntidades> Get()
        {
            return context.AppDocumentosTipoEntidades.ToList();
        }

        public override ICollection<AppDocumentosTipoEntidades> Get(Expression<Func<AppDocumentosTipoEntidades, bool>> predicate)
        {
            return context.AppDocumentosTipoEntidades.Include(p => p.Tdo).Where(predicate).ToList();
        }

        public override ICollection<AppDocumentosTipoEntidades> Get(Expression<Func<AppDocumentosTipoEntidades, bool>> predicate, int page, int size, Func<AppDocumentosTipoEntidades, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override AppDocumentosTipoEntidades GetFirst(Expression<Func<AppDocumentosTipoEntidades, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(AppDocumentosTipoEntidades Entity)
        {
            throw new NotImplementedException();
        }
    }
}
