<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BigDogShop.Web.Admin.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/themes/default/easyui.css" rel="stylesheet" />
    <link href="Styles/themes/icon.css" rel="stylesheet" />
    <%--<script src="Js/jquery.min.js"></script>--%>
    <script src="Js/jquery-2.1.0.js"></script>
    <script src="Js/jquery.easyui.min.js"></script>
    <script src="Js/index.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="easyui-layout" style="width: 1200px;height: 400px; margin-left:auto;margin-right:auto;" >
            <div region="west" split="true" title="Navigator" style="width: 200px">
                <p style="padding: 5px; margin: 0;">Select language:</p>
                <ul id="tt" class="easyui-tree"></ul>
            </div>
            <div  data-options="region:'center',border:false"  >
                <div id="tabContainer" class="easyui-tabs" data-options="fit:true">
                </div>
            </div>
        </div>


        <div class="easyui-layout" style="width: 400px; height: 200px;">
            <div region="west" split="true" title="Navigator" style="width: 150px;">
                <p style="padding: 5px; margin: 0;">Select language:</p>
                <ul>
                    <li><a href="javascript:void(0)" onclick="showcontent('java')">Java</a></li>
                    <li><a href="javascript:void(0)" onclick="showcontent('cshape')">C#</a></li>
                    <li><a href="javascript:void(0)" onclick="showcontent('vb')">VB</a></li>
                    <li><a href="javascript:void(0)" onclick="showcontent('erlang')">Erlang</a></li>
                </ul>
            </div>
            <div id="content" region="center" title="Language" class="easyui-tabs" style="padding: 5px;">
            </div>
        </div>
    </form>
</body>
</html>
