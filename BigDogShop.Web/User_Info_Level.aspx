<%@ Page Language="C#" AutoEventWireup="true" Inherits="BigDogShop.Web.User_Info_Level" Codebehind="User_Info_Level.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link href="Css/Base.css" rel="stylesheet" />
     <link href="Css/User/User.base.2014.css" rel="stylesheet" />

    <script type="text/javascript"  src="Js/jquery-1.4.2.min.js"></script>
    <script  type="text/javascript" src="Js/Effact/LazyLoad.js"></script>
    <script type="text/javascript"  src="Js/ajaxfileupload.js"></script>
    <script type="text/javascript"  src="Js/Effact/Left_Menu.js"></script>
    <script type="text/javascript" src="Js/pcasunzip.js" charset="gb2312"></script>
    <script type="text/javascript">
        new PCAS("province", "city", "area", "江苏省", "苏州市", "沧浪区");
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <!--#include file='~/Include/MenuHeader.txt'-->
    <div id="container">
        <!--#include file='~/Include/left_nav.txt'-->
        <div class="info_container">
            <div class="info_container">
                <div class="title_info">
                    <span><strong>帐户信息</strong></span>
                   
                </div>
            </div>
            <div class="user_info">
                <!--#Include file='~/Include/UserInfoList.txt-->
                <div class="info_detail_left">
                    <table>
                        <tr>
                            <td>用户名：</td>
                            <td>
                                <asp:Label ID="txt_user_name" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>用户等级：</td>
                            <td>
                                <asp:Label ID="lbl_user_score" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>会员类型：</td>
                            <td>
                                <asp:Label ID="lbl_user_type" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>昵称：</td>
                            <td>
                                <asp:TextBox ID="txt_nick_name" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>手机号码：</td>
                           <td>
                               <asp:TextBox ID="txt_phone_number" runat="server"></asp:TextBox>
                           </td>
                        </tr>
                        <tr>
                            <td>邮箱：</td>
                            <td>
                                <a href="#"><asp:Label ID="lbl_email" runat="server"></asp:Label></a>
                            </td>
                        </tr>
                        <tr>
                            <td>真实姓名：</td>
                            <td>
                                <asp:TextBox ID="txt_real_name" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>所在地：</td>
                            <td>
                                <select name="province"></select><select name="city"></select><select name="area"></select>
                            </td>
                        </tr>
                       
                    </table>
                </div>
                <div class="info_detail_right">
                    <div class="photo_container">
                        <img id="user_photo" runat="server" />    
                    </div>
                   <br />
                    <a href="#" id="change_user_photo">修改头像</a>
                </div>
            </div>
        </div>


    </div>
         <!--#include file='Include/Service-2014.txt'-->   
    <!--#Include file='Include/Footer-2014.txt'-->
    </form>
</body>
</html>
