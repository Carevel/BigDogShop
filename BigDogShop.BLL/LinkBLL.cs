using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.IDAL;
using BigDogShop.Model;
using BigDogShop.DALFactory;

namespace BigDogShop.BLL
{
    public class LinkBLL
    {
        protected static ILink linkDAL = Facotry.CreateLink();

        public static  bool Add(LinkInfo link)
        {
            return linkDAL.Add(link);
        }

        public static bool Delete(int id)
        {
            return linkDAL.Delete(id);
        }

        public static bool Update(LinkInfo link)
        {
            return linkDAL.Update(link);
        }

        public static LinkInfo GetById(int id)
        {
            return linkDAL.GetById(id);
        }

        public static DataTable GetLinkList()
        {
            return linkDAL.GetLinkList();
        }
    }
}
