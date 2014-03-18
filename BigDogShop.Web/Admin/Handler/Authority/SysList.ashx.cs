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
    /// Summary description for SysList
    /// </summary>
    public class SysList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string name = context.Request.Params["Name"] != null ? context.Request.Params["Name"] : "";
            StringBuilder sql = new StringBuilder();
            StringBuilder json = new StringBuilder();
            sql.Append("select Id,User_Name,Real_Name,User_Photo_Url,E_Mail,Is_Lock,Created_Date from BigDog_Admin where 1=1 ");
            if (name != "")
            {
                sql.Append(" and User_Name like '%" + name + "%' ");
            }
            DataTable dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                json.Append("[");
                foreach (DataRow dr in dt.Rows)
                {
                    json.Append("{\"Id\":\"" + dr["Id"].ToString() + "\"");
                    json.Append(",\"Name\":\"" + dr["User_Name"].ToString() + "\"");
                    json.Append(",\"Real_Name\":\"" + dr["Real_Name"].ToString() + "\"");
                    json.Append(",\"User_Photo_Url\":\"" + dr["User_Photo_Url"].ToString() + "\"");
                    json.Append(",\"E_Mail\":\"" + dr["E_Mail"].ToString() + "\"");
                    json.Append(",\"Is_Lock\":\"" + dr["Is_Lock"].ToString() + "\"");
                    json.Append("},");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("]");
            }
            context.Response.Write(json.ToString());
        }
        public static string str()
        {
            string json = "a";
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