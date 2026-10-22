using System.Collections;
using System.Threading.Channels;

namespace Advanced02
{
    internal class Program
    { 
        static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
             List<Product> result = new List<Product>();
            foreach (Product p in products)
            {
                if (filter(p))
                {
                    result.Add(p);
                }
            }
            return result;

        }

        static void PrintReport(List<Product> products, Action<Product> report)
        {
            List<Product> products02 = new List<Product>();
            foreach (Product p in products)
            {
                report(p);

            }
        }

        static void Main(string[] args)
        {

            List<Product> catalog = new()
            {
              new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
              new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
              new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
              new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
              new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
              new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
              new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
              new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
              new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
              new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
        };

            #region task01

            Console.WriteLine("--- Electronics ---");
            List<Product> electronics = SearchProducts(catalog, p => p.Category == "Electronics");

            foreach (Product p in electronics)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            Console.WriteLine("\n--- cheaper than $50 ---");

            List<Product> Under50 = SearchProducts(catalog, p => p.Price<50);

            foreach (Product p in Under50)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            Console.WriteLine("\n--- In Stock ---");

            List<Product> InStock = SearchProducts(catalog, p => p.Stock > 0);

            foreach (Product p in InStock)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            Console.WriteLine("\n--- Clothing Under $100 ---");

            List<Product> Under100 = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price<100);

            foreach (Product p in Under100)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }
            #endregion

            #region task03

            
            Console.WriteLine("\n--- Short Report ---");

            PrintReport(catalog, p => { Console.WriteLine($"{p.Name}-{p.Price}"); });

            Console.WriteLine("\n--- Detailed Report ---");

            PrintReport(catalog, p => { Console.WriteLine($"[{p.Category}] {p.Name} | {p.Price} |{p.Stock}"); });
          
          #endregion




        }
    }
}
 