using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Contracts
{
    public interface ISortExpression<T> where T : class
    {
        Expression<Func<T, object>> SortBy { get; set; }
        ListSortDirection SortDirection { get; set; }
    }
}
