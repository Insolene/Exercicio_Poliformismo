using Poliformismo.Entities;
using System.Globalization;

namespace Poliformismo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) 
            {
                Console.Write($"Product {i} data: ");
                Console.Write("Common, used or Imported (c/u/i)? ");
                char ch = char.Parse(Console.ReadLine());
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Price: ");
                double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                if (ch == 'c' || ch == 'C')
                {
                    list.Add(new Product(name, price));
                }
                else if (ch == 'i' || ch == 'I')
                {
                    Console.WriteLine("Customs Free: ");
                    double costfree = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, costfree));
                }
                else
                {
                    Console.WriteLine("Manufacture Date (dd/MM/yyyy): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, date));
                }               
            }
            Console.WriteLine();
            Console.WriteLine("Price Tags");
            foreach (Product product in list)
            {
                Console.WriteLine(product.PriceTag());
            }

        }
    }
}
