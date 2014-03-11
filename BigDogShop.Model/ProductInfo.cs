using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigDogShop.Model
{
    public class ProductInfo:BaseModel
    {
        public string Product_Name { get; set; }
        public int Product_No { get; set; }
        public int Provider_Id { get; set; }
        public int Product_Type_Id { get; set; }
        public string Product_Origin { get; set; }
        public int Sales_Count { get; set; }
        public string Description { get; set; }
        public int Rank { get; set; }
        public decimal Price { get; set; }
        public decimal Promote_Price { get; set; }
        public decimal Member_Price { get; set; }
        public decimal Vip_Price { get; set; }
        public int Stock { get; set; }
        public int Product_Image_Id { get; set; }
        public int Extra_Property_Id { get; set; }
        public string Status { get; set; }
    }
}
