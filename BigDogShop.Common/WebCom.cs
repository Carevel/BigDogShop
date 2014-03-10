using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Xml;

/// <summary>
/// 表示Web上的通用方法,如顯示提示信息,獲取日期,錯誤日志維護等.
/// </summary>
public class WebCom
{

    //获取URL跳转的实际路径，解决多层目录的问题
    /// <summary>
    /// 获取URL跳转的实际路径，解决多层目录的问题
    /// </summary>
    /// <param name="targetURL"></param>
    /// <returns></returns>
    public static string GetTrueRedirect(string targetURL)
    {
        string trueURL = string.Empty;
        try
        {
            string reURL = targetURL;

            string ap = HttpContext.Current.Request.ApplicationPath;
            string newPath = HttpContext.Current.Request.Path;
            string pubPath = newPath.Replace(ap, string.Empty);
            string oldPath = pubPath.Replace("/", string.Empty);

            int length = pubPath.Length - oldPath.Length - 1;
            string serURL = string.Empty;
            string tempFolder = string.Empty;
            if (length > 0)
            {
                for (int m = 0; m < length; m++)
                {
                    tempFolder = "../" + tempFolder;
                }
                trueURL = tempFolder + reURL;
            }
            else
            {
                trueURL = reURL;
            }
        }
        catch (Exception ex)
        {
            trueURL = targetURL;
            ErrorTracking.LodError(ex);
        }
        return trueURL;
    }
    /// <summary>
    /// 过滤生成的HTML信息
    /// </summary>
    /// <param name="inputString"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public static string GetHTMLTagString(string inputString, string pattern)
    {
        //(\s)*表示0或多个空格符、回车符等，*表示比配0或多个。(.*?)表示除回车符外的所有信息
        string outputString = string.Empty;

        MatchCollection TitleMatchs = Regex.Matches(inputString, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
        //循环正则表达式所获取的，满足表达式的内容集合
        foreach (Match NextMatch in TitleMatchs)
        {
            outputString += NextMatch.Value;
        }

        outputString = Regex.Replace(outputString, @"<input type=""hidden"" name=""__VIEWSTATE""([\s|\S]*?)/>", @"", RegexOptions.IgnoreCase);
        outputString = Regex.Replace(outputString, @"<input type=""hidden"" name=""__EVENTVALIDATION""([\s|\S]*?)/>", @"", RegexOptions.IgnoreCase);
        outputString = Regex.Replace(outputString, @"<input type=""hidden"" name=""__VIEWSTATEENCRYPTED""([\s|\S]*?)/>", @"", RegexOptions.IgnoreCase);
        outputString = Regex.Replace(outputString, @"</form>", @"", RegexOptions.IgnoreCase);
        outputString = Regex.Replace(outputString, @"</FORM>", @"", RegexOptions.IgnoreCase);
        outputString = Regex.Replace(outputString, @"<form([\s|\S]*?)>([\s|\S]*?)</form>", @"$2", RegexOptions.IgnoreCase);
        outputString = Regex.Replace(outputString, @"<body([\s|\S]*?)>([\s|\S]*?)</body>", @"<body$1>$2</body>", RegexOptions.IgnoreCase);
        return outputString;
    }
    /// <summary>
    /// 判断文件上传的格式是否正确
    /// </summary>
    /// <param name="fileExt"></param>
    /// <param name="contentType"></param>
    /// <returns></returns>
    public static bool CheckfileFormat(string fileExt, string contentType)
    {
        string Extlist = ".TXT.DOC.PPTS.PPT.XLS.ZIP.7Z";
        if (Extlist.IndexOf(fileExt) == -1)
        {
            return false;
        }
        else
        {
            string conType = "text/plain application/msword application/vnd.openxmlformats-officedocument.presentationml.presentation application/vnd.ms-excel application/x-zip-compressed application/octet-stream";
            if (conType.IndexOf(contentType) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    /// <summary>
    /// 記錄系統處理過後的異常
    /// </summary>
    private static readonly string ErrPath = HttpContext.Current.Server.MapPath("Errlog/") + "BackError.txt";
    public static void SetDetailTableHead(string path, string cachename, GridViewRow gr)
    {
        if (File.Exists(path)) //如果存在，返回该文件夹所在的物理路径
        {
            gr.Cells.Clear();
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(path);
            if (XmlDoc.HasChildNodes)
            {
                XmlNode root = XmlDoc.DocumentElement;
                XmlNodeList xmlchild = root.SelectSingleNode("Table").ChildNodes;
                TableHeaderCell tc;
                if (xmlchild.Count > 0)
                {
                    foreach (XmlNode node in xmlchild)
                    {
                        tc = new TableHeaderCell();
                        tc.Text = node.InnerText;
                        gr.Cells.Add(tc);
                    }
                }
            }
        }
    }
    public WebCom()
    {

    }
    public static string DecodeHTML(string strHTML)
    {
        return HttpContext.Current.Server.UrlEncode(strHTML).Replace("+", "%20");
    }
    /// <summary>
    /// 找到對應XML節點名稱
    /// </summary>
    /// <param name="XMLName"></param>
    /// <param name="scriptList"></param>
    /// <returns></returns>
    public static string GetXMLRoot(string XMLName, string scriptList)
    {
        string vValue = string.Empty;
        if (File.Exists(XMLName))
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(XMLName);
            if (XmlDoc.HasChildNodes)
            {
                XmlNode root = XmlDoc.DocumentElement;
                root.SelectSingleNode(scriptList);
                XmlNode xmlcontext = root.SelectSingleNode("Script/" + scriptList);// root.SelectSingleNode("NoticeTip/Content/Item[@id='" + scriptList + "']");
                if (xmlcontext != null)
                {
                    vValue = xmlcontext.InnerText;
                }

            }
        }
        return vValue;
    }

    public static Dictionary<string, string> GetXMLRoot(string XMLName)
    {
        Dictionary<string, string> vValue = new Dictionary<string, string>();
        if (File.Exists(XMLName))
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(XMLName);
            if (XmlDoc.HasChildNodes)
            {
                XmlNode root = XmlDoc.DocumentElement;
                if (root.SelectSingleNode("Script") != null)
                {
                    XmlNodeList xmlchild = root.SelectSingleNode("Script").ChildNodes;

                    if (xmlchild.Count > 0)
                    {

                        foreach (XmlNode xn in xmlchild)
                        {
                            vValue.Add(xn.Name, xn.InnerText);

                        }
                    }

                }
            }
        }
        return vValue;
    }

    /// <summary>
    /// 找到對應XML節點名稱
    /// </summary>
    /// <param name="XMLName"></param>
    /// <param name="scriptList"></param>
    /// <returns></returns>
    public static Dictionary<string, string> GetXMLRoot(string XMLName, List<string> scriptList)
    {
        Dictionary<string, string> vValue = new Dictionary<string, string>();
        if (File.Exists(XMLName))
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(XMLName);
            if (XmlDoc.HasChildNodes)
            {
                XmlNode root = XmlDoc.DocumentElement;
                XmlNodeList xmlchild = root.SelectSingleNode("Script").ChildNodes;
                if (xmlchild.Count > 0)
                {

                    foreach (XmlNode xn in xmlchild)
                    {
                        foreach (string kvp in scriptList)
                        {
                            if (xn.Name == kvp)
                            {
                                vValue.Add(kvp, xn.InnerText);
                                break;
                            }
                        }
                    }
                }
            }
        }
        return vValue;
    }

    public static string[] GetHeaderList(string filePath, string Flag)
    {

        string[] HeaderList = new string[] { };
        if (File.Exists(filePath)) //如果存在，返回该文件夹所在的物理路径
        {
            XmlDocument XmlDoc = new XmlDocument();

            XmlDoc.Load(filePath);
            if (XmlDoc.HasChildNodes)
            {
                XmlNode root = XmlDoc.DocumentElement;
                XmlNodeList xmlchild = root.SelectSingleNode(Flag).ChildNodes;

                if (xmlchild.Count > 0)
                {
                    HeaderList = new string[xmlchild.Count];
                    int mk = 0;
                    foreach (XmlNode xn in xmlchild)
                    {
                        HeaderList[mk] = xn.InnerText;
                        mk++;
                    }
                }
            }
        }
        return HeaderList;
    }
    /// <summary>
    /// 注册静态脚本参数的值。已适应多语言的内容。
    /// </summary>
    /// <param name="orgPage"></param>
    /// <param name="varList"></param>
    public static void RegJavascriptVar(Page orgPage, Dictionary<string, string> varList)
    {
        Random random = new Random();
        Type csType = orgPage.GetType();
        string strKey = "__StaticINFO_" + random.Next(10000).ToString() + "()";
        string strScript = "<script language=\"javascript\">\n\r";
        strScript += "\r\n\t //<![CDATA[ \r\n\t";
        foreach (KeyValuePair<string, string> kvp in varList)
        {
            strScript += " var " + kvp.Key + "=\"" + kvp.Value + "\" ; \r\n\t ";
        }
        strScript += "\r\n\t";
        strScript += "\r\n\t //]]>";

        strScript += " \r\n\t</script>\n\r";
        orgPage.ClientScript.RegisterStartupScript(csType, strKey, strScript);
    }
    /// <summary>
    /// 顯示javascript的alert消息框,彈出消息框
    /// </summary>
    /// <param name="orgPage"></param>
    /// <param name="strMessage"></param>
    public static void ShowJsMessage(Page orgPage, string strMessage)
    {
        Random random = new Random();
        string strKey = "__ShowMessage" + random.Next(10000).ToString() + "()";
        if (orgPage.ClientScript.IsStartupScriptRegistered(strKey))
        {
            strKey = "__ShowMessage" + random.Next(10000).ToString() + "()";
        }
        string strScript = "<script language=\"JavaScript\">\n\r" +
            "  alert(\"" + strMessage.Replace("\r", "\\r").Replace("\n", "\\n")

            + "\")\n\r" + " </script>\n\r";
        Type csType = orgPage.GetType();
        orgPage.ClientScript.RegisterStartupScript(csType, strKey, strScript);
    }
    public static string RemoveHTML(string html)
    {
        html = Regex.Replace(html, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"-->", "", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"<!--.*", "", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"&#(\d+);", "", RegexOptions.IgnoreCase);
        html = Regex.Replace(html, @"<img[^>]*>;", "", RegexOptions.IgnoreCase);
        html.Replace("<", "");
        html.Replace(">", "");
        html.Replace("\r\n", "");
        //html = HttpContext.Current.Server.HtmlEncode(html).Trim();
        //html = HttpContext.Current.Server.HtmlDecode(html).Trim();
        return html;
    }

    public static string GetComInfoByID(string language, int id)
    {
        string FilePathName = System.Web.HttpContext.Current.Server.MapPath("~/Xml/Common/" + language + ".xml");
        string vMess = string.Empty;
        if (File.Exists(FilePathName))//如果存在，返回该文件夹所在的物理路径
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(FilePathName);
            if (XmlDoc.HasChildNodes)
            {
                XmlNode root = XmlDoc.DocumentElement;
                XmlNode xmlcontext = root.SelectSingleNode("WarnTip/Content/item[@id='" + id + "']");
                if (xmlcontext != null)
                {
                    vMess = xmlcontext.InnerText;
                }
            }
        }
        return vMess;
    }
    public static bool CheckImgFormat(string fileExt, string contentType)
    {
        string Extlist = ".BMP.GIF.JPEG.JPG";
        if (Extlist.IndexOf(fileExt) == -1)
        {
            return false;
        }
        else
        {
            string conType = "image/pjpeg image/gif image/bmp image/x-png image/tiff";
            if (conType.IndexOf(contentType) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public static void ShowAlert(Page orgPage,  string title, string class_name, string  content)
    {


        Random random = new Random();
        string strKey = "__ShowErrorMessage" + random.Next(10000).ToString() + "()";
        if (orgPage.ClientScript.IsStartupScriptRegistered(strKey))
        {
            strKey = "__ShowErrorMessage" + random.Next(10000).ToString() + "()";
        }
        string strScript = "<script language=\"JavaScript\">\n\r" +

          " $(function () {" +
            string.Format(" Dialog.alert(\"{0}\", \"<div  class=\\\"{1}\\\" >{2}</div>\")", title, class_name, content) +
        "});" +
       " \n\r</script>\n\r";
        Type csType = orgPage.GetType();
        orgPage.ClientScript.RegisterStartupScript(csType, strKey, strScript);

    }
   
    public static void ShowJsMessage(Page orgPage, string message, int messHeight, int messWidth)
    {
        string Title = "系统提示";
        string Content = message;
        string BtnName = "确定";
        Random random = new Random();
        string strKey = "__ShowErrorMessage" + random.Next(10000).ToString() + "()";
        if (orgPage.ClientScript.IsStartupScriptRegistered(strKey))
        {
            strKey = "__ShowErrorMessage" + random.Next(10000).ToString() + "()";
        }
        string strScript = "<script language=\"JavaScript\">\n\r" +
            " $(document).ready(ShowErrorMessage);\n\r" +
            " function ShowErrorMessage() " +
            " {\n\r" +
            "   ShowMessageBox(\"" + Content.Replace("\r", Convert.ToString(13)).Replace("\n", Convert.ToString(10))

            + "\"," + messWidth + "," + messHeight + ",\"" + Title + "\",\"" + BtnName + "\")\n\r" + "} \n\r</script>\n\r";
        Type csType = orgPage.GetType();
        orgPage.ClientScript.RegisterStartupScript(csType, strKey, strScript);
    }
    /// <summary>
    /// 顯示javascript的消息框,彈出消息框
    /// </summary>
    /// <param name="orgPage"></param>
    /// <param name="errorMessage"></param>
    /// <param name="messHeight"></param>
    /// <param name="messWidth"></param>
    public static void ShowJsMessage(Page orgPage, string language, int messHeight, int messWidth, string cachename, int id)
    {
        string Title = "";
        string Content = "";
        string BtnName = "";
        if (File.Exists(System.Web.HttpContext.Current.Server.MapPath("~/Xml/Common/" + language + ".xml"))) //如果存在，返回该文件夹所在的物理路径
        {
            XmlDocument XmlDoc = new XmlDocument();
            //XmlDocument xmlcache = (XmlDocument)System.Web.HttpContext.Current.Cache[cachename + language];
            //if (xmlcache == null)
            //{
            //    XmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Xml/Common/" + language + ".xml"));
            //    System.Web.HttpContext.Current.Cache[cachename + language] = XmlDoc;
            //}
            //else
            //{
            //    XmlDoc = xmlcache;
            //}
            XmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Xml/Common/" + language + ".xml"));
            if (XmlDoc.HasChildNodes)
            {
                XmlNode root = XmlDoc.DocumentElement;
                XmlNode xmltitle = root.SelectSingleNode("WarnTip/Title");
                if (xmltitle != null)
                {
                    Title = xmltitle.InnerText;
                }
                XmlNode xmlcontext = root.SelectSingleNode("WarnTip/Content/item[@id='" + id + "']");
                if (xmlcontext != null)
                {
                    Content = "<img src=images/Main/Default/errlog.gif >" + xmlcontext.InnerText;
                }
                XmlNode xmlBtnName = root.SelectSingleNode("WarnTip/BtnName");
                if (xmlBtnName != null)
                {
                    BtnName = xmlBtnName.InnerText;
                }
                Random random = new Random();
                string strKey = "__ShowErrorMessage" + random.Next(10000).ToString() + "()";
                if (orgPage.ClientScript.IsStartupScriptRegistered(strKey))
                {
                    strKey = "__ShowErrorMessage" + random.Next(10000).ToString() + "()";
                }
                string strScript = "<script language=\"JavaScript\">\n\r" +
                    " $(document).ready(ShowErrorMessage);\n\r" +
                    " function ShowErrorMessage() " +
                    " {\n\r" +
                    "   ShowMessageBox(\"" + Content.Replace("\r", Convert.ToString(13)).Replace("\n", Convert.ToString(10))

                    + "\"," + messWidth + "," + messHeight + ",\"" + Title + "\",\"" + BtnName + "\")\n\r" + "} \n\r</script>\n\r";
                Type csType = orgPage.GetType();
                orgPage.ClientScript.RegisterStartupScript(csType, strKey, strScript);
            }

        }



    }
    /// <summary>
    /// 給出系統提示信息
    /// </summary>
    /// <param name="vErrorMessage"></param>
    /// <returns></returns>
    public static string ShowSystemTip(string vErrorMessage)
    {
        StringBuilder ErrorMessage = new StringBuilder();
        ErrorMessage.Length = 0;
        ErrorMessage.Append("<div style=\"padding:20px;width:200px;height:150px\"><div class=\"x-box-blue\"><div class=\"x-box-tl\"><div class=\"x-box-tr\"><div class=\"x-box-tc\"></div></div></div>");
        ErrorMessage.Append("<div class=\"x-box-ml\"><div class=\"x-box-mr\"><div class=\"x-box-mc\">");
        ErrorMessage.Append("<h3>System Message</h3><div style='height:100px;text-align:center;vertical-align: middle;line-height:40px'><font color=#FF0000 size=4 nowrap>" + vErrorMessage + "</font></div>");
        ErrorMessage.Append(" </div></div></div>");
        ErrorMessage.Append(" <div class=\"x-box-bl\"><div class=\"x-box-br\">");
        ErrorMessage.Append(" <div class=\"x-box-bc\"></div></div></div>");
        ErrorMessage.Append(" </div></div>");
        return ErrorMessage.ToString();
    }
    /// <summary>
    /// 給出系統提示信息,並指定信息的接受者
    /// </summary>
    /// <param name="vTip"></param>
    /// <param name="vHeight"></param>
    /// <param name="vWidth"></param>
    /// <returns></returns>
    //public static string ShowSystemTip(string Title,string vTip, int vHeight, int vWidth)
    //{
    //    StringBuilder ErrorMessage = new StringBuilder();
    //    ErrorMessage.Length = 0;
    //    ErrorMessage.Append("  <div style='padding:20px;'><div style='width:" + vWidth + "px;' class='main-div'  > <div class='main-top-left'> <div class='main-top-right'><div class='main-top-header'>" + Title + "</div></div></div>");
    //    ErrorMessage.Append(" <div class='main-middle-left'><div class='main-middle-right'><div class='main-content-border'><div class='main-content' style='height:" + vHeight + "px;padding:5px;font-size:11pt;color:red'>");
    //    ErrorMessage.Append(vTip);
    //    ErrorMessage.Append("</div></div></div></div><div class='main-bottom-left'> <div class='main-bottom-right'><div class='main-bottom-middle'></div></div></div></div></div>");
    //    return ErrorMessage.ToString();
    //}
    /// <summary>
    ///  給出系統提示信息,並指定信息的接受者
    /// </summary>
    /// <param name="Title"></param>
    /// <param name="Message"></param>
    /// <param name="Height"></param>
    /// <param name="Width"></param>
    /// <returns></returns>
    public static string ShowSystemTip(string language, int item, int Height, int Width, string cachename)
    {
        string Title = "";
        string Message = "";
        if (File.Exists(System.Web.HttpContext.Current.Server.MapPath("~/Xml/Common/" + language + ".xml"))) //如果存在，返回该文件夹所在的物理路径
        {
            XmlDocument XmlDoc = new XmlDocument();
            //XmlDocument xmlcache = (XmlDocument)System.Web.HttpContext.Current.Cache[cachename + language];
            //if (xmlcache == null)
            //{
            //    XmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Xml/Common/" + language + ".xml"));
            //    System.Web.HttpContext.Current.Cache[cachename + language] = XmlDoc;
            //}
            //else
            //{
            //    XmlDoc = xmlcache;
            //}
            XmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Xml/Common/" + language + ".xml"));
            if (XmlDoc.HasChildNodes)
            {
                XmlNode root = XmlDoc.DocumentElement;
                XmlNode xmltitle = root.SelectSingleNode("NoticeTip/Title");
                Title = xmltitle.InnerText;
                XmlNode xmlcontext = root.SelectSingleNode("NoticeTip/Content/Item[@id='" + item + "']");
                Message = "<font style='color:red'>" + xmlcontext.InnerText + "</font>";
            }

        }

        StringBuilder ErrorMessage = new StringBuilder();

        ErrorMessage.Length = 0;
        ErrorMessage.Append("<div style='padding:5px;'> <div class='x-window x-window-plain x-window-dlg' style='width:" + Width + "px;'>");
        ErrorMessage.Append("<div class='x-window-tl'>");
        ErrorMessage.Append("       <div class='x-window-tr'>");
        ErrorMessage.Append("          <div class='x-window-tc'>");
        ErrorMessage.Append("          <div class='x-window-header x-unselectable' style='mozuserselect: none;");
        ErrorMessage.Append("            khtmluserselect: none' unselectable='on'>");
        ErrorMessage.Append("            <span class='x-window-header-text'>" + Title + "</span></div>");
        ErrorMessage.Append("   </div>");
        ErrorMessage.Append("    </div>");
        ErrorMessage.Append("  </div>");
        ErrorMessage.Append("    <div class='x-window-bwrap'>");
        ErrorMessage.Append("       <div class='x-window-ml'>");
        ErrorMessage.Append("       <div class='x-window-mr'>");
        ErrorMessage.Append("    <div class='x-window-mc'>");
        ErrorMessage.Append("     <div class='x-window-body' style='height: " + Height + "px; background: white;padding:5px;'>");
        ErrorMessage.Append(Message);
        ErrorMessage.Append("      </div>");
        ErrorMessage.Append("  </div>");
        ErrorMessage.Append("  </div>");
        ErrorMessage.Append("   </div>");
        ErrorMessage.Append("    <div class='x-window-bl'>");
        ErrorMessage.Append("    <div class='x-window-br'>");
        ErrorMessage.Append("    <div class='x-window-bc'>");
        ErrorMessage.Append("       <div class='x-window-footer'>");
        ErrorMessage.Append("     <div class='x-panel-btns-ct'>");
        ErrorMessage.Append("      <div class='x-panel-btns x-panel-btns-center'>");
        ErrorMessage.Append("            <div class='x-clear'>");
        ErrorMessage.Append("               </div>");
        ErrorMessage.Append("       </div>");
        ErrorMessage.Append("  </div>");
        ErrorMessage.Append("  </div>");
        ErrorMessage.Append("</div>");
        ErrorMessage.Append(" </div>");
        ErrorMessage.Append(" </div>");
        ErrorMessage.Append("</div>");
        ErrorMessage.Append("</div>");
        ErrorMessage.Append("</div>");
        return ErrorMessage.ToString();
    }
    /// <summary>
    ///  加密字符,防止敏感信息外泄.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string EncodeBase(string s)
    {
        string strResult = "";
        if (s != "" && s != null)
        {
            strResult = Convert.ToBase64String(System.Text.ASCIIEncoding.Default.GetBytes(s));
        }
        return strResult;
    }


    /// <summary>
    /// 解密字符,防止敏感信息外泄.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string DecodeBase(string s)
    {
        string strResult = "";
        if (s != "" && s != null)
        {
            strResult = System.Text.ASCIIEncoding.Default.GetString(Convert.FromBase64String(s));
        }
        return strResult;
    }

    /// <summary>
    /// 根據周別來獲取本周日期的第一天
    /// </summary>
    /// <param name="weekID"></param>
    /// <returns></returns>
    public static string GetWeekFirstDay(string weekID)
    {
        int year = int.Parse(weekID.Substring(0, 4));
        DateTime newYearDay = new DateTime(year, 1, 1);
        int firstWeekFirstDay = Convert.ToInt32(newYearDay.DayOfWeek);
        int days = (int)(7 - firstWeekFirstDay);
        DateTime secondWeekFirstDay = newYearDay.AddDays(days);
        int week = int.Parse(weekID.Substring(4, 2));
        string firstDate = secondWeekFirstDay.AddDays(((week - 2) * 7) + 1).ToString("yyyy-MM-dd"); ;
        return firstDate;
    }

    /// <summary>
    /// 根據周別來獲取本周日期的最后一天
    /// </summary>
    /// <param name="weekID"></param>
    /// <returns></returns>
    public static string GetWeekLastDay(string weekID)
    {
        int year = int.Parse(weekID.Substring(0, 4));
        DateTime newYearDay = new DateTime(year, 1, 1);

        int firstweekfirstday = Convert.ToInt32(newYearDay.DayOfWeek);
        int days = (int)(7 - firstweekfirstday);
        DateTime secondweekfisrtday = newYearDay.AddDays(days);
        int week = int.Parse(weekID.Substring(4, 2));
        string lastdate = secondweekfisrtday.AddDays((week - 2) * 7 + 7).ToString("yyyy-MM-dd");
        return lastdate;
    }

    public static string ToJson(Dictionary<string, string> JsonList)
    {
        string JsonString = null;
        StringBuilder jsonBuilder = new StringBuilder();
        if (JsonList.Count > 0)
        {
            jsonBuilder.Append("{");
            int f = JsonList.Count;
            int m = 0;
            foreach (KeyValuePair<string, string> kvp in JsonList)
            {
                m++;
                jsonBuilder.Append("\"" + kvp.Key + "\":");
                jsonBuilder.Append("\"" + kvp.Value.Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r") + "\"");
                if (f > m)
                {
                    jsonBuilder.Append(",");
                }
            }
            jsonBuilder.Append("}");
            JsonString = jsonBuilder.ToString();
        }
        return JsonString;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="weekId"></param>
    /// <returns></returns>
    public static string[] GetWeekRange(string weekId)
    {
        string[] day = new string[7];
        int year = int.Parse(weekId.Substring(0, 4));
        DateTime newYearDay = new DateTime(year, 1, 1);
        int firstweekfirstday = Convert.ToInt32(newYearDay.DayOfWeek);
        int days = (int)(7 - firstweekfirstday);
        DateTime secondweekfisrtday = newYearDay.AddDays(days);
        int week = int.Parse(weekId.Substring(4, 2));
        DateTime firstdate = secondweekfisrtday.AddDays((week - 2) * 7);
        DateTime lastdate = secondweekfisrtday.AddDays((week - 2) * 7 + 6);
        day[0] = firstdate.ToString("yyyy-MM-dd");
        for (int i = 1; i <= 5; i++)
        {
            day[i] = firstdate.AddDays(i).ToString("yyyy-MM-dd");
        }
        day[6] = lastdate.ToString("yyyy-MM-dd");
        return day;
    }


    /// <summary>
    /// 根據日期返回周次
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string GetWeekOfYear(DateTime dt)
    {
        CultureInfo ci = CultureInfo.CurrentCulture;
        System.Globalization.Calendar calendar = ci.Calendar;
        CalendarWeekRule rule = ci.DateTimeFormat.CalendarWeekRule;
        DayOfWeek dow = DayOfWeek.Monday;
        int week = calendar.GetWeekOfYear(dt, rule, dow);
        string weekId = week.ToString("00");
        return weekId;
    }

    /// <summary>
    /// 判斷是否輸入整數數字的正則表達
    /// </summary>
    /// <param name="Validate"></param>
    /// <returns></returns>
    public static bool CheckValidate(string Validate)
    {
        Regex re = new Regex(@"^[0-9]+$");//正則表達式

        if (!re.IsMatch(Validate))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    /// <summary>
    /// 產生隨機的字母
    /// </summary>
    /// <returns></returns>
    public static string RandomnAlpha(int i)
    {
        string oriStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstyuwxyz";
        string reStr = "";
        Random rd = new Random();
        for (int k = 0; k < i; k++)
        {
            reStr += oriStr[rd.Next(0, oriStr.Length)].ToString();
        }
        return reStr;
    }
    /// <summary>
    /// 將信息寫入日志文件中
    /// </summary>
    /// <param name="textContent">日志內容</param>
    /// <param name="Path">文件路徑</param>
    public static void WriteLog(string textContent, string Path)
    {
        if (!File.Exists(Path))
        {
            using (StreamWriter writer = File.CreateText(Path))
            {
                writer.WriteLine(textContent + "\r\n\r\n\r\n\r\n");
                writer.Close();
                //string LOG_SOURCE = ConfigurationManager.AppSettings["Event Log Source"];
                //System.Diagnostics.EventLog.WriteEntry(LOG_SOURCE, textContent, System.Diagnostics.EventLogEntryType.Error);

            }
        }
        else
        {
            using (StreamWriter writer2 = File.AppendText(Path))
            {
                try
                {
                    writer2.WriteLine(textContent + "\r\n\r\n\r\n\r\n");
                    writer2.Close();
                }
                catch
                {

                }
            }
        }
    }
    public static string ReplaceHTML(string oriString, bool isRemove)
    {
        if (!string.IsNullOrEmpty(oriString))
        {
            string newString = Regex.Replace(oriString.Trim(), @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            newString = Regex.Replace(newString, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"-->", "", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"<!--.*", "", RegexOptions.IgnoreCase);

            newString = Regex.Replace(newString, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, "xp_cmdshell", "", RegexOptions.IgnoreCase);

            //删除与数据库相关的词
            /*    newString = Regex.Replace(newString, "select", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "insert", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "delete from", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "count''", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "drop table", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "truncate", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "asc", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "mid", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "char", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "xp_cmdshell", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "exec master", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "net localgroup administrators", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "and", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "net user", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "or", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "net", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "delete", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "drop", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "script", "", RegexOptions.IgnoreCase);
                */

            //特殊的字符
            newString = newString.Replace("<", "");
            newString = newString.Replace(">", "");
            //newString = newString.Replace("*", "");
            //newString = newString.Replace("-", "");
            //newString = newString.Replace("?", "");
            //newString = newString.Replace(",", "");
            //newString = newString.Replace("/", "");
            //newString = newString.Replace(";", "");
            //newString = newString.Replace("/**/", "");
            newString = newString.Replace("\r\n", "");
            if (isRemove)
            {
                newString = newString.Replace("'", "''");
            }
            newString = newString.Replace("|", "/");
            //newString = HttpContext.Current.Server.HtmlEncode(newString).Trim();
            return newString;
        }
        else
        {
            return string.Empty;
        }
    }
    public static string ReplaceHTML(string oriString)
    {
        if (!string.IsNullOrEmpty(oriString))
        {
            string newString = Regex.Replace(oriString.Trim(), @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            newString = Regex.Replace(newString, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"-->", "", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"<!--.*", "", RegexOptions.IgnoreCase);

            newString = Regex.Replace(newString, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            newString = Regex.Replace(newString, "xp_cmdshell", "", RegexOptions.IgnoreCase);

            //删除与数据库相关的词
            /*    newString = Regex.Replace(newString, "select", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "insert", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "delete from", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "count''", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "drop table", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "truncate", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "asc", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "mid", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "char", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "xp_cmdshell", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "exec master", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "net localgroup administrators", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "and", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "net user", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "or", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "net", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "delete", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "drop", "", RegexOptions.IgnoreCase);
                newString = Regex.Replace(newString, "script", "", RegexOptions.IgnoreCase);
                */

            //特殊的字符
            newString = newString.Replace("<", "");
            newString = newString.Replace(">", "");
            //newString = newString.Replace("*", "");
            //newString = newString.Replace("-", "");
            //newString = newString.Replace("?", "");
            //newString = newString.Replace(",", "");
            //newString = newString.Replace("/", "");
            //newString = newString.Replace(";", "");
            //newString = newString.Replace("/**/", "");
            newString = newString.Replace("\r\n", "");
            //newString = newString.Replace("'", "''");
            newString = newString.Replace("|", "/");
            //newString = HttpContext.Current.Server.HtmlEncode(newString).Trim();
            return newString;
        }
        else
        {
            return string.Empty;
        }
    }

    public static string SubStr(string oriString, int length, bool isRemove)
    {
        //oriString = Strings.StrConv(oriString, VbStrConv.TraditionalChinese, 1033);
        //byte[] bytes = System.Text.Encoding.Unicode.GetBytes(oriString);
        //int n = 0;
        //int i = 0;
        //for (; i < bytes.GetLength(0) && n < length; i++)
        //{
        //    if (i % 2 == 0)
        //    {
        //        n++;
        //    }
        //    else
        //    {
        //        if (bytes[i] > 0)
        //        {
        //            n++;
        //        }
        //    }
        //}
        //if (i % 2 == 1)
        //{
        //    if (bytes[i] > 0)

        //        i = i - 1;
        //    else
        //        i = i + 1;
        //}
        //return System.Text.Encoding.Unicode.GetString(bytes, 0, i);
        //oriString = Strings.StrConv(oriString, VbStrConv.TraditionalChinese, 1033);
        if (!string.IsNullOrEmpty(oriString))
        {
            string temp = ReplaceHTML(oriString, isRemove);
            int j = 0;
            int k = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (Regex.IsMatch(temp.Substring(i, 1), @"[\u4e00-\u9fa5]+"))
                {
                    j += 3;
                }
                else
                {
                    j += 1;
                }
                if (j <= length)
                {
                    k += 1;
                }
                if (j >= length)
                {
                    temp = temp.Substring(0, k);
                    break;
                }
            }
            return temp;
        }
        else
        {
            return string.Empty;
        }

        //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(oriString);
        //int n = 0;
        //int i = 0;
        //int count = bytes.GetLength(0);
        //for (; i < bytes.GetLength(0) && n < length; i++)
        //{
        //    if (i % 3 == 0)
        //    {
        //        n++;
        //    }
        //    else
        //    {
        //        if (bytes[i] > 0)
        //        {
        //            n++;
        //        }
        //    }
        //}

        //if (i % 3 == 1)
        //{
        //    if (bytes[i] > 0)

        //        i = i - 1;
        //    else
        //        i = i + 1;
        //}
        //string aa = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
        //return System.Text.Encoding.UTF8.GetString(bytes, 0, i);

    }
    /// <summary>
    /// 字符截取擴展
    /// <para></para>
    /// <para> 解決C# 採用 Unicode 16（UCS2）編碼,對於漢字不能處理.</para>
    ///
    /// </summary>
    /// <param name="oriString"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    public static string SubStr(string oriString, int length)
    {
        //oriString = Strings.StrConv(oriString, VbStrConv.TraditionalChinese, 1033);
        //byte[] bytes = System.Text.Encoding.Unicode.GetBytes(oriString);
        //int n = 0;
        //int i = 0;
        //for (; i < bytes.GetLength(0) && n < length; i++)
        //{
        //    if (i % 2 == 0)
        //    {
        //        n++;
        //    }
        //    else
        //    {
        //        if (bytes[i] > 0)
        //        {
        //            n++;
        //        }
        //    }
        //}
        //if (i % 2 == 1)
        //{
        //    if (bytes[i] > 0)

        //        i = i - 1;
        //    else
        //        i = i + 1;
        //}
        //return System.Text.Encoding.Unicode.GetString(bytes, 0, i);
        //oriString = Strings.StrConv(oriString, VbStrConv.TraditionalChinese, 1033);
        if (!string.IsNullOrEmpty(oriString))
        {
            string temp = ReplaceHTML(oriString);
            int j = 0;
            int k = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (Regex.IsMatch(temp.Substring(i, 1), @"[\u4e00-\u9fa5]+"))
                {
                    j += 3;
                }
                else
                {
                    j += 1;
                }
                if (j <= length)
                {
                    k += 1;
                }
                if (j >= length)
                {
                    temp = temp.Substring(0, k);
                    break;
                }
            }
            return temp;
        }
        else
        {
            return string.Empty;
        }

        //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(oriString);
        //int n = 0;
        //int i = 0;
        //int count = bytes.GetLength(0);
        //for (; i < bytes.GetLength(0) && n < length; i++)
        //{
        //    if (i % 3 == 0)
        //    {
        //        n++;
        //    }
        //    else
        //    {
        //        if (bytes[i] > 0)
        //        {
        //            n++;
        //        }
        //    }
        //}

        //if (i % 3 == 1)
        //{
        //    if (bytes[i] > 0)

        //        i = i - 1;
        //    else
        //        i = i + 1;
        //}
        //string aa = System.Text.Encoding.UTF8.GetString(bytes, 0, i);
        //return System.Text.Encoding.UTF8.GetString(bytes, 0, i);

    }
    ////public static string ToBigChinese(string oriString)
    ////{
    ////    string newString = Strings.StrConv(oriString, VbStrConv.TraditionalChinese, 1033);
    ////    return newString;
    ////}
    /// <summary>
    /// 選擇詞匯
    /// </summary>
    /// <param name="text"></param>
    /// <param name="MaxLength"></param>
    /// <returns></returns>
    public static string FilterText(string text, int MaxLength)
    {
        string FilterStr = text;
        FilterStr = text.Trim();
        if (string.IsNullOrEmpty(FilterStr))
            return string.Empty;

        FilterStr = SubStr(FilterStr, MaxLength);
        // FilterStr = ToBigChinese(FilterStr);
        //去掉多個空格
        //FilterStr = Regex.Replace(FilterStr, "[\\s]{2,}", " ");
        //去掉<br/>
        FilterStr = Regex.Replace(FilterStr, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");
        //去掉 &nbsp
        FilterStr = Regex.Replace(FilterStr, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");
        FilterStr = Regex.Replace(FilterStr, "<(.|\\n)*?>", string.Empty);
        FilterStr = FilterStr.Replace("'", "''");
        return FilterStr;
    }
    public static string FilterText(string text)
    {
        string FilterStr = text;
        if (string.IsNullOrEmpty(FilterStr))
            return string.Empty;
        FilterStr = text.Trim();
        //去掉多個空格
        //FilterStr = Regex.Replace(FilterStr, "[\\s]{2,}", " ");
        //去掉<br/>
        FilterStr = Regex.Replace(FilterStr, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");
        //去掉 &nbsp
        FilterStr = Regex.Replace(FilterStr, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");
        FilterStr = Regex.Replace(FilterStr, "<(.|\\n)*?>", string.Empty);
        FilterStr = FilterStr.Replace("'", "''");

        return FilterStr;
    }
    /// <summary>
    /// 記錄系統異常日記
    /// </summary>
    /// <param name="ex"></param>
    public static void WriteSystemLog(Exception ex)
    {
        string Message = "Time:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\nError:" + ex.Message + "\r\nInfo:" + ex.StackTrace;
        WriteLog(Message, ErrPath);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="IPStr"></param>
    /// <returns></returns>
    public static string GetIp(string IPStr)
    {
        int IP = 0;
        string newIp = "";
        if (!string.IsNullOrEmpty(IPStr))
        {
            try
            {
                IP = Convert.ToInt32(IPStr);
                string IpChange = string.Format("{0:X8}", IP);
                if (IpChange.Length == 8)
                {
                    string FirstIp = IpChange.Substring(0, 2);
                    string SecondIp = IpChange.Substring(2, 2);
                    string ThirdIp = IpChange.Substring(4, 2);
                    string FourthIp = IpChange.Substring(6, IpChange.Length - 6);
                    int first = Convert.ToInt32(FirstIp, 16);
                    int Second = Convert.ToInt32(SecondIp, 16);
                    int Third = Convert.ToInt32(ThirdIp, 16);
                    int Fourth = Convert.ToInt32(FourthIp, 16);
                    newIp = first.ToString() + "." + Second.ToString() + "." + Third.ToString() + "." + Fourth.ToString();
                }
            }
            catch
            {
                newIp = "";
            }
        }
        return newIp;
    }
}