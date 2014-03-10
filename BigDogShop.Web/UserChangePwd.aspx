<%@ Page Language="C#" AutoEventWireup="true" Inherits="BigDogShop.Web.UserChangePwd" Codebehind="UserChangePwd.aspx.cs" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link href="Css/Base.css" rel="stylesheet" />
    <link href="Css/User/User.base.2014.css" rel="stylesheet" />
    <script  type="text/javascript" src="Js/jquery-1.4.2.min.js"></script>
    <script  type="text/javascript" src="Js/Effact/LazyLoad.js"></script>
    <script  type="text/javascript" src="Js/ajaxfileupload.js"></script>
    <script  type="text/javascript" src="Js/Effact/Left_Menu.js"></script>
    <script  type="text/javascript" src="Js/Validate.js"></script>
    <script  type="text/javascript" src="Js/SendEamilCode.js"></script>
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
                    <span><strong>修改登录密码</strong></span>
                   
                </div>
            </div>
            <div class="user_info">
                <div class="user_security_info">
                   <div  class="step"><span id="usersp_1">第一步：验证身份</span></div> 
                   <div class="step"><span id="usersp_2">第二步：修改登录密码</span></div> 
                   <div class="step"><span id="usersp_3">第三步：完成</span></div> 
                </div>
                <div class="user_security_info_list">
                    <table>
                        <tr>
                           
                            <td>已验证邮箱:</td>
                            <td>
                                <asp:Label ID="lbl_email" runat="server"></asp:Label>
                            </td>
                        </tr>           
                        <tr>
                            <td></td>
                            <td>
                                <input type="button" id="btn_send_email" value="获取验证码" />
                            </td>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                            <td>
                                请填写邮件验证码：
                            </td>
                            <td>
                                <asp:TextBox ID="txt_email_code" runat="server" ></asp:TextBox>
                            </td>
                        </tr>           
                        <tr>
                            <td>验证码：</td>
                            <td>
                                <asp:TextBox ID="txt_ckcode" runat="server"></asp:TextBox>
                            </td>
                            <td>
                             <img src="Handler/Validate.ashx" id="ckcode" runat="server" />  
                            点击可换
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                              <asp:Button ID="btn_submit" runat="server" Text="提交" OnClick="btn_submit_Click" />
                            </td>
                        </tr>
                    </table>
                    
                </div>
                
            </div>
        </div>

        <input type="hidden" id="temp_code" runat="server" />
    </div>
         <!--#include file='Include/Service-2014.txt'-->   
    <!--#Include file='Include/Footer-2014.txt'-->
    </form>
</body>
</html>
