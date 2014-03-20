using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigDogShop.Web.Admin.Handler.Authority
{
    /// <summary>
    /// Summary description for ModuleList
    /// </summary>
    public class ModuleList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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