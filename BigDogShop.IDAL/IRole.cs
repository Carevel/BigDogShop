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
        bool Delete(string ids);
        bool Update(RoleInfo model);
        RoleInfo GetById(string id);
        DataTable GetList(string name="");
    }
}
