<%@ WebHandler Language="C#" Class="GetEmailCode" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Common;

public class GetEmailCode : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        string code = SendMail.SendEmail();
        //string result="{[ode+":"+code+"]}";
        StringBuilder result = new StringBuilder();
        result.Append("[{");
        result.Append("\"code\":\"" + code + "\"");
        result.Append("}]");
        context.Response.Write(result.ToString());
    }
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}