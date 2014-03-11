using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface IProduct
    {
        bool Add(ProductInfo product);
        bool Delete(int id);
        bool Update(ProductInfo product);
        ProductInfo GetById(int id);
        DataTable GetBySearchKeywords(string keywords);
        DataTable GetByCategory(int id);
        DataTable GetLists();     
    }
}
