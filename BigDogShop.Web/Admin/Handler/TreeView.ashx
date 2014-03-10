<%@ WebHandler Language="C#" Class="TreeHandler" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Configuration;
using BigDogShop.DBUtility;


public class TreeHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        string id = context.Request.Params["id"];
        string type = context.Request.Params["type"];

        StringBuilder sql = new StringBuilder();
        string DB_Type = ConfigurationManager.AppSettings["FactoryType"].ToString();
        DataTable dt = new DataTable();
        if (DB_Type == "SQLServer")
        {
            sql.Append("select a.Id,a.Menu_Name,a.Father_Id,a.Nav_Url,");
            sql.Append("(select (case count(1) when '0' then 'false' else 'true' end) from BigDog_Admin_Menu b where a.Id=b.Father_Id)  Has_Children ");
            sql.Append(" from BigDog_Admin_Menu a where a.Father_Id='" + id + "'");
            var a = sql.ToString();
            dt = SQLHelper.GetDs(sql.ToString()).Tables[0];
        }
        else
        {
            sql.Append("select a.Menu_Id,a.Menu_Name,a.Menu_Father_Id,a.Nav_Url,");
            sql.Append("(select  decode(count(1),0,'true','false' ) from BigDog_Admin_Menu where Menu_Father_Id='" + id + "') Has_Children");
            sql.Append(" from BigDog_Admin_Menu a where a.Menu_Father_Id='" + id + "'");
            dt = OracleHelper.GetDS(sql.ToString()).Tables[0];
        }

        switch (type)
        {
            case "a"://获取树节点
                context.Response.Write(getJsonMenu(dt));
                break;

            default:
                break;
        }

    }

    public string getJsonMenu(DataTable dt)
    {
        StringBuilder html = new StringBuilder();
        if (dt.Rows.Count > 0)
        {
            html.Append("[");
            int count = 1;
            foreach (DataRow dr in dt.Rows)
            {
                if (count != dt.Rows.Count)
                {
                    html.Append("{\"Menu_Name\":\"" + dr["Menu_Name"].ToString() + "\",\"Menu_Id\":\"" + dr["Id"] + "\",\"Nav_Url\":\"" + dr["Nav_Url"] + "\",\"Has_Children\":\"" + dr["Has_Children"] + "\"},");
                    count++;
                }
                else
                {
                    html.Append("{\"Menu_Name\":\"" + dr["Menu_Name"].ToString() + "\",\"Menu_Id\":\"" + dr["Id"] + "\",\"Nav_Url\":\"" + dr["Nav_Url"] + "\",\"Has_Children\":\"" + dr["Has_Children"] + "\"}");
                }

            }
            html.Append("]");
        }
        else
        {
            html = null;
        }
        return html.ToString();
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}