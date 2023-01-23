using SalesProject.Application.DTO.cellar;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface ICellarApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(CellarCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, CellarUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<CellarDTO>> GetByIdAsync(int id);
        Task<Response<CellarDTO>> GetByNameAsync(string name);
        Task<Response<IEnumerable<CellarDTO>>> GetAllAsync();
        #endregion
    }
}
