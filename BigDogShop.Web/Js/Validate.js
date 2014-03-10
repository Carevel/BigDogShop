$(document).ready(function () {
    var name = $("#UserName").val();
    var pwd = $("#Password").val();
    var checkcode = $("#ckcode").val();
    
    //验证码单击事件
    $("#ckcode").click(function () {
        //$(this).src = "Handler/Validate.ashx?r=" + Math.random();
        $(this).attr("src","Handler/Validate.ashx?r=" + Math.random());
    });

    //$("#submit").click(function () {
    //    //if ($("#lbl_ckcode").val() != $("#txt_ckcode").val())
    //    //{
    //    //    alert("验证码不正确");
    //    //    return false;
    //    //}
    //    var arr = document.getElementsByClassName("tx");
    //    for (var i = 0; i < arr.length; i++) {
    //        var option = arr[i];
    //        var vid = option.id;
    //        optObj = $("#" + vid);
    //        if (optObj.val() == "") {
    //            var lf = optObj.offset().left + optObj.width() + 10;
    //            var tp = optObj.offset().top;
    //            var strHtml = "<img id=img" + vid + " src='/Images/Main/attention.png' style='z-index:1000000' title='" + vid + "'>";
    //            var css = { position: "absolute", top: tp + 'px', left: lf + 'px' };
    //            $("#img" + vid).remove();
    //            $(".content").append(strHtml);
    //            $("#img" + vid).css(css);
    //            flag = 'N';
    //        }
    //        else {
    //            $("#img" + vid).remove();
    //        }
    //    }
    //    if (flag == 'N') {
    //        return false;
    //    }
    //}) 
});









