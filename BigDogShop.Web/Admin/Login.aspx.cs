using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BigDogShop.Common;
using BigDogShop.Web.Base;
using BigDogShop.Model;
using BigDogShop.BLL;

namespace BigDogShop.Web.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_name.Text = Utils.GetCookie("BDRememberName");
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string user_name = txt_name.Text.Trim();
            string user_pwd = txt_pwd.Text.Trim();
            AdminInfo admin = AdminBLL.GetModel(user_name, user_pwd);
            if (admin == null)
            {
                lab_mess.Visible = true;
                lab_mess.Text = "用户名或密码错误";
                return;
            }
            HttpContext.Current.Session[Keys.SESSION_ADMIN_INFO] = admin;

            //写入cookie,记住用户名
            if (ck_remember.Checked)
            {
                Utils.WriteCookie("BDRememberName", admin.User_Name, 10080);
            }
            else
            {
                Utils.WriteCookie("BDRememberName", admin.User_Name, -10080);
            }

            Utils.WriteCookie("Admin_Name", "BDAdmin", admin.User_Name);
            Utils.WriteCookie("Admin_Pwd", "BDAdmin", admin.Password);
            Response.Redirect("Index.aspx");
            return;
        }

    }
}