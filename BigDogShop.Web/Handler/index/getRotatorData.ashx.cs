using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using BigDogShop.BLL;
using BigDogShop.DBUtility;

namespace BigDogShop.Web.Handler.index
{
    /// <summary>
    /// Summary description for getRotatorData
    /// </summary>
    public class getRotatorData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            StringBuilder html = new StringBuilder();
            DataTable dt = new DataTable();
            html.Append("[{\"value:\"");
            dt = NewsBLL.GetNewsList(1);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   
                }
            }


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