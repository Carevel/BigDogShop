using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface IProvider
    {
        bool Add(ProviderInfo model);
        bool Delete(int id);
        bool Update(ProviderInfo model);
        ProviderInfo GetById(int id);
        DataTable GetList();
    }
}
