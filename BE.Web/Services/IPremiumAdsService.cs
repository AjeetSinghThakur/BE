using BE.Web.Models.Api;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE.Web.Services
{
    public interface IPremiumAdsService
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<IEnumerable<PremiumAds>> GetPremiumAds();

        Task<IEnumerable<SubCategory>> GetSubCategories();
        Task CreatePremiumAd(PremiumAds premiumAd);
    }
}
