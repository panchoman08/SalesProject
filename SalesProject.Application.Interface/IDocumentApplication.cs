using SalesProject.Application.DTO.document.document;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface IDocumentApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(DocumentCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, DocumentUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<DocumentDTO>> GetByIdAsync(int id);
        Task<Response<DocumentDTO>> GetByNameAsync(string name);
        Task<Response<IEnumerable<DocumentDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<DocumentDTO>>> GetAllAsync();
        #endregion
    }
}
