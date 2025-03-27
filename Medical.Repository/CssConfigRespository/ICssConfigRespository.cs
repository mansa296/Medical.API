
using Medical.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Repository.CssConfigRespository
{
    public interface ICssConfigRespository
    {
        // <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing an enumerable of database data object</returns>
        Task<IEnumerable<CssConfig>> GetAllAsync();
    }
}
