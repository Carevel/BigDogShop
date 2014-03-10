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
    public partial class UserChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["user_id"].ToString());
            string newpwd = txt_new_pwd.Text.ToString();
            string confirm_newpwd = txt_confirm_new_pwd.Text.ToString();
            UserInfo user = UserBLL.GetById(id);
            user.Real_Name = newpwd;
            if (UserBLL.Update(user))
            {
                Response.Redirect("Success.aspx");
            }
        }
    }
}