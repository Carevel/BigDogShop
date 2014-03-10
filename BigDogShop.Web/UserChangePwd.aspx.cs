using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BigDogShop.Model;
using BigDogShop.BLL;
using BigDogShop.Web.Base;

namespace BigDogShop.Web
{
    public partial class UserChangePwd : BasePageInfo
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            //int id =Convert.ToInt32( Session["user_id"].ToString());
            //string pwd = txt_ckcode.Text.ToString();
            //string email_code = txt_email_code.Text.ToString();
            //string ckcode = txt_ckcode.Text.ToString();
            //if (ckcode == Session["ckcode"].ToString())
            //{ 

            //}
            Response.Redirect("ChangePwdAction.aspx");
        }
    }
}