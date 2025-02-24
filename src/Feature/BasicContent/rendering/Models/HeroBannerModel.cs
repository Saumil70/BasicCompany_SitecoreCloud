﻿using Sitecore.LayoutService.Client.Response.Model.Fields;

namespace BasicCompany.Feature.BasicContent.Models
{
    public class HeroBannerModel
    {
        public TextField Title { get; set; }
        public TextField Subtitle { get; set; }
        public ImageField Image { get; set; }
    }
}
