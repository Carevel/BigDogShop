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
            dt2 = CategoryBLL.GetCategoryList();
            
            rpt_menu_category.DataSource = dt2;
            rpt_menu_category.DataBind();
        }       
    }
}