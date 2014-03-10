using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface IAdvertisement
    {
        bool Insert(AdvertisementInfo ad);
        bool Delete(int id);
        bool Update(AdvertisementInfo ad);
        AdvertisementInfo GetById(int id);
        DataTable GetItemsBySearchCase(string keywords, string type, string enabled);
        DataTable GetAllAdvertisement();
    }
}
