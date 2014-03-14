using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BigDogShop.Model;
using BigDogShop.BLL;
using BigDogShop.DBUtility;

namespace BigDogShop.Web.Admin.Handler.Authority
{
    /// <summary>
    /// Summary description for Search
    /// </summary>
    public class Search : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request.Params["name"].ToString();
            StringBuilder json = new StringBuilder();
            DataTable dt = RoleBLL.GetListByName(name);
            if (dt.Rows.Count > 0)
            {
                json.Append("[");
                json.Append("\"result\":\"1\",\"data\":");
                foreach (DataRow dr in dt.Rows)
                {
                    json.Append("{\"Id\":\"" + dr["Id"].ToString() + "\"");
                    json.Append(",\"Name\":\"" + dr["Name"].ToString() + "\"");
                    json.Append(",\"Description\":\"" + dr["Description"].ToString() + "\"");
                    json.Append(",\"Created_Date\":\"" + dr["Created_Date"].ToString() + "\"");
                    json.Append("}");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("]");
            }
            
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