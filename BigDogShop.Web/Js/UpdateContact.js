$(document).ready(function () {
    $("#btn_upload").click(function () {
        $.ajaxFileUpload({
            url: 'Handler/UploadContact.ashx',
            secureuri: false,
            fileElementId: 'fileToUpload',
            dataType: 'json',
            success: function (data) {
                //var dataObj = eval(data);
                if (data.stauts == "1") {
                    $("#user_photo").attr("src", "~/uploadImage/user/" + data.fielname);
                    alert("上传成功");
                }
                else {
                    alert("上传失败");
                }
            }
        });
    });
});
