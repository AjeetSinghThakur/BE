using BE.Web.Models.Api;
using System;
using System.Collections.Generic;

namespace BE.Web.Models.View
{
    public class AddNewModel
    {
        public IEnumerable<Location> Locations { get; set; }

        public IEnumerable<SubCategory> SubCategories { get; set; }

        public string SelectedLocationId { get; set; }

        public string SelectedSubcategoryId { get; set; }

        public DateTime PremiumStart { get; set; } = DateTime.Now;

        public DateTime PremiumEnd { get; set; } = DateTime.Now.AddDays(1);
    }
}
