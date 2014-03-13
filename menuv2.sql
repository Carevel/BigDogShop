select a.id,a.Father_Id,a.Menu_Name,b.Category_Group ,a.Nav_Url
from bigdog_admin_menu a,BigDog_Admin_Menu_Category b where a.Category_Id=b.Category_Id

select a.Id,a.Father_Id,a.Menu_Name,b.Category_Group+'/'+a.Nav_Url url,
(select (case count(1) when '0' then 'false' else 'true' end) from BigDog_Admin_Menu b where a.Id=b.Father_Id) Has_Child 
from BigDog_Admin_Menu a,BigDog_Admin_Menu_Category b where a.Category_Id=b.Category_Id and a.Father_Id=1 