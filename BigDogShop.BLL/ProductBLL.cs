using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BigDogShop.Model;
using BigDogShop.IDAL;
using BigDogShop.DALFactory;

namespace BigDogShop.BLL
{
    public class ProductBLL
    {
        private static IProduct Dal = Facotry.CreateProductImages();

        public static bool Add(ProductInfo model)
        {
            return Dal.Add(model);
        }

        public static bool Delete(int id)
        {
            return Dal.Delete(id);
        }

        public static bool Update(ProductInfo model)
        {
            return Dal.Update(model);
        }

        public ProductInfo GetById(int id)
        {
            return Dal.GetById(id);
        }

        public DataTable GetByCategory(int id)
        {
            return Dal.GetByCategory(id);
        }

        public DataTable GetBySearchKeywords(string keywords)
        {
            return Dal.GetBySearchKeywords(keywords);
        }

        public DataTable GetLists()
        {
            return Dal.GetLists();
        }
    }
}
