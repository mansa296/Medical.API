using Medical.Model.Entities;

namespace Medical.Repository.MenuRepository
{
    public interface IMenuRepository
    {
        Task<int> InsertMenuDetailAsync(MenuDetailReq menuDetail);
        Task<bool> UpdagteMenuDetailAsync(MenuDetailReq menuDetail);
        Task<IEnumerable<MenuDetail>> GetAllMenuDetailAsync();
        Task<IEnumerable<MenuDetail>> GetAllMenuDetailByIdAsync(int M_Id);
        Task<IEnumerable<MCategoryDetail>> GetAllMCategoryAsync();
        Task<IEnumerable<MTypeDetail>> GetAllMTypeByMCatIdAsync(int MCat_Id);
    }
}
