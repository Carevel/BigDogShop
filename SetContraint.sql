alter table [dbo].[bigdog_admin_menu] with nocheck add constraint [FK_Admin_Menu]
 foreign key ([Father_Id]) references [dbo].[bigdog_admin_menu] ([Id])

  alter table [dbo].[bigdog_admin_right] drop constraint [FK_Admin_Right_Module]

 alter table [dbo].[bigdog_admin_right_operate] with check add constraint [FK_Admin_Right_Operate_Admin_Menu]
 foreign key([Module_Id]) references [dbo].[bigdog_admin_module]([Id])

 alter table[dbo].[bigdog_admin_role_user] with check add constraint [FK_Admin_Role_User_Role]
 foreign key([Role_Id]) references [dbo].[bigdog_admin_role]([Id])

 alter table[dbo].[bigdog_admin_right] with check add constraint [FK_Admin_Right_Module] 
 foreign key([Menu_Id]) references [dbo].[bigdog_admin_module]([Id])

  alter table[dbo].[bigdog_admin_operate] with check add constraint [FK_Admin_Module_Operate] 
 foreign key([Menu_Id]) references [dbo].[bigdog_admin_module]([Id])

   alter table[dbo].[bigdog_admin_operate] with check add constraint [FK_Admin_Module_Operate] 
 foreign key([Menu_Id]) references [dbo].[bigdog_admin_module]([Id])