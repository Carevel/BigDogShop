using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.DBUtility;
using BigDogShop.DALFactory;
using BigDogShop.Model;
using BigDogShop.IDAL;

namespace BigDogShop.BLL
{
    public class RoleBLL
    {
        private static IRole Dal = Facotry.CreateOperate();
        public static bool Add(RoleInfo model)
        {
            return Dal.Add(model);
        }

        public static string Delete(string id)
        {
            return Dal.Delete(id);
        }

        public static bool Update(RoleInfo model)
        {
            return Dal.Update(model);
        }

        public static string GetById(string id)
        {
            return Dal.GetById(id);
        }

        public static string GetList()
        {
            return Dal.GetList();
        }

        public static string GetListByName(string name)
        {
            return Dal.GetListByName(name);
        }
    }
}
