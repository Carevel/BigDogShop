using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BigDogShop.IDAL;
using BigDogShop.Model;
using BigDogShop.DALFactory;

namespace BigDogShop.BLL
{
    public class AdvertisementBLL
    {
        protected static IDAL.IAdvertisement Dal = DALFactory.Facotry.CreateAdvertisement();

        public static bool Insert(AdvertisementInfo ad)
        {
            return true;
        }

        public static bool Delete(int id)
        {
            return true;
        }

        public static bool Update(AdvertisementInfo ad)
        {
            return Dal.Update(ad);
            //return true;
        }
        public static AdvertisementInfo GetById(int id)
        {
            return Dal.GetById(id);

        }

        public static DataTable GetItemsBySearchCase(string keywords, string type, string enabled)
        {
            DataTable dt = Dal.GetItemsBySearchCase(keywords, type, enabled);
            return dt;
        }
        public static DataTable GetAllAdvertisement()
        {
            DataTable dt = Dal.GetAllAdvertisement();
            return dt;
        }
    }
}
