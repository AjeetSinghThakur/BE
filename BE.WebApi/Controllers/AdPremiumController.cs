using BE.Service.Dtos;
using BE.Service.Interfaces;
using BE.WebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE.WebApi.Controllers
{
    [Route("api/premium")]
    [ApiController]
    public class AdPremiumController : ControllerBase
    {
        private readonly IAdPremiumService _adPremiumService;

        public AdPremiumController(IAdPremiumService adPremiumService)
        {
            this._adPremiumService = adPremiumService;
        }

        [Route("create")]
        [HttpPost]
        [TransactionFilter()]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<AdPremiumDto>>> CreateAdPremium([FromBody] AdPremiumDto adPremiumDto)
        {
            var result = await _adPremiumService.CreateAdPremium(adPremiumDto);
            return Ok(result);
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<AdPremiumDto>>> GetAllAdPremiums()
        {
            var result = await _adPremiumService.GetAllAdPremiums();
            return Ok(result);
        }
    }
}
