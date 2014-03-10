using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BigDogShop.DBUtility;
using BigDogShop.IDAL;
using BigDogShop.Model;

namespace BigDogShop.SQLServerDAL
{
    public class Product:IProduct
    {
        public ProductInfo GetById(int id)
        {
            ProductInfo pi = new ProductInfo();
            return pi;
        }

        public IList<ProductInfo> GetProductBySearch(string keywords)
        {
            IList<ProductInfo> p = new List<ProductInfo>();
            return p;
        }

        public IList<ProductInfo> GetProductByCateGory(string category)
        {
            IList<ProductInfo> p = new List<ProductInfo>();
            return p;
        }
    }
}
