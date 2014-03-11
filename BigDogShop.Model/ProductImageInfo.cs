using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigDogShop.Model
{
    public class ProductImageInfo:BaseModel
    {
        public int Product_Image_Id { get; set; }
        public int Category_Id { get; set; }
        public string Image_Url { get; set; }
        public string Link_Url { get; set; }
        public string Description { get; set; }
        
    }
}
