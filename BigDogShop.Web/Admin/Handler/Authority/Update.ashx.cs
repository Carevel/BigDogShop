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
    /// Summary description for Update
    /// </summary>
    public class Update : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            string name = context.Request.Params["name"].ToString();
            string desc = context.Request.Params["desc"].ToString();
            StringBuilder sql = new StringBuilder();
            StringBuilder json = new StringBuilder();
            sql.Clear();
            RoleInfo model = new RoleInfo();
            model.Name = name;
            model.Description = desc;
            if (RoleBLL.Update(model))
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