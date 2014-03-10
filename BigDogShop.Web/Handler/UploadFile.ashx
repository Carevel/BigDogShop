<%@ WebHandler Language="C#" Class="UploadFile" %>

using System;
using System.Web;
using System.IO;
using System.Text;
using System.Web.SessionState;
using System.Data;

public class UploadFile : IHttpHandler, IRequiresSessionState{
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "html/text";
        string allowFileExt = ".jpg|.png|.gif|.bmp";
        if (context.Request.Files.Count > 0)
        {
            string path = context.Server.MapPath("~/Upload/User/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                
                var file = context.Request.Files[0];
                string filename = file.FileName;   
                string newFileName=context.Session["user_id"].ToString();
                string fileExt = Path.GetExtension(filename).ToString();
                path = context.Server.MapPath(@path) + "\\" ;
                if (checkFileExt(allowFileExt, fileExt))
                {
                    file.SaveAs(path + newFileName + fileExt);
                    context.Response.Write( "{\"msg\":\"1\",\"value\":\"'" + path + "'\"}");
                }
                else
                {
                    context.Response.Write("{\"msg\":\"0\",\"value\":\"上传过程发生意外.\"}");
                }
                
            }
        }
    }

    public bool checkFileExt(string allowFileExt, string fileExt)
    {
        string[] allowExt = allowFileExt.Split('|');
        for (int i = 0; i < allowExt.Length; i++)
        {
            if (fileExt != allowExt[i])
            {
                return false;
            }   
        }
        return true;
    }
    
    public bool IsReusable
    {
        get {
            return false;
        }
    }

}