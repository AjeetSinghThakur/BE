using BE.Model;
using System.Collections.Generic;

namespace BE.Service.Dtos.ModelMappers
{
    internal static class AdPremiumMapper
    {
        internal static AdPremium MapToModel(this AdPremiumDto dto)
        {
            var model = new AdPremium
            {
                Id = dto.Id,
                LocationsID = dto.LocationsID,
                SubcategoriesID = dto.SubCategoryID,
                PremiumEnd = dto.PremiumEnd,
                PremiumStart = dto.PremiumStart
            };

            return model;
        }

        internal static AdPremiumDto MapToDto(this AdPremium model)
        {
            var dto = new AdPremiumDto
            {
                Id = model.Id,
                LocationsID = model.LocationsID,
                SubCategoryID = model.SubcategoriesID,
                Location = new LocationDto
                {
                    Id = model.Location.Id,
                    Name = model.Location.Name
                },
                SubCategory = new SubCategoryDto
                {
                    Id = model.SubCategory.Id,
                    Name = model.SubCategory.Name
                },
                PremiumEnd = model.PremiumEnd,
                PremiumStart = model.PremiumStart
            };
            return dto;
        }

        internal static IEnumerable<AdPremiumDto> MapListToDto(this List<AdPremium> adPremiums)
        {
            foreach (var adPremium in adPremiums)
            {
                yield return adPremium.MapToDto();
            }
        }
    }
}
