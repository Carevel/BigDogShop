<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="BigDogShop.Web.Admin.Products.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/Base.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="nav">商品管理 > 商品列表</div>
        <div class="tool_bar">
            <a href="javascript:void(0);" onclick="checkAll(this);" class="tool_btn">
                <span>
                    <b class="add">添加</b>
                </span>
            </a>
            <a href="javascript:void(0);" onclick="checkAll(this);" class="tool_btn">
                <span>
                    <b class="all">全选</b>
                </span>
            </a>
            <a href="javascript:void(0);" onclick="checkAll(this);" class="tool_btn">
                <span>
                    <b class="del">批量删除</b>
                </span>
            </a>
             <div class="search_box">
                 <input id="Text1" type="text" runat="server" class="search_input" />
                 <asp:Button ID="btn_search" runat="server" text="搜索" />
             </div>
        </div>
       <div class="select_box">
           <span>请选择</span>
           <asp:DropDownList ID="ddl_user_type" runat="server">
               <asp:ListItem Selected="True" Value="">所有会员</asp:ListItem>
               <asp:ListItem Value="C">普通会员</asp:ListItem>
               <asp:ListItem value="V">Vip会员</asp:ListItem>
           </asp:DropDownList>
       </div>
       <div class="data_list">
           <asp:Repeater ID="rpt_data_list" runat="server">

           </asp:Repeater>
       </div>
    </div>
    </form>
</body>
</html>
