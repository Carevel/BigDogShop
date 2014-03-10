<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserChangePassword.aspx.cs" Inherits="BigDogShop.Web.UserChangePassword" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <link href="Css/Base.css" rel="stylesheet" />
    <link href="Css/CenterInfo/CenterInfo.css" rel="stylesheet" />
    <script  type="text/javascript" src="Js/jquery-1.4.2.min.js"></script>
    <script  type="text/javascript" src="Js/Effact/LazyLoad.js"></script>
    <script  type="text/javascript" src="Js/ajaxfileupload.js"></script>
    <script  type="text/javascript" src="Js/Effact/Left_Menu.js"></script>
    <%--<script src="Js/Validate.js"></script>--%>
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
                            <td>
                                 新的登录密码：
                            </td>
                           <td>
                               <asp:TextBox ID="txt_new_pwd" runat="server" Class="tx" ></asp:TextBox>
                           </td>
                            <td>
                                <span id="sp_newpwd">请输入新的密码</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                确定新密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txt_confirm_new_pwd" runat="server" Class="tx" ></asp:TextBox>
                            </td>
                            <td>
                                <span id="sp_oldpwd">请再次输入新的密码</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                验证码：
                            </td>
                            <td>
                                <asp:TextBox ID="txt_check_code" runat="server" ></asp:TextBox>
                            </td>
                            <td>
                                <img src="Handler/Validate.ashx" runat="server" id="ckcode"  alt="" />看不清楚？
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                              <asp:Button ID="btn_submit" runat="server" Text="提交" OnClick="btn_submit_Click" style="height: 26px" />
                            </td>
                        </tr>
                    </table>
                    
                </div>
                
            </div>
        </div>

        <%-- 弹出修改头像 --%>
      
    </div>
        <input type="hidden" id="temp_code" runat="server" />
    </form>
</body>
</html>
