using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text;
using System.Configuration;
using BigDogShop.DBUtility;

namespace BigDogShop.Web.Handler
{
    /// <summary>
    /// Summary description for GetGlobalLeftMenuData
    /// </summary>
    public class GetGlobalLeftMenuData : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            string type_id = context.Request.Params["type_id"].ToString();
            StringBuilder html = new StringBuilder();
            html.Append("[{ \"value\":\"");
            StringBuilder sql = new StringBuilder();
            string dbtype = ConfigurationManager.AppSettings["FactoryType"].ToString();
            if (dbtype == "SQLServer")
            {
                sql.Append("select a.Type_Id,a.Id,a.Father_Id,a.Category_Name,b.Id bId,b.Father_Id bFather_Id,b.Category_Name bCategory_Name,b.cId,b.cFather_Id,b.cCategory_Name from BigDog_Category a ");
                sql.Append("left join(");
                sql.Append("select b.Id,b.Father_Id,b.Category_Name,c.Id cId,c.Father_Id cFather_id,c.Category_Name cCategory_Name from BigDog_Category b left join (select Id,Father_Id,Category_Name from BigDog_Category ) c on b.Id=c.Father_Id ");
                sql.Append(") b  on a.id=b.Father_Id ");
                sql.Append("where a.Type_Id=@Type_Id and datalength(b.cFather_Id)!=0 order by a.Id");
                //sql.Append("select a.Id,b.Id CId, b.Category_Name,a.Category_name,b.Type_Id,a.Father_Id,a.Link_Url,a.Description from BigDog_Category a,");
                //sql.Append("BigDog_Category b where a.father_id=b.Id  and b.Type_Id=@Type_Id order by  b.Category_Name  ");
                SqlParameter[] parms = new SqlParameter[] { 
                    new SqlParameter("@Type_Id",SqlDbType.Int)
                };
                parms[0].Value = type_id;
                DataTable dt = new DataTable();
                try
                {
                    dt = SQLHelper.GetDs(sql.ToString(), parms).Tables[0];
                    DataTable dtv = dt.DefaultView.ToTable(true, new string[] { "bId", "bCategory_Name" });
                    if (dtv.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtv.Rows.Count; i++)
                        {
                            html.Append("<div class='sort_list'>");
                            html.Append("<dl class='clearfix'><dt>" + dtv.Rows[i][1].ToString() + "</dt>");
                            DataRow[] dr = dt.Select("bId='" + dtv.Rows[i][0] + "'");
                            for (int n = 0; n < dr.Length; n++)
                            {
                                if (n != dr.Length)
                                {
                                    html.Append("<dd><a id='" + dr[n].ItemArray[7].ToString() + "' href='#' target='_blank'>" + dr[n].ItemArray[9].ToString() + "</a>|</dd>");
                                }
                                else
                                {
                                    html.Append("<dd><a id='" + dr[n].ItemArray[7].ToString() + "' href='#' target='_blank'>" + dr[n].ItemArray[9].ToString() + "</a></dd>");
                                }
                            }
                            html.Append("</dt></dl>");
                            html.Append("</div>");
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                //这里根据dt拼出json格式html数据
                html.Append("\"}]");

            }
            else if (dbtype == "Oracle")
            {
                sql.Append("select a.Id,b.Id, b.Category_Name,a.Category_name,a.Type_Id,a.Father_Id,a.Link_Url,a.Description from BigDog_Category a,");
                sql.Append("BigDog_Category b where a.father_id=b.Id and Id=@Id ");
                OleDbParameter[] parms = new OleDbParameter[] {
                    new OleDbParameter(":Id",OleDbType.Integer)
                };
                DataTable dt = OracleHelper.GetDS(sql.ToString()).Tables[0];
            }
            context.Response.Write(html.ToString());
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