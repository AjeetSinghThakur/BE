using BE.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE.Service.Interfaces
{
    public interface IAdPremiumService
    {
        Task<IEnumerable<AdPremiumDto>> GetAllAdPremiums();

        Task<IEnumerable<AdPremiumDto>> CreateAdPremium(AdPremiumDto adPremium);
    }
}
