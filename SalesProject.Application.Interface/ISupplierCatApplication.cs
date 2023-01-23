using SalesProject.Application.DTO.supplier.category;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface ISupplierCatApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(SupplierCatCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, SupplierCatUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<SupplierCatDTO>> GetByIdAsync(int id);
        Task<Response<SupplierCatDTO>> GetByNameAsync(string name);
        Task<Response<IEnumerable<SupplierCatDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<SupplierCatDTO>>> GetAllAsync();
        #endregion
    }
}
