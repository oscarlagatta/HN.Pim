using System.Collections.Generic;
using Core.Common.Contracts;
using HN.Pim.Business.Entities;

namespace HN.Pim.Business.Common
{
    public interface IMenuItemEngine: IBusinessEngine
    {
        IEnumerable<MenuItem> Load(IEnumerable<MenuItem> menus, int parentId);
    }
}