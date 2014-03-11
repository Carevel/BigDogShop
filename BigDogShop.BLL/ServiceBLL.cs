using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.DALFactory;
using BigDogShop.Model;
using BigDogShop.IDAL;

namespace BigDogShop.BLL
{
    public class ServiceBLL
    {
        protected static IService Dal = Facotry.CreateService();

        public static bool Add(ServiceInfo service)
        {
            return Dal.Add(service);
        }

        public static bool Delete(int id)
        {
            return Dal.Delete(id);
        }

        public static bool Update(ServiceInfo service)
        {
            return Dal.Update(service);
        }

        public static ServiceInfo GetById(int id)
        {
            return Dal.GetById(id);
        }

        public static DataTable GetServiceList(int id)
        {
            return Dal.GetServiceList(id);
        }

        public static DataTable GetServiceList()
        {
            return Dal.GetServiceList();
        }
    }
}
