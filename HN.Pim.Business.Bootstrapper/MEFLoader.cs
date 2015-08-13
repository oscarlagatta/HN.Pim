using System.ComponentModel.Composition.Hosting;
using HN.Pim.Business.Business_Engines;
using HN.Pim.Data.Data_Repositories;

namespace HN.Pim.Business.Bootstrapper
{
    public static class MEFLoader
    {
        public static CompositionContainer Init()
        {
            AggregateCatalog catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ProductRepository).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ProductEngine).Assembly));

            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }
    }
}