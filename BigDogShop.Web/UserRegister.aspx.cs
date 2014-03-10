using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BigDogShop.Model;
using BigDogShop.Web.Base;
using BigDogShop.BLL;

namespace BigDogShop.Web
{
    public partial class UserRegister : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string user_name = txt_user_name.Text.ToString();
            string password = txt_password.Text.ToString();
            string email = txt_email.Text.ToString();
            UserInfo u = new UserInfo();
            u.User_Name = user_name;
            u.Password = password;
            u.E_Mail = email;
            bool result = UserBLL.Register(u);
            if (result)
            {
                UserInfo user = new UserInfo();
                //user = UserBLL.GetUser(u);
                Session["user_id"] = user.Id;
                Response.Redirect("Success.aspx");
            }
            
        }
    }
}