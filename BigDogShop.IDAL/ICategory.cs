using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface ICategory
    {
        bool Add(CategoryInfo category);
        bool Delete(int id);
        bool Update(CategoryInfo category);
        CategoryInfo GetById(int id);
        DataTable GetChildList(int father_id,int type_id);
        DataTable GetList(int father_id);
    }
}
