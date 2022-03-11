using BE.Dal;
using BE.Service.Dtos;
using BE.Service.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BE.Service.Dtos.ModelMappers;
using System.Linq;

namespace BE.Service
{
    public class LocationService : ServiceBase, ILocationService
    {
        public LocationService(EntityDbContext dbContext)
            : base(dbContext)
        {
        }
        public async Task<IEnumerable<LocationDto>> GetLocations()
        {
            var locations = await DbContext.Locations.OrderBy(x => x.Name).ToListAsync();
            return locations.MapListToDto();
        }
    }
}
