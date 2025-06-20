using System;
using System.Collections.Generic;

namespace MyCSharpApp
{
    class Product : IComparable<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(int productId, string productName, string category)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
        }

        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return this.ProductName.CompareTo(other.ProductName);
        }

        public override string ToString()
        {
            return $"Product({ProductId}, \"{ProductName}\", \"{Category}\")";
        }
    }

    class Program
    {
        static Product? LinearSearch(List<Product> products, string targetName)
        {
            foreach (var product in products)
            {
                if (product.ProductName.Equals(targetName, StringComparison.OrdinalIgnoreCase))
                    return product;
            }
            return null;
        }

        static Product? BinarySearch(List<Product> products, string targetName)
        {
            int left = 0, right = products.Count - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                int comparison = products[mid].ProductName.CompareTo(targetName);
                if (comparison == 0)
                    return products[mid];
                else if (comparison < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }

        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product(1, "Laptop", "Electronics"),
                new Product(2, "Mouse", "Electronics"),
                new Product(3, "Chair", "Furniture"),
                new Product(4, "Table", "Furniture"),
                new Product(5, "Headphones", "Electronics")
            };

            Console.WriteLine("---- Linear Search ----");
            var result1 = LinearSearch(products, "Chair");
            Console.WriteLine(result1 != null ? result1.ToString() : "Product not found");

            // Sort for binary search
            products.Sort();

            Console.WriteLine("---- Binary Search ----");
            var result2 = BinarySearch(products, "Chair");
            Console.WriteLine(result2 != null ? result2.ToString() : "Product not found");
        }
    }
}
