<%@ Page Language="C#" AutoEventWireup="true" Inherits="BigDogShop.Web.HistoryList" Codebehind="HistoryList.aspx.cs" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link href="Css/Base.css" rel="stylesheet" />
   <link href="Css/User/User.base.2014.css" rel="stylesheet" />
    <script type="text/javascript"  src="Js/jquery-1.4.2.min.js"></script>
    <script  type="text/javascript" src="Js/Effact/LazyLoad.js"></script>
    <script  type="text/javascript" src="Js/ajaxfileupload.js"></script>
    <script  type="text/javascript" src="Js/Effact/Left_Menu.js"></script>
    <script type="text/javascript" src="Js/pcasunzip.js" charset="gb2312"></script>
</head>
<body>
    <form id="form1" runat="server">
     <!--#include file='~/Include/MenuHeader.txt'-->
    <div id="container">
        <!--#include file='~/Include/left_nav.txt'-->
        <div class="info_container">
            <div class="info_container">
                <div class="title_info">
                    <span><strong>浏览历史</strong></span>
                   
                </div>
            </div>
            <div class="user_info">
                <div class="user_security_info">
                    浏览历史：

                </div>
                <div class="user_security_info_list">
                    <table>
                        <tr>
                            <td>密码强度:</td>
                            <td>
                                <asp:Label ID="txt_user_name" runat="server"></asp:Label>
                            </td>
                            <td><a href="UserChangePwd.aspx">修改</a></td>
                        </tr>
                        
                        <tr>

                            <td>邮箱：</td>
                            <td>
                                <a href="#"><asp:Label ID="lbl_email" runat="server"></asp:Label></a>
                            </td>
                        </tr>

                    </table>
                </div>
                
            </div>
        </div>


    </div>
    </form>
</body>
</html>
