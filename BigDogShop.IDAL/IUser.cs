using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigDogShop.Model;

namespace BigDogShop.IDAL
{
    public interface IUser
    {
        bool Exists(string user_name); 
        bool Register(UserInfo user);
        bool Update(UserInfo user);
        bool Delete(int id);
        UserInfo GetById(int id);
        UserInfo GetUserInfo(string user_name, string password);
    }
}
