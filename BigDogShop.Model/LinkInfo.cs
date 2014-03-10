using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDogShop.Model
{
    public class LinkInfo:BaseModel
    {
        public string Link_Name { get; set; }
        public string Link_Url { get; set; }
        public string Description { get; set; }
    }
}
