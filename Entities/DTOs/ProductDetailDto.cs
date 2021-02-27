using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //DTO Data Transformation Object = joinleme, productname ile categoryname i birlikte kullanmak.
    //IEntity interfacesini almadı çünkü bu bir veri tabanı tablosu değil
    //Joinlenmiş tablolar tolulugu
    //Ayrıca IDto da her zaman aynı yapı oldugğu için core katmanına yazabiliriz.
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }

    }
}
