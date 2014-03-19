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

            string type = context.Request.Params["type"] != null ? context.Request.Params["type"].ToString() : "GetList";
            StringBuilder sql = new StringBuilder();
            string json = "";
            switch (type)
            {
                case "GetList":
                    string name="";
                    try
                    { name = context.Request.Params["Name"] != null ? context.Request.Params["Name"] : ""; }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    
                    json = GetList(name);
                    break;
                case "Add":
                    string user_name = context.Request["user_name"].ToString();
                    string password = context.Request["password"].ToString();
                    string e_mail = context.Request["e_mail"].ToString();
                    json = Add(user_name, password, e_mail);
                    break;
                case "Delete":
                    string ids="";
                    try
                    {
                        ids = context.Request.Params["ids"].ToString();
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    json = Delete(ids);
                    break;
                case "Update":
                    string id = context.Request.Params["id"].ToString();
                    string u_user_name = context.Request.Params["user_name"].ToString();
                    string u_password = context.Request.Params["password"].ToString();
                    string u_is_lock = context.Request.Params["is_lock"].ToString();
                    string u_e_mail = context.Request.Params["e_mail"].ToString();
                    json = Update(id, u_user_name, u_password, u_e_mail, u_is_lock);
                    break;
                case "Edit":
                    string id1 = context.Request.Params["id"].ToString();
                    json = GetById(id1);
                    break;
                default:
                    break;
            }
            context.Response.Write(json.ToString());
        }
        public static string GetList(string name = "")
        {
            StringBuilder json = new StringBuilder();
            StringBuilder sql = new StringBuilder();
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
                    json.Append(",\"User_Name\":\"" + dr["User_Name"].ToString() + "\"");
                    json.Append(",\"User_Photo_Url\":\"" + dr["User_Photo_Url"].ToString() + "\"");
                    json.Append(",\"E_Mail\":\"" + dr["E_Mail"].ToString() + "\"");
                    json.Append(",\"Is_Lock\":\"" + dr["Is_Lock"].ToString() + "\"");
                    json.Append("},");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("]");
            }
            return json.ToString();
        }

        public static string Add(string user_name, string password, string e_mail)
        {
            AdminInfo admin = new AdminInfo();
            admin.User_Name = user_name;
            admin.Password = password;
            admin.E_Mail = e_mail;
            bool successs = AdminBLL.Add(admin);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"success\":\"" + successs + "\"");
            json.Append("}]");
            return json.ToString();
        }
        public static string Delete(string ids)
        {
            bool successs = AdminBLL.Delete(ids);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"success\":\"" + successs + "\"");
            json.Append("}]");
            return json.ToString();
        }
        public static string Update(string id, string user_name,  string password,
            string e_mail, string is_lock)
        {
            AdminInfo admin = new AdminInfo();

            admin.User_Name = user_name;
            admin.Password = password;
            admin.Is_Lock = is_lock;
            admin.Id = Convert.ToInt32(id);
            bool success = AdminBLL.Update(admin);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"success\":\"" + success + "\"");
            json.Append("}]");
            return json.ToString();
        }
        public static string GetById(string id)
        {

            AdminInfo admin = AdminBLL.GetById(Convert.ToInt32(id));

            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"Id\":\"" + admin.Id + "\"");
            json.Append("\"User_Name\":\"" + admin.User_Name + "\"");
            json.Append("\"Real_Name\":\"" + admin.Real_Name + "\"");
            json.Append("\"User_Photo_Url\":\"" + admin.User_Photo_Url + "\"");
            json.Append("\"E_Mail\":\"" + admin.E_Mail + "\"");
            json.Append("}]");

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