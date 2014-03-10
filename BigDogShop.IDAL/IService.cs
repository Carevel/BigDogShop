using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface IService
    {
        bool Add(ServiceInfo service);
        bool Delete(int id);
        bool Update(ServiceInfo service);
        ServiceInfo GetById(int id);
        DataTable GetServiceList(int id);
        DataTable GetServiceList();
        
    }
}
