using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BigDogShop.Model;
using BigDogShop.BLL;
using BigDogShop.Web.Base;
public partial class CenterInfo : BasePageInfo
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            if (Session["user_id"] ==null)
            {
                Response.Redirect("Login.apsx");
            }
            else
            {
                int id = Convert.ToInt32(Session["user_id"]);
                //BindDetail(id);
                BindUserInfoById(id);
            }
        }
    }
}