$(function () {
    $("#data").datagrid({
        title: "系统管理员列表",
        fit: true,
        nowrap: true,
        //fitColumns:true,
        method: 'post',
        loadMsg: '加载中...',
        width:600,
        autoRowHeight: false,
        url: '/Admin/Handler/Authority/SysList.ashx?type=GetList',
        idField: 'Id',
        striped: true,
        columns: [[
                { field: 'ck', checkbox: true, rowspan: 2 },
                { field: 'Id', title: 'Id', width: 150, rowspan: 2 },
                { field: 'User_Photo_Url', title: '头像', width: 150, rowspan: 2 },
                {
                    field: 'User_Name', title: '名称', width: 120, rowspan: 3, sortable: true,
                    sorter: function (a, b) {
                        return (a > b ? 1 : -1);
                    }
                },
                { field: 'E_Mail', title: 'E_Mail', width: 150, rowspan: 2 },
                { field: 'Is_Lock', title: '是否锁定', width: 150, rowspan: 2 }
        ]],
        pagination: true,
        rownumbers: true,
    });
    $('#txt_e_mail').validatebox({
        required: true,
        validType: 'email'
    });
    $("#btnSearch").click(function () {
        var name = $("#txt_search").val();
        $("#data").datagrid('reload', {
            Name: name
        });
    });
    $("#btnAdd").click(function () {
        $("#dialog_add").dialog('open');
    });
    $("#btnSubmitAdd").click(function () {
        var user_name = $("#txt_user_name").val();
        var password = $("#txt_pwd").val();
        var e_mail = $("#txt_e_mail").val();
        //var data = ;
        $.ajax({
            type: 'post',
            url: '/Admin/Handler/Authority/SysList.ashx?type=Add',
            //contentType: 'application/json',
            //data: { user_name: user_name },
            //data:'user_name='+user_name+'&password='+password+'&e_mail'+e_mail,
            data: { user_name: user_name, password: password, e_mail: e_mail },
            datatype: 'json',
            success: function (data) {
                var json = eval(data)[0];
                $.messager.show({
                    title: '操作提示',
                    msg: '操作成功.'
                });
                $("#dialog_add").dialog('close');
                $("#data").datagrid('clearSelections');
                $("#data").datagrid('reload');
            },
            error: function (err) {
                $.messager.alert('操作提示', '操作失败!');
            }
        });
    });
    $("#btnCancelAdd").click(function () {
        $("#txt_id").val("");
        $("#txt_name").val("");
        $("#txt_desc").val("");
        $("#dialog_add").dialog('close');
    });
    $("#btnDel").click(function () {
        var ids = "";
        var rows = $("#data").datagrid('getChecked');
        if (rows.length == 0) {
            $.messager.alert("操作提示", "请选择要删除的项");
            return false;
        }
        for (var i = 0; i < rows.length; i++) {
            ids = ids + rows[i].Id + ",";
        }
        ids = ids.substring(0, ids.length - 1);
        if (rows) {
            $.messager.confirm("提示信息", "确定要删除吗？", function (r) {
                if (r) {
                    $.ajax({
                        type: "get",
                        url: "/Admin/Handler/Authority/SysList.ashx?type=Delete",
                        contentType: "application/json",
                        data: { ids: ids },
                        datatype: "json",
                        success: function (result) {
                            var s = $.parseJSON(result)[0];
                            if (s.success) {
                                $.messager.show({
                                    title: '操作提示',
                                    msg: '操作成功.'
                                });
                                $("#data").datagrid('reload');
                                $("#data").datagrid('clearSelections');
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
        $("#txt_id").val("");
        $("#txt_name").val("");
        $("#txt_desc").val("");
        var rows = $("#data").datagrid("getChecked");
        if (rows.length > 1) {
            $.messager.alert("操作提示", "只能选择一项进行编辑.");
            return false;
        }
        if (rows.length == 0)
        {
            $.messager.alert("操作提示", "请选择一项进行编辑.");
            return false;
        }
        if (rows) {
            $("#dialog_edit").dialog('open');
            var id = rows.Id;
            $.ajax({
                type: "post",
                url: "/Admin/Handler/Authority/SysList.ashx?type=GetById",
                contentType: "application/json",
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
    });
    $("#btnCancelEdit").click(function () {  
        $("#dialog_edit").dialog('close');
    });
    $("#btnSubmitEdit").click(function () {
        var id = $("#txt_eid").val();
        var name = $("#txt_ename").val();
        var desc = $("#txt_edesc").val();
        $.ajax({
            type: "post",
            url: "/Admin/Handler/Authority/SysList.ashx?type=Update",
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
    $("#btnDetail").click(function () {
        $("#txt_id").val("");
        $("#txt_name").val("");
        $("#txt_desc").val("");
        var rows = $("#data").datagrid("getChecked");
        if (rows.length > 1) {
            $.messager.alert("操作提示", "只能选择一项显示详细.");
            return false;
        }
        if (rows.length == 0) {
            $.messager.alert("操作提示", "请选择一项显示详细.");
            return false;
        }
        if (rows) {
            $("#dialog_edit").dialog('open');
            var id = rows.Id;
            $.ajax({
                type: "post",
                url: "/Admin/Handler/Authority/SysList.ashx?type=GetById",
                contentType: "application/json",
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
    });
});
