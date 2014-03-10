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
            DataTable dt = NewsBLL.GetNewsList();
            rpt_news.DataSource = dt;
            rpt_news.DataBind();
        }

    }
}