<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RightList.aspx.cs" Inherits="BigDogShop.Web.Admin.Authority.RightList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/themes/default/easyui.css" rel="stylesheet" />
    <link href="../Styles/themes/icon.css" rel="stylesheet" />
    <script src="../Js/jquery-2.1.0.js"></script>
    <script src="../Js/jquery.easyui.min.js"></script>
    <script src="../Js/Authority/RightManager.js"></script>
</head>
<body>
    <!--datagrid-->
    <div region="center" style="width: 330px; height: 630px; float: left;" border="false" class="easyui-layout">
        <table id="data" toolbar="#dlg-toolbar"></table>
        <div id="dlg-toolbar">
            <span>角色名称:</span>
            <input id="txt_search" style="line-height: 20px; border: 1px solid #ccc">
            <a href="#" id="btnSearch" class="easyui-linkbutton" plain="true" iconcls="icon-search">查询</a>
        </div>
    </div>
    <div style="float: left; margin-left: 10px;">
        <div title="菜单模块" style="width: 280px; height: 630px; padding: 10px 20px 20px 10px;" class="easyui-panel">
            <table id="data_menu" style="margin-left: 5px;"></table>
        </div>
    </div>

    <div style="float: left; margin-left: 10px;">
        <div title="角色权限" style="width: 330px; height: 630px;" class="easyui-panel">
            <table id="data_right" style="margin-left: 5px;"></table>
        </div>
    </div>


</body>
</html>
