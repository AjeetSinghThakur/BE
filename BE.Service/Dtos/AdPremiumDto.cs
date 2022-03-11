using BE.Service.Exceptions;
using BE.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BE.Service.Dtos
{
    public class AdPremiumDto : IDtoValidator
    {
        public int Id { get; set; }
        public int LocationsID { get; set; }
        public virtual LocationDto Location { get; set; }
        public int SubCategoryID { get; set; }
        public virtual SubCategoryDto SubCategory { get; set; }
        public DateTime PremiumStart { get; set; }
        public DateTime PremiumEnd { get; set; }

        public void Validate()
        {
            this.LocationsID.ThrowIfZero();
            this.SubCategoryID.ThrowIfZero();
        }

        public void ValidateForUpdate()
        {
            this.Id.ThrowIfZero();
            this.Validate();
        }
    }
}
