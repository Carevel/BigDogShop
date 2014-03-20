<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BigDogShop.Web.Admin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/Base.css" rel="stylesheet" />
    <link href="Styles/themes/default/easyui.css" rel="stylesheet" />
    <link href="Styles/themes/icon.css" rel="stylesheet" />
    <script type="text/javascript" src="../Js/jquery-1.4.2.min.js"></script>
    <script src="Js/jquery.easyui.min.js"></script>
    <script src="Js/index.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <Admin:Ad ID="ad1" runat="server" />
        <div class="easyui-layout" style="width:1200px; height: 680px; margin-left:auto;margin-right:auto;">
            <div region="west" split="true" title="管理菜单" style="width: 200px">
                <ul id="tt" class="easyui-tree" style="margin-left:15px; margin-top:20px;">
                </ul>
            </div>
            <div split="true" data-options="region:'center'">
                <div id="tabContainer" class="easyui-tabs" data-options="border:false,fit:true">
                </div>
            </div>
        </div>
        <AdminB:Ab ID="ab1" runat="server" />
    </form>
</body>
</html>
