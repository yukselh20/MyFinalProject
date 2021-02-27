using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // Generic constraint
    // class ==> referans tip
    // IEntity ==> IEntity veya onu iplemente eden her şey T değeri olabilir
    // new() ==> Soyut nesneler(IEntity) t olamaz ve new lenemez.
    public interface IEntityRepository<T> where T : class, IEntity, new()
        // metodlar hem IProductDal hem de ICategory dal için bir kalıp.
        // Bu yüzdenn repository oluşturduk.
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        //E ticaret uygulamalarındaki gibi filtreleme de yapabiliriz. Bunun için Expression kullanılır.
        //List<T> GetAllByCategory(int categoryId); gibi ayrı ayrı filtre için metod yazmak gerekmez
        //Filtre yoksa hepsini listeler.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        //List<T> GetAllByCategory(int categoryId);
    }
}
