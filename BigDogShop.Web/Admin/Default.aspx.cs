using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BigDogShop.Common;
using BigDogShop.BLL;
using BigDogShop.Web.Base;

namespace BigDogShop.Web.Admin
{
    public partial class Default : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //判断管理员是否登录
                if (IsAdminLogin())
                {
                    admin = GetAdminInfo();
                }
                else
                {
                    Response.Redirect("Login.aspx");//中转到登录页面
                }
            }
        }
    }
}