<%@ Page Language="C#" AutoEventWireup="true" Inherits="CenterInfo" Codebehind="CenterInfo.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/Base.css" rel="stylesheet" />
    <link href="Css/User/User.base.2014.css" rel="stylesheet" />
    <script src="Js/jquery-1.4.2.min.js"></script>
    <script src="Js/Effact/LazyLoad.js"></script>
    <script src="Js/Effact/Left_Menu.js"></script>
</head>
<body>
    <form id="form1" runat="server"> 
         <!--#include file='~/Include/MenuHeader.txt'-->
    <div id="container">
        <!--#include file='~/Include/left_nav.txt'-->
        <div class="info_container">
            <div class="title_info">
            <span><strong>我的走壹走</strong></span>
                <hr />
        </div>
        <div class="user_container">
            <div class="user_img">
                <img id="user_photo" runat="server" alt="" />
            </div>
            <div class="user_info2">
                <table>
                    <tr>
                        <td>
                            欢迎您:
                        </td>
                        <td></td>
                        <td>
                            <asp:Label ID="lbl_name" runat="server"></asp:Label>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            会员等级：
                        </td>
                        <td></td>
                        <td>
                            积分：<asp:Label ID="lbl_score" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            我的关注：
                        </td>
                        <td></td>
                        <td>
                            邮箱是否已验证：<asp:Label ID="lbl_email" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            专长:<asp:Label ID="lbl_special" runat="server"></asp:Label>
                        </td>
                        <td></td>
                        <td>
                            喜好：<asp:Label ID="lbl_love" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                    <tr>
                        <td>
                            地区:<asp:Label ID="lbl_area" runat="server"></asp:Label>
                        </td>
                        <td></td>
                        <td>
                            联系方式：<asp:Label ID="lbl_contact" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            
        </div>
           
        </div>
         <div class="order_info">
                <span>近一个月订单</span>
                
            </div>
        
    </div>
        <!--#include file='~/Include/Service-2014.txt'-->
        <!--#Include file='Include/Footer-2014.txt'-->
    </form>
</body>
</html>
