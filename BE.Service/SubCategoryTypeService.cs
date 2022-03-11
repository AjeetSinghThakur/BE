using BE.Dal;
using BE.Service.Dtos;
using BE.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BE.Service.Dtos.ModelMappers;
using System.Linq;

namespace BE.Service
{
    public class SubCategoryTypeService : ServiceBase, ISubcategoryTypeService
    {
        public SubCategoryTypeService(EntityDbContext dbContext)
            : base(dbContext)
        {
        }
        public async Task<IEnumerable<SubCategoryDto>> GetSubcategories()
        {
            var subcategories = await DbContext.Subcategories.OrderBy(x => x.Name).ToListAsync();
            return subcategories.MapListToDto();
        }
    }
}
