<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerCenter.aspx.cs" Inherits="BigDogShop.Web.Admin.ManagerCenter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Base.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="navigation nav_icon">你好：<i><asp:Label ID="lbl_admin_name" runat="server"></asp:Label></i>,欢迎进入后台管理中心</div>
        <div class="login_info">
            <ul>
                <li>本次登录IP:<asp:Label id="login_ip" runat="server"></asp:Label></li>
                <li>上次登录IP:<asp:Label id="login_last_ip" runat="server"></asp:Label></li>
                <li>上次登录时间:<asp:Label id="login_last_time" runat="server"></asp:Label></li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
