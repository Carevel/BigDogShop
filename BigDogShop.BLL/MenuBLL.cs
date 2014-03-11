using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BigDogShop.Model;
using BigDogShop.DALFactory;
using BigDogShop.IDAL;

namespace BigDogShop.BLL
{
    public class MenuBLL
    {
        protected static IMenu Dal = DALFactory.Facotry.CreateMenu();
        public static bool Add(MenuInfo menu)
        {
            return Dal.Add(menu);
        }

        public static bool Delete(int id)
        {
            return Dal.Delete(id);
        }

        public static bool Update(MenuInfo menu)
        {
            return Dal.Update(menu);
        }

        public static MenuInfo GetById(int id)
        {
            return Dal.GetById(id);
        }

        public static DataTable GetMenuItems()
        {
            return Dal.GetMenuList();
        }
    }
}
