using System.Collections;
using System.Threading.Channels;

namespace Advanced02
{
    internal class Program
    {

        // Func<Product, bool> is used to search products based on a condition.
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

        // Action<Product> is used to print products without returning a value.
        static void PrintReport(List<Product> products, Action<Product> report)
        {
            foreach (Product p in products)
            {
                report(p);
            }
        }

        // Func<Product, string> is used to convert each product into a string.
        static List<string> TransformProducts(List<Product> products, Func<Product, string> transform)
        {
            List<string> result2 = new List<string>();

            foreach (Product p in products)
            {
                result2.Add(transform(p));
            }

            return result2;
        }

        // Predicate<Product> is used to filter products based on a true or false condition.
        static List<Product> FilterProducts(List<Product> products, Predicate<Product> filter)
        {
            List<Product> filtered = new List<Product>();

            foreach (Product p in products)
            {
                if (filter(p))
                {
                    filtered.Add(p);
                }
            }

            return filtered;
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

            Console.WriteLine("\n--- Product Summaries ---");

            List<string> summary = TransformProducts(catalog, p => $"{p.Name} ({p.Price})") ;

            foreach (string s in summary)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("\n--- Price Labels ---");

            List<string> lables = TransformProducts(catalog, p => p.Price>100? $"{p.Name}: Expensive!": $"{p.Name}:Affordable");

            foreach(string s in lables)
            { 
              Console.WriteLine(s);
            }


            #endregion


            Console.WriteLine("\n-----low stock---------");
            List<Product> filter = FilterProducts(catalog, p => p.Stock < 20);
            foreach (Product p in filter)
            {
                Console.WriteLine($"[LOW STOCK]{p.Name}:only {p.Stock} left");
            }
        }
    }
}
 