using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface IMenu
    {
        bool Add(MenuInfo menu);
        bool Delete(int id);
        bool Update(MenuInfo menu);
        MenuInfo GetById(int id);
        DataTable GetMenuList();
    }
}
