using System;
using Resources.Concrete;

namespace HN.Pim.ResourceBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HN.Pim.Resources.Utility.ResourceBuilder();
            string filePath = builder.Create(new DbResourceProvider(@"Data Source=.;Initial Catalog=eCommerce;Integrated Security=True;Pooling=False"),
                summaryCulture: "en-us");

            Console.WriteLine("Created file {0}", filePath);         
        }
    }
}
