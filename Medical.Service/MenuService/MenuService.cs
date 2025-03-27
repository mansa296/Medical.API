using Medical.Model.DTOs.Responses;
using Medical.Model.Entities;
using Medical.Repository.MenuRepository;

namespace Medical.Service.MenuService
{
    public class MenuService : IMenuService
    {
        protected readonly IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<CommandResponse<IEnumerable<MenuDetail>>> GetMenuDetailAsync()
        {
            try
            {
                var result = await _menuRepository.GetAllMenuDetailAsync();
                if (result is null || !result.Any())
                {
                    return CommandResponse<IEnumerable<MenuDetail>>.Succeeded(new List<MenuDetail>());
                }
                return CommandResponse<IEnumerable<MenuDetail>>.Succeeded(result);
            }
            catch (Exception ex)
            {
                return CommandResponse<IEnumerable<MenuDetail>>.Succeeded(new List<MenuDetail>());
            }
        }
        public async Task<CommandResponse<IEnumerable<MenuDetail>>> GetMenuDetailBYIdAsync(int M_Id)
        {
            try
            {
                var result = await _menuRepository.GetAllMenuDetailByIdAsync(M_Id);
                if (result is null || !result.Any())
                {
                    return CommandResponse<IEnumerable<MenuDetail>>.Succeeded(new List<MenuDetail>());
                }
                return CommandResponse<IEnumerable<MenuDetail>>.Succeeded(result);
            }
            catch (Exception ex)
            {
                return CommandResponse<IEnumerable<MenuDetail>>.Succeeded(new List<MenuDetail>());
            }
        }
        public async Task<CommandResponse<IEnumerable<MCategoryDetail>>> GetAllMCategoryAsync()
        {
            try
            {
                var result = await _menuRepository.GetAllMCategoryAsync();
                if (result is null || !result.Any())
                {
                    return CommandResponse<IEnumerable<MCategoryDetail>>.Succeeded(new List<MCategoryDetail>());
                }
                return CommandResponse<IEnumerable<MCategoryDetail>>.Succeeded(result);
            }
            catch (Exception ex)
            {
                return CommandResponse<IEnumerable<MCategoryDetail>>.Succeeded(new List<MCategoryDetail>());
            }
        }
        public async Task<CommandResponse<IEnumerable<MTypeDetail>>> GetAllMTypeByMCatIdAsync( int MCatId)
        {
            try
            {
                var result = await _menuRepository.GetAllMTypeByMCatIdAsync(MCatId);
                if (result is null || !result.Any())
                {
                    return CommandResponse<IEnumerable<MTypeDetail>>.Succeeded(new List<MTypeDetail>());
                }
                return CommandResponse<IEnumerable<MTypeDetail>>.Succeeded(result);
            }
            catch (Exception ex)
            {
                return CommandResponse<IEnumerable<MTypeDetail>>.Succeeded(new List<MTypeDetail>());
            }
        }
        public async Task<CommandResponse<MenuDetail>> AddUpdateMenuDetailAsync(MenuDetailReq menuDetail)
        {
            if (menuDetail is null)
            {
                return CommandResponse<MenuDetail>.Failed();
            }

            MenuDetailReq menu = new()
            {
                M_Id = menuDetail.M_Id,
                MCat_Id = menuDetail.MCat_Id,
                MT_Id = menuDetail.MT_Id,
                MenuName = menuDetail.MenuName,
                Price = menuDetail.Price,
                Discount = menuDetail.Discount,
                Active = menuDetail.Active,
                
            };
            if (menu.M_Id == 0)
            {
                menu.M_Id = await _menuRepository.InsertMenuDetailAsync(menu);
            }
            else
            {
                await _menuRepository.UpdagteMenuDetailAsync(menu);
            }
            IEnumerable<MenuDetail> menuDetail1;
            menuDetail1 = await _menuRepository.GetAllMenuDetailByIdAsync(menu.M_Id);
            if (menuDetail is null)
            {
                return CommandResponse<MenuDetail>.Succeeded(new MenuDetail());
            }
            return CommandResponse<MenuDetail>.Succeeded(menuDetail1.FirstOrDefault());

        }
    }
}
