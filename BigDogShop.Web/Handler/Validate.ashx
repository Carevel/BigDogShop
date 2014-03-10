<%@ WebHandler Language="C#" Class="Validate" %>

using System;
using System.Web;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web.SessionState;
using BigDogShop.Common;

public class Validate : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/gif";
        int fontSize = 16;
        Bitmap basemap = new Bitmap(60, 25);
        Random rd = new Random();
        Graphics g = Graphics.FromImage(basemap);
        //颜色列表，用于验证码、噪线、噪点 
        Color[] color = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Purple, Color.Brown, Color.DarkBlue, Color.DarkRed };
        //字体列表，用于验证码 

        string[] font = { "Times New Roman", "Verdana", "Arial", "Gungsuh", "Impact", "Bradley Hand (TC", "Forte", "Tempus Sans ITC" };

        g.FillRectangle(new SolidBrush(Color.White), 0, 0, 60, 25);
        //Font font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold, GraphicsUnit.Pixel);

        string strs = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string str = string.Empty;
        StringBuilder s = new StringBuilder();
        //随机添加5个字母
        for (int i = 0; i < 4; i++)
        {
            Color clr = color[rd.Next(color.Length)];
            string fnt = font[rd.Next(font.Length)];
            Font ft = new Font(fnt, fontSize);
            //str = strs.Substring(rd.Next(0, strs.Length - 1), 1);
            str = strs[rd.Next(0, strs.Length - 1)].ToString();
            s.Append(str);
            g.DrawString(str, ft, new SolidBrush(clr), i * 14, rd.Next(0, 3));

        }

        //for (int i = 0; i <3; i++)
        //{
        //    Color clr = color[rd.Next(color.Length)];
        //    int x1 = rd.Next(basemap.Width);
        //    int x2 = rd.Next(basemap.Width);
        //    int y1 = rd.Next(basemap.Height);
        //    int y2 = rd.Next(basemap.Height);
        //    g.DrawLine(new Pen(clr), x1, y1, x2, y2);
        //}
        context.Session[Keys.SESSION_CODE] = s.ToString();

        //噪点
        for (int i = 0; i < 50; i++)
        {
            int x = rd.Next(basemap.Width);
            int y = rd.Next(basemap.Height);
            basemap.SetPixel(x, y, Color.FromArgb(rd.Next()));
        }
        //混淆背景
        Pen linpen = new Pen(new SolidBrush(Color.Black), 2);
        //for (int x = 0; x < 6; x++)
        //{
        //g.DrawLine(linpen, new Point(rd.Next(0, 50), rd.Next(0, 15)), new Point(rd.Next(0, 59), rd.Next(0,12)));
        //将图片保存在输出流中
        basemap.Save(context.Response.OutputStream, ImageFormat.Gif);
        context.Session["CheckCode"] = s.ToString();
        context.Response.End();
        //} 
    }
 
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}