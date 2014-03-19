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
        private static IRole Dal = Facotry.CreateRole();
        public static bool Add(RoleInfo model)
        {
            return Dal.Add(model);
        }

        public static bool Delete(string id)
        {
            return Dal.Delete(id);
        }

        public static bool Update(RoleInfo model)
        {
            return Dal.Update(model);
        }

        public static RoleInfo GetById(string id)
        {
            return Dal.GetById(id);
        }

        public static DataTable GetList(string name="")
        {
            return Dal.GetList(name);
        }

       
    }
}
