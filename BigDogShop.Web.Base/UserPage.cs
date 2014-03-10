using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BigDogShop.Common;
using BigDogShop.Model;
using BigDogShop.BLL;

namespace BigDogShop.Web.Base
{
    public class UserPage:System.Web.UI.Page
    {
        protected string preUrl = string.Empty;

        //protected override void OnInit(EventArgs e)
        //{
        //    preUrl = Utils.GetCookie(Keys.COOKIE_URL_REFERRER);
        //    if (IsUserLogin())
        //    {
        //        Response.Redirect(preUrl);
        //        return;
        //    }
        //    base.OnInit(e);
        //}

        /// <summary>
        /// 判断用户是否登录，如果登录就设置Session保存实体
        /// </summary>
        /// <returns></returns>
        public bool IsUserLogin()
        {
            string user_name = Utils.GetCookie(Keys.COOKIE_USER_NAME_REMEMBER, "BDUser");
            string password = Utils.GetCookie(Keys.COOKIE_USER_PWD_REMEMBER, "BDUser");
            if (user_name != "" && password != "")
            {
                UserInfo user = UserBLL.GetUserInfo(user_name, password);
                if (user != null)
                {
                    HttpContext.Current.Session[Keys.SESSION_USER_INFO] = user;
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// 获取用户信息实体
        /// </summary>
        /// <returns></returns>
        public UserInfo GetUserInfo()
        {
            if (IsUserLogin())
            {
                UserInfo user = Session[Keys.SESSION_USER_INFO] as UserInfo;
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
