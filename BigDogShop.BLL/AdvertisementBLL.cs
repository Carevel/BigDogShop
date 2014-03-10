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
        protected static IDAL.IAdvertisement AdvertisementDAL = DALFactory.Facotry.CreateAdvertisement();

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
            return AdvertisementDAL.Update(ad);
            //return true;
        }
        public static AdvertisementInfo GetById(int id)
        {
            return AdvertisementDAL.GetById(id);

        }

        public static DataTable GetItemsBySearchCase(string keywords, string type, string enabled)
        {
            DataTable dt = AdvertisementDAL.GetItemsBySearchCase(keywords, type, enabled);
            return dt;
        }
        public static DataTable GetAllAdvertisement()
        {
            DataTable dt = AdvertisementDAL.GetAllAdvertisement();
            return dt;
        }
    }
}
