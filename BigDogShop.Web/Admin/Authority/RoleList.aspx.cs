using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using BigDogShop.BLL;
using BigDogShop.Model;
using BigDogShop.Web.Base;

namespace BigDogShop.Web.Admin.Authority
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
               
            }
        }

        //[WebMethod]
        //public static bool  Add(string name,string desc,string id)
        //{
        //    RoleInfo role = new RoleInfo();
        //    role.Name = name;
        //    role.Description = desc;
        //    role.Id = id;
        //    return RoleBLL.Add(role);
        //}

        //[WebMethod]
        //public static string Delete(string id)
        //{
        //    return RoleBLL.Delete(id);
        //}

        //[WebMethod]
        //public static bool Update(string id,string name,string desc)
        //{
        //    RoleInfo role = new RoleInfo();
        //    role.Name = name;
        //    role.Description = desc;
        //    role.Id = id;
        //    return RoleBLL.Update(role);
        //}

        //[WebMethod]
        //public static string GetById(string id)
        //{
            
        //    return RoleBLL.GetById(id);
        //}

        //[WebMethod]
        //public static string GetList()
        //{
        //    return RoleBLL.GetList();
        //}

        //[WebMethod]
        //public static string GetListByName(string name)
        //{
        //    return RoleBLL.GetListByName(name);
        //}
    }
}