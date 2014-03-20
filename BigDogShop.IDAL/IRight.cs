using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface IRight
    {
        bool Add(RightInfo model);
        bool Delete(string id);
        bool Update(RightInfo model);
        RightInfo GetById(string id);
        DataTable GetList(string name = "");
    }
}
