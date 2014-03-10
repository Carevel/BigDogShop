using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface ILink
    {
        bool Add(LinkInfo link);
        bool Delete(int id);
        bool Update(LinkInfo link);
        LinkInfo GetById(int id);
        DataTable GetLinkList();
    }
}
