﻿using System;
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

        public static bool Delete(int id)
        {
            return Dal.Delete(id);
        }

        public static bool Update(RoleInfo model)
        {
            return Dal.Update(model);
        }

        public static RoleInfo GetById(int id)
        {
            return Dal.GetById(id);
        }

        public static DataTable GetList()
        {
            return Dal.GetList();
        }

        public static DataTable GetListByName(string name)
        {
            return Dal.GetListByName(name);
        }
    }
}
