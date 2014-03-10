using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BigDogShop.Common;
using BigDogShop.Model;
using BigDogShop.Web.Base;

namespace BigDogShop.Web.Admin.UserControl
{
    public partial class TopInfo : System.Web.UI.UserControl
    {
        protected AdminInfo admin = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsAdminLogin())
            {
                txt_admin_name.Text = admin.User_Name;
            }
        }

        public bool IsAdminLogin()
        {
            if (HttpContext.Current.Session[Keys.SESSION_ADMIN_INFO] != null)
            {
                admin = HttpContext.Current.Session[Keys.SESSION_ADMIN_INFO] as AdminInfo;
                return true;
            }
            return false;
        }

        protected void lbtn_Click(object sender, EventArgs e)
        {
            Session[Keys.SESSION_ADMIN_INFO] = null;
            Utils.WriteCookie("Admin_Name", "BDAdmin", -10080);
            Utils.WriteCookie("Admin_Pwd", "BDAdmin", -10080);
            Response.Redirect("Login.aspx");
        }
    }
}