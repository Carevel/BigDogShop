using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data;
using System.Security.Authentication;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using BigDogShop.DBUtility;
using Wuqi.Webdiyer;

namespace Common
{
    public class Function
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
        /// md5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string str)
        {
            string result = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            for (int i = 0; i < s.Length; i++)
            {
                result = result + s[i].ToString("X");
            }
            return result;
        }

        /// <summary>
        /// 过滤字符串
        /// </summary>
        /// <param name="str"></param>
        public void Filter(string str)
        {

        }

        public static string EncryptEmail(string str)
        {
            int n = str.IndexOf("@");
            string ss = "";
            string t = "*";
            for (int i = n - 2; i >= 2; i--)
            {
                //str.Replace(str[i], '*');
                ss = str[i] + ss;
                t += "*";
            }
            string aa = str.Replace(ss, t);
            return aa;
        }

        /// <summary>
        /// 针对Repeater控件,初始化分页控件
        /// </summary>
        //public static void InitPageData(string sql, string tablename, string whereString, string orderString, int pageSize, int pageIndex, AspNetPager aspnetpage1, Repeater rpt1)
        //{
        //    DataTable dt = OracleHelper.GetDS(sql.ToString()).Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
               
        //        aspnetpage1.RecordCount = dt.Rows.Count;
        //    }
        //    else
        //    {
                
        //        aspnetpage1.RecordCount = 0;
        //    }
        //    GetPageDate(tablename, whereString, orderString, pageSize, pageIndex, aspnetpage1,rpt1);
        //}
        public static DataTable InitPageData(string sql, int pageSize, int pageIndex, AspNetPager aspnetpage1, Repeater rpt1)
        {
            DataTable dt = OracleHelper.GetDS(sql.ToString()).Tables[0];
            if (dt.Rows.Count > 0)
            {
                aspnetpage1.RecordCount = dt.Rows.Count;
            }
            else
            {
                aspnetpage1.RecordCount = 0;
            }
           return GetPageDate(sql, pageSize, pageIndex, aspnetpage1);
        }
        /// <summary>
        /// 针对GridView 控件,初始化分页控件
        /// </summary>
        /// <param name="pagesize"></param>s
        /// <param name="pageIndex"></param>
        /// <param name="tablename"></param>
        /// <param name="orderstring"></param>
        /// <param name="aspnetpage1"></param>
        /// <param name="gridview1"></param>
        //public static void InitPageData(int pagesize, int pageIndex, string tablename, string whereString, string orderstring, AspNetPager aspnetpage1, GridView gridview1)
        //{
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("select count(1) from " + tablename + "");
        //    DataTable dt = OracleHelper.GetDS(sql.ToString()).Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        gridview1.DataSource = dt;
        //        gridview1.DataBind();
        //        aspnetpage1.RecordCount = dt.Rows.Count;
        //    }
        //    else
        //    {
        //        gridview1.Visible = false;
        //        aspnetpage1.RecordCount = 0;
        //    }
        //    GetPageDate(tablename, whereString, orderstring, pagesize, pageIndex, aspnetpage1, gridview1);
        //}

        /// <summary>
        /// 分布数据
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="orderString"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="aspnetpage1"></param>
        /// <returns></returns>
        //public static void GetPageDate(string tableName, string whereString, string orderString, int pageSize, int pageIndex, AspNetPager aspnetpage1,Repeater rpt1)
        //{
        //    DataTable dt = new DataTable();
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("select * from (select rownum rn,a.* from " + tableName + " where " + whereString + " order by " + orderString + "  )");
        //    sql.Append(" where rn>'" + aspnetpage1.CurrentPageIndex * (pageSize - 1) + "' and rn<='" + aspnetpage1.CurrentPageIndex * pageSize + "'");
        //    dt = OracleHelper.GetDS(sql.ToString()).Tables[0];
        //    rpt1.DataSource = dt;
        //    rpt1.DataBind();
        //    //return dt;
        //}

        //public static void GetPageDate(string tableName, string whereString, string orderString, int pageSize, int pageIndex, AspNetPager aspnetpage1, GridView gridview1)
        //{
        //    DataTable dt = new DataTable();
        //    StringBuilder sql = new StringBuilder();
        //    sql.Append("select * from (select rownum rn,a.* from " + tableName + " where " + whereString + " order by " + orderString + "  )");
        //    sql.Append(" where rn>'" + aspnetpage1.CurrentPageIndex * (pageSize - 1) + "' and rn<='" + aspnetpage1.CurrentPageIndex * pageSize + "'");
        //    dt = OracleHelper.GetDS(sql.ToString()).Tables[0];
        //    gridview1.DataSource = dt;
        //    gridview1.DataBind();
        //    //return dt;
        //}


        public static DataTable GetPageDate(string sql, int pageSize, int pageIndex, AspNetPager aspnetpage1)
        {
            DataTable dt = new DataTable();
            StringBuilder sql2 = new StringBuilder();
            sql2.Append("select * from (select rownum rn,a.* from ("+sql+") a)");
            sql2.Append(" where rn>'" + aspnetpage1.CurrentPageIndex * (pageSize - 1) + "' and rn<='" + aspnetpage1.CurrentPageIndex * pageSize + "'");
            dt = OracleHelper.GetDS(sql2.ToString()).Tables[0];
            return dt;
            //rpt1.DataSource = dt;
            //rpt1.DataBind();
            //return dt;
        }
    }
}