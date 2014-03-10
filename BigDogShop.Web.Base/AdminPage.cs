using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.HtmlControls;
using BigDogShop.Common;
using BigDogShop.Model;
using BigDogShop.BLL;

namespace BigDogShop.Web.Base
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected internal AdminInfo admin;

        /// <summary>
        /// 判断管理员是否登录，针对session超时
        /// </summary>
        /// <returns></returns>
        public bool IsAdminLogin()
        {
            //session是否为null
            if (Session[Keys.SESSION_ADMIN_INFO] != null)
            {
                return true;
            }
            else
            {
                //检查cookie
                string admin_name = Utils.GetCookie("Admin_Name", "BDAdmin");
                string admin_pwd = Utils.GetCookie("Admin_Pwd", "BDAdmin");
                if (admin_name != "" && admin_pwd != "")
                {
                    admin = AdminBLL.GetModel(admin_name, admin_pwd);
                    if (admin != null)
                    {
                        HttpContext.Current.Session[Keys.SESSION_ADMIN_INFO] = admin;
                        return true;
                    }
                }
            }
            return false;
        }

        //获取管理员实体
        public AdminInfo GetAdminInfo()
        {
            if (IsAdminLogin())
            {
                AdminInfo admin = HttpContext.Current.Session[Keys.SESSION_ADMIN_INFO] as AdminInfo;
                if (admin != null)
                {
                    return admin;
                }     
            }
            return null;
        }
    }
}
