<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BigDogShop.Web.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Base.css" rel="stylesheet" />
    <script src="../Js/jquery-1.4.2.min.js"></script>
    <script src="../Js/Validate.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login_container">
            <div class="login">
                <table>
                    <tr>
                        <td>用户名：</td>
                        <td>
                            <asp:TextBox ID="txt_name" runat="server" class="tx"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lbl_name_tip" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>密码：</td>
                        <td>
                            <asp:TextBox ID="txt_pwd" runat="server" TextMode="Password" class="tx"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lbl_pwd_tip" runat="server"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td>验证码：</td>
                        <td>
                            <asp:TextBox ID="txt_ckcode" runat="server" TextMode="Password" class="tx"></asp:TextBox>
                        </td>
                        <td>
                            <img src="../Handler/Validate.ashx" id="ckcode" alt="验证码" />
                            <asp:Label ID="lbl_ckcode_tip" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: left">
                            <asp:CheckBox ID="ck_remember" runat="server" />记住我
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center" class="auto-style1">
                            <asp:Button ID="submit" runat="server" Text="登录" CssClass="btn" OnClick="submit_Click" />
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:Label ID="lab_mess" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
