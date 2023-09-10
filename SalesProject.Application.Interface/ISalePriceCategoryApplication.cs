using SalesProject.Application.DTO.sale_price_category;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface ISalePriceCategoryApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(SalePriceCatCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, SalePriceCatUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<SalePriceCatDTO>> GetByIdAsync(int id);
        Task<Response<SalePriceCatDTO>> GetByNameAsync(string name);
        Task<Response<IEnumerable<SalePriceCatDTO>>> GetAllThatContainsName(string name);
        Task<Response<IEnumerable<SalePriceCatDTO>>> GetAllAsync();

        #endregion
    }
}
