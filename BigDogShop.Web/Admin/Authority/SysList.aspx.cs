using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;
using BigDogShop.Model;
using BigDogShop.Web.Base;
using BigDogShop.BLL;

namespace BigDogShop.Web.Admin.Authority
{
    public partial class SysList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetList(string usernames= "")
        {
            DataTable dt = AdminBLL.GetList(usernames);
            StringBuilder json = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                json.Append("[{");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    json.Append("\"User_Name\":\"" + dt.Rows[0]["User_Name"].ToString() + "\"");
                    json.Append("\"Real_Name\":\"" + dt.Rows[0]["Real_Name"].ToString() + "\"");
                    json.Append("\"User_Photo_Url\":\"" + dt.Rows[0]["User_Photo_Url"].ToString() + "\"");
                    json.Append("\"E_Mail\":\"" + dt.Rows[0]["E_Mail"].ToString() + "\"");
                    json.Append("\"Is_Lock\":\"" + dt.Rows[0]["Is_Lock"].ToString() + "\"");
                }
                json.Append("}]");
                HttpContext.Current.Response.ContentType = "application/json;charset=utf-8";
                HttpContext.Current.Response.Write(json.ToString());
            }
            return null;
        }

        [WebMethod]
        public static string Add(string user_name, string real_name, string password, string e_mail)
        {
            AdminInfo admin = new AdminInfo();
            admin.User_Name = user_name;
            admin.Real_Name = real_name;
            admin.Password = password;
            admin.E_Mail = e_mail;
            bool successs = AdminBLL.Add(admin);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"success\":\"" + successs + "\"");
            json.Append("}]");
            return json.ToString();
        }

        [WebMethod]
        public static string Delete(string usernames)
        {
            bool successs = AdminBLL.Delete(usernames);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"success\":\"" + successs + "\"");
            json.Append("}]");
            return json.ToString();
        }

        [WebMethod]
        public static string Update(string id, string user_name, string real_name, string password,
            string user_photo_url, string e_mail, string is_lock)
        {
            AdminInfo admin = new AdminInfo();

            admin.User_Name = user_name;
            admin.Real_Name = real_name;
            admin.Password = password;
            admin.User_Photo_Url = user_photo_url;
            admin.Is_Lock = is_lock;
            admin.Id = Convert.ToInt32(id);
            bool success = AdminBLL.Update(admin);
            StringBuilder json = new StringBuilder();
            json.Append("[{");
            json.Append("\"success\":\"" + success + "\"");
            json.Append("}]");
            return json.ToString();
        }

        [WebMethod]
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


    }
}