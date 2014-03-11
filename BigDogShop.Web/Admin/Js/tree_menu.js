$(document).ready(function () {

    initTree(0);
    var flag = true;
    //$(".framecontainer").load("Login.aspx");
    var Oli = document.getElementsByClassName('tree_li_header');
    for (var i = 0; i < Oli.length; i++) {
        Oli[i].onclick = function () {
            var id = this.id;
            $.get("Handler/GlobalTree.ashx", { father_id: id }, function (data) {
                if ($("li[id='" + id + "']").children('ul').length <= 0) {
                    $("li[id='" + id + "']").append(data);
                    $("li[id='" + id + "']").children().hide();
                }
                if (flag) {
                    $("li[id='" + id + "']").children().show();
                    flag = false;
                }
                else {
                    $("li[id='" + id + "']").children().hide();
                    flag = true;
                }            
            });
        };
    }

});
function initTree(id) {
    $.ajax({
        type: 'post',
        async: false,
        url: 'Handler/GlobalTree.ashx',
        data: "father_id=" + id,
        dataType: 'html',
        success: function (data) {
            $(".tree_div").append(data);
        }
    });
}
