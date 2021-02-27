using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //normalde silme getirme ekleme fonksiyonlarını ayrı ayrı yazardık.Core katmanında ortak olan her şey var. Sadece ilgili
    //data access layer daki classlara göre IEntityRepository i iplemente eden EfEntityRepositoryBase i kullandık.
    //Interface deki (IEntityRepository deki) tüm fonksiyonlar EfEntityRepositoryBase classında uygulandı.
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
        
    }
}
