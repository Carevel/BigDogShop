$(function () {
    $('#form1').form({
        onSubmit: function () {
            return $(this).form('validate');
        },
        success: function (data) {
            $.messager.alert('Info', data, 'info');
        }
    });
    $("#data").datagrid({
        title: "角色列表",
        fit: true,
        //width: 965,
        //height: 550,
        nowrap: true,
        autoRowHeight: false,
        url: '/Admin/Handler/Authority/RoleList.ashx?type=GetList',
        idField: 'Id',
        striped: true,
        //frozenColumns: [[{ field: 'Id', checkbox: true }]],
        columns: [[
                { field: 'ck', checkbox: true, rowspan: 2 },
                { field: 'Id', title: '角色ID', width: 120, rowspan: 3 },
                {
                    field: 'Name', title: '角色名称', width: 120, rowspan: 3, sortable: true,
                    sorter: function (a, b) {
                        return (a > b ? 1 : -1);
                    }
                },
                { field: 'Description', title: '说明', width: 120, rowspan: 3 },
                { field: 'Created_Date', title: '创建时间', width: 150, rowspan: 2 },
                { field: 'Created_Date', title: '下属管理员', width: 150, rowspan: 2 }
        ]],
        pagination: true,
        rownumbers: true,
    });
    $("#btnSearch").click(function () {
        var name = $("#txt_search").val();
        $("#data").datagrid('reload', {
            Name: name
        });
    });
    $("#btnAdd").click(function () {
        $("#txt_id").val("");
        $("#txt_name").val("");
        $("#txt_desc").val("");
        $("#dialog_add").dialog('open');
    });
    $("#btnSubmitAdd").click(function () {
        var id = $("#txt_id").val();
        var name = $("#txt_name").val();
        var desc = $("#txt_desc").val();
        $.ajax({
            type: 'post',
            url: '/Admin/Authority/RoleList.aspx/Add',
            //data: "{'name':'" + name + "','desc':'" + desc + "','id':'" + id + "'}",
            data: { name: name, id: id, desc: desc },
            contentType: 'application/json',
            datatype: 'json',
            success: function (data) {
                $.messager.alert('操作提示', '操作成功!');
                $("#dialog_add").dialog('close');
                $("#data").datagrid('reload');
            },
            error: function (err) {
                $.messager.alert('操作提示', '操作失败!');
            }
        });
    });
    $("#btnCancelAdd").click(function () {
        $("#dialog_add").dialog('close');
    });
    $("#btnDel").click(function () {
        var id = "";
        var row = $("#data").datagrid('getChecked');
        for (var i = 0; i < row.length; i++) {
            id = id + row[i].Id + ",";
        }
        id = id.substr(0, id.length - 1);
        //var id = row.Id;
        if (row) {
            $.messager.confirm("提示信息", "确定要删除吗？", function (r) {
                if (r) {
                    $.ajax({
                        type: "post",
                        url: "/Admin/Authority/RoleList.aspx/Delete",
                        contentType: "application/json",
                        //data: "{'id':'" + id + "'}",
                        data: { id: id },
                        success: function (result) {
                            var s = $.parseJSON(result.d)[0];
                            if (s.success) {
                                $.messager.show({
                                    title: '操作提示',
                                    msg: '操作成功.'
                                });
                                $("#data").datagrid('clearSelections');
                                $("#data").datagrid('reload');
                            }
                            else {
                                $.messager.show({
                                    title: '发生错误',
                                    msg: result.errorMsg
                                });
                                $("#data").datagrid('clearSelections');
                                $("#data").datagrid('reload');
                            }
                        }
                    });
                }
            });
        }
    });
    $("#btnEdit").click(function () {
        var row = $("#data").datagrid("getSelected");
        if (row) {
            $("#dialog_edit").dialog('open');
            var id = row.Id;
            $.ajax({
                type: "post",
                url: "/Admin/Authority/RoleList.aspx/GetById",
                contentType: "application/json",
                //data: "{'id':'" + id + 
                data: { id: id },
                datatype: "json",
                success: function (data) {
                    var a = $.parseJSON(data.d)[0];
                    $("#txt_eid").val(a.Id);
                    $("#txt_ename").val(a.Name);
                    $("#txt_edesc").val(a.Description);
                    $("#dialog_edit").dialog('open');
                }
            });
        }
        else {
            $.messager.alert("操作提示", "请选择一项!");
        }
    });
    $("#btnCancelEdit").click(function () {
        $("#txt_id").val("");
        $("#txt_name").val("");
        $("#txt_desc").val("");
        $("#dialog_edit").dialog('close');
    });
    $("#btnSubmitEdit").click(function () {
        var id = $("#txt_eid").val();
        var name = $("#txt_ename").val();
        var desc = $("#txt_edesc").val();
        $.ajax({
            type: "post",
            url: "/Admin/Authority/RoleList.aspx/Update",
            contentType: "application/json",
            //data: "{'id':'" + id + "','name':'" + name + "','desc':'" + desc + "'}",
            data: { id: id, name: name, desc: desc },
            datatype: "json",
            success: function (data) {
                var s = $.parseJSON(result.d)[0];
                if (s.success) {
                    $.messager.show({
                        title: '操作提示',
                        msg: '操作成功.'
                    });
                    $("#data").datagrid('clearSelections');
                    $("#data").datagrid('reload');
                }
                else {
                    $.messager.show({
                        title: '发生错误',
                        msg: result.errorMsg
                    });
                    $("#data").datagrid('clearSelections');
                    $("#data").datagrid('reload');
                }
            }
        });
    });
});