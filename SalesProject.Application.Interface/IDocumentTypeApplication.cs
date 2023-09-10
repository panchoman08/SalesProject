using SalesProject.Application.DTO.document.documentType;
using SalesProject.Transversal.Common;

namespace SalesProject.Application.Interface
{
    public interface IDocumentTypeApplication
    {
        #region async methods
        Task<Response<bool>> InsertAsync(DocumentTypeCreateDTO obj);
        Task<Response<bool>> UpdateAsync(int id, DocumentTypeUpdateDTO obj);
        Task<Response<bool>> DeleteAsync(int id);
        Task<Response<DocumentTypeDTO>> GetByIdAsync(int id);
        Task<Response<DocumentTypeDTO>> GetByNameAsync(string name);
        Task<Response<IEnumerable<DocumentTypeDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<DocumentTypeDTO>>> GetAllAsync();
        #endregion
    }
}
