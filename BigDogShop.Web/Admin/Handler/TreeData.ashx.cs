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
    /// Summary description for TreeData
    /// </summary>
    public class TreeData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string father_id = context.Request.Params["id"].ToString();
            StringBuilder sql = new StringBuilder();
            StringBuilder html = new StringBuilder();
            sql.Append("select a.Id,a.Father_Id,a.Menu_Name,b.Category_Group+'/'+a.Nav_Url Url,");
            sql.Append("(select (case count(1) when '0' then 'false' else 'true' end) from BigDog_Admin_Menu b where a.Id=b.Father_Id) Has_Child ");
            sql.Append(" from BigDog_Admin_Menu a,BigDog_Admin_Menu_Category b where a.Category_Id=b.Category_Id and a.Father_Id=@father_id");
            SqlParameter[] parms = new SqlParameter[] { 
                new SqlParameter("@father_id",SqlDbType.Int)
            };
            parms[0].Value = father_id;
            DataTable dt = new DataTable();
            dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];

            if (dt.Rows.Count > 0)
            {
                html.Append(GetJsonTree(dt));
            }
            context.Response.Write(html.ToString());
        }

        public string GetJsonTree(DataTable dt)
        {
            StringBuilder json = new StringBuilder();
            json.Append("[");
            foreach (DataRow dr in dt.Rows)
            {
                json.Append("{\"id\":" + dr["Id"].ToString());
                json.Append(",\"text\":\"" + dr["Menu_Name"].ToString() + "\"");
                json.Append(",\"state\":\"" + (dr["Has_Child"].ToString() == "true" ? "closed" : "open") + "\"");
                json.Append(",\"attributes\":{\"url\":\"" + dr["Url"].ToString() + "\"}");
                json.Append("},");
            }
            if (dt.Rows.Count > 0)
            {
                json.Remove(json.Length - 1, 1);
            }
            json.Append("]");
            return json.ToString();
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