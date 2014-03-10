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
        protected static IMenu MenuDAL = DALFactory.Facotry.CreateMenu();
        public static bool Add(MenuInfo menu)
        {
            return MenuDAL.Add(menu);
        }

        public static bool Delete(int id)
        {
            return MenuDAL.Delete(id);
        }

        public static bool Update(MenuInfo menu)
        {
            return MenuDAL.Update(menu);
        }

        public static MenuInfo GetById(int id)
        {
            return MenuDAL.GetById(id);
        }

        public static DataTable GetMenuItems()
        {
            return MenuDAL.GetMenuList();
        }
    }
}
