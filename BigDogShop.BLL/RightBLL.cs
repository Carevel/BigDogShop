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
    public class RightBLL
    {
        protected static IRight Dal = Facotry.CreateRight();

        public static  bool Add(RightInfo model)
        {
            return Dal.Add(model);
        }

        public static bool Delete(string ids)
        {
            return Dal.Delete(ids);
        }

        public static bool Update(RightInfo model)
        {
            return Dal.Update(model);
        }

        public static DataTable GetList(string name = "")
        {
            return Dal.GetList(name);
        }

        public static RightInfo GetById(string id)
        {
            return Dal.GetById(id);
        }
    }
}
