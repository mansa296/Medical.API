using Dapper;
using Medical.Infrastructure.Persistence.UnitOfWork;
using Medical.Model.Entities;

namespace Medical.Repository.CssConfigRespository
{
    public class CssConfigRespository : ICssConfigRespository
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="CssConfigRespository"/> class
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public CssConfigRespository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates the database data object
        /// </summary>
        /// <param name="databaseDataObject">The database data object</param>
        /// <returns>A task containing the int</returns>
        public async Task<IEnumerable<CssConfig>> GetAllAsync()
        {
            return await _unitOfWork.Connection
                .QueryAsync<CssConfig>(CssConfigQueries.GetAll);
        }
    }
}
