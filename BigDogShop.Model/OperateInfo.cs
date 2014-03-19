using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDogShop.Model
{
    public class OperateInfo:BaseModel
    {
        public string Operate_Name { get; set; }
        public string Key_Code { get; set; }
        public string Menu_Id { get; set; }
        public string Enabled { get; set; }
        public int Sort_Id { get; set; }
    }
}
