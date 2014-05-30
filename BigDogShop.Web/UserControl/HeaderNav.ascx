<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderNav.ascx.cs" Inherits="BigDogShop.Web.UserControl.HeaderNav" %>
<%@ OutputCache Duration="20" VaryByParam="none" Shared="true" VaryByCustom="browser" %>
<div class="header_nav_1">
    <div>
        <a href="#" class="nav">全部商品分类</a>
    </div>
    <!--所有菜单-->
    <div class="allsort_box">

        <ul id="sort_lists">
            <asp:Repeater ID="rpt_menu_category" runat="server">
                <ItemTemplate>
                    <li class="<%# Convert.ToInt32(Eval("Type_Id"))/2==0?"sort_color":"sort_color" %>" typeid="<%#Eval("Type_Id") %>">
                        <%#Eval("Category_Name") %>
                        <div typeid="<%#Eval("Type_Id") %>" class="show_sort global_loading"></div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <div id="list_detail">
    </div>
    <!--主菜单-->
    <div class="header_nav">
        <ul>
            <asp:Repeater ID="rpt_menu" runat="server">
                <ItemTemplate>
                    <li><a href="#"><%#Eval("Menu_Name") %></a></li>
                </ItemTemplate>
            </asp:Repeater>

        </ul>
         缓存菜单测试(20秒):<asp:Label ID="lbl_time" runat="server"></asp:Label>
    </div>
   
</div>
