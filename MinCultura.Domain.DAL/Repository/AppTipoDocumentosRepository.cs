using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class AppTipoDocumentosRepository : BaseRepository<AppTipoDocumentos>
    {
        public AppTipoDocumentosRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<AppTipoDocumentos, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(AppTipoDocumentos Entity)
        {
            throw new NotImplementedException();
        }

        public override AppTipoDocumentos Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<AppTipoDocumentos> Get()
        {
            return context.AppTipoDocumentos.ToList();
            //throw new NotImplementedException();
        }

        public override ICollection<AppTipoDocumentos> Get(Expression<Func<AppTipoDocumentos, bool>> predicate)
        {
            return context.AppTipoDocumentos.Where(predicate).ToList();
        }

        public override ICollection<AppTipoDocumentos> Get(Expression<Func<AppTipoDocumentos, bool>> predicate, int page, int size, Func<AppTipoDocumentos, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override AppTipoDocumentos GetFirst(Expression<Func<AppTipoDocumentos, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(AppTipoDocumentos Entity)
        {
            throw new NotImplementedException();
        }
    }
}
