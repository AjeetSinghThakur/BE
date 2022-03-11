using System;
using System.Collections.Generic;
using System.Text;

namespace BE.Model
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<AdPremium> AdPremium { get; set; }
    }
}
