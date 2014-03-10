using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigDogShop.Model
{
    public class ProductImageInfo:BaseModel
    {
        public int ProductNo { get; set; }
        public string ImageUrl { get; set; }
        public int Status { get; set; }
    }
}
