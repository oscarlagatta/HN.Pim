using System.ComponentModel.Composition;
using Core.Common.ServiceModel;
using HN.Pim.Client.Contracts;
using HN.Pim.Client.Entities;

namespace HN.Pim.Client.Proxies
{
    [Export(typeof(IStyleService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StyleClient : UserClientBase<IStyleService>, IStyleService
    {
        public Style GetStyle(int merretStyleID)
        {
            return Channel.GetStyle(merretStyleID);
        }

        public Style[] GetAllStyles()
        {
            return Channel.GetAllStyles();
        }

        public Style[] GetPagedStyles(
            int? page, 
            int? pageSize = null, 
            string[] includePaths = null,
            string[] filter = null,
            string[] sortExpression = null
            )
        {
            return Channel.GetPagedStyles(
                page,
                pageSize,
                includePaths,
                filter,
                sortExpression
                );
        }

        public Style UpdateStyle(Style style)
        {
            return Channel.UpdateStyle(style);
        }

        public void DeleteStyle(int MerretStleID)
        {
            Channel.DeleteStyle(MerretStleID);
        }

        /// <summary>
        /// Get Total quantity of style
        /// records
        /// </summary>
        /// <returns></returns>
        public int GetTotalOfStyles()
        {
            return Channel.GetTotalOfStyles();
        }
    }
}