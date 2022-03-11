using BE.Service.Dtos;
using BE.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE.WebApi.Controllers
{
    [Route("api/subcategories")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubcategoryTypeService _subcategoryTypeService;
        public SubCategoryController(ISubcategoryTypeService subcategoryTypeService)
        {
            _subcategoryTypeService = subcategoryTypeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<SubCategoryDto>>> GetSubcategories()
        {
            var result = await _subcategoryTypeService.GetSubcategories();
            return Ok(result);
        }
    }
}
