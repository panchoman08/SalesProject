using SalesProject.Application.DTO.document.document;
using SalesProject.Application.DTO.pagination;
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
        Task<Response<List<DocumentDTO>>> GetAllByDocumentTypeAsync(string name);
        Task<Response<IEnumerable<DocumentDTO>>> GetAllTthatContainsNameAsync(string name);
        Task<Response<IEnumerable<DocumentDTO>>> GetAllAsync();
        Task<Response<PagedList<DocumentDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParametersDTO);
        #endregion
    }
}
