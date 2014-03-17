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

namespace BigDogShop.Web.Admin.Handler
{
    /// <summary>
    /// RoleJson 的摘要说明
    /// </summary>
    public class RoleJson : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string type = context.Request.Params["type"].ToString();
            StringBuilder sql = new StringBuilder();
            StringBuilder json = new StringBuilder();

            if (type == "read")  //检索数据
            {
                sql.Append("select Id,Name,Description,Created_Date from BigDog_Admin_Role");
                DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
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
                    json.Append("]");
                }
            }
            if (type == "add")
            {
                string name = context.Request.Params["name"].ToString();
                string desc = context.Request.Params["desc"].ToString();
                sql.Clear();
                sql.Append("insert into BigDog_Admin_Role(name,description)values(@name,@desc)");
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
                    json.Append("\"result\":\"1\",\"data\":\"\"");
                    json.Append("]");
                }
                else
                {
                    json.Append("[");
                    json.Append("\"result\":\"0\",\"data\":\"\"");
                    json.Append("]");

                }
            }
           
            if (type == "update")
            {
                string name = context.Request.Params["name"].ToString();
                string desc = context.Request.Params["desc"].ToString();
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