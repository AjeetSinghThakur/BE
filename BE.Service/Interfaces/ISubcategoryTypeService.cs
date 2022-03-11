using BE.Service.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE.Service.Interfaces
{
    public interface ISubcategoryTypeService
    {
        Task<IEnumerable<SubCategoryDto>> GetSubcategories();
    }
}
