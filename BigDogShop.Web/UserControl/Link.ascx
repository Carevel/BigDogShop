<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Link.ascx.cs" Inherits="BigDogShop.Web.UserControl.Link" %>
<div class="footer-2014">
    <div class="links">
        <asp:Repeater ID="rpt_link" runat="server">
            <ItemTemplate>
                <a href="<%#Eval("Link_Url") %>" target="_blank"><%#Eval("Link_Name") %></a>&nbsp;|&nbsp;
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="copyright">
        Copyright&copy;2013-2014&nbsp;&nbsp;TouchStudio&copy;版权所有
    </div>
</div>