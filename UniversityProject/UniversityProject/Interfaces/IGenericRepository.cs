﻿using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UniversityProject.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> FindAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null
            );
        Task<T> Find(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);
        Task<bool> IsExists(Expression<Func<T, bool>> expression = null);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
