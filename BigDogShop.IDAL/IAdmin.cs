using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface IAdmin
    {
        bool Exists(int id);
        bool Exists(string user_name);
        bool Add(AdminInfo admin);
        bool Update(AdminInfo admin);
        bool Delete(int id);
        AdminInfo GetById(int id);
        AdminInfo GetModel(string user_name, string password);
    }
}
