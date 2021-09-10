using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;

namespace MinCultura.Domain.DAL.Repository
{
    public class FuncionarioRepository : BaseRepository<Funcionario>
    {
        public FuncionarioRepository(ConcertacionContext context) : base(context) { }

        public override int Count()
        {
            throw new NotImplementedException();
        }

        public override int Count(Expression<Func<Funcionario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override long Create(Funcionario Entity)
        {
            throw new NotImplementedException();
        }

        public override Funcionario Get(long id)
        {
            throw new NotImplementedException();
        }

        public override ICollection<Funcionario> Get()
        {
            //return context.AppLineas.ToList();
            return context.Funcionario.ToList();
        }

        public override ICollection<Funcionario> Get(Expression<Func<Funcionario, bool>> predicate)
        {
            return context.Funcionario.Where(predicate).ToList();
        }

        public override ICollection<Funcionario> Get(Expression<Func<Funcionario, bool>> predicate, int page, int size, Func<Funcionario, object> filterAttribute, bool descending)
        {
            throw new NotImplementedException();
        }

        public override Funcionario GetFirst(Expression<Func<Funcionario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Update(Funcionario Entity)
        {
            throw new NotImplementedException();
        }
    }
}
