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
    public class AdminBLL
    {
        protected static IAdmin Dal = DALFactory.Facotry.CreateAdmin();

        public static bool Exists(int id)
        {
            return Dal.Exists(id);
        }

        public static bool Exists(string user_name)
        {
            return Dal.Exists(user_name);
        }

        /// <summary>
        /// 获取对像实体
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static AdminInfo GetModel(string user_name, string password)
        {
            return Dal.GetModel(user_name, password);
        }

        public static bool Add(AdminInfo admin)
        {
            return Dal.Add(admin);
        }

        public static bool Update(AdminInfo admin)
        {
            return Dal.Update(admin);
        }

        public static bool Delete(int id)
        {
            return Dal.Delete(id);
        }

        public static AdminInfo GetById(int id)
        {
            return Dal.GetById(id);
        }

        public static DataTable GetList(string name="")
        {
            return Dal.GetList(name);
        }
    }
}
