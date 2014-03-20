$(document).ready(function () {
    $('#tt').tree({
        url: 'Handler/TreeData.ashx?id=0',
        onBeforeExpand: function (node, param) {
            $('#tt').tree('options').url = "Handler/TreeData.ashx";
        },
        onClick: function (node) {
            var id = node.id;
            var state = node.state;
            var title = node.text;
            var url = node.attributes.url;
            var n = $("#tt").tree("getSelected");
            var pnode = $('#tt').tree('getParent', n.target);
            if (pnode != null && pnode.state == 'open') {
                AddTab(node.text, url);
            }
        }
    });

    function AddTab(title, url) {
        if ($('#tabContainer').tabs('exists', title)) {
            $('#tabContainer').tabs('select', title);
        } else {
            var content = '<iframe scrolling="no" frameborder="0"  src="' + url + '" style="width:100%;height:100%;"></iframe>';
            $('#tabContainer').tabs('add', {
                title: title,
                content: content,
                closable: true
            });
        }
    }
});