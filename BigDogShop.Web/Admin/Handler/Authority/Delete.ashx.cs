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
    /// Summary description for Delete
    /// </summary>
    public class Delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            StringBuilder sql = new StringBuilder();
            StringBuilder json = new StringBuilder();
            sql.Clear();
            int id = Convert.ToInt32(context.Request.Params["id"].ToString());
            if (RoleBLL.Delete(id))
            {
                json.Append("[");
                json.Append("\"result\":\"1\",\"data\":\"\"");
                json.Append("]");
            }
            else
            {
                json.Append("[");
                json.Append("\"result\":\"0\",\"data\":\"\"");
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