using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using BigDogShop.Model;
using BigDogShop.BLL;
using Wuqi.Webdiyer;

namespace BigDogShop.Web.Admin.Advertisement
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                InitPage();

            }
        }
        public void InitPage()
        {
            //string sql = "select type_id f1,type_name,Meaning f2 from BigDog_Parameters";
            //OracleHelper.SetDDL(sql.ToString(), ddl_ad_type, 2);
        }
        public void BindData()
        {
            //string sql = "select a.Ad_Id,a.Image_Url,a.Title,a.Link_Url,a.Enabled,b.Meaning from BigDog_Advertisement a,bigdog_parameters b ";
            //string tableName = "BigDog_Advertisement a,BigDog_Parameters b ";
            //string whereString=" a.type_id=b.type_id and a.type_id=1";
            //string orderString= " Ad_Id ";

            string kewords = txt_ad_title.Text.ToString();
            string ad_type = ddl_ad_type.SelectedValue.ToString();
            string enabled = ddl_ad_enabled.SelectedValue.ToString();
            StringBuilder sql = new StringBuilder();
            sql.Append("select a.Ad_Id,a.Image_Url,a.Title,a.Link_Url,a.Enabled,b.Meaning from BigDog_Advertisement a,bigdog_parameters b");
            sql.Append(" where a.type_id=b.type_id  ");
            if (!string.IsNullOrEmpty(kewords))
            {
                sql.Append("and a.Title like '%" + kewords + "'");
            }
            if (!string.IsNullOrEmpty(ad_type))
            {
                sql.Append("and a.Type_Id ='" + ad_type + "'");
            }
            if (!string.IsNullOrEmpty(enabled))
            {
                sql.Append("and a.enabled='" + enabled + "'");
            }
            DataTable dt = new DataTable();
            //DataTable dt = Function.InitPageData(sql.ToString(), AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, AspNetPager1, rpt_ad);
            rpt_ad.DataSource = dt;
            rpt_ad.DataBind();
            //Function.InitPageData(sql, tableName, whereString, orderString, AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, AspNetPager1, rpt_ad);
        }
        public void Bind()
        {
            DataTable dt = AdvertisementBLL.GetAllAdvertisement();
            if (dt != null)
            {
                rpt_ad.DataSource = dt;
                rpt_ad.DataBind();
                lab_mess.Visible = false;
            }
            {
                //rpt_ad.Visible = false;
                lab_mess.Visible = true;
            }

        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {

        }
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            Response.Write("<Script type='text/javascript' >alert('a');</script>");
        }
        protected void btn_show_Click(object sender, EventArgs e)
        {

        }
        protected void btn_search_Click(object sender, EventArgs e)
        {
            string kewords = txt_ad_title.Text.ToString();
            string ad_type = ddl_ad_type.SelectedValue.ToString();
            string enabled = ddl_ad_enabled.SelectedValue.ToString();
            BindData();
            //DataTable dt = AdvertisementBLL.GetItemsBySearchCase(kewords, ad_type, enabled);
            //if (dt != null)
            //{
            //    rpt_ad.DataSource = dt;
            //    rpt_ad.DataBind();
            //    lab_mess.Visible = false;
            //}
            //else
            //{
            //    rpt_ad.Visible = false;
            //    lab_mess.Visible = true;
            //}
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}