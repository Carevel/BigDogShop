using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface IProduct
    {
        IList<ProductInfo> GetProductByCateGory(string category);
        IList<ProductInfo> GetProductBySearch(string keywords);
        ProductInfo GetById(int id);
    }
}
