using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Web.UI.HtmlControls;
using BigDogShop.Model;
using BigDogShop.BLL;
using BigDogShop.Common;
using BigDogShop.Web.Base;

namespace BigDogShop.Web
{
    public partial class Index : UserPage
    {
        protected UserInfo user = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsUserLogin())
                {
                    user = GetUserInfo();
                }
                Bind();
            }
        }

        public void Bind()
        {
            DataTable dt = NewsBLL.GetNewsList(1);
            rpt_news.DataSource = dt;
            rpt_news.DataBind();

            initRptData();
        }

        public void initRptData()
        {
            DataTable dt = new DataTable();

            dt = NewsBLL.GetNewsList(7);
            rpt_slide.DataSource = dt;
            rpt_slide.DataBind();

            dt = NewsBLL.GetNewsList(2);
            rpt_corner.DataSource = dt;
            rpt_corner.DataBind();

            dt = NewsBLL.GetNewsList(3);
            rpt_tuan.DataSource = dt;
            rpt_tuan.DataBind();

            dt = NewsBLL.GetNewsList(4);
            rpt_specialty.DataSource = dt;
            rpt_specialty.DataBind();

            dt = NewsBLL.GetNewsList(5);
            rpt_newgoods.DataSource = dt;
            rpt_newgoods.DataBind();

            dt = NewsBLL.GetNewsList(6);
            rpt_activity.DataSource = dt;
            rpt_activity.DataBind();
        }
    }
}