<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysList.aspx.cs" Inherits="BigDogShop.Web.Admin.Authority.SysList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Styles/themes/default/easyui.css" rel="stylesheet" />
    <link href="../Styles/themes/icon.css" rel="stylesheet" />
    <script src="../../Js/jquery-1.4.2.min.js"></script>
    <script src="../Js/jquery.easyui.min.js"></script>
    <script src="../Js/SysList.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <!--datagrid-->
        <table id="data" toolbar="#dlg-toolbar"></table>
        <div id="dlg-toolbar">
            <span>系统管理员名称:</span>
            <input id="txt_search" style="line-height: 20px; border: 1px solid #ccc">
            <a href="#" id="btnSearch" class="easyui-linkbutton" plain="true" iconcls="icon-search">查询</a>
            <a href="#" id="btnAdd" class="easyui-linkbutton" plain="true" iconcls="icon-add">添加</a>
            <a href="#" id="btnEdit" class="easyui-linkbutton" plain="true" iconcls="icon-edit">编辑</a>
            <a href="#" class="easyui-linkbutton" plain="true" iconcls="icon-details" onclick="javascript:alert('Ok')">详细</a>
            <a href="#" id="btnDel" class="easyui-linkbutton" plain="true" iconcls="icon-remove">删除</a>
        </div>

        <!--添加-->
        <div id="dialog_add" class="easyui-dialog" style="padding: 5px; width: 500px; height: 300px;"
            title="添加系统管理员" iconcls="icon-ok" buttons="#dlg-buttonsAdd" closed="true" modal="true">
            <table>
                <tr>
                    <td>管理员昵称</td>
                    <td>
                        <asp:TextBox ID="txt_user_name" name="name" runat="server" />
                    </td>

                    <td>管理员姓名</td>
                    <td>
                        <asp:TextBox ID="txt_real_name" name="name" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>密码</td>
                    <td>
                        <asp:TextBox ID="txt_pwd" name="desc" runat="server" />
                    </td>
                    <td>E_Mail</td>
                    <td>
                        <asp:TextBox ID="txt_e_mail" name="desc" runat="server" />
                    </td>
                    
                </tr>
                <tr>
                    <td>头像</td>
                    <td>
                        <img id="img_user" alt="用户头像" />
                        <input type="file" id="fileToUpload"  />
                    </td>
                </tr>

            </table>
        </div>
        <div id="dlg-buttonsAdd">
            <a href="#" id="btnSubmitAdd" class="easyui-linkbutton" iconcls="icon-ok">添加</a>
            <a href="#" id="btnCancelAdd" class="easyui-linkbutton" iconcls="icon-cancel">取消</a>
        </div>

        <!--编辑-->
        <div id="dialog_edit" class="easyui-dialog" style="padding: 5px; width: 400px; height: 200px;"
            title="编辑管理员" iconcls="icon-edit" buttons="#dlg-buttonsEdit" closed="true" modal="true">
            <table>
                <tr>
                    <td>管理员ID</td>
                    <td>
                        <asp:TextBox ID="txt_eid" name="name" runat="server"></asp:TextBox></td>

                </tr>
                <tr>
                    <td>管理员名称</td>
                    <td>
                        <asp:TextBox ID="txt_ename" name="name" runat="server"></asp:TextBox></td>

                </tr>
                <tr>
                    <td>说明</td>
                    <td>
                        <asp:TextBox ID="txt_edesc" type="text" name="desc" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="dlg-buttonsEdit">
            <a href="#" id="btnSubmitEdit" class="easyui-linkbutton" iconcls="icon-ok">更新</a>
            <a href="#" id="btnCancelEdit" class="easyui-linkbutton" iconcls="icon-cancel">取消</a>
        </div>

    </form>
</body>
</html>
