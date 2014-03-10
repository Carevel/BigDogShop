using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BigDogShop.BLL;

namespace BigDogShop.Web.UserControl
{
    public partial class Link : System.Web.UI.UserControl
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
            DataTable dt = new DataTable();
            dt = LinkBLL.GetLinkList();
            rpt_link.DataSource = dt;
            rpt_link.DataBind();
        }
    }
}