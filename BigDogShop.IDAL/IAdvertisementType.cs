using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface IAdvertisementType
    {
        bool Add(AdvertisementTypeInfo ad_Type);
        bool Delete(int ad_Id);
        bool Update(AdvertisementTypeInfo ad_Type);
        AdvertisementTypeInfo GetById(int ad_Id);
        DataTable GetByCategory(string categoryName);
        DataTable GetAllItems();
    }
}
