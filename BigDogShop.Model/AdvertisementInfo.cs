using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigDogShop.Model
{
    public class AdvertisementInfo : BaseModel
    {
        public string Title { get; set; }
        public string Image_Url { get; set; }
        public string Link_Url { get; set; }

        //public AdvertisementInfo(string title, string adImgUrl, string linkUrl)
        //{
        //    this.Title = title;
        //    this.Image_Url = adImgUrl;
        //    this.Link = linkUrl;
        //}
    }
}
