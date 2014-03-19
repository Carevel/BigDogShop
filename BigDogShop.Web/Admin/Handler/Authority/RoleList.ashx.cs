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
    public class RoleList : IHttpHandler
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
                    string name = "";
                     name = context.Request.Params["Name"] != null ? context.Request.Params["Name"] : ""; 
                    json = GetList(name);
                    break;
                case "Add":
                    string a_id = context.Request.Params["id"].ToString();
                    string name1 = context.Request.Params["name"].ToString();
                    string desc = context.Request.Params["desc"].ToString();
                    json = Add(a_id, name1, desc);
                    break;
                case "Delete":
                    string ids = "";
                    try
                    {
                        ids = context.Request.Params["ids"].ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    json = Delete(ids);
                    break;
                case "Update":
                    string _id = context.Request["id"].ToString();
                    string u_name = context.Request["name"].ToString();
                    string u_desc = context.Request["desc"].ToString();
                    json = Update(_id, u_name, u_desc);
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
            DataTable dt = OperateBLL.GetList(name);            
            if (dt.Rows.Count > 0)
            {
                json.Append("[");
                foreach (DataRow dr in dt.Rows)
                {
                    json.Append("{\"Id\":\"" + dr["Id"].ToString() + "\"");
                    json.Append(",\"User_Name\":\"" + dr["User_Name"].ToString() + "\"");
                    json.Append(",\"Real_Name\":\"" + dr["Real_Name"].ToString() + "\"");
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

        public static string Add(string id, string name,string desc)
        {
            RoleInfo model = new RoleInfo();
            model.Id = id;
            model.Name = name;
            model.Description = desc;
            bool successs = RoleBLL.Add(model);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"success\":\"" + successs + "\"");
            json.Append("}]");
            return json.ToString();
        }
        public static string Delete(string ids)
        {
            bool successs = RoleBLL.Delete(ids);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"success\":\"" + successs + "\"");
            json.Append("}]");
            return json.ToString();
        }
        public static string Update(string u_id,string u_name,string u_desc)
        {
            RoleInfo model = new RoleInfo();
            model.Id = u_id;
            model.Name = u_name;
            model.Description = u_desc;
            bool success = RoleBLL.Update(model);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"success\":\"" + success + "\"");
            json.Append("}]");
            return json.ToString();
        }
        public static string GetById(string id)
        {
            RoleInfo model = RoleBLL.GetById(id);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"Id\":\"" + model.Id + "\"");
            json.Append("\"User_Name\":\"" + model.Name + "\"");
            json.Append("\"Real_Name\":\"" + model.Description + "\"");
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