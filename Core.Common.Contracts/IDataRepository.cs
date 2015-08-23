using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Common.Contracts
{
    public interface IDataRepository
    {

    }

    public interface IDataRepository<T> : IDataRepository
        where T : class, IIdentifiableEntity, new()
    {
        T Add(T entity);

        void Remove(T entity);

        void Remove(int id);

        T Update(T entity);

        IEnumerable<T> Get();

        T Get(int id);

        IEnumerable Get(
            int? page = 0,
            int? pageSize = null,
            string[] includePaths = null,
            Expression<Func<T, bool>> filter = null,
            params ISortExpression<T>[] sortExpressions
            );

        
    }
}