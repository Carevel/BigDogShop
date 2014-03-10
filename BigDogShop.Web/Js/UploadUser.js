$(document).ready(function () {
    $("#btn_upload").click(function () {
        $.ajaxFileUpload({
            url: 'Handler/UploadUser.ashx',
            secureuri: false,
            fileElementId: 'fileToUpload',
            dataType: 'json',
            success: function (data) {
                var dataObj = eval(data);
                if (dataObj.status == "1") {
                    //alert(data.filePath);
                    //alert($("#user_photo").attr("src"));
                    $("#user_photo").attr("src", "~/UploadImage/User/" + dataObj.filePath + "");
                    alert($("#user_photo").attr("src"));
                    alert("上传成功");
                }
                else {
                    alert("上传失败");
                }
            }
        });
    });
   
});
