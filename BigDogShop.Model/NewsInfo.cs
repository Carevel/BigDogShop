using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDogShop.Model
{
    public class NewsInfo : BaseModel
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public int Father_Id { get; set; }
        public string Description { get; set; }
        public string Image_Url { get; set; }
        public string Link_Url { get; set; }
    }
}
