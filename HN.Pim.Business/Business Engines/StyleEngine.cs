using System.ComponentModel.Composition;
using HN.Pim.Business.Common;

namespace HN.Pim.Business.Business_Engines
{
    [Export(typeof (IProductEngine))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class StyleEngine : IStyleEngine
    {


    }
}