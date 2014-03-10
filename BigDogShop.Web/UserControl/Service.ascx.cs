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
    public partial class Service: System.Web.UI.UserControl
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
            dt = ServiceBLL.GetServiceList(0);
            rpt_service.DataSource = dt;
            rpt_service.DataBind();
        }

        protected void rpt_service_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptNew =(Repeater) e.Item.FindControl("rpt_service_detail") as Repeater;
                DataRowView drv = (DataRowView)e.Item.DataItem;
                int father_id = Convert.ToInt32(drv["Id"]);
                DataTable dt = ServiceBLL.GetServiceList(father_id);
                if (dt != null)
                {
                    rptNew.DataSource = ServiceBLL.GetServiceList(father_id);
                    rptNew.DataBind();
                }
                return;
            }
        }


    }
}