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
    /// Summary description for Right
    /// </summary>
    public class Right : IHttpHandler
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
                    string a_id = DateTime.Now.ToShortDateString();
                    string a_role_id = context.Request.Params["role_id"].ToString();
                    string a_right_id = context.Request.Params["right_id"].ToString();
                    string a_desc = context.Request.Params["desc"].ToString();
                    json = Add(a_id,a_role_id, a_right_id, a_desc);
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
                    string _id = context.Request["Id"].ToString();
                    string _right_id = context.Request["Right_Id"].ToString();
                    string _role_id = context.Request["Role_Id"].ToString();
                    string _desc = context.Request["desc"].ToString();
                    json = Update(_id, _right_id, _role_id,_desc);
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
            DataTable dt = RightBLL.GetList(name);
            if (dt.Rows.Count > 0)
            {
                json.Append("[");
                foreach (DataRow dr in dt.Rows)
                {
                    json.Append("{\"Id\":\"" + dr["Id"].ToString() + "\"");
                    json.Append(",\"Name\":\"" + dr["Right_Id"].ToString() + "\"");
                    json.Append(",\"Description\":\"" + dr["Role_Id"].ToString() + "\"");
                    json.Append(",\"Created_Date\":\"" + dr["Description"].ToString() + "\"");
                    json.Append(",\"Created_Date\":\"" + dr["Created_Date"].ToString() + "\"");
                    json.Append("},");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("]");
            }
            return json.ToString();
        }

        public static string Add(string id,string right_id,string role_id, string desc)
        {
            RightInfo model = new RightInfo();
            model.Id = id;
            model.Right_Id = right_id;
            model.Role_Id = role_id;
            model.Description = desc;
            bool successs = RightBLL.Add(model);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"success\":\"" + successs + "\"");
            json.Append("}]");
            return json.ToString();
        }
        public static string Delete(string ids)
        {
            bool successs = RightBLL.Delete(ids);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"success\":\"" + successs + "\"");
            json.Append("}]");
            return json.ToString();
        }
        public static string Update(string u_id, string u_right_id, string u_role_id,string u_desc)
        {
            RightInfo model = new RightInfo();
            model.Id = u_id;
            model.Right_Id = u_right_id;
            model.Role_Id = u_role_id;
            model.Description = u_desc;
            bool success = RightBLL.Update(model);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"success\":\"" + success + "\"");
            json.Append("}]");
            return json.ToString();
        }
        public static string GetById(string id)
        {
            RightInfo model = RightBLL.GetById(id);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"Id\":\"" + model.Id + "\"");
            json.Append("\"Role_Id\":\"" + model.Role_Id + "\"");
            json.Append("\"Right_Id\":\"" + model.Right_Id + "\"");
            json.Append("\"Description\":\"" + model.Description + "\"");
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