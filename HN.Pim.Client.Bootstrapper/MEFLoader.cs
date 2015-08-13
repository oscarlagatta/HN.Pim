using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using HN.Pim.Client.Proxies;

namespace HN.Pim.Client.Bootstrapper
{
    public static class MEFLoader
    {
        //public static CompositionContainer Init()
        //{
        //    AggregateCatalog catalog = new AggregateCatalog();

        //    catalog.Catalogs.Add(new AssemblyCatalog(typeof(ProductRepository).Assembly));
        //    catalog.Catalogs.Add(new AssemblyCatalog(typeof(ProductEngine).Assembly));

        //    CompositionContainer container = new CompositionContainer(catalog);

        //    return container;
        //}

        public static CompositionContainer Init()
        {
            return Init(null);
        }

        public static CompositionContainer Init(ICollection<ComposablePartCatalog> catalogParts)
        {
            AggregateCatalog catalog = new AggregateCatalog();

            catalog.Catalogs.Add(new AssemblyCatalog(typeof(ProductClient).Assembly));


            if (catalogParts != null)
                foreach (var part in catalogParts)
                    catalog.Catalogs.Add(part);

            CompositionContainer container = new CompositionContainer(catalog);

            return container;
        }

    }
}