using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Core.Common.Contracts;
using Core.Common.Utils;

namespace Core.Common.Data
{
    public abstract class DataRepositoryBase<T, U> : IDataRepository<T>
        where T : class, IIdentifiableEntity, new()
        where U : DbContext, new()
    {
        protected abstract T AddEntity(U entityContext, T entity);

        protected abstract T UpdateEntity(U entityContext, T entity);

        protected abstract IEnumerable<T> GetEntities(U entityContext);

        protected abstract T GetEntity(U entityContext, int id);

        public T Add(T entity)
        {
            using (U entityContext = new U())
            {
                T addedEntity = AddEntity(entityContext, entity);
                entityContext.SaveChanges();
                return addedEntity;
            }
        }

        public void Remove(T entity)
        {
            using (U entityContext = new U())
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public T Update(T entity)
        {
            using (U entityContext = new U())
            {
                T existingEntity = UpdateEntity(entityContext, entity);

                SimpleMapper.PropertyMap(entity, existingEntity);
                entityContext.SaveChanges();
                return existingEntity;
            }
        }

        public IEnumerable<T> Get()
        {
            using (U entityContext = new U())
                return (GetEntities(entityContext)).ToArray().ToList();
        }

        public T Get(int id)
        {
            using (U entityContext = new U())
                return GetEntity(entityContext, id);
        }

     
         
        public IEnumerable Get(
            int? page = 0,
            int? pageSize = null,
            string[] includePaths = null,
            Expression<Func<T, bool>> filter = null,
            params ISortExpression<T>[] sortExpressions)
        {
            using (U entityContext = new U())
            {
                var query = entityContext.Set<T>() as IQueryable<T>;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includePaths != null)
                {
                    for (var i = 0; i < includePaths.Count(); i++)
                    {
                        query = query.Include(includePaths[i]);
                    }
                }

                if (sortExpressions != null)
                {
                    IOrderedQueryable<T> orderedQuery = null;
                    for (var i = 0; i < sortExpressions.Count(); i++)
                    {
                        if (i == 0)
                        {
                            if (sortExpressions[i].SortDirection == ListSortDirection.Ascending)
                            {
                                orderedQuery = query.OrderBy(sortExpressions[i].SortBy);
                            }
                            else
                            {
                                orderedQuery = query.OrderByDescending(sortExpressions[i].SortBy);
                            }
                        }
                        else
                        {
                            if (sortExpressions[i].SortDirection == ListSortDirection.Ascending)
                            {
                                orderedQuery = orderedQuery.ThenBy(sortExpressions[i].SortBy);
                            }
                            else
                            {
                                orderedQuery = orderedQuery.ThenByDescending(sortExpressions[i].SortBy);
                            }

                        }
                    }

                    if (page != null)
                    {
                        query = orderedQuery.Skip(((int)++page - 1) * (int)pageSize);
                    }
                }

                if (pageSize != null)
                {
                    query = query.Take((int)pageSize);
                }

                return query.ToList();
            }
        }
    }

}