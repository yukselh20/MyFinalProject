using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System.Text;
using System;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAllByCategoryId(2)) // Business daki serviceler kullanılıyor. get all by category id falan
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
