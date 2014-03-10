using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BigDogShop.Model;
using BigDogShop.BLL;
using BigDogShop.Web.Base;
using BigDogShop.Common;

namespace BigDogShop.Web
{
    public partial class Login : UserPage
    {
        //protected UserInfo user = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_user_name.Text = Utils.GetCookie(Keys.COOKIE_USER_NAME_REMEMBER, "BDUser");
                txt_user_pwd.Text = Utils.GetCookie(Keys.COOKIE_USER_PWD_REMEMBER, "BDUser");
            }
        }
        
        protected void btnOk_Click(object sender, EventArgs e)
        {
            string user_name = txt_user_name.Text.Trim().ToString();
            string password = txt_user_pwd.Text.Trim().ToString();
            UserInfo user = new UserInfo();
            user = UserBLL.GetUserInfo(user_name, password);
            if (user != null)
            {
                HttpContext.Current.Session[Keys.SESSION_USER_INFO] = user;
                HttpContext.Current.Session.Timeout = 45;

                //写入cookie,时间为1周
                if (cb_check.Checked == true)
                {
                    Utils.WriteCookie(Keys.COOKIE_USER_NAME_REMEMBER, "BDUser", user.User_Name, 10080);
                    Utils.WriteCookie(Keys.COOKIE_USER_PWD_REMEMBER, "BDUser", user.Password, 10080);
                }

                Session["user_id"] = user.Id.ToString();
                Session["status"] = user.Status.ToString();
                if (Session["status"].ToString() == "Y")
                {
                    if (Session["status"].ToString() == "N")
                    {
                        Session["error_message"] = "该账号未激活，请登录你的注册邮箱激活";
                        this.lab_mess.Text = "该账号未激活，请登录你的注册邮箱激活";

                        WebCom.ShowAlert(this.Page, "系统提示!", "error", "该账号未激活，请登录你的注册邮箱激活");
                    }
                    else
                    {
                        if (HttpContext.Current.Session[Keys.COOKIE_URL_REFERRER] != null)
                        {
                            Response.Redirect(HttpContext.Current.Session[Keys.COOKIE_URL_REFERRER].ToString());
                        }
                        Response.Redirect("Index.aspx");
                    }
                }
                else
                {
                    Session["error_message"] = "请输入正确的用户名和密码";
                    this.lab_mess.Text = "请输入正确的用户名和密码";
                    return;
                }
                //HttpContext.Current.Response.Redirect(preUrl);//跳转到登录前页面
            }
            else
            {
                Session["error_message"] = "请输入正确的用户名和密码";
                this.lab_mess.Text = "请输入正确的用户名和密码";
                return;
            }
        }

    }

}