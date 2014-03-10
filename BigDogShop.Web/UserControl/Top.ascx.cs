using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BigDogShop.Common;
using BigDogShop.Model;

namespace BigDogShop.Web.UserControl
{
    public partial class AdminHeader : System.Web.UI.UserControl
    {
        protected UserInfo user = null;
        protected string preUrl = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //顶部栏位切换
            if (IsUserLogin())
            {
                lbl_user_name.Text = user.User_Name;
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
        }

        /// <summary>
        /// 根据session判断是否登录
        /// </summary>
        /// <returns></returns>
        public bool IsUserLogin()
        {
            if (HttpContext.Current.Session[Keys.SESSION_USER_INFO] != null)
            {
                user = HttpContext.Current.Session[Keys.SESSION_USER_INFO] as UserInfo;
                return true;            
            }
            return false;          
        }

        //退出
        protected void lbtn_Exit_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session[Keys.SESSION_USER_INFO] = null;

            var a = Request.Url.ToString();
            HttpContext.Current.Session[Keys.COOKIE_URL_REFERRER] = Request.Url.ToString();
            Response.Redirect("Login.aspx");
        }
    }
}