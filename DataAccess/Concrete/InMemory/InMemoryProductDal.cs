using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle, sql, Posgres, MongoDb, server
            _products = new List<Product> {
                new Product {ProductId = 1, CategoryId = 1, ProductName ="Bardak", UnitInStock = 15, UnitPrice=15 },
                new Product {ProductId = 2, CategoryId = 1, ProductName ="Kamera", UnitInStock = 3, UnitPrice=300 },
                new Product {ProductId = 3, CategoryId = 2, ProductName ="Telefon", UnitInStock = 2, UnitPrice=1500 },
                new Product {ProductId = 4, CategoryId = 2, ProductName ="Klavye", UnitInStock = 65, UnitPrice=150 },
                new Product {ProductId = 5, CategoryId = 2, ProductName ="Mouse", UnitInStock = 1, UnitPrice=85 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            //LINQ  Language Integrated Query
            //Product productToDelete = null;

            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            //_products.SingleOrDefault(p=>) == Içerdeki lambda ve foreach ile yaptığımız kismın aynısını yapar.
            //_products listesindeki her bir p için
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId); // product olan methoda gönderilen referans.

            _products.Remove(productToDelete);

            //_products.Remove(product); Bu şekilde listeden asla silinemez.. Products lar newlendiğinden dolayı referans numaraları bilinmeli.
            //yoksa silinemez. Değer tipler silinebilir.

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
            //Where koşulu içindeki koşula bağlı olarak yeni liste oluşturur.
        }

        public void Update(Product product)
        {
            // Gönderilen ürün Id sine sahip olan listedeki ürünü bulmak.
            Product productToUpdate = _products.SingleOrDefault(p => product.ProductId == p.ProductId);
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
