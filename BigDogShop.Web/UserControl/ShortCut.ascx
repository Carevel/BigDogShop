<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShortCut.ascx.cs" Inherits="BigDogShop.Web.UserControl.ShortCut" %>
<div class="top_header_info">
    <a href="Index.aspx">
        <div class="top_img"></div>
    </a>
    <div class="top_search">
        <asp:TextBox runat="server" ID="txt_search_keywords"></asp:TextBox>
        <asp:Button runat="server" ID="btn_search_keywords" Text="搜索" OnClick="btn_search_keywords_Click"></asp:Button>
        <a href="CenterInfo.aspx">我的BigDog</a>
    </div>
</div>
