using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.DALFactory;
using BigDogShop.Model;
using BigDogShop.IDAL;

namespace BigDogShop.BLL
{
    public class ProductImagesBLL
    {
        private static IProductImages Dal = Facotry.CreateProductImages();

        public static bool Add(ProductImageInfo model)
        {
            return Dal.Add(model);
        }

        public static bool Delete(int id)
        {
            return Dal.Delete(id);
        }

        public static bool Update(ProductImageInfo model)
        {
            return Dal.Update(model);
        }

        public static  ProductImageInfo GetById(int id)
        {
            return Dal.GetById(id);
        }

        public static DataTable GetByCategory(int category_id)
        {
            return Dal.GetByCategory(category_id);
        }

        public static DataTable GetList()
        {
            return Dal.GetList();
        }
    }
}
