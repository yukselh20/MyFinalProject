using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //normalde silme getirme ekleme fonksiyonlarını ayrı ayrı yazardık.Core katmanında ortak olan her şey var. Sadece ilgili
    //data access layer daki classlara göre IEntityRepository i iplemente eden EfEntityRepositoryBase i kullandık.
    //Interface deki (IEntityRepository deki) tüm fonksiyonlar EfEntityRepositoryBase classında uygulandı.
    //IProductDal ın durma sebebi product nesnesi için özel fonksiyon yazılabilecek olması.
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto {ProductId = p.ProductId, 
                                 CategoryName = c.CategoryName, ProductName = p.ProductName, 
                                 UnitsInStock = p.UnitsInStock };
                //Verilen yapıya göre uyanları productdetaildto nesnesine tablola.

                return result.ToList();

            }
        }
    }
}
