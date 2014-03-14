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
    /// Summary description for Add
    /// </summary>
    public class Add : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request.Params["name"].ToString();
            string desc = context.Request.Params["desc"].ToString();
            StringBuilder sql = new StringBuilder();
            StringBuilder json = new StringBuilder();

            sql.Clear();
            sql.Append("insert into BigDog_Admin_Role(id,name,description)values(1,@name,@desc)");
            SqlParameter[] parms = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.NVarChar,50),
                new SqlParameter("@desc",SqlDbType.NVarChar,200)
            };
            parms[0].Value = name;
            parms[1].Value = desc;
            int val = SQLHelper.ExecuteNonQuery(CommandType.Text, sql.ToString(), parms);
            if (val > 0)
            {
                json.Append("[");
                json.Append("{\"result\":\"1\"}");
                json.Append("]");
            }
            else
            {
                json.Append("[");
                json.Append("{\"result\":\"0\"}");
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