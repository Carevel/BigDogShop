<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="BigDogShop.Web.Admin.Advertisement.List" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <h3>广告列表</h3>
        <div class="a_container">
            <div class="btn_group">
                <div class="search_toolbar">
                    <table>
                        <tr>
                            <td>广告名</td>
                            <td>
                                <asp:TextBox ID="txt_ad_title" runat="server"></asp:TextBox></td>
                            <td>广告类型</td>
                            <td>
                                <asp:DropDownList ID="ddl_ad_type" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>是否发布</td>
                            <td>
                                <asp:DropDownList ID="ddl_ad_enabled" runat="server">
                                    <asp:ListItem Value="" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="Y">Y</asp:ListItem>
                                    <asp:ListItem Value="N">N</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btn_search" runat="server" CssClass="btn" Text="搜索" OnClick="btn_search_Click" />
                            </td>
                            <td>
                                <asp:Button ID="btn_add" runat="server" CssClass="btn" Text="添加广告" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="btn_toolbar">
                    <asp:Button ID="btn_import" runat="server" CssClass="btn" Text="批量导入" />
                    <asp:Button ID="btn_operate" runat="server" CssClass="btn" Text="批量删除" />
                    <asp:Button ID="btn_port" runat="server" CssClass="btn" Text="批量导出" />
                </div>
            </div>
            <div class="data_container" id="data_container">
                <table class="tab_info">
                    <thead>
                        <tr>
                            <td>
                                <input type="checkbox" name="ck" title="全选/全不选" /></td>
                            <td>广告标题</td>
                            <td>广告链接</td>
                            <td>广告类型</td>
                            <td>是否发布</td>
                            <td>基本操作</td>
                        </tr>
                    </thead>
                    <asp:Repeater ID="rpt_ad" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input type="checkbox" id="ckbox" name="ck" />
                                </td>
                                <td>
                                    <%#Eval("Title") %>
                                </td>
                                <td>
                                    <%#Eval("Link_Url") %>
                                </td>
                                <td>
                                    <%#Eval("Meaning") %>
                                </td>
                                <td>
                                    <%#Eval("Enabled") %>
                                </td>
                                <td>
                                    <a href='<%#String.Format("Advertisement_Update.aspx?id={0}",Eval("Ad_Id") )%>'>
                                        <img src="../../Images/Icons/document_a4_edit.png" alt="编辑" title="编辑" /></a>&nbsp;
                                    <a href='<%#String.Format("Advertisement_Update.aspx?id={0}",Eval("Ad_Id") )%>'>
                                        <img src="../../Images/Icons/ico_delete_16.png" alt="删除" title="删除" /></a>&nbsp;
                                    <a href='<%#String.Format("Advertisement_Update.aspx?id={0}",Eval("Ad_Id") )%>'>
                                        <img src="../../Images/Icons/zoom.png" alt="查看" title="查看" /></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div id="lab_mess" runat="server" style="display: none;">
                暂无数据
            </div>
            <div class="pageStyle">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" OnPageChanged="AspNetPager1_PageChanged" PageSize="2"></webdiyer:AspNetPager>
            </div>
        </div>
        <asp:Button ID="btn_edit" runat="server" Style="display: none" OnClick="btn_edit_Click" />
        <asp:Button ID="btn_delete" runat="server" Style="display: none" OnClick="btn_delete_Click" />
        <asp:Button ID="btn_show" runat="server" Style="display: none" OnClick="btn_show_Click" />
    </form>
</body>
</html>
