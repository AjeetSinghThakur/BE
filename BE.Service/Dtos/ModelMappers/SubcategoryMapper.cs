using BE.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BE.Service.Dtos.ModelMappers
{
    internal static class SubcategoryMapper
    {
        internal static SubCategoryDto MapToDto(this SubCategory model)
        {
            var dto = new SubCategoryDto
            {
                Id = model.Id,
                Name = model.Name,
            };

            return dto;
        }

        internal static IEnumerable<SubCategoryDto> MapListToDto(this List<SubCategory> subCategories)
        {
            foreach (var subCategory in subCategories)
            {
                yield return subCategory.MapToDto();
            }
        }
    }
}
