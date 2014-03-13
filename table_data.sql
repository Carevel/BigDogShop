delete from BigDog_Admin_Operate

INSERT INTO [BigDog_Admin_Operate] ([Id],[Operate_Name],[Key_Code],[Menu_Id],[Enabled],[Sort_Id]) values ('Create','創建','Create','BaseSample',0,0)
INSERT INTO [BigDog_Admin_Operate] ([Id],[Operate_Name],[Key_Code],[Menu_Id],[Enabled],[Sort_Id]) values ('Delete','删除','Delete','BaseSample',0,0)
INSERT INTO [BigDog_Admin_Operate] ([Id],[Operate_Name],[Key_Code],[Menu_Id],[Enabled],[Sort_Id]) values ('Details','详细','Details','BaseSample',0,0)
INSERT INTO [BigDog_Admin_Operate] ([Id],[Operate_Name],[Key_Code],[Menu_Id],[Enabled],[Sort_Id]) values ('Edit','编辑','Edit','BaseSample',0,0)
INSERT INTO [BigDog_Admin_Operate] ([Id],[Operate_Name],[Key_Code],[Menu_Id],[Enabled],[Sort_Id]) values ('Export','导出','Export','BaseSample',0,0)
INSERT INTO [BigDog_Admin_Operate] ([Id],[Operate_Name],[Key_Code],[Menu_Id],[Enabled],[Sort_Id]) values ('Query','查询','Query','BaseSample',0,0)
INSERT INTO [BigDog_Admin_Operate] ([Id],[Operate_Name],[Key_Code],[Menu_Id],[Enabled],[Sort_Id]) values ('Save1','保存','Save','BaseSample',0,0)

select * from BigDog_Admin_Operate

INSERT INTO [BigDog_Admin_Right_Operate] ([Id],[Right_Id],[Key_Code],[Enabled]) values ('administratorBaseSampleCreate','administratorBaseSample','Create',1)
INSERT INTO [BigDog_Admin_Right_Operate] ([Id],[Right_Id],[Key_Code],[Enabled]) values ('administratorBaseSampleDelete','administratorBaseSample','Delete',1)
INSERT INTO [BigDog_Admin_Right_Operate] ([Id],[Right_Id],[Key_Code],[Enabled]) values ('administratorBaseSampleDetails','administratorBaseSample','Details',1)
INSERT INTO [BigDog_Admin_Right_Operate] ([Id],[Right_Id],[Key_Code],[Enabled]) values ('administratorBaseSampleEdit','administratorBaseSample','Edit',1)
INSERT INTO [BigDog_Admin_Right_Operate] ([Id],[Right_Id],[Key_Code],[Enabled]) values ('administratorBaseSampleExport','administratorBaseSample','Export',1)
INSERT INTO [BigDog_Admin_Right_Operate] ([Id],[Right_Id],[Key_Code],[Enabled]) values ('administratorBaseSampleQuery','administratorBaseSample','Query',1)
INSERT INTO [BigDog_Admin_Right_Operate] ([Id],[Right_Id],[Key_Code],[Enabled]) values ('administratorBaseSampleSave','administratorBaseSample','Save',1)


select a.USER_ID,a.Role_Id,b.Name,b.Description,c.id,c.module_id,d.Operate_Name
from BigDog_Admin_role_user a,BigDog_Admin_Role b,BigDog_Admin_Right c,BigDog_Admin_Operate d
where a.Role_Id=b.Id and b.Id=c.Role_Id and c.Module_Id=d.Module_Id