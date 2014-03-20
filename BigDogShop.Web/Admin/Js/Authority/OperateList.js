$(function () {
    $("#data").datagrid({
        title: "基本操作列表",
        fit: true,
        width: 965,
        height: 550,
        nowrap: true,
        autoRowHeight: false,
        url: '/Admin/Handler/Authority/OperateList.ashx?type=GetList',
        idField: 'Id',
        striped: true,
        //frozenColumns: [[{ field: 'Id', checkbox: true }]],
        columns: [[
                { field: 'ck', checkbox: true, rowspan: 2 },
                { field: 'Id', title: '操作ID', width: 120, rowspan: 3 },
                {
                    field: 'Name', title: '操作名称', width: 120, rowspan: 3, sortable: true,
                    sorter: function (a, b) {
                        return (a > b ? 1 : -1);
                    }
                },
                { field: 'Description', title: '操作说明', width: 120, rowspan: 3 },
                { field: 'Created_Date', title: '创建时间', width: 150, rowspan: 2 }
        ]],
        pagination: true,
        rownumbers: true,
    });
});