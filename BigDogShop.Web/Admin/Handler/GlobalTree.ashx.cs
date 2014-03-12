using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text;
using BigDogShop.DBUtility;

namespace BigDogShop.Web.Admin.Handler
{
    /// <summary>
    /// Summary description for GlobalTree
    /// </summary>
    public class GlobalTree : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string father_id = context.Request.Params["id"].ToString();

            StringBuilder sql = new StringBuilder();
            StringBuilder html = new StringBuilder();
            sql.Append("select Id,Father_Id,Menu_Name,Nav_Url,");
            sql.Append("(select (case count(1) when '0' then 'false' else 'true' end) from BigDog_Admin_Menu b where a.Id=b.Father_Id) Has_Child ");
            sql.Append(" from BigDog_Admin_Menu a where a.Father_Id=@father_id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@father_id",SqlDbType.Int)
            };
            parms[0].Value = father_id;
            DataTable dt = new DataTable();
            dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
            if (dt.Rows.Count > 0)
            {
                html.Append("<ul>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Has_Child"].ToString() == "true")
                    {
                        html.Append("<li id=" + dt.Rows[i]["Id"] + " class='tree_li_header'>");
                        html.Append("<span id=" + dt.Rows[i]["Id"] + " class='tree_hit tree_collapsed' onclick='getList(this," + dt.Rows[i]["Id"] + ");'></span>");
                        html.Append("<div class='tree_title'>" + dt.Rows[i]["Menu_Name"] + "</tree_title></li>");
                    }
                    else
                    {
                        html.Append("<li id=" + dt.Rows[i]["Id"] + " data-rel='"+dt.Rows[i]["Nav_Url"].ToString()+"' class='tree_li_header tree_child'>");
                        html.Append("<span id=" + dt.Rows[i]["Id"] + " class='tree_file' onclick='getList(this," + dt.Rows[i]["Id"] + ");'></span>");
                        html.Append("<div class='tree_title'>" + dt.Rows[i]["Menu_Name"] + "</tree_title></li>");
                    }

                }
                html.Append("</ul>");
            }
            context.Response.Write(html.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}