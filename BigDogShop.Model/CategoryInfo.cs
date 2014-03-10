using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigDogShop.Model
{
    public class CategoryInfo:BaseModel
    {
        public string Category_Name { get; set; }
        public int Type_Id { get; set; }
        public int Father_Id { get; set; }
        public string Link_Url { get; set; }
        public string Description { get; set; }
        public string Seo_Name { get; set; }
        public string Seo_KeyWords { get; set; }
        public string Seo_Description { get; set; }
    }
}
