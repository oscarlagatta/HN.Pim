using System;
using Resources.Concrete;

namespace Charon.eCommerce.Resources.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Utility.ResourceBuilder();
            string filePath = builder.Create(new DbResourceProvider(@"Data Source=.;Initial Catalog=eCommerce;Integrated Security=True;Pooling=False"),
                summaryCulture: "en-us");

            Console.WriteLine("Created file {0}", filePath);
        }
    }
}
    