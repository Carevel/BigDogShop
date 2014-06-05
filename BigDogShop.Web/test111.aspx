<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test111.aspx.cs" Inherits="BigDogShop.Web.test111" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Js/jquery-1.4.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            var a = $("#div3").offsetParent();
            var n = 0;
            var cc = $(a);
            var dd = $("body");
            while (!$(a).is("body"))
            {
                n = n + 1;
                a = a.offsetParent();
            }
            alert($(a).children().first().attr("id"));
            //alert($("html").offsetParent());
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="div1" style="position: absolute; width: 200px; height: 400px; position: absolute; background: red;">
            <div id="div2" style="width: 150px; height: 200px; position: absolute; background: #ccc;">
                <div id="div3" style="position: absolute; width: 100px; height: 100px; position: absolute; background: yellow;">aaa</div>
            </div>
        </div>
        <input type="text" id="testvalue" />
    </form>
</body>
</html>
