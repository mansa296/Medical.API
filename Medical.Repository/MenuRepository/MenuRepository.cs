using Dapper;
using Medical.Infrastructure.Persistence.UnitOfWork;
using Medical.Model.Entities;

namespace Medical.Repository.MenuRepository
{
    public class MenuRepository: IMenuRepository
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnitRepository"/> class
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public MenuRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> InsertMenuDetailAsync(MenuDetailReq menuDetail)
        {
            int result = 0;
            try
            {

                var query = string.Concat(MenuQueries.InsertMenu, " ", CommonQueries.SelectScopeIdentity);
                result = await _unitOfWork.Connection.ExecuteScalarAsync<int>(query, menuDetail, _unitOfWork.Transaction);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return result;

        }

        public async Task<bool> UpdagteMenuDetailAsync(MenuDetailReq menuDetail)
        {
            try
            {

                var updatedRows = await _unitOfWork.Connection
                    .ExecuteAsync(MenuQueries.UpdateMenu, menuDetail, _unitOfWork.Transaction);

                return updatedRows != 0;
            }
            catch (Exception ex) { ex.ToString(); }
            return false;
        }

        
        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing an enumerable of get all kick off approval</returns>
        public async Task<IEnumerable<MenuDetail>> GetAllMenuDetailAsync()
        {
            return await _unitOfWork.Connection
                .QueryAsync<MenuDetail>(MenuQueries.MenuList);
        }
        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing an enumerable of get all kick off approval</returns>
        public async Task<IEnumerable<MenuDetail>> GetAllMenuDetailByIdAsync(int M_Id)
        {
            try
            {
                return await _unitOfWork.Connection
                    .QueryAsync<MenuDetail>(MenuQueries.MenuListById, new { M_Id });
            }
            catch(Exception e)
            {
                e.ToString();
            }
            return null;
        }
        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing an enumerable of get all kick off approval</returns>
        public async Task<IEnumerable<MCategoryDetail>> GetAllMCategoryAsync()
        {
            return await _unitOfWork.Connection
                .QueryAsync<MCategoryDetail>(MenuQueries.MCategoryList);

        }
        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing an enumerable of get all kick off approval</returns>
        public async Task<IEnumerable<MTypeDetail>> GetAllMTypeByMCatIdAsync(int MCat_Id)
        {
            return await _unitOfWork.Connection
                .QueryAsync<MTypeDetail>(MenuQueries.MTypeByMCatId, new { MCat_Id });

        }
        
    }
}
