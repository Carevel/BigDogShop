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
            sql.Append("select Id,Father_Id,Menu_Name,Nav_Url from BigDog_Admin_Menu where Father_Id=@father_id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@father_id",SqlDbType.Int)
            };
            parms[0].Value = father_id;
            DataTable dt = new DataTable();
            dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
            if (dt.Rows.Count > 0)
            {
                //html.Append("<span class='tree_indent'></span>");
                html.Append("<ul>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html.Append("<li id=" + dt.Rows[i]["Id"] + " class='tree_li_header'><span id=" + dt.Rows[i]["Id"] + " class='tree_hit tree_collapsed' onclick='getList(this," + dt.Rows[i]["Id"] + ");'></span><div class='tree_title'>" + dt.Rows[i]["Menu_Name"] + "</tree_title></li>");
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