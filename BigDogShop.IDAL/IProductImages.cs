using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface IProductImages
    {
        bool Add(ProductImageInfo model);
        bool Delete(int id);
        bool Update(ProductImageInfo model);
        ProductImageInfo GetById(int id);
        DataTable GetByCategory(int category_id);
        DataTable GetList();
    }
}
