using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using BigDogShop.DBUtility;
using System.Data.SqlClient;
using BigDogShop.Model;
using BigDogShop.BLL;
namespace BigDogShop.Web.Admin.Handler.Authority
{
    /// <summary>
    /// Summary description for List
    /// </summary>
    public class List : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request.Params["Name"] != null ? context.Request.Params["Name"] : "";
            StringBuilder sql = new StringBuilder();
            StringBuilder json = new StringBuilder();
            sql.Append("select Id,Name,Description,Created_Date from BigDog_Admin_Role where 1=1 ");
            if (name != "")
            {
                sql.Append(" and Name like '%" + name + "%' ");
            }
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                json.Append("[");
                foreach (DataRow dr in dt.Rows)
                {
                    json.Append("{\"Id\":\"" + dr["Id"].ToString() + "\"");
                    json.Append(",\"Name\":\"" + dr["Name"].ToString() + "\"");
                    json.Append(",\"Description\":\"" + dr["Description"].ToString() + "\"");
                    json.Append(",\"Created_Date\":\"" + dr["Created_Date"].ToString() + "\"");
                    json.Append("},");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("]");
            }
            context.Response.Write(json.ToString());
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