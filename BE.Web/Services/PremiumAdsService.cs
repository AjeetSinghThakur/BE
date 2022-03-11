using BE.Web.Extensions;
using BE.Web.Models.Api;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BE.Web.Services
{
    public class PremiumAdsService : IPremiumAdsService
    {
        private readonly HttpClient client;
        public PremiumAdsService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<IEnumerable<Location>> GetLocations()
        {
            var response = await client.GetAsync("/api/locations");
            return await response.ReadContentAs<List<Location>>();
        }

        public async Task<IEnumerable<PremiumAds>> GetPremiumAds()
        {
            var response = await client.GetAsync("api/premium/all");
            return await response.ReadContentAs<List<PremiumAds>>();
        }
        public async Task<IEnumerable<SubCategory>> GetSubCategories()
        {
            var response = await client.GetAsync("api/subcategories");
            return await response.ReadContentAs<List<SubCategory>>();
        }
        public async Task CreatePremiumAd(PremiumAds premiumAd)
        {
            await client.PostAsJson("api/premium/create", premiumAd);
        }
    }
}
