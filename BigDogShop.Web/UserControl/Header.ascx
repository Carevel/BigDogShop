<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="BigDogShop.Web.UserControl.Header" %>

<div class="top_container">
    <div class="top_header_info">
        <a href="Index.aspx">
            <div class="top_img"></div>
        </a>
        <div class="top_search">
            <div class="search_box">
                <asp:TextBox runat="server" ID="txt_search_keywords"></asp:TextBox>
                <asp:Button runat="server" ID="btn_search_keywords" Text="搜索" OnClick="btn_search_keywords_Click"></asp:Button>
            </div>
            <div>
                <a href="CenterInfo.aspx">我的BigDog</a>
                <a href="#">去购物车结算</a>
            </div>

        </div>
    </div>
</div>
