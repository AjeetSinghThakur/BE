using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Web.Models.Api
{
    public class PremiumAds
    {
        public int Id { get; set; }
        public int LocationsID { get; set; }
        public int SubCategoryID { get; set; }
        public Location Location { get; set; }
        public SubCategory SubCategory { get; set; }
        public DateTime PremiumStart { get; set; }
        public DateTime PremiumEnd { get; set; }
    }
    
}
