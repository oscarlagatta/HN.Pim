using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Common.Contracts;
using HN.Pim.Business.Entities;

namespace HN.Pim.Business.Common
{
    public interface IStyleEngine : IBusinessEngine
    {
        Style[] GetPagedStyles(
            int? page,
            int? pageSize = null,
            string[] includePaths = null,
            Expression<Func<Style, bool>> filter = null,
            params ISortExpression<Style>[] sortExpression
            );

           //  Style[] GetPagedStyles(
           //int? page,
           //int? pageSize = null,
           //string[] includePaths = null,
           //Expression<Func<Style, bool>> filter = null,
           //ICollection<ISortExpression<Style>> sortExpression = null
           //);
    }
}