using BE.Dal;
using BE.Service.Dtos;
using BE.Service.Interfaces;
using System;
using BE.Service.Dtos.ModelMappers;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using BE.Model;


namespace BE.Service
{
    public class AdPremiumService : ServiceBase, IAdPremiumService
    {
        public AdPremiumService(EntityDbContext dbContext)
           : base(dbContext)
        {
        }
        public async Task<IEnumerable<AdPremiumDto>> CreateAdPremium(AdPremiumDto adPremium)
        {
            var model = adPremium.MapToModel();
            DbContext.AdPremiums.Add(model);
            
            await DbContext.SaveChangesAsync();
            return await GetAllAdPremiums();
        }

        public async Task<IEnumerable<AdPremiumDto>> GetAllAdPremiums()
        {
            var adPremiums = await DbContext.AdPremiums
                .Include(x => x.Location)
                .Include(x => x.SubCategory)
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            return adPremiums.MapListToDto();
        }
    }
}
