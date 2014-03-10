using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface INews
    {
        bool Add(NewsInfo news);
        bool Delete(int id);
        bool Update(NewsInfo news);
        NewsInfo GetById(int id);
        DataTable GetNewsList(int father_id);
        DataTable GetNewsList();
    }
}
