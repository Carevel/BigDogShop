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
        string Delete(string id);
        bool Update(RoleInfo model);
        string GetById(string id);
        //RoleInfo GetById(int id);
        //DataTable GetList();
        string GetList();
        //DataTable GetListByName(string name);
        string GetListByName(string name);
    }
}
