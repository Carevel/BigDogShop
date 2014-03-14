using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface IRole
    {
        bool Add(RoleInfo model);
        bool Delete(int id);
        bool Update(RoleInfo model);
        RoleInfo GetById(int id);
        DataTable GetList();
        DataTable GetListByName(string name);
    }
}
