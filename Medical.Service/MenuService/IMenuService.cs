using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medical.Model.DTOs.Responses;
using Medical.Model.Entities;

namespace Medical.Service.MenuService
{
    public interface IMenuService
    {
        Task<CommandResponse<IEnumerable<MenuDetail>>> GetMenuDetailAsync();
        Task<CommandResponse<IEnumerable<MenuDetail>>> GetMenuDetailBYIdAsync(int M_Id);
        Task<CommandResponse<IEnumerable<MCategoryDetail>>> GetAllMCategoryAsync();
        Task<CommandResponse<IEnumerable<MTypeDetail>>> GetAllMTypeByMCatIdAsync(int MCatId);
        Task<CommandResponse<MenuDetail>> AddUpdateMenuDetailAsync(MenuDetailReq menuDetail);
    }
}
