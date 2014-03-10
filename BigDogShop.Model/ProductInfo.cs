using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigDogShop.Model
{
    public class ProductInfo:BaseModel
    {
        public string ProductName { get; set; }
        public int ProductNo { get; set; }
        public int ProviderId { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductOrigin { get; set; }
        public string ProductStatus { get; set; }
        public int SalesCount { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public int Price { get; set; }
        public int PromotePrice { get; set; }
        public int MemberPrice { get; set; }
        public int VipPrice { get; set; }
        public int Stock { get; set; }
        public int ProductImageId { get; set; }
        public int ExtraProperties { get; set; }
        public string Status { get; set; }
    }
}
