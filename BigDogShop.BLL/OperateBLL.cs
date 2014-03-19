using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.Model;
using BigDogShop.IDAL;
using BigDogShop.DALFactory;

namespace BigDogShop.BLL
{
    public class OperateBLL
    {
        protected static IOperate Dal = Facotry.CreateOperate();

        public static bool Add(OperateInfo model)
        {
            return Dal.Add(model);
        }

        public static bool Delete(int id)
        {
            return Dal.Delete(id);
        }

        public static bool Update(OperateInfo model)
        {
            return Dal.Update(model);
        }

        public static OperateInfo GetById(int id)
        {
            return Dal.GetById(id);
        }

        public static DataTable GetList(string name = "")
        {
            return Dal.GetList(name);
        }
    }
}
