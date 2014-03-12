using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BigDogShop.BLL;
using BigDogShop.Model;
using BigDogShop.Web.Base;
using BigDogShop.Common;

namespace BigDogShop.Web.Admin
{
    public partial class ManagerCenter :AdminPage
    {
        //private AdminInfo admin = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsAdminLogin())
            //{
            //    admin = GetAdminInfo();
            //}
            //else
            //{
            //    Response.Redirect("Login.aspx");
            //}
            string ip = Requests.GetIP();
            login_ip.Text = Requests.GetIP();
        }




    }
}