using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BigDogShop.Common
{
    /// <summary>
    /// Request class
    /// </summary>
    public class Requests
    {
        public static string GetIP()
        {
            string IPstr = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            if (string.IsNullOrEmpty(IPstr))
            {
                IPstr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            if (string.IsNullOrEmpty(IPstr))
            {
                IPstr = HttpContext.Current.Request.UserHostAddress;
            }
            if (string.IsNullOrEmpty(IPstr)|!Utils.IsIp(IPstr))
                return "127.0.0.1";
            return IPstr;
        }
    }
}
