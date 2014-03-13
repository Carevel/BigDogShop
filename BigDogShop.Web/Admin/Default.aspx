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
        <div class="easyui-layout" style="width:1200px; height: 600px; margin-left:auto;margin-right:auto;">
            <div region="west" split="true" title="管理菜单" style="width: 200px">
                <p style="padding: 5px; margin: 0;">选择一个菜单:</p>
                <ul id="tt" class="easyui-tree">
                </ul>
            </div>
            <div data-options="region:'center',border:false">
                <div id="tabContainer" class="easyui-tabs" data-options="fit:true">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
