using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BigDogShop.IDAL;
using BigDogShop.Model;
using BigDogShop.DALFactory;

namespace BigDogShop.BLL
{
    public class AdminBLL
    {
        protected static IAdmin AdminDAL = DALFactory.Facotry.CreateAdmin();

        public static bool Exists(int id)
        {
            return AdminDAL.Exists(id);
        }

        public static bool Exists(string user_name)
        {
            return AdminDAL.Exists(user_name);
        }

        /// <summary>
        /// 获取对像实体
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static AdminInfo GetModel(string user_name, string password)
        {
            return AdminDAL.GetModel(user_name, password);
        }

        public static bool Add(AdminInfo admin)
        {
            return AdminDAL.Add(admin);
        }

        public static bool Update(AdminInfo admin)
        {
            return AdminDAL.Update(admin);
        }

        public static bool Delete(int id)
        {
            return AdminDAL.Delete(id);
        }

        public static AdminInfo GetById(int id)
        {
            return AdminDAL.GetById(id);
        }
    }
}
