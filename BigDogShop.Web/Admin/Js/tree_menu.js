$(document).ready(function () {
    var id = 0;
    initTree(id);
});
function initTree(id)
{
    $.ajax({
        type: 'post',
        url: 'Handler/GlobalTree.ashx',
        data: "father_id=" + id,
        dataType: 'html',
        success: function (data) {
            $(".tree_div").append(data);
        }
    });
}
function getList(father_id)
{
    $.ajax({
        type: 'post',
        url: 'Handler/GlobalTree.ashx',
        data: "father_id=" + father_id,
        dataType: 'html',
        success: function (data) {
            $("li[id='"+father_id+"']").append(data);
        }
    });
}