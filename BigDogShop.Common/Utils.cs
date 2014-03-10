using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BigDogShop.Common
{
    public class Utils
    {

        /// <summary>
        /// 返回随机字符串
        /// </summary>
        /// <param name="n">字符总数</param>
        /// <returns></returns>
        public static string GetRandomStr(int n)
        {
            Random rd = new Random();
            string str = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string resultStr = string.Empty;
            for (int i = 0; i < n; i++)
            {
                resultStr += str.Substring(rd.Next(0, str.Length - 1), 1);
            }
            return resultStr;
        }

        /// <summary>
        /// 删除字符最后一个逗号
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string DelLastComma(string str)
        {
            return str.Substring(0,str.LastIndexOf(","));
        }
        /// <summary>
        /// 生成日期编码
        /// </summary>
        /// <returns></returns>
        public static string GetRandomDataCode()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }

        /// <summary>
        /// 单值cookies添加
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写入cookie
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="expires">过期时间(单位:分钟)</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = UrlEncode(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 对对应位置值进行设置
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="key">键名</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 写入cookies
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="key">键名</param>
        /// <param name="strValue">值</param>
        /// <param name="expires">过期时间(单位:分钟)</param>
        public static void WriteCookie(string strName, string key, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = strValue;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读取cookie
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            {
                return HttpContext.Current.Request.Cookies[strName].Value.ToString();
            }
            return "";
        }
        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public static string GetCookie(string strName, string key)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null && HttpContext.Current.Request.Cookies[strName][key] != null)
            {
                return UrlDecode(HttpContext.Current.Request.Cookies[strName][key].ToString());
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 对url字符串进行编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlEncode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            else
            {
                str = str.Replace("'", "");
                return HttpContext.Current.Server.UrlEncode(str);
            }
        }

        /// <summary>
        /// 对url字符串进行解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UrlDecode(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "";
            }
            return HttpContext.Current.Server.UrlDecode(str);
        }
    }
}
