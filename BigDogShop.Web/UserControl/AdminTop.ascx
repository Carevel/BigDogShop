<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminTop.ascx.cs" Inherits="BigDogShop.Web.Admin.UserControl.AdminTop" %>

<link href="../Admin/Styles/Base.css" rel="stylesheet" />

<div class="top">
    <div class="top_right">
        <div class="admin_photo">
            <img id="Img1" src="~/Images/Photo/Admin/default_user_avatar.gif" runat="server" />
        </div>
        <div class="admin_right_info">
            <br />
            <b>管理员:<asp:Label ID="txt_admin_name" runat="server"></asp:Label></b>
            你好，欢迎光临
            <br />
            <a href="Default.aspx">管理中心</a> |
            <a target="_blank" href="../Index.aspx">预览网站</a> |
            <asp:LinkButton ID="lbtn_Exit" runat="server" OnClick="lbtn_Click">安全退出</asp:LinkButton>
        </div>
    </div>
</div>