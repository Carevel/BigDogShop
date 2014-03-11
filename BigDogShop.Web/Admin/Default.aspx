<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BigDogShop.Web.Admin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/Base.css" rel="stylesheet" />
    <script type="text/javascript" src="../Js/jquery-1.4.2.min.js"></script>
    <script src="Js/Tree.js"></script>
    <script src="../Js/Effact/GeneralFramework.js"></script>
    <%--<script type="text/javascript" src="Js/Tree2.js"></script>--%>
    <%--<script src="Js/tree_menu.js"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <Admin:Ad ID="ad1" runat="server" />   
        <div class="content">
            <div class="TreeMenu">
                <div class="l-layout-header">
                    <div class="l-layout-header-toogle"></div>
                    <div class="l-layout-header-text">管理菜单</div>
                </div>
                <div class="l-layout-content">
                    <div class="l-layout-member">
                        <div class="tree"></div>
                    </div>
                </div>
            </div>
            <div class="framecontainer" style="width:1000px;min-width:800px;">        
              <iframe id="sysContent" width="1000" height="800" frameborder="0" src="ManagerCenter.aspx" ></iframe>
            </div>
        </div>
    </form>
</body>
</html>
