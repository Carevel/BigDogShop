<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Web.SessionState;
using System.Drawing;
using System.Drawing.Imaging;

using BigDogShop.DBUtility;

public class Upload : IHttpHandler,IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        //context.Response.ContentType = "text/plain";
        HttpPostedFile file = context.Request.Files[0];
        string allowFileExt = ".jpg|.png|.gif|.bmp";
        string path = context.Server.MapPath("~/UploadImage/User/");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        
        string filename = file.FileName;
        string user_id = HttpContext.Current.Session["user_id"].ToString();
        string fileExt = System.IO.Path.GetExtension(filename);
        StringBuilder msg = new StringBuilder();
        if (checkFileExt(allowFileExt, fileExt))
        {
            string newFileName = user_id + fileExt;
            filename = Path.Combine(path, newFileName);
            //file.SaveAs(filename);
            
            string Thumbnail_s = context.Server.MapPath("~/UploadImage/User/"+newFileName+"");
            //string Thumbnail_s2 = context.Server.MapPath("~/UploadImage/User/User_s/" + newFileName + "") ;
            MakeThumbnail(file, Thumbnail_s, 150, 150, "HW");//
            string sql2 = "update zyz_users set user_photo_url='" + newFileName + "' where user_id='" + user_id + "'";
            int i = OracleHelper.ExeSQL(sql2);

            
            if (i > 0)
            {

                msg.Append("{");
                msg.Append("\"filePath\":\"" + newFileName + "\",\"status\":\"1\"");
                msg.Append("}");
            }
            else
            {
                msg.Append("{");
                msg.Append("\"filePath\":\"" + newFileName + "\",\"status\":\"0\"");
                msg.Append("}");
            }
        }
        
        context.Response.Write(msg.ToString());
    }

    /// 〈summary> 
    /// 生成缩略图 
    /// 〈/summary> 
    /// 〈param name="originalImagePath">源图路径（物理路径）〈/param> 
    /// 〈param name="thumbnailPath">缩略图路径（物理路径）〈/param> 
    /// 〈param name="width">缩略图宽度〈/param> 
    /// 〈param name="height">缩略图高度〈/param> 
    /// 〈param name="mode">生成缩略图的方式〈/param>     
    public static void MakeThumbnail(HttpPostedFile file, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage =System.Drawing.Image.FromStream(file.InputStream);


        int towidth = width;
        int toheight = height;
        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;
        switch (mode)
        {
            case "HW": //指定高宽缩放（可能变形）                 
                break;
            case "W": //指定宽，高按比例                     
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H": //指定高，宽按比例 
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut": //指定高宽裁减（不变形）                 
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }
        //新建一个bmp图片 
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板 
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
        //设置高质量插值法 
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //设置高质量,低速度呈现平滑程度 
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        
        //清空画布并以透明背景色填充 
        g.Clear(System.Drawing.Color.Transparent);
        
        //在指定位置并且按指定大小绘制原图片的指定部分 
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
             new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);
        try
        {
            //以jpg格式保存缩略图 
            bitmap.Save(thumbnailPath, ImageFormat.Jpeg);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }
    public bool checkFileExt(string allowFileExt, string fileExt)
    {
        string[] allowExt = allowFileExt.Split('|');
        for (int i = 0; i < allowExt.Length; i++)
        {
            if (fileExt == allowExt[i])
            {
                return true;
            }
        }
        return false;
    }
    

    public static void ImageResize(string sourcePath, string savePath, int w, int h)
    {
        System.Drawing.Image _sourceImg = System.Drawing.Image.FromFile(sourcePath);
        double _newW = (double)w, _newH = (double)h, t;
        if ((double)_sourceImg.Width > w)
        {
            t = (double)w;
        }
        else
        {
            t = (double)_sourceImg.Width;
        }

        if ((double)_sourceImg.Height * (double)t / (double)_sourceImg.Width > (double)h)
        {
            _newH = (double)h;
            _newW = (double)h / (double)_sourceImg.Height * (double)_sourceImg.Width;
        }
        else
        {
            _newW = t;
            _newH = (t / (double)_sourceImg.Width) * (double)_sourceImg.Height;
        }
        System.Drawing.Image bitmap = new System.Drawing.Bitmap((int)_newW, (int)_newH);
        Graphics g = Graphics.FromImage(bitmap);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        g.Clear(Color.Transparent);
        g.DrawImage(_sourceImg, new Rectangle(0, 0, (int)_newW, (int)_newH), new Rectangle(0, 0, _sourceImg.Width, _sourceImg.Height), GraphicsUnit.Pixel);
        _sourceImg.Dispose();
        g.Dispose();
        try
        {
            bitmap.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch
        {
        }

        bitmap.Dispose();
    }

    

    public bool IsReusable {
        get {
            return false;
        }
    }

}