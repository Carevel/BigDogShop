<%@ Page Language="C#" AutoEventWireup="true" Inherits="Admin_Default" Codebehind="Index.aspx.cs" %>

<%@ Register TagPrefix="Admin" TagName="Ad" Src="UserControl/Admin.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="Styles/Base.css" rel="stylesheet" />
    <script type="text/javascript" src="../Js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="Js/Tree2.js"></script>
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
                    <div class="l-accordion-header">
                    </div>
                    <div class="l-layout-member">
                        <div class="tree_div"></div>
                    </div>
                </div>
            </div>
            <div class="framecontainer">
                <iframe id="frameContent" style="float: left;" frameborder="0" runat="server" width="1000" height="600"></iframe>
            </div>
        </div>
    </form>
</body>
</html>




