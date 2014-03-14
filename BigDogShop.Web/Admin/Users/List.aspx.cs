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

namespace BigDogShop.Web.Admin.Users
{
    public partial class List : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public void Bind()
        {
            DataTable dt = UserBLL.GetList();
            rpt_data_list.DataSource = dt;
            rpt_data_list.DataBind();
            gv_data_list.DataSource = dt;
            gv_data_list.DataBind();
        }
    }
}