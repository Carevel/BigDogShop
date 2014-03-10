<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BigDogShop.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Css/Base.css" rel="stylesheet" />
    <script type="text/javascript" src="Js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="Js/Validate.js"></script>
</head>
<body id="body">
    <form id="form1" runat="server">
        <div class="top">
            <div runat="server" id="top_header">
            </div>
        </div>
        <div class="top_info">
            <div class="logo">
                <a href="Index.aspx">
                    <img id="welcome_logo" src="Images/Logo/Logo.jpg" alt="" />
                </a>
            </div>
        </div>
        <div class="content">
            <div class="login_img">
                <img src="Images/AdImages/1.jpg" alt="" />
            </div>
            <div class="login">
                <table>
                    <tr>
                        <td class="txt_td" style="width: 100px">用户名：</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txt_user_name" runat="server" class="tx"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td class="txt_td" style="width: 100px">密码：</td>
                    </tr>
                    <tr>
                        <td>
                           <asp:TextBox ID="txt_user_pwd" runat="server" TextMode="Password" class="tx"></asp:TextBox> 
                        </td>
                    </tr>
                    <tr>
                        <td class="txt_td" style="width: 100px">验证码：</td>
                    </tr>
                    <tr>
                        <td>
                            <input type-="text" id="txt_ckcode" value="" runat="server" class="tx" style="width:150px;" />

                       <%-- </td>
                        <td>--%>
                            <img src="Handler/Validate.ashx" id="ckcode" alt="验证码" />
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:CheckBox ID="cb_check" runat="server" />一周以内不用登录
                        </td>
                    </tr>
                    <tr></tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Button ID="submit" runat="server" Text="登录" CssClass="btn" OnClick="btnOk_Click" />
                        </td>
                    </tr>   
                </table>
                <div>
                    <asp:Label ID="lab_mess" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <asp:Label ID="lbl_ckcode" runat="server" Style="visibility: hidden"></asp:Label>
        <Link:Li ID="li1" runat="server" />
    </form>
</body>
</html>
