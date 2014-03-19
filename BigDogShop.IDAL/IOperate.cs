using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
   public  interface IOperate
    {
       bool Add(OperateInfo model);
       bool Delete(int id);
       bool Update(OperateInfo model);
       OperateInfo GetById(int id);
       DataTable GetList(string name="");
    }
}
