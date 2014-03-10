$(document).ready(function () {
    $(".del").click(function () {
        var id = $(this).attr("id");
        $("#tempId").val(id);
        //var ckArr = document.getElementsByName("ck");
        //for (var i = 0; i < ckArr.length; i++)
        //{
        //    if (ckArr[i].checked == true)
        //    {
        //        $("#tempId").val($("#tempId").val() + ckArr[i].value+',');
        //    }
        //}
        //alert($("#tempId").val());
    });
});