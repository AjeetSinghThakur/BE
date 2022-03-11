using BE.Model;
using System.Collections.Generic;
using System.Linq;

namespace BE.Service.Dtos.ModelMappers
{
    internal static class LocationMapper
    {
        internal static LocationDto MapToDto(this Location model)
        {
            var dto = new LocationDto
            {
                Id = model.Id,
                Name = model.Name,
            };

            return dto;
        }

        internal static IEnumerable<LocationDto> MapListToDto(this List<Location> locations)
        {
            foreach (var location in locations)
            {
                yield return location.MapToDto();
            }
        }
    }
}
