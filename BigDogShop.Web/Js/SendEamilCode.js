$(document).ready(function () {
    var emailCode;
    $("#btn_send_email").click(function () {
        $.ajax({
            type: "get",
            dataType: "text",
            url: "Handler/GetEmailCode.ashx",
            success: function (data) {
                var dataObj = eval(data);
                $("#temp_code").val(dataObj[0].code);
                alert('邮件已发送到您的邮箱！');
            },
            error: function (data) {
                alert("发生错误！");
            }
        });
    });
    $("#btn_submit").click(function () {
        if ($("#txt_email_code").val() != $("#temp_code").val()) {
            alert("您输入的邮件验证码不正确");
            return false;
        }
        if ($("#txt_ckcode").val() == "") {
            alert('输入验证码');
            return false;
        }

    });
});