using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using Core.Common.Contracts;
using Core.Common.Data;
using HN.Pim.Business.Common;
using HN.Pim.Business.Entities;
using HN.Pim.Data.Contracts.Repository_Interfaces;

namespace HN.Pim.Business.Business_Engines
{
    [Export(typeof (IStyleEngine))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class StyleEngine : IStyleEngine
    {
        [ImportingConstructor]
        public StyleEngine(IDataRepositoryFactory dataRepositoryFactory)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
        }

        IDataRepositoryFactory _dataRepositoryFactory;

        public Style[] GetPagedStyles(
            int? page, 
            int? pageSize = null, 
            string[] includePaths = null, 
            Expression<Func<Style, bool>> filter = null,
            params ISortExpression<Style>[] sortExpression)
        {
            IStyleRepository styleRepository = _dataRepositoryFactory.GetDataRepository<IStyleRepository>();

            var styles  = (IEnumerable<Style>) styleRepository.Get(
                page, 
                pageSize, 
                includePaths, 
                filter, 
                sortExpression);

            return styles.ToArray();

        }

        /**/

        //public Style[] GetPagedStyles(
        //    int? page,
        //    int? pageSize = null,
        //    string[] includePaths = null,
        //    Expression<Func<Style, bool>> filter = null,
        //    ICollection<ISortExpression<Style>> sortExpressions = null)
        //{
        //    IStyleRepository styleRepository = _dataRepositoryFactory.GetDataRepository<IStyleRepository>();


        //    var styles = (IEnumerable<Style>)styleRepository.Get(
        //        page,
        //        pageSize,
        //        includePaths,
        //        filter,
        //        sortExpressions);

        //    return styles.ToArray();

        //}
    }
}