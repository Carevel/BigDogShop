using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BigDogShop.BLL;
using BigDogShop.Model;

namespace BigDogShop.Web.UserControl
{
    public partial class HeaderNav : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                lbl_time.Text = DateTime.Now.ToString();
                Bind();
            }
        }
        public void Bind()
        {
            DataTable dt = new DataTable();
            dt = MenuBLL.GetMenuItems();
            rpt_menu.DataSource = dt;
            rpt_menu.DataBind();

            DataTable dt2 = new DataTable();
            //dt2 = dt.DefaultView.ToTable(true, "Type_Id");
            dt2 = CategoryBLL.GetCategoryList(0);
            dt2 = dt2.DefaultView.ToTable(true, new string[]{"Type_Id","Father_Id"});
            rpt_menu_category.DataSource = dt2;
            rpt_menu_category.DataBind();
        }

        protected void rpt_menu_category_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Repeater rptDetial = (Repeater)e.Item.FindControl("rpt_menu_category_list") as Repeater;
                DataRowView drv = (DataRowView)e.Item.DataItem;
                int type_id = Convert.ToInt32(drv["Type_Id"]);
                int father_id = Convert.ToInt32(drv["Father_id"]);
                DataTable d = CategoryBLL.GetChildList(father_id, type_id);
                rptDetial.DataSource = CategoryBLL.GetChildList(father_id, type_id);
                rptDetial.DataBind();
            }

        }
    }
}