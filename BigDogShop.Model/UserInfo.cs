using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDogShop.Model
{
    public class UserInfo:BaseModel 
    {
        public string User_Name { get; set; }
        public string Nick_Name { get; set; }
        public string Real_Name { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
        public string User_Photo_Url { get; set; }
        public DateTime Birthday { get; set; }
        public string Income { get; set; }
        public string Marry_Status { get; set; }
        public string E_Mail { get; set; }
        public string Phone_Number { get; set; }
        public int User_Type { get; set; }
        public string Hobby { get; set; }
        public string Click_Number { get; set; }
        public string Address { get; set; }
        public string School_Type { get; set; }
        public string School { get; set; }
        public string Department { get; set; }
        public string Enrolled_Date { get; set; }
        public string Company_Name { get; set; }
        public string Worked_Begin_Time { get; set; }
        public string Worked_End_Time { get; set; }
        public string Status { get; set; }
        public string Mailed_Key { get; set; }      
    }
}
