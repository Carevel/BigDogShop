<%@ Page Language="C#" AutoEventWireup="true" Inherits="MyFollow" Codebehind="MyFollow.aspx.cs" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link href="Css/Base.css" rel="stylesheet" />
     <link href="Css/CenterInfo.css" rel="stylesheet" />
    <link href="Css/CenterInfo/CenterInfo.css" rel="stylesheet" />
    <script src="Js/jquery-1.4.2.min.js"></script>
    <script src="Js/Effact/LazyLoad.js"></script>
    <script src="Js/ajaxfileupload.js"></script>
    <script src="Js/Effact/Left_Menu.js"></script>
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
                    <span><strong>我的关注</strong></span>
                   
                </div>
            </div>
            <div class="user_info">
                <div class="user_security_info">
                    关注列表：

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