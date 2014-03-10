<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Top.ascx.cs" Inherits="BigDogShop.Web.UserControl.AdminHeader" %>

<div class="top">
    <div class="top_header">
        <asp:Panel ID="panel1" runat="server">
            <ul>
                <li>你好:<asp:Label ID="lbl_user_name" runat="server"></asp:Label>&nbsp;,欢迎来到BigDog商城</li>
                <li><asp:LinkButton ID="lbtn_Exit" runat="server" OnClick="lbtn_Exit_Click">[退出]</asp:LinkButton></li>
                <li><a href="#">我的订单</a></li>
                <li><a href="#">客服服务</a></li>
            </ul>
        </asp:Panel>
        <asp:Panel ID="panel2" runat="server">
            <ul>
                <li>欢迎来到BigDog商城</li>
                <li><a href="../Login.aspx">[登录]</a> | <a href="../UserRegister.aspx">[免费注册]</a></li>
                <li><a href="#">我的订单</a></li>
                <li><a href="#">客服服务</a></li>
            </ul>
        </asp:Panel>
    </div>
</div>

