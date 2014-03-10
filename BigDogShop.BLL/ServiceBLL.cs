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
        protected static IService serviceDAL = Facotry.CreateService();

        public static bool Add(ServiceInfo service)
        {
            return serviceDAL.Add(service);
        }

        public static bool Delete(int id)
        {
            return serviceDAL.Delete(id);
        }

        public static bool Update(ServiceInfo service)
        {
            return serviceDAL.Update(service);
        }

        public static ServiceInfo GetById(int id)
        {
            return serviceDAL.GetById(id);
        }

        public static DataTable GetServiceList(int id)
        {
            return serviceDAL.GetServiceList(id);
        }

        public static DataTable GetServiceList()
        {
            return serviceDAL.GetServiceList();
        }
    }
}
