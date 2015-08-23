using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Core.Common.Contracts;

namespace Core.Common.Data
{
    public class SortExpression<T> : ISortExpression<T> where T : class
    {
        public SortExpression(Expression<Func<T, object>> sortBy, ListSortDirection sortDirection)
        {
            SortBy = sortBy;
            SortDirection = sortDirection;
        }

        public Expression<Func<T, object>> SortBy { get; set; }
        public ListSortDirection SortDirection { get; set; }
    }
}