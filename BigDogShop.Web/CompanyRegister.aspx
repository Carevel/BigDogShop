<%@ Page Language="C#" AutoEventWireup="true" Inherits="CompanyRegister" Codebehind="CompanyRegister.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Css/Base.css" rel="stylesheet" />
    <script src="Js/jquery-1.4.2.min.js"></script>
    <script src="Js/Validate.js"></script>    
</head>
<body id="body">
    <form id="form1" runat="server">
       
         <div class="top">
            <div runat="server" id="top_header">    
            </div>
         </div>
        
       
        <div class="top_info">
            <div><a href="Index.aspx"><img id="welcome_logo" src="Images/rightside_logo.jpg" /></a></div>
        </div>
        <div class="mt">
            <div class="tab">
                <ul>
                    <li id="reg_person"><a href="Register.aspx">个人注册</a></li>
                    <li id="reg_company"><a href="CompanyRegister.aspx">商家注册</a></li>
                </ul>
            </div>
            <div class="extra_info">
                <span>我已经有帐户，现在就<a href="Login.aspx">登录</a></span>
            </div>
        </div>
        <div class="reg_content">
           
            <div class="reg_info_container">               
                
                <div class="reg_info_left">
                    <div class="item">
                        <span class="label">
                            <b>*</b>
                            账户名：
                        </span>
                        <div class="item_info">
                            <asp:TextBox ID="txt_user_name" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="item">
                        <span class="label">
                            <b>*</b>
                            请输入密码：
                        </span>
                        <div class="item_info">
                            <asp:TextBox ID="txt_password" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="item">
                        <span class="label">
                            <b>*</b>
                            请确定密码：
                        </span>
                        <div class="item_info">
                            <asp:TextBox ID="txt_confirm_password" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="item">
                        <span class="label">
                            <b>*</b>
                            请输入验证码：
                        </span>
                        <div class="item_info">
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            <label class="img">
                            <img src="Handler/Validate.ashx" id="ckcode" />
                        </label>
                        <label class="img_info">
                            <a href="javascript:void(0)">看不清楚？换一张</a>
                        </label>
                        </div>
                        
                    </div>
                </div>
                <div >
                    <asp:Label ID="lab_mess" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="footer">
            <div class="links">
                <a href="about.aspx" target="_blank">关于我们</a> |
                <a href="Contact.appx" target="_blank">联系我们</a>｜
                <a href="Contact.appx" target="_blank">友情链接</a>｜
                <a href="Contact.appx" target="_blank">广告服务</a>｜
                <a href="Contact.appx" target="_blank">商家入驻</a>｜
            </div>
            <div class="copyright">
                Copyright&copy;2014-2014&nbsp;&nbsp;TouchStudio&copy;版权所有
            </div>
        </div>
    </form>
</body>
</html>
