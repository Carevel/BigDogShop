<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RightList.aspx.cs" Inherits="BigDogShop.Web.Admin.Authority.RightList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/themes/default/easyui.css" rel="stylesheet" />
    <link href="../Styles/themes/icon.css" rel="stylesheet" />
    <script src="../Js/jquery-2.1.0.js"></script>
    <script src="../Js/jquery.easyui.min.js"></script>
    <script src="../Js/Authority/OperateList.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="easyui-layout">
            <div region="center" style="padding: 5px;" border="false">
                <table id="data"></table>
            </div>
        </div>
    </form>
</body>
</html>
