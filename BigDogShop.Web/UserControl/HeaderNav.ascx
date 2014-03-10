<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderNav.ascx.cs" Inherits="BigDogShop.Web.UserControl.HeaderNav" %>
<%@ OutputCache Duration="20" VaryByParam="none" Shared="true" VaryByCustom="browser" %>
<div class="nav_container">
    <span id="nav">全部商品分类</span>
    <!--所有菜单-->
    <div class="allsort_box">
        <ul id="sort_lists">
            <asp:Repeater ID="rpt_menu_category" runat="server" OnItemDataBound="rpt_menu_category_ItemDataBound">
                <ItemTemplate>
                    <li class="sort_color">
                        <span class="bg_gray" id="<%#Eval("Type_Id") %>">
                            <asp:Repeater ID="rpt_menu_category_list" runat="server">
                                <ItemTemplate>
                                    <a href="#"><%#Eval("Category_Name") %>,</a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </span>
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

    </div>
    缓存菜单测试(20秒):<asp:Label ID="lbl_time" runat="server"></asp:Label>
</div>
