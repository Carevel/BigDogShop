<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="测试滑动js.aspx.cs" Inherits="BigDogShop.Web.测试滑动js" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Js/jquery-1.4.1.min.js"></script>
    <script src="Js/Effact/GeneralFramework.js"></script>
    <style type="text/css">
        #slideBox
        {
            width: 680px;
            height: 150px;
            background: #ccc;
            margin-left:auto;
            margin-right:auto;
        }

            #slideBox ul
            {
                padding: 0px;
                margin: 0px;
                position: absolute;
            }

                #slideBox ul li
                {
                    position:relative;
                    list-style: none;
                    float: left;
                    width: 680px;
                    height: 150px;
                }
    </style>
    <script type="text/javascript">
        window.onload = function () {
            var timer = null;
            var Objli = document.getElementsByClassName('slidepic');
            var oDiv = document.getElementById("slideBox");
            oDiv.style.width = "3400px";
            function slide() {
                var picBox = document.getElementById("picBox");

                //picBox =picBox+ picBox;
     
                var slideBox = document.getElementById("slideBox");
                picBox.style.left = picBox.offsetLeft - 1 + "px";
                if (picBox.offsetLeft == 0) {
                    //picBox.style.left = "12px";
                    //startMove(picBox, 'left', 120);
                    clearInterval(timer);
                }
            }
            for (var i = 0; i < Objli.length; i++) {
                Objli[i].onmouseover = function () {
                    clearInterval(timer);
                };
                Objli[i].onmouseout = function () {
                    timer = setInterval(slide, 50);
                };
            }
            timer = setInterval(slide, 50);


        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="slideBox">
                <ul id="picBox">
                    <li class="slidepic"><a href="#">
                        <img src="Images/Rotate/Slide/1.jpg" /></a></li>
                    <li class="slidepic"><a href="#">
                        <img src="Images/Rotate/Slide/2.jpg" /></a></li>
                    <li class="slidepic"><a href="#">
                        <img src="Images/Rotate/Slide/3.jpg" /></a></li>
                    <li class="slidepic"><a href="#">
                        <img src="Images/Rotate/Slide/4.jpg" /></a></li>
                    <li class="slidepic"><a href="#">
                        <img src="Images/Rotate/Slide/5.jpg" /></a></li>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
