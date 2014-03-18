$(function () {
    //$.ajax({
    //    type: 'post',
    //    url: '/Admin/Authority/SysList.aspx/GetList',
    //    data:"{'user_name':'a'}",
    //    contentType: 'application/json',
    //    success: function (data)
    //    {
    //        alert('a');
    //    }
    //});
    $("#data").datagrid({
        title: "角色列表",
        width: 965,
        height: 550,
        nowrap: true,
        method:'post',
        autoRowHeight: false,
        url: '/Admin/Handler/Authority/SysList.ashx',
        idField: 'Id',
        striped: true,
        columns: [[
                { field: 'ck', checkbox: true, rowspan: 2 },
                { field: 'Id', title: '用户Id', width: 150, rowspan: 2 },
                { field: 'User_Photo_Url', title: '用户头像', width: 150, rowspan: 2 },
                {
                    field: 'User_Name', title: '名称', width: 120, rowspan: 3, sortable: true,
                    sorter: function (a, b) {
                        return (a > b ? 1 : -1);
                    }
                },
                { field: 'Real_Name', title: '真实姓名', width: 120, rowspan: 3 },

                { field: 'E_Mail', title: 'E_Mail', width: 150, rowspan: 2 },
                { field: 'Is_Lock', title: '是否锁定', width: 150, rowspan: 2 }
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
        $("#dialog_add").dialog('open');
    });
    $("#btnSubmitAdd").click(function () {
        var user_name = $("#txt_user_name").val();
        var real_name = $("#txt_real_name").val();
        var password = $("#txt_pwd").val();
        var e_mail = $("#txt_e_mail").val();
        $.ajax({
            type: 'post',
            url: '/Admin/Authority/SysList.aspx/Add',
            data: "{'user_name':'" + user_name + "','real_name':'" + real_name + "','password':'" + password + "','e_mail':'"+e_mail+"'}",
            contentType: 'application/json',
            datatype: 'json',
            success: function (data) {
                var json = eval(data.d)[0];
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
        $("#txt_id").val("");
        $("#txt_name").val("");
        $("#txt_desc").val("");
        $("#dialog_add").dialog('close');
    });
    $("#btnDel").click(function () {
        var usernames="";
        var rows = $("#data").datagrid('getChecked');
        for (var i = 0; i < rows.length; i++)
        {
            usernames = usernames + rows[i].User_Name + ",";
        }
        usernames = usernames.substring(0, id.length - 1);
        //var id = row.Id;
        if (row) {
            $.messager.confirm("提示信息", "确定要删除吗？", function (r) {
                if (r) {
                    $.ajax({
                        type: "post",
                        url: "/Admin/Authority/SysList.aspx/Delete",
                        contentType: "application/json",
                        data: "{'usernames':'" + usernames + "'}",
                        success: function (result) {
                            var s = $.parseJSON(result.d)[0];
                            if (s.success) {
                                $.messager.show({
                                    title: '操作提示',
                                    msg: '操作成功.'
                                });
                                $("#data").datagrid('reload');
                            }
                            else {
                                $.messager.show({
                                    title: '发生错误',
                                    msg: result.errorMsg
                                });
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
                url: "/Admin/Authority/SysList.aspx/GetById",
                contentType: "application/json",
                data: "{'id':'" + id + "'}",
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
            url: "/Admin/Authority/SysList.aspx/Update",
            contentType: "application/json",
            data: "{'id':'" + id + "','name':'" + name + "','desc':'" + desc + "'}",
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