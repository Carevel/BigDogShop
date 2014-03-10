using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigDogShop.Model
{
    public class MenuInfo:BaseModel
    {
        public string Menu_Name { get; set; }
        public int Father_Id { get; set; }
        public string Link_Url { get; set; }
        public string Description { get; set; }
    }
}
