using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDogShop.Model
{
    public class ServiceInfo:BaseModel
    {
        public string Service_Name { get; set; }
        public int Father_Id { get; set; }
        public string Description { get; set; }
        public string Service_Url { get; set; }
        
    }
}
