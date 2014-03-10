using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using BigDogShop.DALFactory;
using BigDogShop.IDAL;
using BigDogShop.Model;

namespace BigDogShop.BLL
{
    public class UserBLL
    {

        protected static IDAL.IUser UserDAL = DALFactory.Facotry.CreateUser();

        /// <summary>
        /// 判断用户名是否已经存在
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public static bool Exists(string user_name)
        {
            return UserDAL.Exists(user_name);
        }

        /// <summary>
        /// 根据用户名密码获取用户信息
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public  static UserInfo GetUserInfo(string user_name, string password)
        {
            return UserDAL.GetUserInfo(user_name, password);
        }

        /// <summary>
        /// 用户註冊
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool Register(UserInfo user)
        {
            return UserDAL.Register(user);
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool Update(UserInfo user)
        {
            return UserDAL.Update(user);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            return UserDAL.Delete(id);
        }

       
        /// <summary>
        /// 根据用户ID获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserInfo GetById(int id)
        {
            //Users u = new Users();
            return UserDAL.GetById(id);
        }

        ///// <summary>
        ///// 检测邮件是否注册过
        ///// </summary>
        ///// <param name="email"></param>
        ///// <returns></returns>
        //public static bool CheckEmail(string email)
        //{
        //    return User.CheckEmail(email);
        //}

     
    }
}
