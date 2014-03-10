using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigDogShop.Model
{
    public class AdminInfo : BaseModel
    {
        public int Role_Id { get; set; }
        public int Role_Type { get; set; }
        public string User_Name { get; set; }
        public string Real_Name { get; set; }
        public string Password { get; set; }
        public string User_Photo_Url { get; set; }
        public string E_Mail { get; set; }
        public string Is_Lock { get; set; }
    }
}
