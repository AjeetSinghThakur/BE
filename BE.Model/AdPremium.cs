using System;
using System.Collections.Generic;
using System.Text;

namespace BE.Model
{
    public class AdPremium
    {
        public int Id { get; set; }
        public int LocationsID { get; set; }
        public virtual Location Location { get; set; }
        public int SubcategoriesID { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public DateTime PremiumStart { get; set; }
        public DateTime PremiumEnd { get; set; }
    }
}
