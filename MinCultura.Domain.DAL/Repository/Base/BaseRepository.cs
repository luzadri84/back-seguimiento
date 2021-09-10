﻿using Microsoft.EntityFrameworkCore;
using MinCultura.Domain.DAL.Context;
using MinCultura.Domain.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MinCultura.Domain.DAL.Repository.Base
{
    public abstract class BaseRepository<T> : IRepository<T>, IDisposable where T : class
    {
        protected ConcertacionContext context = null;

        private readonly DbSet<T> entity = null;
       
        protected BaseRepository(ConcertacionContext context)
        {
            this.context = context;
            entity = context.Set<T>();
        }

        public ConcertacionContext Context
        {
            get
            {
                return context;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public abstract T GetFirst(Expression<Func<T, bool>> predicate);
        public abstract T Get(long id);
        public abstract ICollection<T> Get();
        public abstract ICollection<T> Get(Expression<Func<T, bool>> predicate);
        public abstract ICollection<T> Get(Expression<Func<T, bool>> predicate, int page, int size, Func<T, object> filterAttribute, bool @descending);
        public abstract int Count();
        public abstract int Count(Expression<Func<T, bool>> predicate);
        public abstract long Create(T Entity);
        public abstract void Update(T Entity);
    }
}
