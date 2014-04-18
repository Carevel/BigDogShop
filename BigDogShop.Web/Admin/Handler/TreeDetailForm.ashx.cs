using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BigDogShop.DBUtility;
using BigDogShop.SQLServerDAL;

namespace BigDogShop.Web.Admin.Handler
{
    /// <summary>
    /// Summary description for TreeDetailForm
    /// </summary>
    public class TreeDetailForm : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.Params["type"].ToString();
            string id = context.Request.Params["id"].ToString();
            StringBuilder json = new StringBuilder();
            StringBuilder sql = new StringBuilder();
            sql.Append("select id,menu_name,father_id,category_id,nav_url from BigDog_Admin_Menu where id=@id");
            SqlParameter[] param=new SqlParameter[]{
                new SqlParameter("@id",SqlDbType.VarChar,400)
            };
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            json.Append("[");
            foreach (DataRow dr in dt.Rows)
            {
                json.Append("{\"id\":" + dr["Id"].ToString());
                json.Append(",\"menu_name\":\"" + dr["Menu_Name"].ToString() + "\"");
                json.Append(",\"father_id\":\"" + dr["Father_Id"].ToString() + "\"");
                json.Append(",\"category_id\"" + dr["category_id"].ToString() + "\"}");
                json.Append("},");
            }
            if (dt.Rows.Count > 0)
            {
                json.Remove(json.Length - 1, 1);
            }
            json.Append("]");
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